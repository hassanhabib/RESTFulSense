// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Moq;
using RESTFulSense.Brokers.Reflections;
using RESTFulSense.Models.Foundations.PropertyValues;
using RESTFulSense.Services.Foundations.Properties;
using Tynamix.ObjectFiller;

namespace RESTFulSense.Tests.Services.Foundations.Properties
{
    public partial class PropertyServiceTests
    {
        private readonly Mock<IReflectionBroker> reflectionBrokerMock;
        private readonly IPropertyService propertyService;

        public PropertyServiceTests()
        {
            reflectionBrokerMock = new Mock<IReflectionBroker>();
            propertyService = new PropertyService(reflectionBrokerMock.Object);
        }

        private List<PropertyValue> GetRandomProperties() =>
            Enumerable.Range(start: 0, count: GetRandomNumber())
                .Select(i => CreateRandomPropertyValue())
                .ToList();

        private PropertyValue CreateRandomPropertyValue() =>
            new PropertyValue { PropertyInfo = It.IsAny<PropertyInfo>(), Value = CreateRandomString() };

        private static string CreateRandomString() =>
            new MnemonicString().GetValue();

        private static int GetRandomNumber() =>
            new IntRange(min: 2, max: 10).GetValue();
    }
}
