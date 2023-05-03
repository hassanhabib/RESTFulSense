// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using System.Reflection;
using FluentAssertions;
using Moq;
using RESTFulSense.Models.Foundations.Values.Exceptions;
using Xunit;

namespace RESTFulSense.Tests.Services.Foundations.Values
{
    public partial class ValueServiceTests
    {
        [Fact]
        public void ShouldThrowValueServiceExceptionIfExceptionOccurs()
        {
            // given
            object someObject = CreateSomeObject();
            PropertyInfo somePropertyInfo = CreateSomePropertyInfo();
            var someException = new Exception();

            var failedFailedValueServiceException =
                new FailedValueServiceException(someException);

            var expectedValueServiceException =
                new ValueServiceException(failedFailedValueServiceException);

            this.valueBrokerMock.Setup(broker =>
                broker.GetPropertyValue(It.IsAny<object>(), It.IsAny<PropertyInfo>()))
                    .Throws(someException);

            // when
            Action retrieveTypeAction = () =>
                this.valueService.RetrievePropertyValue(someObject, somePropertyInfo);

            ValueServiceException actualValueServiceException =
                Assert.Throws<ValueServiceException>(retrieveTypeAction);

            // then
            actualValueServiceException.Should().BeEquivalentTo(expectedValueServiceException);

            this.valueBrokerMock.Verify(broker =>
                broker.GetPropertyValue(It.IsAny<object>(), It.IsAny<PropertyInfo>()),
                    Times.Once());

            this.valueBrokerMock.VerifyNoOtherCalls();
        }
    }
}
