// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FluentAssertions;
using Force.DeepCloner;
using Moq;
using RESTFulSense.Models.Attributes;
using RESTFulSense.Models.Foundations.FileNames.Exceptions;
using RESTFulSense.Models.Foundations.Properties;
using RESTFulSense.Models.Processings.FileNames.Exceptions;
using RESTFulSense.Models.Processings.StreamContents;
using Xunit;

namespace RESTFulSense.Tests.Services.Processings.FilesNames
{
    public partial class FileNameProcessingServiceTests
    {
        [Fact]
        public void ShouldThrowFileNameProcessingDependencyValidationExceptionIfFileNameValidationExceptionOccurs()
        {
            // given
            dynamic[] randomPropertiesNoAttribute = CreateRandomProperties();
            dynamic[] randomPropertiesWithAttribute = CreateRandomPropertiesWithAttributes();

            IEnumerable<dynamic> allProperties = randomPropertiesNoAttribute.Union(randomPropertiesWithAttribute);
            dynamic[] randomProperties = ShuffleRandomProperties(allProperties);

            List<PropertyInfo> randomPropertyInfos =
                randomProperties.Select(GetPropertyInfo).ToList();

            List<NamedStreamContent> expectedNamedStreamContents =
                randomProperties.Where(property => property.Attribute != null)
                    .Select(GetAttribute).ToList();

            var outNamedStreamContents = expectedNamedStreamContents.DeepClone();

            List<PropertyValue> randomPropertyValues =
                randomProperties.Select(property => new PropertyValue
                {
                    PropertyInfo = property.PropertyInfo,
                    Value = property.Object
                }).ToList();

            List<PropertyValue> inputPropertyValues = randomPropertyValues;

            List<RESTFulFileContentNameAttribute> expectedRESTFulFileContentNameAttributes =
                randomProperties.Select(property => (RESTFulFileContentNameAttribute)property.Attribute)
                    .ToList();


            var nullPropertyInfoException = new NullPropertyInfoException();

            var fileNameValidationException =
                new FileNameValidationException(nullPropertyInfoException);

            var expectedFileNameProcessingDependencyValidationException =
                new FileNameProcessingDependencyValidationException(fileNameValidationException);


            this.fileNameServiceMock.Setup(service =>
                service.RetrieveFileName(It.IsAny<PropertyInfo>()))
                    .Throws(fileNameValidationException);

            // when
            Action updateFileNamesFunction = () =>
                this.fileNameProcessingService.UpdateFileNames(expectedNamedStreamContents, inputPropertyValues);

            FileNameProcessingDependencyValidationException actualFileNameProcessingDependencyException =
               Assert.Throws<FileNameProcessingDependencyValidationException>(updateFileNamesFunction);

            // then
            actualFileNameProcessingDependencyException.Should()
               .BeEquivalentTo(expectedFileNameProcessingDependencyValidationException);

            this.fileNameServiceMock.Verify(service =>
                service.RetrieveFileName(It.IsAny<PropertyInfo>()), Times.Once);

            this.fileNameServiceMock.VerifyNoOtherCalls();
        }

