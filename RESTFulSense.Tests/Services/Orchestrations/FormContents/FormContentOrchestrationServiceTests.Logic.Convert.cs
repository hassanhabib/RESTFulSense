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

            int expectedItemCount = returnedNamedStringContents.Count + returnedNamedStreamContents.Count;
            var sequence = new MockSequence();

            this.propertyProcessingServiceMock.InSequence(sequence).Setup(service =>
                service.RetrieveProperties(It.IsAny<Object>()))
                    .Returns(returnedPropertyValues);

            this.stringContentProcessingServiceMock.InSequence(sequence).Setup(service =>
                service.FilterStringContents(returnedPropertyValues))
                    .Returns(returnedNamedStringContents);

            this.streamContentProcessingServiceMock.InSequence(sequence).Setup(service =>
                service.FilterStreamContents(returnedPropertyValues))
                    .Returns(returnedNamedStreamContents);

            this.fileNameProcessingServiceMock.InSequence(sequence).Setup(service =>
                service.UpdateFileNames(It.IsAny<IEnumerable<NamedStreamContent>>(), returnedPropertyValues))
                    .Verifiable();

            // when
            MultipartFormDataContent actualMultipartFormDataContent =
                this.formContentOrchestrationService.ConvertToMultipartFormDataContent(inputObject);

            // then
            foreach (NamedStringContent namedStringContents in returnedNamedStringContents)
            {
                actualMultipartFormDataContent.Contains(namedStringContents.StringContent).Should().BeTrue();
                namedStringContents.StringContent.Headers.ContentDisposition.Name.Should().Be(namedStringContents.Name);
            }

            foreach (NamedStreamContent namedStreamContents in returnedNamedStreamContents)
            {
                actualMultipartFormDataContent.Contains(namedStreamContents.StreamContent).Should().BeTrue();
                namedStreamContents.StreamContent.Headers.ContentDisposition.Name.Should().Be(namedStreamContents.Name);
                namedStreamContents.StreamContent.Headers.ContentDisposition.FileName.Should().Be(namedStreamContents.FileName);
            }

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
    }
}
