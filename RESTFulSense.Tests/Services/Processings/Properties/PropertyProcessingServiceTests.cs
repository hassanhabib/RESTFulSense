// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Moq;
using RESTFulSense.Models.Foundations.Properties;
using RESTFulSense.Services.Foundations.Properties;
using RESTFulSense.Services.Processings.Properties;
using Tynamix.ObjectFiller;

namespace RESTFulSense.Tests.Services.Processings
{
    public partial class PropertyProcessingServiceTests
    {
        private readonly Mock<IPropertyService> propertyServiceMock;
        private readonly IPropertyProcessingService propertyProcessingService;

        public PropertyProcessingServiceTests()
        {
            this.propertyServiceMock = new Mock<IPropertyService>();
            this.propertyProcessingService =
                new PropertyProcessingService(propertyServiceMock.Object);
        }

        private static object CreateSomeObject() => new Object();

        private static int GetRandomNumber() =>
            new IntRange(min: 2, max: 10).GetValue();

        private static IEnumerable<PropertyValue> CreateRandomPropertyValues() =>
            Enumerable.Range(start: 0, count: GetRandomNumber())
                .Select(_ => CreatePropertyValueFiller().Create())
                    .ToList();

        private static PropertyValue CreateRandomPropertyValue() =>
            CreatePropertyValueFiller().Create();

        private static Filler<PropertyValue> CreatePropertyValueFiller()
        {
            var filler = new Filler<PropertyValue>();

            filler.Setup()
                .OnType<PropertyInfo>().Use(CreateMockPropertyInfo())
                .OnType<object>().Use(CreateSomeObject());

            return filler;
        }

        private static PropertyInfo CreateMockPropertyInfo() => new Mock<PropertyInfo>().Object;
    }
}
