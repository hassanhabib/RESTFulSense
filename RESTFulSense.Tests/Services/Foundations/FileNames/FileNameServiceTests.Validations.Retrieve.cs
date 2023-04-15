// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using FluentAssertions;
using Moq;
using RESTFulSense.Models.Foundations.FileNames.Exceptions;
using System.Reflection;
using Xunit;

namespace RESTFulSense.Tests.Services.Foundations.FileNames
{
    public partial class FileNameServiceTests
    {
        [Fact]
        public void ShouldThrowValidationExceptionOnRetrieveFileNameIfPropertyInfoIsNull()
        {
            PropertyInfo someProperty = null;

            var nullPropertyInfoException = new NullPropertyInfoException();

            var expectedFileNameValidationException =
                new FileNameValidationException(nullPropertyInfoException);

            // when
            FileNameValidationException actualFileNameValidationException =
                Assert.Throws<FileNameValidationException>(() => this.fileNameService.RetrieveFileName(someProperty));

            // then
            actualFileNameValidationException.Should()
              .BeEquivalentTo(expectedFileNameValidationException);

            this.reflectionBrokerMock.Verify(reflectionBroker =>
                reflectionBroker.GetFileContentStreamAttribute(It.IsAny<PropertyInfo>()), Times.Never);

            this.reflectionBrokerMock.VerifyNoOtherCalls();
        }

    }
}
