// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using RESTFulSense.Models.Foundations.Properties;
using RESTFulSense.Models.Foundations.Properties.Exceptions;
using Xunit;

namespace RESTFulSense.Tests.Services.Foundations.Properties
{
    public partial class PropertyServiceTests
    {
        [Fact]
        public void ShouldThrowValidationExceptionOnRetrievePropertiesIfObjectIsNullAsync()
        {
            // given
            object inputObject = null;

            var nullObjectException = new NullObjectException();

            var expectedPropertyValidationException =
                new PropertyValidationException(nullObjectException);

            // when
            PropertyValidationException actualPropertyValidationException =
                Assert.Throws<PropertyValidationException>(() => this.propertyService.RetrieveProperties(inputObject));

            // then
            actualPropertyValidationException.Should()
              .BeEquivalentTo(expectedPropertyValidationException);

            this.reflectionBrokerMock.Verify(reflectionBroker =>
                reflectionBroker.GetPropertyValues(It.IsAny<object>()), Times.Never);

            this.reflectionBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public void ShouldThrowServiceExceptionOnRetrievePropertiesIfServiceErrorOccurs()
        {
            // given
            object someObject = new object();
            
            var serviceException = new Exception();

            var failedPropertyServiceException =
                new FailedPropertyServiceException(serviceException);

            var expectedPropertyServiceException =
                new PropertyServiceException(
                    failedPropertyServiceException);

            this.reflectionBrokerMock.Setup(broker => broker.GetPropertyValues(
                It.IsAny<object>()))
                    .Throws(serviceException);

            // when

            PropertyServiceException actualPropertyServiceException =
                  Assert.Throws<PropertyServiceException>(() => this.propertyService.RetrieveProperties(someObject));

            // then
            actualPropertyServiceException.Should().BeEquivalentTo(
                expectedPropertyServiceException);

            this.reflectionBrokerMock.Verify(broker =>
                broker.GetPropertyValues(
                    It.IsAny<object>()),
                        Times.Once);

            this.reflectionBrokerMock.VerifyNoOtherCalls();
        }
    }
}
