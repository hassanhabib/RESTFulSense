// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using Moq;
using RESTFulSense.Models.Foundations.Properties;
using RESTFulSense.Models.Processings.StreamContents;
using RESTFulSense.Models.Processings.StringContents;
using RESTFulSense.Services.Orchestrations.FormContents;
using RESTFulSense.Services.Processings.FileNames;
using RESTFulSense.Services.Processings.Properties;
using RESTFulSense.Services.Processings.StreamContents;
using RESTFulSense.Services.Processings.StringContents;
using Tynamix.ObjectFiller;

namespace RESTFulSense.Tests.Services.Orchestrations.FormContents
{
    public partial class FormContentOrchestrationServiceTests
    {
        private readonly Mock<IPropertyProcessingService> propertyProcessingServiceMock;
        private readonly Mock<IStringContentProcessingService> stringContentProcessingServiceMock;
        private readonly Mock<IStreamContentProcessingService> streamContentProcessingServiceMock;
        private readonly Mock<IFileNameProcessingService> fileNameProcessingServiceMock;
        private readonly IFormContentOrchestrationService formContentOrchestrationService;

        public FormContentOrchestrationServiceTests()
        {
            this.propertyProcessingServiceMock = new Mock<IPropertyProcessingService>();
            this.stringContentProcessingServiceMock = new Mock<IStringContentProcessingService>();
            this.streamContentProcessingServiceMock = new Mock<IStreamContentProcessingService>();
            this.fileNameProcessingServiceMock = new Mock<IFileNameProcessingService>();

            this.formContentOrchestrationService =
                new FormContentOrchestrationService(
                    propertyProcessingServiceMock.Object,
                    stringContentProcessingServiceMock.Object,
                    streamContentProcessingServiceMock.Object,
                    fileNameProcessingServiceMock.Object);
        }
        private Object CreateSomeObject() => new Object();

        private enum PropertyType
        {
            None,
            StringContent,
            StreamContent,
            FileName
        }

        private static PropertyInfo GetMockPropertyInfo() => new Mock<PropertyInfo>().Object;

        private PropertyType GetRandomPropertyType() =>
            Enum.GetValues<PropertyType>().OrderBy(a => GetBigRandomNumber()).First();

        List<dynamic> GetRandomProperties()
        {
            IEnumerable<PropertyType> randomPropertyTypes =
                Enumerable.Range(start: 0, count: GetRandomPropertiesNumber())
                    .Select(_ => GetRandomPropertyType());

            return randomPropertyTypes.SelectMany(
                randomPropertyType => FakeProperty(randomPropertyType, CreateRandomString())).ToList();
        }

        private static dynamic[] FakeProperty(PropertyType propertyType, string name)
        {
            return propertyType switch
            {
                PropertyType.StringContent => CreateStringContent(),
                PropertyType.StreamContent => CreateStreamContent(),
                PropertyType.FileName => CreateNamedStringContent(),
                _ => new dynamic[] { new { Type = PropertyType.None, Name = CreateRandomString(), Value = CreateRandomString() } },
            };
        }

        private static dynamic[] CreateStringContent()
        {
            return new dynamic[]
            {
                new
                {
                    Type = PropertyType.StringContent,
                    Name = CreateRandomString(),
                    Value = CreateRandomString()
                }
            };
        }

        private static dynamic[] CreateStreamContent()
        {
            return new dynamic[]
            {
                new
                {
                    Type = PropertyType.StreamContent,
                    Name = CreateRandomString(),
                    Value = CreateRandomStream(),
                    FileName = default(string)
                }
            };
        }

        private static dynamic[] CreateNamedStringContent()
        {
            string name = CreateRandomString();
            string fileName = CreateRandomString();

            return new dynamic[]
            {
                new
                {
                    Type = PropertyType.StreamContent,
                    Name = name,
                    Value = CreateRandomStream(),
                    FileName = fileName
                },
                new
                {
                    Type = PropertyType.FileName,
                    Name = name,
                    Value = fileName
                }
            };
        }

        private static string CreateRandomString() =>
            new MnemonicString().GetValue();

        private static int GetRandomNumber() =>
            new IntRange(min: 2, max: 10).GetValue();

        private static int GetRandomPropertiesNumber() =>
            new IntRange(min: 5, max: 15).GetValue();

        private static int GetBigRandomNumber() =>
            new IntRange(min: int.MinValue, max: int.MaxValue).GetValue();

        private static Stream CreateRandomStream()
        {
            return new MemoryStream();
        }

        private PropertyValue CreateRandomPropertyValue()
        {
            PropertyValue propertyValue = new PropertyValue
            {
                PropertyInfo = new Mock<PropertyInfo>().Object,
                Value = 1
            };

            return propertyValue;
        }

        private static PropertyValue CreatePropertyValue(dynamic randomProperty)
        {
            return new PropertyValue
            {
                Value = randomProperty.Value,
                PropertyInfo = GetMockPropertyInfo()
            };
        }

        private static NamedStringContent CreateNamedStringContent(dynamic randomProperty)
        {
            return new NamedStringContent
            {
                Name = randomProperty.Name,
                StringContent = new StringContent(randomProperty.Value)
            };
        }

        private static NamedStreamContent CreateNamedStreamContent(dynamic randomProperty)
        {
            return new NamedStreamContent
            {
                Name = randomProperty.Name,
                StreamContent = new StreamContent(randomProperty.Value),
                FileName = randomProperty.FileName
            };
        }

    }
}
