// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using FluentAssertions;
using Moq;
using Xunit;

namespace RESTFulSense.Tests.Services.Foundations.Types
{
    public partial class TypeServiceTests
    {
        [Theory]
        [MemberData(nameof(TestData))]
        public void ShouldRetrieveType(Type expectedType)
        {
            // given
            object someObject = new object();
            object inputObject = someObject;

            this.typeBrokerMock.Setup(broker =>
                broker.GetType(inputObject))
                    .Returns(expectedType);

            // when
            Type actualType = this.typeService.RetrieveType(inputObject);

            // then
            actualType.Should().Be(expectedType);

            this.typeBrokerMock.Verify(broker =>
                broker.GetType(inputObject),
                    Times.Once());

            this.typeBrokerMock.VerifyNoOtherCalls();
        }
    }
}
