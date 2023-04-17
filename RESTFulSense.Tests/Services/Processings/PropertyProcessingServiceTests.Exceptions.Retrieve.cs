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
        public void ShouldThrowPropertyProcessingDependencyExceptionIfPropertyServiceExceptionOccurs()
        {
            // given
            Object someObject = CreateSomeObject();
            Object inputObject = someObject;
            NullObjectException nullObjectException = new NullObjectException();

            PropertyServiceException propertyServiceException =
                new PropertyServiceException(nullObjectException);

            PropertyProcessingDependencyException expectedPropertyProcessingDependencyException =
                new PropertyProcessingDependencyException(propertyServiceException);

            this.propertyServiceMock.Setup(service =>
                service.RetrieveProperties(inputObject)).Throws(propertyServiceException);

            Action retrievePropertiesAction = () => this.propertyProcessingService.RetrieveProperties(inputObject);

            // when
            PropertyProcessingDependencyException actualPropertyProcessingDependencyException =
               Assert.Throws<PropertyProcessingDependencyException>(retrievePropertiesAction);

            // then
            actualPropertyProcessingDependencyException.Should()
                .BeEquivalentTo(expectedPropertyProcessingDependencyException);

            this.propertyServiceMock.Verify(service =>
                service.RetrieveProperties(inputObject),
                    Times.Once);

            this.propertyServiceMock.VerifyNoOtherCalls();
        }
    }
}
