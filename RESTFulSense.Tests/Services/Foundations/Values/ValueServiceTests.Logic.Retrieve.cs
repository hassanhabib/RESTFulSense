// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System.Reflection;
using FluentAssertions;
using Moq;
using Xunit;

namespace RESTFulSense.Unit.Tests.Services.Foundations.Values
{
    public partial class ValueServiceTests
    {
        [Fact]
        public void ShouldRetrievePropertyValue()
        {
            // given
            object someObject = CreateSomeObject();
            object someValue = CreateSomeObject();
            object expectedValue = someValue;
            PropertyInfo somePropertyInfo = CreateSomePropertyInfo();

            this.valueBrokerMock.Setup(broker =>
                broker.GetPropertyValue(It.IsAny<object>(), It.IsAny<PropertyInfo>()))
                    .Returns(someValue);

            // when
            object actualValue =
                this.valueService.RetrievePropertyValue(someObject, somePropertyInfo);

            // then
            actualValue.Should().Be(expectedValue);

            this.valueBrokerMock.Verify(broker =>
                broker.GetPropertyValue(It.IsAny<object>(), It.IsAny<PropertyInfo>()),
                    Times.Once());

            this.valueBrokerMock.VerifyNoOtherCalls();
        }
    }
}
