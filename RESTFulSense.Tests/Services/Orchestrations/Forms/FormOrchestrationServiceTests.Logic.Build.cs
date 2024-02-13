// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System.Data;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using FluentAssertions;
using Moq;
using Moq.Language;
using RESTFulSense.Models.Attributes;
using RESTFulSense.Models.Orchestrations.Forms;
using Xunit;

namespace RESTFulSense.Tests.Services.Orchestrations.Forms
{
    public partial class FormOrchestrationServiceTests
    {
        [Fact]
        private void ShouldBuildFormModel()
        {
            // given
            FormModel someFormModel = CreateRandomFormModel();
            FormModel inputFormModel = someFormModel;
            dynamic[] randomTestData = CreateTestData();

            dynamic[] randomFileNameData =
                randomTestData.Where(a => a.Attribute is RESTFulFileNameAttribute).ToArray();

            dynamic[] randomStringContentData =
                randomTestData.Where(a => a.Attribute is RESTFulStringContentAttribute).ToArray();

            dynamic[] randomByteArrayContentData =
                randomTestData.Where(a => a.Attribute is RESTFulByteArrayContentAttribute).ToArray();

            dynamic[] randomStreamContentData =
                randomTestData.Where(a => a.Attribute is RESTFulStreamContentAttribute).ToArray();

            dynamic[] randomPropertyContents = randomFileNameData
                .Union(randomStringContentData)
                .Union(randomByteArrayContentData)
                .Union(randomStreamContentData)
                .ToArray();

            dynamic[] inputPropertyContents = randomPropertyContents;
            PropertyInfo[] randomProperties = CreateRandomProperties(inputPropertyContents);
            PropertyInfo[] inputProperties = randomProperties;
            someFormModel.Properties = inputProperties;

            ISetupSequentialResult<RESTFulFileNameAttribute> fileAttributeSequence =
                attributeServiceMock.SetupSequence(service =>
                        service.RetrieveAttribute<RESTFulFileNameAttribute>(It.IsAny<PropertyInfo>()));

            foreach (var data in inputPropertyContents)
            {
                fileAttributeSequence = fileAttributeSequence.Returns(data.Attribute as RESTFulFileNameAttribute);
            }

            ISetupSequentialResult<RESTFulStringContentAttribute> stringAttributeSequence =
                attributeServiceMock.SetupSequence(service =>
                    service.RetrieveAttribute<RESTFulStringContentAttribute>(It.IsAny<PropertyInfo>()));

            foreach (var data in inputPropertyContents)
            {
                stringAttributeSequence =
                    stringAttributeSequence.Returns(data.Attribute as RESTFulStringContentAttribute);
            }

            ISetupSequentialResult<RESTFulByteArrayContentAttribute> byteAttributeSequence =
                attributeServiceMock.SetupSequence(service =>
                        service.RetrieveAttribute<RESTFulByteArrayContentAttribute>(It.IsAny<PropertyInfo>()));

            foreach (var data in inputPropertyContents)
            {
                byteAttributeSequence =
                    byteAttributeSequence.Returns(data.Attribute as RESTFulByteArrayContentAttribute);
            }

            ISetupSequentialResult<RESTFulStreamContentAttribute> streamAttributeSequence =
                attributeServiceMock.SetupSequence(service =>
                        service.RetrieveAttribute<RESTFulStreamContentAttribute>(It.IsAny<PropertyInfo>()));

            foreach (var randomPropertyContent in inputPropertyContents)
            {
                streamAttributeSequence =
                    streamAttributeSequence.Returns(randomPropertyContent.Attribute as RESTFulStreamContentAttribute);
            }

            ISetupSequentialResult<object> propertyValueSequence = valueServiceMock.SetupSequence(service =>
                service.RetrievePropertyValue(It.IsAny<object>(), It.IsAny<PropertyInfo>()));

            foreach (var randomPropertyContent in inputPropertyContents)
            {
                propertyValueSequence = propertyValueSequence.Returns(randomPropertyContent.Content);
            }

            ISetupSequentialResult<MultipartFormDataContent> dd = formServiceMock.SetupSequence(service =>
                   service.AddStringContent(inputFormModel.MultipartFormDataContent, It.IsAny<string>(), It.IsAny<string>()));

            formServiceMock.Setup(service =>
                service.AddStringContent(inputFormModel.MultipartFormDataContent, It.IsAny<string>(), It.IsAny<string>()))
                    .Returns(inputFormModel.MultipartFormDataContent);

            formServiceMock.Setup(service =>
                service.AddByteArrayContent(inputFormModel.MultipartFormDataContent, It.IsAny<byte[]>(), It.IsAny<string>()))
                    .Returns(inputFormModel.MultipartFormDataContent);

            formServiceMock.Setup(service =>
                service.AddStreamContent(inputFormModel.MultipartFormDataContent, It.IsAny<Stream>(), It.IsAny<string>()))
                    .Returns(inputFormModel.MultipartFormDataContent);

            // when
            FormModel actualFormModel = formOrchestrationService.BuildFormModel(inputFormModel);

            // then
            actualFormModel.Should().Be(inputFormModel);

            attributeServiceMock.Verify(service =>
                service.RetrieveAttribute<RESTFulFileNameAttribute>(It.IsAny<PropertyInfo>()),
                Times.Exactly(inputPropertyContents.Length));

            attributeServiceMock.Verify(service =>
                service.RetrieveAttribute<RESTFulStringContentAttribute>(It.IsAny<PropertyInfo>()),
                Times.Exactly(inputPropertyContents.Length));

            attributeServiceMock.Verify(service =>
                service.RetrieveAttribute<RESTFulByteArrayContentAttribute>(It.IsAny<PropertyInfo>()),
                    Times.Exactly(inputPropertyContents.Length));

            attributeServiceMock.Verify(service =>
                service.RetrieveAttribute<RESTFulStreamContentAttribute>(It.IsAny<PropertyInfo>()),
                    Times.Exactly(inputPropertyContents.Length));

            valueServiceMock.Verify(service =>
                 service.RetrievePropertyValue(It.IsAny<object>(), It.IsAny<PropertyInfo>()),
                     Times.Exactly(inputPropertyContents.Length));

            var addStringContentCount = inputPropertyContents
                .Select(a => a.Attribute).OfType<RESTFulStringContentAttribute>().Count();

            formServiceMock.Verify(service =>
                service.AddStringContent(
                    inputFormModel.MultipartFormDataContent,
                    It.IsAny<string>(),
                    It.IsAny<string>()),
                        Times.Exactly(addStringContentCount));

            var addByteContentCount = inputPropertyContents
                .Select(a => a.Attribute).OfType<RESTFulByteArrayContentAttribute>().Count();

            formServiceMock.Verify(service =>
                service.AddByteArrayContent(
                    inputFormModel.MultipartFormDataContent,
                    It.IsAny<byte[]>(),
                    It.IsAny<string>()),
                        Times.Exactly(addByteContentCount));

            var addStreamContentCount = inputPropertyContents
                .Select(a => a.Attribute).OfType<RESTFulStreamContentAttribute>().Count();

            formServiceMock.Verify(service =>
                service.AddStreamContent(
                    inputFormModel.MultipartFormDataContent,
                    It.IsAny<Stream>(),
                    It.IsAny<string>()),
                        Times.Exactly(addStreamContentCount));

            attributeServiceMock.VerifyNoOtherCalls();
            valueServiceMock.VerifyNoOtherCalls();
            formServiceMock.VerifyNoOtherCalls();
        }
    }
}
