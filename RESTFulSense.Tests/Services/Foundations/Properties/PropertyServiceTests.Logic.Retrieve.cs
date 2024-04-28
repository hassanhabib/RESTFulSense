// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using System.Reflection;
using FluentAssertions;
using Moq;
using Xunit;

namespace RESTFulSense.Tests.Services.Properties
{
    public partial class PropertyServiceTests
    {
        [Fact]
        private void ShouldRetrieveProperties()
        {
            // given
            PropertyInfo[] randomPropertyInfos =
                CreateRandomProperties();

            PropertyInfo[] returnedPropertyInfos =
                randomPropertyInfos;

            PropertyInfo[] expectedPropertyInfos =
                returnedPropertyInfos;

            this.propertyBrokerMock.Setup(broker =>
                broker.GetProperties(It.IsAny<Type>()))
                    .Returns(returnedPropertyInfos);

            // when
            var actualPropertyInfos =
                this.propertyService.RetrieveProperties(
                    typeof(PropertyServiceTests));

            // then
            actualPropertyInfos.Should().BeEquivalentTo(
                expectedPropertyInfos);

            this.propertyBrokerMock.Verify(broker =>
                broker.GetProperties(It.IsAny<Type>()),
                    Times.Once());

            this.propertyBrokerMock.VerifyNoOtherCalls();
        }
    }
}
