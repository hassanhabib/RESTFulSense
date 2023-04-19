// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using FluentAssertions;
using Moq;
using RESTFulSense.Models.Foundations.Properties;
using RESTFulSense.Models.Foundations.Properties.Exceptions;
using RESTFulSense.Models.Orchestrations.FormContents.Exceptions;
using RESTFulSense.Models.Processings.Properties.Exceptions;
using RESTFulSense.Models.Processings.StreamContents;
using RESTFulSense.Models.Processings.StreamContents.Exceptions;
using RESTFulSense.Models.Processings.StringContents;
using RESTFulSense.Models.Processings.StringContents.Exceptions;
using Xunit;

namespace RESTFulSense.Tests.Services.Orchestrations.FormContents
{
    public partial class FormContentOrchestrationServiceTests
    {
        [Fact]
        public void ShouldThrowFormContentOrchestrationDependencyValidationExceptionIfPropertyProcessingDependencyValidationExceptionOccurs()
        {
            // given
            Object someObject = CreateSomeObject();
            Object inputObject = someObject;

            List<dynamic> randomProperties = GetRandomProperties();

            List<PropertyValue> returnedPropertyValues =
                randomProperties.Select(CreatePropertyValue).ToList();

            List<NamedStringContent> returnedNamedStringContents
                = randomProperties.Where(randomProperty => randomProperty.Type == PropertyType.StringContent)
                     .Select(CreateNamedStringContent).ToList();

            List<NamedStreamContent> returnedNamedStreamContents
                = randomProperties.Where(randomProperty => randomProperty.Type == PropertyType.StreamContent)
                     .Select(CreateNamedStreamContent).ToList();

            var nullObjectException = new NullObjectException();

            var propertyProcessingDependencyValidationException =
                new PropertyProcessingDependencyValidationException(nullObjectException);

            var expectedFormContentOrchestrationDependencyValidationException =
                new FormContentOrchestrationDependencyValidationException(propertyProcessingDependencyValidationException);

            this.propertyProcessingServiceMock.Setup(service =>
                service.RetrieveProperties(It.IsAny<Object>()))
                    .Throws(propertyProcessingDependencyValidationException);

            // when
            Func<MultipartFormDataContent> convertToMultipartFormDataContentFunction = () =>
                this.formContentOrchestrationService.ConvertToMultipartFormDataContent(inputObject);

            FormContentOrchestrationDependencyValidationException actualFormContentOrchestrationDependencyValidationException =
               Assert.Throws<FormContentOrchestrationDependencyValidationException>(convertToMultipartFormDataContentFunction);

            // then
            actualFormContentOrchestrationDependencyValidationException.Should()
                .BeEquivalentTo(expectedFormContentOrchestrationDependencyValidationException);

            this.propertyProcessingServiceMock.Verify(service =>
                service.RetrieveProperties(inputObject),
                    Times.Once);

            this.propertyProcessingServiceMock.VerifyNoOtherCalls();
            this.stringContentProcessingServiceMock.VerifyNoOtherCalls();
            this.streamContentProcessingServiceMock.VerifyNoOtherCalls();
            this.fileNameProcessingServiceMock.VerifyNoOtherCalls();
        }

