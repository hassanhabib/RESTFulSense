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
        public void ShouldThrowServiceExceptionOnRetrieveFileNameIfServiceErrorOccurs()
        {
            // given
            PropertyInfo somePropertyInfo = CreateMockPropertyInfo();
            var serviceException = new Exception();

            var failedFileNameServiceException =
                new FailedFileNameServiceException(serviceException);

            var expectedFileNameServiceException =
                new FileNameServiceException(
                    failedFileNameServiceException);

            this.reflectionBrokerMock.Setup(
                broker => broker.GetFileContentNameAttribute(somePropertyInfo))
                    .Throws(serviceException);

            // when
            Func<RESTFulFileContentNameAttribute> retrieveFileNameFunction = () =>
                this.fileNameService.RetrieveFileName(somePropertyInfo);

            FileNameServiceException actualFileNameServiceException =
                Assert.Throws<FileNameServiceException>(retrieveFileNameFunction);

            // then
            actualFileNameServiceException.Should().BeEquivalentTo(
                expectedFileNameServiceException);

            this.reflectionBrokerMock.Verify(broker =>
                broker.GetFileContentNameAttribute(
                    somePropertyInfo),
                        Times.Once);

            this.reflectionBrokerMock.VerifyNoOtherCalls();
        }
    }
}
