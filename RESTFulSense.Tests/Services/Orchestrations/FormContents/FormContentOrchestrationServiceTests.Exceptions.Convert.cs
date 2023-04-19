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
using RESTFulSense.Models.Processings.StringContents;
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

            var propertyPropertyProcessingDependencyException =
                new PropertyProcessingDependencyException(nullObjectException);

            var expectedFormContentOrchestrationDependencyException =
                new FormContentOrchestrationDependencyException(propertyPropertyProcessingDependencyException);

            this.propertyProcessingServiceMock.Setup(service =>
                service.RetrieveProperties(It.IsAny<Object>()))
                    .Throws(propertyPropertyProcessingDependencyException);

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
    }
}
