// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using System.Reflection;
using FluentAssertions;
using Moq;
using RESTFulSense.Models.Foundations.Attributes.Exceptions;
using RESTFulSense.Models.Foundations.Properties.Exceptions;
using Xunit;

namespace RESTFulSense.Tests.Services.Foundations.Attributes
{
    public partial class AttributeServiceTests
    {
        [Fact]
        public void ShouldThrowAttributeServiceExceptionIfExceptionOccurs()
        {
            // given
            PropertyInfo somelPropertyInfo = CreateSomePropertyInfo();

            var someException = new Exception();

            var failedAttributeServiceException =
                new FailedAttributeServiceException(someException);

            var expectedAttributeServiceException =
                new AttributeServiceException(failedAttributeServiceException);

            this.attributeBrokerMock.Setup(broker =>
                broker.GetPropertyCustomAttribute<TestAttribute>(It.IsAny<PropertyInfo>(), It.IsAny<bool>()))
                    .Throws(someException);

            // when
            Action retrieveAttributeAction =
                () => this.attributeService.RetrieveAttribute<TestAttribute>(somelPropertyInfo);

            AttributeServiceException actualAttributeServiceException =
                  Assert.Throws<AttributeServiceException>(retrieveAttributeAction);

            // then
            actualAttributeServiceException.Should().BeEquivalentTo(expectedAttributeServiceException);

            this.attributeBrokerMock.Verify(broker =>
                broker.GetPropertyCustomAttribute<TestAttribute>(It.IsAny<PropertyInfo>(), It.IsAny<bool>()),
                    Times.Once());

            this.attributeBrokerMock.VerifyNoOtherCalls();
        }
    }
}
