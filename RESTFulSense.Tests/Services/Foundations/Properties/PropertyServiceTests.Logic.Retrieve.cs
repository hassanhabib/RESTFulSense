// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Collections.Generic;
using FluentAssertions;
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
            object randomObject = new object();
            List<PropertyValue> randomPropertyValues = GetRandomProperties();
            List<PropertyValue> expectedPropertyValues = randomPropertyValues;

            this.reflectionBrokerMock.Setup(reflectionBroker =>
                reflectionBroker.GetPropertyValues(randomObject))
                    .Returns(expectedPropertyValues);

            // when
            var actualPropertyValues =
                this.propertyService.RetrieveProperties(randomObject);

            // then
            this.reflectionBrokerMock.Verify(reflectionBroker =>
                reflectionBroker.GetPropertyValues(randomObject), Times.Once);

            actualPropertyValues.Should().BeSameAs(expectedPropertyValues);

            this.reflectionBrokerMock.VerifyNoOtherCalls();
        }
    }
}
