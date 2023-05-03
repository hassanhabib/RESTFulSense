// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System.Linq;
using System.Reflection;
using Moq;
using RESTFulSense.Brokers.Properties;
using RESTFulSense.Services.Foundations.Properties;
using RESTFulSense.Services.Properties;
using Tynamix.ObjectFiller;

namespace RESTFulSense.Tests.Services.Properties
{
    public partial class PropertyServiceTests
    {
        private readonly Mock<IPropertyBroker> propertyBrokerMock;
        private readonly IPropertyService propertyService;

        public PropertyServiceTests()
        {
            this.propertyBrokerMock = new Mock<IPropertyBroker>();
            this.propertyService = new PropertyService(this.propertyBrokerMock.Object);
        }

        private static PropertyInfo[] CreateRandomProperties()
        {
            int randomPropertyCount = GetRandomNumber();

            PropertyInfo[] properties = Enumerable.Range(start: 0, count: randomPropertyCount)
                .Select(i => new Mock<PropertyInfo>().Object)
                    .ToArray();

            return properties;
        }

        private static int GetRandomNumber() =>
            new IntRange(min: 2, max: 10).GetValue();
    }
}
