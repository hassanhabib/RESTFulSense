// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using Moq;
using RESTFulSense.Models.Attributes;
using RESTFulSense.Models.Processings.StringContents;
using RESTFulSense.Services.Foundations.StreamContents;
using RESTFulSense.Services.Processings.StreamContents;
using Tynamix.ObjectFiller;

namespace RESTFulSense.Tests.Services.Processings.StreamContents
{
    public partial class StreamContentProcessingServiceTests
    {

        private readonly Mock<IStreamContentService> streamContentServiceMock;
        private readonly IStreamContentProcessingService streamContentProcessingService;

        public StreamContentProcessingServiceTests()
        {
            this.streamContentServiceMock = new Mock<IStreamContentService>();
            this.streamContentProcessingService =
                new StreamContentProcessingService(streamContentServiceMock.Object);
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
                Object = CreateSomeObject(),
                Name = CreateRandomString(),
                Value = CreateRandomStream(),
                Attribute = default(RESTFulFileContentStreamAttribute),
            };
        }

        private static dynamic CreateRandomPropertyWithAttribute()
        {
            return new
            {
                PropertyInfo = CreateMockPropertyInfo(),
                Object = CreateSomeObject(),
                Name = CreateRandomString(),
                Value = CreateRandomStream(),
                Attribute = CreateRandomRESTFulFileContentStreamAttribute(),
            };
        }

        private static object CreateSomeObject() => new Object();

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

        private static RESTFulFileContentStreamAttribute CreateRandomRESTFulFileContentStreamAttribute() =>
            CreateRESTFulFileContentStreamAttributeFiller().Create();

        private static Filler<RESTFulFileContentStreamAttribute> CreateRESTFulFileContentStreamAttributeFiller()
        {
            Filler<RESTFulFileContentStreamAttribute> filler = new Filler<RESTFulFileContentStreamAttribute>();

            return filler;
        }

        private static PropertyInfo CreateMockPropertyInfo() => new Mock<PropertyInfo>().Object;

        private static PropertyInfo GetPropertyInfo(dynamic property) =>
           (PropertyInfo)property.PropertyInfo;

        private static NamedStringContent GetAttribute(dynamic property)
        {
            return new NamedStringContent
            {
                Name = property.Attribute?.Name ?? null,
                StringContent = new StringContent(CreateRandomString())
            };
        }
    }
}
