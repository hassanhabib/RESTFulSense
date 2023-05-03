// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using System.Reflection;
using FluentAssertions;
using Force.DeepCloner;
using Moq;
using RESTFulSense.Models.Orchestrations.Properties;
using Xunit;

namespace RESTFulSense.Tests.Services.Orchestrations.Properties
{
    public partial class PropertyOrchestrationServiceTests
    {
        [Fact]
        public void ShouldRetrieveProperties()
        {
            // given
            object someObject = new object();
            object inputObject = someObject;
            PropertyModel somePropertyModel = CreateSomePropertyModel(inputObject);
            PropertyModel inputPropertyModel = somePropertyModel;
            PropertyModel expectedPropertyModel = inputPropertyModel.DeepClone();
            Type someType = typeof(object);
            PropertyInfo[] randomProperties = CreateRandomProperties();
            PropertyInfo[] returnedProperties = randomProperties;
            PropertyInfo[] expectedProperties = returnedProperties;
            expectedPropertyModel.Properties = expectedProperties.DeepClone();
            var sequence = new MockSequence();

            this.typeServiceMock.InSequence(sequence).Setup(service =>
                service.RetrieveType(inputObject))
                    .Returns(someType);

            this.propertyServiceMock.InSequence(sequence).Setup(service =>
                service.RetrieveProperties(someType))
                    .Returns(returnedProperties);

            // when
            var actualPropertyModel =
                this.propertyOrchestrationService.RetrieveProperties(inputPropertyModel);

            // then
            actualPropertyModel.Should().BeEquivalentTo(expectedPropertyModel);

            this.typeServiceMock.Verify(service =>
                service.RetrieveType(inputObject),
                    Times.Once());

            this.propertyServiceMock.Verify(service =>
                service.RetrieveProperties(someType),
                    Times.Once());

            this.typeServiceMock.VerifyNoOtherCalls();
            this.propertyServiceMock.VerifyNoOtherCalls();
        }
    }
}
