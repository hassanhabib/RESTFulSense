// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using FluentAssertions;
using Moq;
using RESTFulSense.Models.Foundations.Properties.Exceptions;
using RESTFulSense.Models.Processings.Properties.Exceptions;
using Xunit;

namespace RESTFulSense.Tests.Services.Processings
{
    public partial class PropertyProcessingServiceTests
    {
        [Fact]
        public void ShouldThrowPropertyProcessingDependencyValidationExceptionIfPropertyValidationExceptionOccurs()
        {
            // given
            Object someObject = CreateSomeObject();
            Object inputObject = someObject;
            NullObjectException nullObjectException = new NullObjectException();

            PropertyValidationException propertyValidationException =
                new PropertyValidationException(nullObjectException);

            PropertyProcessingDependencyValidationException expectedPropertyProcessingDependencyValidationException =
                new PropertyProcessingDependencyValidationException(propertyValidationException);

            this.propertyServiceMock.Setup(service =>
                service.RetrieveProperties(inputObject)).Throws(propertyValidationException);

            Action retrievePropertiesAction = () => this.propertyProcessingService.RetrieveProperties(inputObject);

            // when
            PropertyProcessingDependencyValidationException actualPropertyProcessingDependencyValidationException =
               Assert.Throws<PropertyProcessingDependencyValidationException>(retrievePropertiesAction);

            // then
            actualPropertyProcessingDependencyValidationException.Should()
                .BeEquivalentTo(expectedPropertyProcessingDependencyValidationException);

            this.propertyServiceMock.Verify(service =>
                service.RetrieveProperties(inputObject), Times.Once);

            this.propertyServiceMock.VerifyNoOtherCalls();
        }
    }
}
