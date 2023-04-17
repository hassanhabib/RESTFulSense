// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FluentAssertions;
using Moq;
using RESTFulSense.Models.Foundations.Properties;
using RESTFulSense.Models.Foundations.StringContents.Exceptions;
using RESTFulSense.Models.Processings.Properties.Exceptions;
using RESTFulSense.Models.Processings.StringContents;
using RESTFulSense.Models.Processings.StringContents.Exceptions;
using Xunit;

namespace RESTFulSense.Tests.Services.Processings.StringContents
{
    public partial class StringContentProcessingServiceTests
    {
        [Fact]
        public void ShouldThrowStringContentProcessingDependencyValidationExceptionIfStringContentValidationExceptionOccurs()
        {
            // given
            dynamic[] randomPropertiesNoAttribute = CreateRandomProperties();
            dynamic[] randomPropertiesWithAttribute = CreateRandomPropertiesWithAttributes();
            dynamic[] randomProperties =
                ShuffleRandomProperties(randomPropertiesNoAttribute.Union(randomPropertiesWithAttribute));

            PropertyInfo somePropertyInfo = CreateMockPropertyInfo();
            PropertyInfo inputPropertyInfo = somePropertyInfo;

            List<PropertyValue> randomPropertyValues =
                 randomProperties.Select(property => new PropertyValue
                 {
                     PropertyInfo = property.PropertyInfo,
                     Value = property.Value
                 }).ToList();

            List<PropertyValue> inputPropertyValues = randomPropertyValues;

            var nullPropertyInfoException = new NullPropertyInfoException();

            var stringContentValidationException =
                new StringContentValidationException(nullPropertyInfoException);

            var expectedStringContentProcessingDependencyValidationException =
                new StringContentProcessingDependencyValidationException(stringContentValidationException);

            this.stringContentServiceMock.Setup(service =>
                service.RetrieveStringContent(It.IsAny<PropertyInfo>()))
                    .Throws(stringContentValidationException);

            // when
            Func<IEnumerable<NamedStringContent>> filterStringContentsFunction = () =>
               this.stringContentProcessingService.FilterStringContents(inputPropertyValues).ToList();

            StringContentProcessingDependencyValidationException actualStringContentProcessingDependencyValidationException =
               Assert.Throws<StringContentProcessingDependencyValidationException>(filterStringContentsFunction);

            // then
            actualStringContentProcessingDependencyValidationException.Should()
                .BeEquivalentTo(expectedStringContentProcessingDependencyValidationException);

            this.stringContentServiceMock.Verify(service =>
                service.RetrieveStringContent(It.IsAny<PropertyInfo>()), Times.Once);

            this.stringContentServiceMock.VerifyNoOtherCalls();
        }

        [Fact]
        public void ShouldThrowPropertyProcessingDependencyExceptionIfStringContentServiceExceptionOccurs()
        {
            // given
            dynamic[] randomPropertiesNoAttribute = CreateRandomProperties();
            dynamic[] randomPropertiesWithAttribute = CreateRandomPropertiesWithAttributes();
            dynamic[] randomProperties =
                ShuffleRandomProperties(randomPropertiesNoAttribute.Union(randomPropertiesWithAttribute));

            PropertyInfo somePropertyInfo = CreateMockPropertyInfo();
            PropertyInfo inputPropertyInfo = somePropertyInfo;

            List<PropertyValue> randomPropertyValues =
                 randomProperties.Select(property => new PropertyValue
                 {
                     PropertyInfo = property.PropertyInfo,
                     Value = property.Value
                 }).ToList();

            List<PropertyValue> inputPropertyValues = randomPropertyValues;

            var stringContentServiceException =
                new StringContentServiceException(
                    innerException: new FailedStringContentServiceException(
                        innerException: new Exception()));

            var expectedStringContentProcessingDependencyException =
                new StringContentProcessingDependencyException(stringContentServiceException);

            this.stringContentServiceMock.Setup(service =>
                service.RetrieveStringContent(It.IsAny<PropertyInfo>()))
                    .Throws(stringContentServiceException);

            // when
            Func<IEnumerable<NamedStringContent>> filterStringContentsFunction = () =>
               this.stringContentProcessingService.FilterStringContents(inputPropertyValues).ToList();

            StringContentProcessingDependencyException actualStringContentProcessingDependencyException =
               Assert.Throws<StringContentProcessingDependencyException>(filterStringContentsFunction);

            // then
            actualStringContentProcessingDependencyException.Should()
                .BeEquivalentTo(expectedStringContentProcessingDependencyException);

            this.stringContentServiceMock.Verify(service =>
                service.RetrieveStringContent(It.IsAny<PropertyInfo>()), Times.Once);

            this.stringContentServiceMock.VerifyNoOtherCalls();
        }

        [Fact]
        public void ShouldThrowStringContentProcessingServiceExceptionIfExceptionOccurs()
        {
            // given
            dynamic[] randomPropertiesNoAttribute = CreateRandomProperties();
            dynamic[] randomPropertiesWithAttribute = CreateRandomPropertiesWithAttributes();
            dynamic[] randomProperties =
                ShuffleRandomProperties(randomPropertiesNoAttribute.Union(randomPropertiesWithAttribute));

            PropertyInfo somePropertyInfo = CreateMockPropertyInfo();
            PropertyInfo inputPropertyInfo = somePropertyInfo;

            List<PropertyValue> randomPropertyValues =
                 randomProperties.Select(property => new PropertyValue
                 {
                     PropertyInfo = property.PropertyInfo,
                     Value = property.Value
                 }).ToList();

            List<PropertyValue> inputPropertyValues = randomPropertyValues;

            var exception = new Exception();

            var expectedStringContentProcessingServiceException =
                new StringContentProcessingServiceException(innerException: exception);

            this.stringContentServiceMock.Setup(service =>
                service.RetrieveStringContent(It.IsAny<PropertyInfo>()))
                    .Throws(exception);

            // when
            Func<IEnumerable<NamedStringContent>> filterStringContentsFunction = () =>
               this.stringContentProcessingService.FilterStringContents(inputPropertyValues).ToList();

            StringContentProcessingServiceException actualStringContentProcessingServiceException =
               Assert.Throws<StringContentProcessingServiceException>(filterStringContentsFunction);

            // then
            actualStringContentProcessingServiceException.Should()
                .BeEquivalentTo(expectedStringContentProcessingServiceException);

            this.stringContentServiceMock.Verify(service =>
                service.RetrieveStringContent(It.IsAny<PropertyInfo>()), Times.Once);

            this.stringContentServiceMock.VerifyNoOtherCalls();
        }
    }
}
