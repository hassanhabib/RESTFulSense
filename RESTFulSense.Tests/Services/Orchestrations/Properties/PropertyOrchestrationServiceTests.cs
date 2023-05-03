using System.Linq;
using System.Reflection;
using Moq;
using RESTFulSense.Models.Orchestrations.Properties;
using RESTFulSense.Services.Foundations.Properties;
using RESTFulSense.Services.Foundations.Types;
using RESTFulSense.Services.Orchestrations.Properties;
using Tynamix.ObjectFiller;

namespace RESTFulSense.Tests.Services.Orchestrations.Properties
{
    public partial class PropertyOrchestrationServiceTests
    {
        private readonly Mock<ITypeService> typeServiceMock;
        private readonly Mock<IPropertyService> propertyServiceMock;
        private readonly IPropertyOrchestrationService propertyOrchestrationService;

        public PropertyOrchestrationServiceTests()
        {
            this.typeServiceMock = new Mock<ITypeService>(MockBehavior.Strict);
            this.propertyServiceMock = new Mock<IPropertyService>(MockBehavior.Strict);

            this.propertyOrchestrationService =
                new PropertyOrchestrationService(this.typeServiceMock.Object, this.propertyServiceMock.Object);
        }

        private static int GetRandomNumber()
            => new IntRange(min: 2, max: 10).GetValue();

        private static PropertyModel CreateSomePropertyModel(object inputObject)
        {
            return new PropertyModel
            {
                Object = inputObject,
            };
        }

        private static PropertyInfo[] CreateRandomProperties()
        {
            int randomPropertyCount = GetRandomNumber();

            PropertyInfo[] properties = Enumerable.Range(start: 0, count: randomPropertyCount)
                .Select(i => new Mock<PropertyInfo>().Object)
                    .ToArray();

            return properties;
        }
    }
}
