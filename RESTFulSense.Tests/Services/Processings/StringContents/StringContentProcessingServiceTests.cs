// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using Moq;
using RESTFulSense.Models.Attributes;
using RESTFulSense.Models.Foundations.Properties;
using RESTFulSense.Models.Processings.StreamContents;
using RESTFulSense.Models.Processings.StringContents;
using RESTFulSense.Services.Foundations.StringContents;
using RESTFulSense.Services.Processings.StringContents;
using Tynamix.ObjectFiller;

namespace RESTFulSense.Tests.Services.Processings.StringContents
{
    public partial class StringContentProcessingServiceTests
    {
        private readonly Mock<IStringContentService> stringContentServiceMock;
        private readonly IStringContentProcessingService stringContentProcessingService;

        public StringContentProcessingServiceTests()
        {
            this.stringContentServiceMock = new Mock<IStringContentService>();
            this.stringContentProcessingService =
                new StringContentProcessingService(stringContentServiceMock.Object);
        }

        private static string CreateRandomString() =>
            new MnemonicString().GetValue();

        private static dynamic[] ShuffleRandomProperties(IEnumerable<dynamic> properties)
        {
            return properties.OrderBy(property => GetBigRangeRandomNumber())
                .ToArray();
        }

        private static dynamic[] CreateRandomProperties() =>
            Enumerable.Range(start: 0, count: GetRandomNumber())
                .Select(property => CreateRandomProperty())
                    .ToArray();

        private static dynamic[] CreateRandomPropertiesWithAttributes() =>
            Enumerable.Range(start: 0, count: GetRandomNumber())
                .Select(property => CreateRandomPropertyWithAttribute())
                    .ToArray();

        private static dynamic CreateRandomProperty()
        {
            return new
            {
                PropertyInfo = CreateMockPropertyInfo(),
                Object = CreateSomeObject(),
                Name = CreateRandomString(),
                Value = CreateRandomString(),
                Attribute = default(RESTFulStringContentAttribute),
            };
        }

        private static dynamic CreateRandomPropertyWithAttribute()
        {
            return new
            {
                PropertyInfo = CreateMockPropertyInfo(),
                Object = CreateSomeObject(),
                Name = CreateRandomString(),
                Value = CreateRandomString(),
                Attribute = CreateRandomRESTFulStringContentAttribute(),
            };
        }

        private static object CreateSomeObject() => new Object();

        private static int GetRandomNumber() =>
            new IntRange(min: 2, max: 10).GetValue();

        private static int GetBigRangeRandomNumber() =>
            new IntRange(min: int.MinValue, max: int.MaxValue).GetValue();

        private static RESTFulStringContentAttribute CreateRandomRESTFulStringContentAttribute() =>
            CreateRandomRESTFulStringContentAttributeFiller().Create();

        private static Filler<RESTFulStringContentAttribute> CreateRandomRESTFulStringContentAttributeFiller()
        {
            Filler<RESTFulStringContentAttribute> filler = new Filler<RESTFulStringContentAttribute>();

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

        private static PropertyValue ConvertToPropertyValue(dynamic property)
        {
            return new PropertyValue
            {
                PropertyInfo = property.PropertyInfo,
                Value = property.Value
            };
        }

    }
}
