// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using Moq;
using RESTFulSense.Models.Foundations.Properties;
using RESTFulSense.Models.Processings.StreamContents;
using RESTFulSense.Models.Processings.StringContents;
using Xunit;

namespace RESTFulSense.Tests.Services.Orchestrations.FormContents
{
    public partial class FormContentOrchestrationServiceTests
    {
        [Fact]
        public void ShouldConvertToMultipartFormDataContent()
        {
            // given
            Object someObject = new Object();
            Object inputObject = someObject;

            List<dynamic> randomProperties = GetRandomProperties();

            List<PropertyValue> randomPropertyValues =
                randomProperties.Select(randomProperty =>
                    new PropertyValue
                    {
                        Value = randomProperty.Value,
                        PropertyInfo = GetMockPropertyInfo()
                    }).ToList();

            List<NamedStringContent> namedStringContents
                = randomProperties.Where(randomProperty => randomProperty.Type == PropertyType.StringContent)
                     .Select(randomProperty => new NamedStringContent
                     {
                         Name = randomProperty.Name,
                         StringContent = new StringContent(randomProperty.Value)
                     }).ToList();

            List<NamedStreamContent> namedStreamContents
                = randomProperties.Where(randomProperty => randomProperty.Type == PropertyType.StreamContent)
                     .Select(randomProperty => new NamedStreamContent
                     {
                         Name = randomProperty.Name,
                         StreamContent = new StreamContent(randomProperty.Value),
                         FileName = randomProperty.FileName
                     }).ToList();

            this.propertyProcessingServiceMock.Setup(service =>
                service.RetrieveProperties(It.IsAny<Object>()))
                    .Returns(randomPropertyValues);

            this.stringContentProcessingServiceMock.Setup(service =>
                service.FilterStringContents(It.IsAny<List<PropertyValue>>()))
                    .Returns(namedStringContents);

            this.streamContentProcessingServiceMock.Setup(service =>
                service.FilterStreamContents(It.IsAny<List<PropertyValue>>()))
                    .Returns(namedStreamContents);

            this.fileNameProcessingServiceMock.Setup(service =>
                service.UpdateFileNames(It.IsAny<IEnumerable<NamedStreamContent>>(), It.IsAny<List<PropertyValue>>()))
                    .Verifiable();

            // when
            MultipartFormDataContent actualMultipartFormDataContent =
                this.formContentOrchestrationService.ConvertToMultipartFormDataContent(inputObject);

            // then
            this.propertyProcessingServiceMock.Verify(service =>
                service.RetrieveProperties(It.IsAny<Object>()),
                    Times.Once);

            this.stringContentProcessingServiceMock.Verify(service =>
                service.FilterStringContents(It.IsAny<List<PropertyValue>>()),
                    Times.Once);

            this.streamContentProcessingServiceMock.Verify(service =>
                service.FilterStreamContents(It.IsAny<List<PropertyValue>>()),
                    Times.Once);

            this.fileNameProcessingServiceMock.Verify(service =>
                service.UpdateFileNames(It.IsAny<IEnumerable<NamedStreamContent>>(), It.IsAny<List<PropertyValue>>()),
                    Times.Once);

            this.propertyProcessingServiceMock.VerifyNoOtherCalls();
            this.stringContentProcessingServiceMock.VerifyNoOtherCalls();
            this.streamContentProcessingServiceMock.VerifyNoOtherCalls();
            this.fileNameProcessingServiceMock.VerifyNoOtherCalls();
        }
    }
}
