// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using FluentAssertions;
using Moq;
using RESTFulSense.Models.Foundations.StreamContents.Exceptions;
using System;
using System.Reflection;
using Xunit;

namespace RESTFulSense.Tests.Services.Foundations.StreamContents
{
    public partial class StreamContentServiceTests
    {
        [Fact]
        public void ShouldThrowServiceExceptionOnRetrieveStreamContentIfServiceErrorOccurs()
        {
            // given
            PropertyInfo somePropertyInfo = CreateMockPropertyInfo();

            var serviceException = new Exception();

            var failedStreamContentServiceException =
                new FailedStreamContentServiceException(serviceException);

            var expectedStreamContentServiceException =
                new StreamContentServiceException(
                    failedStreamContentServiceException);

            this.reflectionBrokerMock.Setup(broker => broker.GetFileContentStreamAttribute(
                somePropertyInfo))
                    .Throws(serviceException);

            // when
            StreamContentServiceException actualStreamContentServiceException =
                Assert.Throws<StreamContentServiceException>(() =>
                    this.streamContentService.RetrieveStreamContent(somePropertyInfo));

            // then
            actualStreamContentServiceException.Should().BeEquivalentTo(
                expectedStreamContentServiceException);

            this.reflectionBrokerMock.Verify(broker =>
                broker.GetFileContentStreamAttribute(
                    somePropertyInfo),
                        Times.Once);

            this.reflectionBrokerMock.VerifyNoOtherCalls();
        }
    }
}
