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
        public void ShouldThrowPropertyOrchestrationValidationExceptionOnRetrievePropertiesIfNullPropertyModelOccurs()
        {
            // given
            PropertyModel nullPropertyModel = null;
            PropertyModel inputPropertyModel = nullPropertyModel;
            Type someType = typeof(object);

            var argumentNullException =
                new ArgumentNullException(paramName: "propertyModel");

            var nullPropertyModelException =
                new NullPropertyModelException(argumentNullException);

            var expectedPropertyOrchestrationValidationException =
                new PropertyOrchestrationValidationException(nullPropertyModelException);

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
