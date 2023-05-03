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
        public void ShouldAddStringContent()
        {
            // given
            var multipartFormDataContent = new MultipartFormDataContent();
            var expectedMultipartFormDataContent = new MultipartFormDataContent();
            string someContent = CreateRandomString();
            string randomName = CreateRandomString();

            this.multipartFormDataContentBroker.Setup(broker =>
                broker.AddStringContent(multipartFormDataContent, someContent, randomName))
                    .Returns(expectedMultipartFormDataContent);

            // when
            var actualMultipartFormDataContent =
                formService.AddStringContent(multipartFormDataContent, someContent, randomName);

            // then
            actualMultipartFormDataContent.Should()
                .BeSameAs(expectedMultipartFormDataContent);

            this.multipartFormDataContentBroker.Verify(broker =>
                broker.AddStringContent(multipartFormDataContent, someContent, randomName),
                    Times.Once);

            this.multipartFormDataContentBroker.VerifyNoOtherCalls();
        }
    }
}
