﻿// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using Moq;
using RESTFulSense.Models.Attributes;
using RESTFulSense.Models.Processings.StreamContents;
using RESTFulSense.Services.Foundations.FileNames;
using RESTFulSense.Services.Processings.FileNames;
using Tynamix.ObjectFiller;

namespace RESTFulSense.Tests.Services.Processings.FilesNames
{
    public partial class FileNameProcessingServiceTests
    {
        private readonly Mock<IFileNameService> fileNameServiceMock;
        private readonly IFileNameProcessingService fileNameProcessingService;

        public FileNameProcessingServiceTests()
        {
            this.fileNameServiceMock = new Mock<IFileNameService>();
            this.fileNameProcessingService =
                new FileNameProcessingService(fileNameServiceMock.Object);
        }

        private static string CreateRandomString() =>
            new MnemonicString().GetValue();

        private static dynamic[] ShuffleRandomProperties(IEnumerable<dynamic> properties)
        {
            return properties.OrderBy(i => GetBigRandomNumber())
                .ToArray();
        }

        private static dynamic[] CreateRandomProperties() =>
            Enumerable.Range(start: 0, count: GetRandomNumber())
                .Select(i => CreateRandomProperty()).ToArray();

        private static dynamic[] CreateRandomPropertiesWithAttributes() =>
            Enumerable.Range(start: 0, count: GetRandomNumber())
                .Select(i => CreateRandomPropertyWithAttribute()).ToArray();

        private static dynamic CreateRandomProperty()
        {
            return new
            {
                PropertyInfo = CreateMockPropertyInfo(),
                Object = CreateRandomString(),
                Name = CreateRandomString(),
                Value = CreateRandomString(),
                Attribute = default(RESTFulFileContentNameAttribute),
            };
        }

        private static dynamic CreateRandomPropertyWithAttribute()
        {
            return new
            {
                PropertyInfo = CreateMockPropertyInfo(),
                Object = CreateRandomString(),
                Name = CreateRandomString(),
                Value = CreateRandomString(),
                Attribute = CreateRandomRESTFulFileContentNameAttribute(),
            };
        }

        private static int GetRandomNumber() =>
            new IntRange(min: 2, max: 10).GetValue();

        private static int GetBigRandomNumber() =>
            new IntRange(min: int.MinValue, max: int.MaxValue).GetValue();

        private static Stream CreateRandomStream()
        {
            string randomLine = new MnemonicString(GetRandomNumber()).GetValue();
            byte[] buffer = Encoding.UTF8.GetBytes(randomLine);
            return new MemoryStream(buffer);
        }

        private static RESTFulFileContentNameAttribute CreateRandomRESTFulFileContentNameAttribute() =>
            CreateRESTFulFileContentNameAttributeFiller().Create();

        private static Filler<RESTFulFileContentNameAttribute> CreateRESTFulFileContentNameAttributeFiller()
        {
            Filler<RESTFulFileContentNameAttribute> filler = new Filler<RESTFulFileContentNameAttribute>();

            return filler;
        }

        private static PropertyInfo CreateMockPropertyInfo() => new Mock<PropertyInfo>().Object;

        private static PropertyInfo GetPropertyInfo(dynamic property) =>
           (PropertyInfo)property.PropertyInfo;

        private static NamedStreamContent GetAttribute(dynamic property)
        {
            return new NamedStreamContent
            {
                Name = property.Attribute?.Name ?? null,
                StreamContent = new StreamContent(CreateRandomStream()),
                FileName = null,
            };
        }
    }
}