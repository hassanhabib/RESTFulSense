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
        [Theory]
        [MemberData(nameof(DependencyValidationExceptions))]
        public void ShouldThrowPropertyOrchestrationDependencyValidationExceptionIfDependencyExceptionOccurs(
            Exception dependencyValidationException)
        {
            // given
            object someObject = new object();
            object inputObject = someObject;
            PropertyModel somePropertyModel = CreateSomePropertyModel(inputObject);

            var expectedPropertyOrchestrationDependencyValidationException =
                new PropertyOrchestrationDependencyValidationException(dependencyValidationException);

            typeServiceMock.Setup(service =>
                service.RetrieveType(It.IsAny<object>()))
                    .Throws(dependencyValidationException);

            // when
            Action retrievePropertiesAction =
                () => propertyOrchestrationService.RetrieveProperties(somePropertyModel);

            PropertyOrchestrationDependencyValidationException actualPropertyOrchestrationDependencyValidationException =
                Assert.Throws<PropertyOrchestrationDependencyValidationException>(retrievePropertiesAction);

            // then
            actualPropertyOrchestrationDependencyValidationException.Should()
                .BeEquivalentTo(expectedPropertyOrchestrationDependencyValidationException);

            typeServiceMock.Verify(service =>
                service.RetrieveType(It.IsAny<object>()),
                    Times.Once());

            propertyServiceMock.Verify(service =>
                service.RetrieveProperties(It.IsAny<Type>()),
                    Times.Never());

            typeServiceMock.VerifyNoOtherCalls();
            propertyServiceMock.VerifyNoOtherCalls();
        }
    }
}
