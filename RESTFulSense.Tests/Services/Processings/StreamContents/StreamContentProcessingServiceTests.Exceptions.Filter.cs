// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

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
using RESTFulSense.Models.Foundations.StreamContents.Exceptions;
using RESTFulSense.Models.Processings.StreamContents;
using RESTFulSense.Models.Processings.StreamContents.Exceptions;
using Xunit;

namespace RESTFulSense.Tests.Services.Processings.StreamContents
{
    public partial class StreamContentProcessingServiceTests
    {
        [Fact]
        public void ShouldThrowStreamContentProcessingDependencyValidationExceptionIfStreamContentValidationExceptionOccurs()
        {
            // given
            dynamic[] randomPropertiesNoAttribute = CreateRandomProperties();
            dynamic[] randomPropertiesWithAttribute = CreateRandomPropertiesWithAttributes();
            IEnumerable<dynamic> allProperties = randomPropertiesNoAttribute.Union(randomPropertiesWithAttribute);
            dynamic[] randomProperties = ShuffleRandomProperties(allProperties);

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
                new StreamContentValidationException(nullPropertyInfoException);

            var expectedStreamContentProcessingDependencyValidationException =
                new StreamContentProcessingDependencyValidationException(stringContentValidationException);

            this.streamContentServiceMock.Setup(service =>
                service.RetrieveStreamContent(It.IsAny<PropertyInfo>()))
                    .Throws(stringContentValidationException);

            // when
            Func<IEnumerable<NamedStreamContent>> filterStreamContentsFunction = () =>
               this.streamContentProcessingService.FilterStreamContents(inputPropertyValues).ToList();

            StreamContentProcessingDependencyValidationException actualStreamContentProcessingDependencyValidationException =
               Assert.Throws<StreamContentProcessingDependencyValidationException>(filterStreamContentsFunction);

            // then
            actualStreamContentProcessingDependencyValidationException.Should()
                .BeEquivalentTo(expectedStreamContentProcessingDependencyValidationException);

            this.streamContentServiceMock.Verify(service =>
                service.RetrieveStreamContent(It.IsAny<PropertyInfo>()), Times.Once);

            this.streamContentServiceMock.VerifyNoOtherCalls();
        }

        [Fact]
        public void ShouldThrowStreamContentProcessingDependencyExceptionIfStreamContentServiceException()
        {
            // given
            dynamic[] randomPropertiesNoAttribute = CreateRandomProperties();
            dynamic[] randomPropertiesWithAttribute = CreateRandomPropertiesWithAttributes();
            IEnumerable<dynamic> allProperties = randomPropertiesNoAttribute.Union(randomPropertiesWithAttribute);
            dynamic[] randomProperties = ShuffleRandomProperties(allProperties);

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

            var streamContentServiceException =
                new StreamContentServiceException(nullPropertyInfoException);

            var expectedStreamContentProcessingDependencyException =
                new StreamContentProcessingDependencyException(streamContentServiceException);

            this.streamContentServiceMock.Setup(service =>
                service.RetrieveStreamContent(It.IsAny<PropertyInfo>()))
                    .Throws(streamContentServiceException);

            // when
            Func<IEnumerable<NamedStreamContent>> filterStreamContentsFunction = () =>
               this.streamContentProcessingService.FilterStreamContents(inputPropertyValues).ToList();

            StreamContentProcessingDependencyException actualStreamContentProcessingDependencyException =
               Assert.Throws<StreamContentProcessingDependencyException>(filterStreamContentsFunction);

            // then
            actualStreamContentProcessingDependencyException.Should()
                .BeEquivalentTo(expectedStreamContentProcessingDependencyException);

            this.streamContentServiceMock.Verify(service =>
                service.RetrieveStreamContent(It.IsAny<PropertyInfo>()), Times.Once);

            this.streamContentServiceMock.VerifyNoOtherCalls();
        }

        [Fact]
        public void ShouldThrowStreamContentProcessingServiceExceptionIfExceptionOccurs()
        {
            // given
            dynamic[] randomPropertiesNoAttribute = CreateRandomProperties();
            dynamic[] randomPropertiesWithAttribute = CreateRandomPropertiesWithAttributes();
            IEnumerable<dynamic> allProperties = randomPropertiesNoAttribute.Union(randomPropertiesWithAttribute);
            dynamic[] randomProperties = ShuffleRandomProperties(allProperties);

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

            var failedStreamContentProcessingServiceException =
                new FailedStreamContentProcessingServiceException(exception);

            var expectedStreamContentProcessingServiceException =
                new StreamContentProcessingServiceException(failedStreamContentProcessingServiceException);

            this.streamContentServiceMock.Setup(service =>
                service.RetrieveStreamContent(It.IsAny<PropertyInfo>()))
                    .Throws(exception);

            // when
            Func<IEnumerable<NamedStreamContent>> filterStreamContentsFunction = () =>
               this.streamContentProcessingService.FilterStreamContents(inputPropertyValues).ToList();

            StreamContentProcessingServiceException actualStreamContentProcessingServiceException =
               Assert.Throws<StreamContentProcessingServiceException>(filterStreamContentsFunction);

            // then
            actualStreamContentProcessingServiceException.Should()
                .BeEquivalentTo(expectedStreamContentProcessingServiceException);

            this.streamContentServiceMock.Verify(service =>
                service.RetrieveStreamContent(It.IsAny<PropertyInfo>()), Times.Once);

            this.streamContentServiceMock.VerifyNoOtherCalls();
        }
    }
}
