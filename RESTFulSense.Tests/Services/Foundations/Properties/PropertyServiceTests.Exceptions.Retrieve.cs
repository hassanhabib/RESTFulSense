// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
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
        public void ShouldThrowServiceExceptionOnRetrievePropertiesIfServiceErrorOccurs()
        {
            // given
            object someObject = CreateSomeObject();
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
            Func<IEnumerable<PropertyValue>> retrievePropertiesFunction = () =>
                this.propertyService.RetrieveProperties(someObject);

            PropertyServiceException actualPropertyServiceException =
                  Assert.Throws<PropertyServiceException>(retrievePropertiesFunction);

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
