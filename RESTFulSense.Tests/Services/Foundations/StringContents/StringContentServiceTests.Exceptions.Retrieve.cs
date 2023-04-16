// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using System.Reflection;
using FluentAssertions;
using Moq;
using RESTFulSense.Models.Attributes;
using RESTFulSense.Models.Foundations.StringContents.Exceptions;
using Xunit;

namespace RESTFulSense.Tests.Services.Foundations.StringContents
{
    public partial class StringContentServiceTests
    {
        [Fact]
        public void ShouldThrowServiceExceptionOnRetrieveStringContentIfServiceErrorOccurs()
        {
            // given
            PropertyInfo somePropertyInfo = CreateMockPropertyInfo();
            var serviceException = new Exception();

            var failedStringContentServiceException =
                new FailedStringContentServiceException(serviceException);

            var expectedStringContentServiceException =
                new StringContentServiceException(
                    failedStringContentServiceException);

            this.reflectionBrokerMock.Setup(
                broker => broker.GetStringContentAttribute(somePropertyInfo))
                    .Throws(serviceException);

            // when
            Func<RESTFulStringContentAttribute> retrieveStringContentFunction = () =>
                this.stringContentService.RetrieveStringContent(somePropertyInfo);

            StringContentServiceException actualStringContentServiceException =
                Assert.Throws<StringContentServiceException>(retrieveStringContentFunction);

            // then
            actualStringContentServiceException.Should().BeEquivalentTo(
                expectedStringContentServiceException);

            this.reflectionBrokerMock.Verify(broker =>
                broker.GetStringContentAttribute(somePropertyInfo),
                    Times.Once);

            this.reflectionBrokerMock.VerifyNoOtherCalls();
        }
    }
}
