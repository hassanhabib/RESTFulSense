// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using System.Reflection;
using FluentAssertions;
using Moq;
using RESTFulSense.Models.Attributes;
using RESTFulSense.Models.Foundations.FileNames.Exceptions;
using Xunit;

namespace RESTFulSense.Tests.Services.Foundations.FileNames
{
    public partial class FileNameServiceTests
    {
        [Fact]
        public void ShouldThrowValidationExceptionOnRetrieveFileNameIfPropertyInfoIsNull()
        {
            PropertyInfo someProperty = CreateNullPropertyInfo();
            var nullPropertyInfoException = new NullPropertyInfoException();

            var expectedFileNameValidationException =
                new FileNameValidationException(nullPropertyInfoException);

            // when
            Func<RESTFulFileContentNameAttribute> retrieveFileNameFunction = () =>
              this.fileNameService.RetrieveFileName(someProperty);

            FileNameValidationException actualFileNameValidationException =
                Assert.Throws<FileNameValidationException>(retrieveFileNameFunction);

            // then
            actualFileNameValidationException.Should()
              .BeEquivalentTo(expectedFileNameValidationException);

            this.reflectionBrokerMock.Verify(reflectionBroker =>
                reflectionBroker.GetFileContentStreamAttribute(
                    It.IsAny<PropertyInfo>()),
                        Times.Never);

            this.reflectionBrokerMock.VerifyNoOtherCalls();
        }
    }
}
