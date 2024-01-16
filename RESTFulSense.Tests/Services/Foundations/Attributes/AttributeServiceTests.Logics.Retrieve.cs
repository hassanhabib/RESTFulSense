// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System.Reflection;
using FluentAssertions;
using Moq;
using Xunit;

namespace RESTFulSense.Tests.Services.Foundations.Attributes
{
    public partial class AttributeServiceTests
    {
        [Fact]
        private void ShouldRetrieveAttribute()
        {
            // given
            PropertyInfo somePropertyInfo = CreateSomePropertyInfo();
            TestAttribute someAttribute = new TestAttribute();
            TestAttribute expectedSomeAttribute = someAttribute;

            this.attributeBrokerMock.Setup(broker =>
                broker.GetPropertyCustomAttribute<TestAttribute>(
                    It.IsAny<PropertyInfo>(),
                    It.IsAny<bool>()))
                    .Returns(someAttribute);

            // when
            TestAttribute actualSomeAttribute =
                this.attributeService.RetrieveAttribute<TestAttribute>(somePropertyInfo);

            // then
            actualSomeAttribute.Should().BeSameAs(expectedSomeAttribute);

            this.attributeBrokerMock.Verify(broker =>
                broker.GetPropertyCustomAttribute<TestAttribute>(
                    It.IsAny<PropertyInfo>(),
                    It.IsAny<bool>()),
                    Times.Once());

            this.attributeBrokerMock.VerifyNoOtherCalls();
        }
    }
}
