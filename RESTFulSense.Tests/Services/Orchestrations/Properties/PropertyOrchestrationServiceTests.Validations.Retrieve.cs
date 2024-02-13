// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using FluentAssertions;
using Moq;
using RESTFulSense.Models.Orchestrations.Properties;
using RESTFulSense.Models.Orchestrations.Properties.Exceptions;
using Xunit;

namespace RESTFulSense.Tests.Services.Orchestrations.Properties
{
    public partial class PropertyOrchestrationServiceTests
    {
        [Fact]
        private void ShouldThrowPropertyOrchestrationValidationExceptionOnRetrievePropertiesIfNullPropertyModelOccurs()
        {
            // given
            PropertyModel nullPropertyModel = null;
            PropertyModel inputPropertyModel = nullPropertyModel;
            Type someType = typeof(object);

            var argumentNullException =
                new ArgumentNullException(paramName: "propertyModel");

            var nullPropertyModelException =
                new NullPropertyModelException(
                    message: "PropertyModel is null, fix errors and try again.",
                    innerException: argumentNullException);

            var expectedPropertyOrchestrationValidationException =
                new PropertyOrchestrationValidationException(
                    message: "Property validation error occurred, fix errors and try again.",
                    innerException: nullPropertyModelException);

            // when
            Action retrievePropertiesAction =
                () => propertyOrchestrationService.RetrieveProperties(inputPropertyModel);

            PropertyOrchestrationValidationException actualPropertyOrchestrationValidationException =
                Assert.Throws<PropertyOrchestrationValidationException>(retrievePropertiesAction);

            // then
            actualPropertyOrchestrationValidationException.Should()
                .BeEquivalentTo(expectedPropertyOrchestrationValidationException);

            typeServiceMock.Verify(service =>
                service.RetrieveType(It.IsAny<PropertyModel>()),
                    Times.Never());

            propertyServiceMock.Verify(service =>
                service.RetrieveProperties(someType),
                    Times.Never());

            typeServiceMock.VerifyNoOtherCalls();
            propertyServiceMock.VerifyNoOtherCalls();
        }

        [Fact]
        private void ShouldThrowPropertyOrchestrationValidationExceptionOnRetrievePropertiesIfNullObjectOccurs()
        {
            // given
            PropertyModel nullObjectModel = CreateSomePropertyModel(null);
            PropertyModel inputPropertyModel = nullObjectModel;
            Type someType = typeof(object);

            var argumentNullException =
                new ArgumentNullException(paramName: "object");

            var nullPropertyModelException =
                new NullObjectException(
                    message: "Object is null, fix errors and try again.",
                    innerException: argumentNullException);

            var expectedPropertyOrchestrationValidationException =
                new PropertyOrchestrationValidationException(
                    message: "Property validation error occurred, fix errors and try again.",
                    innerException: nullPropertyModelException);

            // when
            Action retrievePropertiesAction =
                () => propertyOrchestrationService.RetrieveProperties(inputPropertyModel);

            PropertyOrchestrationValidationException actualPropertyOrchestrationValidationException =
                Assert.Throws<PropertyOrchestrationValidationException>(retrievePropertiesAction);

            // then
            actualPropertyOrchestrationValidationException.Should()
                .BeEquivalentTo(expectedPropertyOrchestrationValidationException);

            typeServiceMock.Verify(service =>
                service.RetrieveType(It.IsAny<PropertyModel>()),
                    Times.Never());

            propertyServiceMock.Verify(service =>
                service.RetrieveProperties(someType),
                    Times.Never());

            typeServiceMock.VerifyNoOtherCalls();
            propertyServiceMock.VerifyNoOtherCalls();
        }
    }
}
