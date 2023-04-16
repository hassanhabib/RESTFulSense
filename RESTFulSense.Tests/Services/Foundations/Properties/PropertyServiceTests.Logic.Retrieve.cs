// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Collections.Generic;
using FluentAssertions;
using Moq;
using RESTFulSense.Models.Foundations.Properties;
using Xunit;

namespace RESTFulSense.Tests.Services.Foundations.Properties
{
    public partial class PropertyServiceTests
    {
        [Fact]
        public void ShouldRetrieveProperties()
        {
            // given
            object someObject = CreateSomeObject();
            List<PropertyValue> randomPropertyValues = GetRandomProperties();
            List<PropertyValue> expectedPropertyValues = randomPropertyValues;

            this.reflectionBrokerMock.Setup(reflectionBroker =>
                reflectionBroker.GetPropertyValues(someObject))
                    .Returns(expectedPropertyValues);

            // when
            IEnumerable<PropertyValue> actualPropertyValues =
                this.propertyService.RetrieveProperties(someObject);

            // then
            this.reflectionBrokerMock.Verify(reflectionBroker =>
                reflectionBroker.GetPropertyValues(someObject),
                    Times.Once);

            actualPropertyValues.Should().BeSameAs(expectedPropertyValues);

            this.reflectionBrokerMock.VerifyNoOtherCalls();
        }
    }
}
