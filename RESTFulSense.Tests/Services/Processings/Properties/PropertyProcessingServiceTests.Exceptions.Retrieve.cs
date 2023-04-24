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
        public void ShouldThrowPropertyProcessingDependencyExceptionIfPropertyServiceExceptionOccurs()
        {
            // given
            Object someObject = CreateSomeObject();
            Object inputObject = someObject;
            var nullObjectException = new NullObjectException();

            var propertyServiceException =
                new PropertyServiceException(nullObjectException);

            var expectedPropertyProcessingDependencyException =
                new PropertyProcessingDependencyException(propertyServiceException);

            this.propertyServiceMock.Setup(
                service => service.RetrieveProperties(inputObject))
                    .Throws(propertyServiceException);

            // when
            Func<IEnumerable<PropertyValue>> retrievePropertiesFunction = () =>
                this.propertyProcessingService.RetrieveProperties(inputObject);

            PropertyProcessingDependencyException actualPropertyProcessingDependencyException =
               Assert.Throws<PropertyProcessingDependencyException>(retrievePropertiesFunction);

            // then
            actualPropertyProcessingDependencyException.Should()
                .BeEquivalentTo(expectedPropertyProcessingDependencyException);

            this.propertyServiceMock.Verify(service =>
                service.RetrieveProperties(inputObject),
                    Times.Once);

            this.propertyServiceMock.VerifyNoOtherCalls();
        }

        [Fact]
        public void ShouldThrowPropertyProcessingServiceExceptionIfExceptionOccurs()
        {
            // given
            Object someObject = CreateSomeObject();
            Object inputObject = someObject;
            var inputException = new Exception();

            var expectedPropertyProcessingServiceException =
                new PropertyProcessingServiceException(inputException);

            this.propertyServiceMock.Setup(
                service => service.RetrieveProperties(inputObject))
                    .Throws(inputException);

            // when
            Func<IEnumerable<PropertyValue>> retrievePropertiesFunction = () =>
               this.propertyProcessingService.RetrieveProperties(inputObject);

            PropertyProcessingServiceException actualPropertyProcessingServiceException =
               Assert.Throws<PropertyProcessingServiceException>(retrievePropertiesFunction);

            // then
            actualPropertyProcessingServiceException.Should()
                .BeEquivalentTo(expectedPropertyProcessingServiceException);

            this.propertyServiceMock.Verify(service =>
                service.RetrieveProperties(inputObject),
                    Times.Once);

            this.propertyServiceMock.VerifyNoOtherCalls();
        }
    }
}
