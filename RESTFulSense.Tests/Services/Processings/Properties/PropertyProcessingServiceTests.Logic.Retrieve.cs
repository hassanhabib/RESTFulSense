// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using FluentAssertions;
using Moq;
using RESTFulSense.Models.Foundations.Properties;
using Xunit;

namespace RESTFulSense.Tests.Services.Processings.Properties
{
    public partial class PropertyProcessingServiceTests
    {
        [Fact]
        public void ShouldRetrieveProperties()
        {
            // given
            Object someObject = CreateSomeObject();
            Object inputObject = someObject;
            Object expectedObject = inputObject;

            IEnumerable<PropertyValue> randomProperties = CreateRandomPropertyValues();
            IEnumerable<PropertyValue> expectedProperties = randomProperties;

            this.propertyServiceMock.Setup(service =>
                service.RetrieveProperties(expectedObject))
                    .Returns(expectedProperties);

            // when
            IEnumerable<PropertyValue> actualPropertyValues =
                this.propertyProcessingService.RetrieveProperties(inputObject);

            // then
            this.propertyServiceMock.Verify(service =>
                service.RetrieveProperties(expectedObject), Times.Once);

            actualPropertyValues.Should().BeEquivalentTo(expectedProperties);

            this.propertyServiceMock.VerifyNoOtherCalls();
        }
    }
}