        [Fact]
        public void ShouldThrowFileNameProcessingDependencyExceptionIfFileNameServiceExceptionOccurs()
        {
            // given
            dynamic[] randomPropertiesNoAttribute = CreateRandomProperties();
            dynamic[] randomPropertiesWithAttribute = CreateRandomPropertiesWithAttributes();

            IEnumerable<dynamic> allProperties = randomPropertiesNoAttribute.Union(randomPropertiesWithAttribute);
            dynamic[] randomProperties = ShuffleRandomProperties(allProperties);

            List<PropertyInfo> randomPropertyInfos =
                randomProperties.Select(GetPropertyInfo).ToList();

            List<NamedStreamContent> expectedNamedStreamContents =
                randomProperties.Where(property => property.Attribute != null)
                    .Select(GetAttribute).ToList();

            var outNamedStreamContents = expectedNamedStreamContents.DeepClone();

            List<PropertyValue> randomPropertyValues =
                randomProperties.Select(property => new PropertyValue
                {
                    PropertyInfo = property.PropertyInfo,
                    Value = property.Object
                }).ToList();

            List<PropertyValue> inputPropertyValues = randomPropertyValues;

            List<RESTFulFileContentNameAttribute> expectedRESTFulFileContentNameAttributes =
                randomProperties.Select(property => (RESTFulFileContentNameAttribute)property.Attribute)
                    .ToList();

            var nullPropertyInfoException = new NullPropertyInfoException();

            var fileNameServiceException =
                new FileNameServiceException(nullPropertyInfoException);

            var expectedFileNameProcessingDependencyException =
                new FileNameProcessingDependencyException(fileNameServiceException);

            this.fileNameServiceMock.Setup(service =>
                service.RetrieveFileName(It.IsAny<PropertyInfo>()))
                    .Throws(fileNameServiceException);

            // when
            Action updateFileNamesFunction = () =>
                this.fileNameProcessingService.UpdateFileNames(expectedNamedStreamContents, inputPropertyValues);

            FileNameProcessingDependencyException actualFileNameProcessingDependencyException =
               Assert.Throws<FileNameProcessingDependencyException>(updateFileNamesFunction);

            // then
            actualFileNameProcessingDependencyException.Should()
               .BeEquivalentTo(expectedFileNameProcessingDependencyException);

            this.fileNameServiceMock.Verify(service =>
                service.RetrieveFileName(It.IsAny<PropertyInfo>()), Times.Once);

            this.fileNameServiceMock.VerifyNoOtherCalls();
        }

        [Fact]
        public void ShouldThrowFileNameProcessingServiceExceptionIfExceptionOccurs()
        {
            // given
            dynamic[] randomPropertiesNoAttribute = CreateRandomProperties();
            dynamic[] randomPropertiesWithAttribute = CreateRandomPropertiesWithAttributes();

            IEnumerable<dynamic> allProperties = randomPropertiesNoAttribute.Union(randomPropertiesWithAttribute);
            dynamic[] randomProperties = ShuffleRandomProperties(allProperties);

            List<PropertyInfo> randomPropertyInfos =
                randomProperties.Select(GetPropertyInfo).ToList();

            List<NamedStreamContent> expectedNamedStreamContents =
                randomProperties.Where(property => property.Attribute != null)
                    .Select(GetAttribute).ToList();

            var outNamedStreamContents = expectedNamedStreamContents.DeepClone();

            List<PropertyValue> randomPropertyValues =
                randomProperties.Select(property => new PropertyValue
                {
                    PropertyInfo = property.PropertyInfo,
                    Value = property.Object
                }).ToList();

            List<PropertyValue> inputPropertyValues = randomPropertyValues;

            List<RESTFulFileContentNameAttribute> expectedRESTFulFileContentNameAttributes =
                randomProperties.Select(property => (RESTFulFileContentNameAttribute)property.Attribute)
                    .ToList();

            var exception = new Exception();

            var failedFileNameProcessingServiceException =
                new FailedFileNameProcessingServiceException(exception);

            var expectedFileNameProcessingServiceException =
                new FileNameProcessingServiceException(failedFileNameProcessingServiceException);

            this.fileNameServiceMock.Setup(service =>
                service.RetrieveFileName(It.IsAny<PropertyInfo>()))
                    .Throws(exception);

            // when
            Action updateFileNamesFunction = () =>
                this.fileNameProcessingService.UpdateFileNames(expectedNamedStreamContents, inputPropertyValues);

            FileNameProcessingServiceException actualFileNameProcessingServiceException =
               Assert.Throws<FileNameProcessingServiceException>(updateFileNamesFunction);

            // then
            actualFileNameProcessingServiceException.Should()
               .BeEquivalentTo(expectedFileNameProcessingServiceException);

            this.fileNameServiceMock.Verify(service =>
                service.RetrieveFileName(It.IsAny<PropertyInfo>()), Times.Once);

            this.fileNameServiceMock.VerifyNoOtherCalls();
        }
    }
}
