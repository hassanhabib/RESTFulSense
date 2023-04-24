﻿// ---------------------------------------------------------------------------------- 
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
using RESTFulSense.Models.Processings.FileNames.Exceptions;
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
        public void ShouldThrowFormContentOrchestrationDependencyExceptionIfPropertyProcessingDependencyExceptionOccurs()
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

            var propertyProcessingDependencyException =
                new PropertyProcessingDependencyException(nullObjectException);

            var expectedFormContentOrchestrationDependencyException =
                new FormContentOrchestrationDependencyException(propertyProcessingDependencyException);

            this.propertyProcessingServiceMock.Setup(service =>
                service.RetrieveProperties(It.IsAny<Object>()))
                    .Throws(propertyProcessingDependencyException);

            // when
            Func<MultipartFormDataContent> convertToMultipartFormDataContentFunction = () =>
                this.formContentOrchestrationService.ConvertToMultipartFormDataContent(inputObject);

            FormContentOrchestrationDependencyException actualFormContentOrchestrationDependencyException =
               Assert.Throws<FormContentOrchestrationDependencyException>(convertToMultipartFormDataContentFunction);

            // then
            actualFormContentOrchestrationDependencyException.Should()
                .BeEquivalentTo(expectedFormContentOrchestrationDependencyException);

            this.propertyProcessingServiceMock.Verify(service =>
                service.RetrieveProperties(inputObject),
                    Times.Once);

            this.propertyProcessingServiceMock.VerifyNoOtherCalls();
            this.stringContentProcessingServiceMock.VerifyNoOtherCalls();
            this.streamContentProcessingServiceMock.VerifyNoOtherCalls();
            this.fileNameProcessingServiceMock.VerifyNoOtherCalls();
        }

        [Fact]
        public void ShouldThrowFormContentOrchestrationDependencyExceptionIfStringContentProcessingDependencyExceptionOccurs()
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

            var stringContentProcessingDependencyException =
                new StringContentProcessingDependencyException(nullObjectException);

            var expectedFormContentOrchestrationDependencyException =
                new FormContentOrchestrationDependencyException(stringContentProcessingDependencyException);

            this.propertyProcessingServiceMock.Setup(service =>
                service.RetrieveProperties(It.IsAny<Object>()))
                    .Returns(returnedPropertyValues);

            this.stringContentProcessingServiceMock.Setup(service =>
                service.FilterStringContents(returnedPropertyValues))
                    .Throws(stringContentProcessingDependencyException);

            // when
            Func<MultipartFormDataContent> convertToMultipartFormDataContentFunction = () =>
                this.formContentOrchestrationService.ConvertToMultipartFormDataContent(inputObject);

            FormContentOrchestrationDependencyException actualFormContentOrchestrationDependencyException =
               Assert.Throws<FormContentOrchestrationDependencyException>(convertToMultipartFormDataContentFunction);

            // then
            actualFormContentOrchestrationDependencyException.Should()
                .BeEquivalentTo(expectedFormContentOrchestrationDependencyException);

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
        public void ShouldThrowFormContentOrchestrationDependencyExceptionIfStreamContentProcessingDependencyExceptionOccurs()
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

            var streamContentProcessingDependencyException =
                new StreamContentProcessingDependencyException(nullObjectException);

            var expectedFormContentOrchestrationDependencyException =
                new FormContentOrchestrationDependencyException(streamContentProcessingDependencyException);

            this.propertyProcessingServiceMock.Setup(service =>
                service.RetrieveProperties(It.IsAny<Object>()))
                    .Returns(returnedPropertyValues);

            this.stringContentProcessingServiceMock.Setup(service =>
                service.FilterStringContents(returnedPropertyValues))
                    .Returns(returnedNamedStringContents);

            this.streamContentProcessingServiceMock.Setup(service =>
                service.FilterStreamContents(returnedPropertyValues))
                    .Throws(streamContentProcessingDependencyException);

            // when
            Func<MultipartFormDataContent> convertToMultipartFormDataContentFunction = () =>
                this.formContentOrchestrationService.ConvertToMultipartFormDataContent(inputObject);

            FormContentOrchestrationDependencyException actualFormContentOrchestrationDependencyException =
               Assert.Throws<FormContentOrchestrationDependencyException>(convertToMultipartFormDataContentFunction);

            // then
            actualFormContentOrchestrationDependencyException.Should()
                .BeEquivalentTo(expectedFormContentOrchestrationDependencyException);

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

        [Fact]
        public void ShouldThrowFormContentOrchestrationDependencyExceptionIfFileNameProcessingDependencyExceptionOccurs()
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

            var fileNameProcessingDependencyException =
                new FileNameProcessingDependencyException(nullObjectException);

            var expectedFormContentOrchestrationDependencyException =
                new FormContentOrchestrationDependencyException(fileNameProcessingDependencyException);

            this.propertyProcessingServiceMock.Setup(service =>
                service.RetrieveProperties(It.IsAny<Object>()))
                    .Returns(returnedPropertyValues);

            this.stringContentProcessingServiceMock.Setup(service =>
                service.FilterStringContents(returnedPropertyValues))
                    .Returns(returnedNamedStringContents);

            this.streamContentProcessingServiceMock.Setup(service =>
                service.FilterStreamContents(returnedPropertyValues))
                    .Returns(returnedNamedStreamContents);

            this.fileNameProcessingServiceMock.Setup(service =>
                service.UpdateFileNames(It.IsAny<IEnumerable<NamedStreamContent>>(), returnedPropertyValues))
                    .Throws(fileNameProcessingDependencyException);

            // when
            Func<MultipartFormDataContent> convertToMultipartFormDataContentFunction = () =>
                this.formContentOrchestrationService.ConvertToMultipartFormDataContent(inputObject);

            FormContentOrchestrationDependencyException actualFormContentOrchestrationDependencyException =
               Assert.Throws<FormContentOrchestrationDependencyException>(convertToMultipartFormDataContentFunction);

            // then
            actualFormContentOrchestrationDependencyException.Should()
                .BeEquivalentTo(expectedFormContentOrchestrationDependencyException);

            this.propertyProcessingServiceMock.Verify(service =>
                service.RetrieveProperties(inputObject),
                    Times.Once);

            this.stringContentProcessingServiceMock.Verify(service =>
                service.FilterStringContents(returnedPropertyValues),
                     Times.Once);

            this.streamContentProcessingServiceMock.Verify(service =>
                 service.FilterStreamContents(returnedPropertyValues),
                    Times.Once);

            this.fileNameProcessingServiceMock.Verify(service =>
                service.UpdateFileNames(It.IsAny<IEnumerable<NamedStreamContent>>(), returnedPropertyValues),
                    Times.Once);

            this.propertyProcessingServiceMock.VerifyNoOtherCalls();
            this.stringContentProcessingServiceMock.VerifyNoOtherCalls();
            this.streamContentProcessingServiceMock.VerifyNoOtherCalls();
            this.fileNameProcessingServiceMock.VerifyNoOtherCalls();
        }

        [Fact]
        public void ShouldThrowServiceExceptionOnConvertToMultipartFormDataContentIfServiceErrorOccurs()
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

            var serviceException = new Exception();

            var failedFormContentOrchestrationServiceException =
                new FailedFormContentOrchestrationServiceException(serviceException);

            var expectedFormContentOrchestrationServiceException =
                new FormContentOrchestrationServiceException(failedFormContentOrchestrationServiceException);

            this.propertyProcessingServiceMock.Setup(service =>
                service.RetrieveProperties(It.IsAny<Object>()))
                    .Throws(serviceException);

            // when
            Func<MultipartFormDataContent> convertToMultipartFormDataContentFunction = () =>
                this.formContentOrchestrationService.ConvertToMultipartFormDataContent(inputObject);

            FormContentOrchestrationServiceException actualFormContentOrchestrationServiceException =
               Assert.Throws<FormContentOrchestrationServiceException>(convertToMultipartFormDataContentFunction);

            // then
            actualFormContentOrchestrationServiceException.Should()
                .BeEquivalentTo(expectedFormContentOrchestrationServiceException);

            this.propertyProcessingServiceMock.Verify(service =>
                service.RetrieveProperties(inputObject),
                    Times.Once);

            this.propertyProcessingServiceMock.VerifyNoOtherCalls();
            this.stringContentProcessingServiceMock.VerifyNoOtherCalls();
            this.streamContentProcessingServiceMock.VerifyNoOtherCalls();
            this.fileNameProcessingServiceMock.VerifyNoOtherCalls();
        }
    }
}