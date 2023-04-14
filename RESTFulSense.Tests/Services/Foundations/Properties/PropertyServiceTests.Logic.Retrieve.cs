// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Collections.Generic;
using Moq;
using RESTFulSense.Models.Foundations.PropertyValues;
using Xunit;

namespace RESTFulSense.Tests.Services.Foundations.Properties
{
    public partial class PropertyServiceTests
    {
        [Fact]
        public void ShouldRetrieveProperties()
        {
            // given
            List<PropertyValue> randomPropertyValues = GetRandomProperties();
            List<PropertyValue> expectedPropertyValues = randomPropertyValues;

            this.reflectionBrokerMock.Setup(reflectionBroker =>
                reflectionBroker.GetPropertyValues(It.IsAny<object>))
                    .Returns(expectedPropertyValues);

            // when
            var actualPropertyValues =
                this.propertyService.RetrieveProperties(It.IsAny<object>());

            // then
            this.reflectionBrokerMock.Verify(reflectionBroker =>
                reflectionBroker.GetPropertyValues(It.IsAny<object>), Times.Once);

            this.reflectionBrokerMock.VerifyNoOtherCalls();
        }

    }
}
