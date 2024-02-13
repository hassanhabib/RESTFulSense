// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System.IO;
using System.Net.Http;
using FluentAssertions;
using Moq;
using Xunit;

namespace RESTFulSense.Tests.Services.Foundations.Forms
{
    public partial class FormServiceTests
    {
        [Fact]
        private void ShouldAddStreamContentWithNoFileName()
        {
            // given
            var multipartFormDataContent = new MultipartFormDataContent();
            var expectedMultipartFormDataContent = new MultipartFormDataContent();
            Stream someContent = CreateSomeStreamContent();
            string randomName = CreateRandomString();

            this.multipartFormDataContentBroker.Setup(broker =>
                broker.AddStreamContent(multipartFormDataContent, someContent, randomName))
                    .Returns(expectedMultipartFormDataContent);

            // when
            var actualMultipartFormDataContent =
                formService.AddStreamContent(multipartFormDataContent, someContent, randomName);

            // then
            actualMultipartFormDataContent.Should()
                .BeSameAs(expectedMultipartFormDataContent);

            this.multipartFormDataContentBroker.Verify(broker =>
                broker.AddStreamContent(multipartFormDataContent, someContent, randomName),
                    Times.Once);

            this.multipartFormDataContentBroker.VerifyNoOtherCalls();
        }

        [Fact]
        private void ShouldAddStreamContentWithFileName()
        {
            // given
            var multipartFormDataContent = new MultipartFormDataContent();
            var expectedMultipartFormDataContent = new MultipartFormDataContent();
            Stream someContent = CreateSomeStreamContent();
            string randomName = CreateRandomString();
            string randomFileName = CreateRandomString();

            this.multipartFormDataContentBroker.Setup(broker =>
                broker.AddStreamContent(multipartFormDataContent, someContent, randomName, randomFileName))
                    .Returns(expectedMultipartFormDataContent);

            // when
            var actualMultipartFormDataContent =
                formService.AddStreamContent(multipartFormDataContent, someContent, randomName, randomFileName);

            // then
            actualMultipartFormDataContent.Should()
                .BeSameAs(expectedMultipartFormDataContent);

            this.multipartFormDataContentBroker.Verify(broker =>
                broker.AddStreamContent(multipartFormDataContent, someContent, randomName, randomFileName),
                    Times.Once);

            this.multipartFormDataContentBroker.VerifyNoOtherCalls();
        }
    }
}