        [Fact]
        public void ShouldThrowFormContentOrchestrationDependencyValidationExceptionIfStringContentProcessingDependencyValidationExceptionOccurs()
        {
            // given
            Object someObject = CreateSomeObject();
            Object inputObject = someObject;

            List<dynamic> randomProperties = GetRandomProperties();

            List<PropertyValue> returnedPropertyValues =
                randomProperties.Select(CreatePropertyValue).ToList();

            List<NamedStringContent> returnedNamedStringContents
                = randomProperties.Where(randomProperty => randomProperty.Type == PropertyType.StringContent)
                     .Select(CreateNamedStringContent).ToList();

            List<NamedStreamContent> returnedNamedStreamContents
                = randomProperties.Where(randomProperty => randomProperty.Type == PropertyType.StreamContent)
                     .Select(CreateNamedStreamContent).ToList();

            var nullObjectException = new NullObjectException();

            var stringContentProcessingDependencyValidationException =
                new StringContentProcessingDependencyValidationException(nullObjectException);

            var expectedFormContentOrchestrationDependencyValidationException =
                new FormContentOrchestrationDependencyValidationException(stringContentProcessingDependencyValidationException);

            this.propertyProcessingServiceMock.Setup(service =>
                service.RetrieveProperties(It.IsAny<Object>()))
                    .Returns(returnedPropertyValues);

            this.stringContentProcessingServiceMock.Setup(service =>
                service.FilterStringContents(returnedPropertyValues))
                    .Throws(stringContentProcessingDependencyValidationException);

            // when
            Func<MultipartFormDataContent> convertToMultipartFormDataContentFunction = () =>
                this.formContentOrchestrationService.ConvertToMultipartFormDataContent(inputObject);

            FormContentOrchestrationDependencyValidationException actualFormContentOrchestrationDependencyValidationException =
               Assert.Throws<FormContentOrchestrationDependencyValidationException>(convertToMultipartFormDataContentFunction);

            // then
            actualFormContentOrchestrationDependencyValidationException.Should()
                .BeEquivalentTo(expectedFormContentOrchestrationDependencyValidationException);

            this.propertyProcessingServiceMock.Verify(service =>
                service.RetrieveProperties(inputObject),
                    Times.Once);

            this.stringContentProcessingServiceMock.Verify(service =>
                service.FilterStringContents(returnedPropertyValues),
                     Times.Once);

            this.propertyProcessingServiceMock.VerifyNoOtherCalls();
            this.stringContentProcessingServiceMock.VerifyNoOtherCalls();
            this.streamContentProcessingServiceMock.VerifyNoOtherCalls();
            this.fileNameProcessingServiceMock.VerifyNoOtherCalls();
        }

        [Fact]
        public void ShouldThrowFormContentOrchestrationDependencyValidationExceptionIfStreamContentProcessingDependencyValidationExceptionOccurs()
        {
            // given
            Object someObject = CreateSomeObject();
            Object inputObject = someObject;

            List<dynamic> randomProperties = GetRandomProperties();

            List<PropertyValue> returnedPropertyValues =
                randomProperties.Select(CreatePropertyValue).ToList();

            List<NamedStringContent> returnedNamedStringContents
                = randomProperties.Where(randomProperty => randomProperty.Type == PropertyType.StringContent)
                     .Select(CreateNamedStringContent).ToList();

            List<NamedStreamContent> returnedNamedStreamContents
                = randomProperties.Where(randomProperty => randomProperty.Type == PropertyType.StreamContent)
                     .Select(CreateNamedStreamContent).ToList();

            var nullObjectException = new NullObjectException();

            var streamContentProcessingDependencyValidationException =
                new StreamContentProcessingDependencyValidationException(nullObjectException);

            var expectedFormContentOrchestrationDependencyValidationException =
                new FormContentOrchestrationDependencyValidationException(streamContentProcessingDependencyValidationException);

            this.propertyProcessingServiceMock.Setup(service =>
                service.RetrieveProperties(It.IsAny<Object>()))
                    .Returns(returnedPropertyValues);

            this.stringContentProcessingServiceMock.Setup(service =>
                service.FilterStringContents(returnedPropertyValues))
                    .Returns(returnedNamedStringContents);

            this.streamContentProcessingServiceMock.Setup(service =>
                service.FilterStreamContents(returnedPropertyValues))
                    .Throws(streamContentProcessingDependencyValidationException);

            // when
            Func<MultipartFormDataContent> convertToMultipartFormDataContentFunction = () =>
                this.formContentOrchestrationService.ConvertToMultipartFormDataContent(inputObject);

            FormContentOrchestrationDependencyValidationException actualFormContentOrchestrationDependencyValidationException =
               Assert.Throws<FormContentOrchestrationDependencyValidationException>(convertToMultipartFormDataContentFunction);

            // then
            actualFormContentOrchestrationDependencyValidationException.Should()
                .BeEquivalentTo(expectedFormContentOrchestrationDependencyValidationException);

            this.propertyProcessingServiceMock.Verify(service =>
                service.RetrieveProperties(inputObject),
                    Times.Once);

            this.stringContentProcessingServiceMock.Verify(service =>
                service.FilterStringContents(returnedPropertyValues),
                     Times.Once);

            this.streamContentProcessingServiceMock.Verify(service =>
                 service.FilterStreamContents(returnedPropertyValues),
                    Times.Once);

            this.propertyProcessingServiceMock.VerifyNoOtherCalls();
            this.stringContentProcessingServiceMock.VerifyNoOtherCalls();
            this.streamContentProcessingServiceMock.VerifyNoOtherCalls();
            this.fileNameProcessingServiceMock.VerifyNoOtherCalls();
        }
    }
}
