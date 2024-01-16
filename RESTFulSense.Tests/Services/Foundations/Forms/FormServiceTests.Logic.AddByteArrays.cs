// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System.Net.Http;
using FluentAssertions;
using Moq;
using Xunit;

namespace RESTFulSense.Tests.Services.Foundations.Forms
{
    public partial class FormServiceTests
    {
        [Fact]
        private void ShouldAddByteArrayContentWithNoFileName()
        {
            // given
            var multipartFormDataContent = new MultipartFormDataContent();
            var expectedMultipartFormDataContent = new MultipartFormDataContent();
            byte[] someContent = CreateSomeByteArrayContent();
            byte[] inputContent = someContent;
            string randomName = CreateRandomString();
            string inputName = randomName;

            this.multipartFormDataContentBroker.Setup(broker =>
                broker.AddByteArrayContent(multipartFormDataContent, inputContent, inputName))
                    .Returns(expectedMultipartFormDataContent);

            // when
            var actualMultipartFormDataContent =
                formService.AddByteArrayContent(multipartFormDataContent, inputContent, inputName);

            // then
            actualMultipartFormDataContent.Should()
                .BeSameAs(expectedMultipartFormDataContent);

            this.multipartFormDataContentBroker.Verify(broker =>
                broker.AddByteArrayContent(multipartFormDataContent, inputContent, inputName),
                    Times.Once);

            this.multipartFormDataContentBroker.VerifyNoOtherCalls();
        }


        [Fact]
        private void ShouldAddByteArrayContentWithFileName()
        {
            // given
            var multipartFormDataContent = new MultipartFormDataContent();
            var expectedMultipartFormDataContent = new MultipartFormDataContent();
            byte[] someContent = CreateSomeByteArrayContent();
            byte[] inputContent = someContent;
            string randomName = CreateRandomString();
            string inputName = randomName;
            string randomFileName = CreateRandomString();
            string inputFileName = randomFileName;

            this.multipartFormDataContentBroker.Setup(broker =>
                broker.AddByteArrayContent(multipartFormDataContent, inputContent, inputName, inputFileName))
                    .Returns(expectedMultipartFormDataContent);

            // when
            var actualMultipartFormDataContent =
                formService.AddByteArrayContent(multipartFormDataContent, inputContent, inputName, inputFileName);

            // then
            actualMultipartFormDataContent.Should()
                .BeSameAs(expectedMultipartFormDataContent);

            this.multipartFormDataContentBroker.Verify(broker =>
                broker.AddByteArrayContent(multipartFormDataContent, inputContent, inputName, inputFileName),
                    Times.Once);

            this.multipartFormDataContentBroker.VerifyNoOtherCalls();
        }
    }
}
