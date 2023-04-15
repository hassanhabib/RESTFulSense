// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Moq;
using RESTFulSense.Models.Foundations.FileNames.Exceptions;
using System.Reflection;
using System;
using Xunit;
using FluentAssertions;

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

            this.reflectionBrokerMock.Setup(broker => broker.GetFileContentNameAttribute(
                somePropertyInfo))
                    .Throws(serviceException);

            // when
            FileNameServiceException actualFileNameServiceException =
                Assert.Throws<FileNameServiceException>(() =>
                    this.fileNameService.RetrieveFileName(somePropertyInfo));

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
