// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using FluentAssertions;
using Moq;
using RESTFulSense.Models.Attributes;
using System.Reflection;
using Xunit;

namespace RESTFulSense.Tests.Services.Foundations.FileNames
{
    public partial class FileNameServiceTests
    {
        [Fact]
        public void ShouldRetrieveFileName()
        {
            // given
            PropertyInfo somePropertyInfo = new Mock<PropertyInfo>().Object;

            RESTFulFileContentNameAttribute randomFileNameContent = CreateRandomFileNameContent();
            RESTFulFileContentNameAttribute expectedFileNameContent = randomFileNameContent;

            this.reflectionBrokerMock.Setup(reflectionBroker =>
                reflectionBroker.GetFileContentNameAttribute(It.IsAny<PropertyInfo>()))
                    .Returns(expectedFileNameContent);

            // when
            var actualFileNameContent =
                this.fileNameService.RetrieveFileName(somePropertyInfo);

            // then
            this.reflectionBrokerMock.Verify(reflectionBroker =>
                reflectionBroker.GetFileContentNameAttribute(It.IsAny<PropertyInfo>()), Times.Once);

            actualFileNameContent.Should().BeSameAs(expectedFileNameContent);

            this.reflectionBrokerMock.VerifyNoOtherCalls();
        }
    }
}
