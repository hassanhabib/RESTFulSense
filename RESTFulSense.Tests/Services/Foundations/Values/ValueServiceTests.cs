// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System.Reflection;
using Moq;
using RESTFulSense.Brokers.Values;
using RESTFulSense.Services.Foundations.Values;

namespace RESTFulSense.Tests.Services.Foundations.Values
{
    public partial class ValueServiceTests
    {
        private readonly Mock<IValueBroker> valueBrokerMock;
        private readonly IValueService valueService;

        public ValueServiceTests()
        {
            this.valueBrokerMock = new Mock<IValueBroker>();
            this.valueService = new ValueService(this.valueBrokerMock.Object);
        }

        private static object CreateSomeObject() => new object();

        private static PropertyInfo CreateSomePropertyInfo() =>
            typeof(string).GetProperty(name: "Length");
    }
}
