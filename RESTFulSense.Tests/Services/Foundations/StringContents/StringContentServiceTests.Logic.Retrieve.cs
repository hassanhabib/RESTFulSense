// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Reflection;
using FluentAssertions;
using Moq;
using RESTFulSense.Models.Attributes;
using Xunit;

namespace RESTFulSense.Tests.Services.Foundations.StringContents
{
    public partial class StringContentServiceTests
    {
        [Fact]
        public void ShouldRetrieveStringContent()
        {
            // given
            RESTFulStringContentAttribute randomStringContent = CreateRandomeStringContent();
            RESTFulStringContentAttribute expectedStringContent = randomStringContent;

            this.reflectionBrokerMock.Setup(reflectionBroker =>
                reflectionBroker.GetStringContentAttribute(It.IsAny<PropertyInfo>()))
                    .Returns(expectedStringContent);

            // when
            var actualStringContent =
                this.stringContentService.RetrieveStringContent(It.IsAny<PropertyInfo>());

            // then
            this.reflectionBrokerMock.Verify(reflectionBroker =>
                reflectionBroker.GetStringContentAttribute(It.IsAny<PropertyInfo>()), Times.Once);

            actualStringContent.Should().BeSameAs(expectedStringContent);

            this.reflectionBrokerMock.VerifyNoOtherCalls();
        }
    }
}
