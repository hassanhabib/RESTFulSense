// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using FluentAssertions;
using Moq;
using RESTFulSense.Models.Foundations.Properties.Exceptions;
using Xunit;

namespace RESTFulSense.Tests.Services.Properties
{
    public partial class PropertyServiceTests
    {
        [Fact]
        private void ShouldThrowPropertyServiceExceptionIfExceptionOccurs()
        {
            // given
            var someObject = new object();
            var someException = new Exception();

            var failedPropertyServiceException =
                new FailedPropertyServiceException(
                     message: "Failed Property Service Exception occurred, please contact support for assistance.",
                    innerException: someException);
            
            var expectedPropertyServiceException =
                new PropertyServiceException(
                    message: "Property service error occurred, contact support.",
                    innerException: failedPropertyServiceException);

            this.propertyBrokerMock.Setup(broker =>
                broker.GetProperties(It.IsAny<Type>()))
                    .Throws(someException);

            // when
            Action retrieveTypeAction = () =>
                this.propertyService.RetrieveProperties(typeof(PropertyServiceTests));

            PropertyServiceException actualPropertyServiceException =
                Assert.Throws<PropertyServiceException>(retrieveTypeAction);

            // then
            actualPropertyServiceException.Should().BeEquivalentTo(
                expectedPropertyServiceException);

            this.propertyBrokerMock.Verify(broker =>
                broker.GetProperties(It.IsAny<Type>()),
                    Times.Once);

            this.propertyBrokerMock.VerifyNoOtherCalls();
        }
    }
}
