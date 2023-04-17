// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using FluentAssertions;
using Moq;
using RESTFulSense.Models.Foundations.Properties;
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
            var nullObjectException = new NullObjectException();

            var propertyValidationException =
                new PropertyValidationException(nullObjectException);

            var expectedPropertyProcessingDependencyValidationException =
                new PropertyProcessingDependencyValidationException(propertyValidationException);

            this.propertyServiceMock.Setup(service =>
                service.RetrieveProperties(inputObject)).Throws(propertyValidationException);

            // when
            Func<IEnumerable<PropertyValue>> retrievePropertiesFunction = () =>
               this.propertyProcessingService.RetrieveProperties(inputObject);

            PropertyProcessingDependencyValidationException actualPropertyProcessingDependencyValidationException =
               Assert.Throws<PropertyProcessingDependencyValidationException>(retrievePropertiesFunction);

            // then
            actualPropertyProcessingDependencyValidationException.Should()
                .BeEquivalentTo(expectedPropertyProcessingDependencyValidationException);

            this.propertyServiceMock.Verify(service =>
                service.RetrieveProperties(inputObject), Times.Once);

            this.propertyServiceMock.VerifyNoOtherCalls();
        }
    }
}
