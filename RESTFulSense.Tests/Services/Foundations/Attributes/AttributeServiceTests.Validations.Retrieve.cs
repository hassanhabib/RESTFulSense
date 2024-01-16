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
        private void ShouldThrowValidationExceptionOnRetrieveIfPropertyInfoIsNull()
        {
            // given
            PropertyInfo nullPropertyInfo = CreateNullPropertyInfo();

            var argumentNullException = new ArgumentNullException();

            var nullPropertyInfoException =
                new NullPropertyInfoException(
                    message: "PropertyInfo is null, fix errors and try again.",
                    innerException: argumentNullException);

            var expectedAttributeValidationException =
                new AttributeValidationException(
                    message: "Attribute validation error occurred, fix errors and try again.",
                    innerException: nullPropertyInfoException);

            // when
            Action retrieveAttributeAction =
                () => this.attributeService.RetrieveAttribute<TestAttribute>(nullPropertyInfo);

            var actualAttributeValidationException =
                  Assert.Throws<AttributeValidationException>(retrieveAttributeAction);

            // then
            actualAttributeValidationException.Should().BeEquivalentTo(
                expectedAttributeValidationException);

            this.attributeBrokerMock.Verify(broker =>
                broker.GetPropertyCustomAttribute<TestAttribute>(
                    It.IsAny<PropertyInfo>(),
                    It.IsAny<bool>()),
                    Times.Never());

            this.attributeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(GetCustomAttributeExceptions))]
        private void ShouldThrowDependencyValidationExceptionOnRetrieveIfDependencyValidationExceptionErrorOccurs(
         Exception dependencyValidationException)
        {
            // given
            PropertyInfo somePropertyInfo = CreateSomePropertyInfo();

            var failedAttributeServiceException =
                new FailedAttributeServiceException(
                    message: "Failed Attribute Service Exception occurred, please contact support for assistance.",
                    innerException: dependencyValidationException);

            var expectedAttributeDependencyValidationException =
                new AttributeDependencyValidationException(
                    message: "Attribute dependency validation error occurred, fix errors and try again.",
                    innerException: failedAttributeServiceException);

            this.attributeBrokerMock.Setup(broker =>
                broker.GetPropertyCustomAttribute<TestAttribute>(
                    It.IsAny<PropertyInfo>(),
                    It.IsAny<bool>()))
                    .Throws(dependencyValidationException);

            // when
            Action retrieveAttributeAction =
                () => this.attributeService.RetrieveAttribute<TestAttribute>(somePropertyInfo);

            AttributeDependencyValidationException actualAttributeDependencyValidationException =
                  Assert.Throws<AttributeDependencyValidationException>(retrieveAttributeAction);

            // then
            actualAttributeDependencyValidationException.Should()
                .BeEquivalentTo(expectedAttributeDependencyValidationException);

            this.attributeBrokerMock.Verify(broker =>
                broker.GetPropertyCustomAttribute<TestAttribute>(
                    It.IsAny<PropertyInfo>(),
                    It.IsAny<bool>()),
                    Times.Once());

            this.attributeBrokerMock.VerifyNoOtherCalls();
        }
    }
}
