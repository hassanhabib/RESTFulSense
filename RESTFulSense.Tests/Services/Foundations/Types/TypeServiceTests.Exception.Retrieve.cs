// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using FluentAssertions;
using Moq;
using RESTFulSense.Models.Foundations.Types.Exceptions;
using Xunit;

namespace RESTFulSense.Tests.Services.Foundations.Types
{
    public partial class TypeServiceTests
    {
        [Theory]
        [MemberData(nameof(GetDependencyValidationExceptions))]
        private void ShouldThrowDependencyValidationExceptionOnRetrieveTypeIfErrorOccurs(
            Exception dependencyValidationException)
        {
            // given
            var someObject = new object();

            var failedTypeDependencyValidationException =
                new FailedTypeDependencyValidationException(
                    message: "Failed type dependency validation error occurred, fix errors and try again.",
                    innerException: dependencyValidationException);

            var expectedTypeDependencyValidationException =
                new TypeDependencyValidationException(
                    message: "Type dependency validation occurred, fix errors and try again.",
                    innerException: failedTypeDependencyValidationException);

            this.typeBrokerMock.Setup(broker =>
                broker.GetType(It.IsAny<object>()))
                    .Throws(dependencyValidationException);

            // when
            Action retrieveTypeAction = () =>
                this.typeService.RetrieveType(someObject);

            TypeDependencyValidationException actualTypeDependencyValidationException =
                Assert.Throws<TypeDependencyValidationException>(retrieveTypeAction);

            // then
            actualTypeDependencyValidationException.Should().BeEquivalentTo(
                expectedTypeDependencyValidationException);

            this.typeBrokerMock.Verify(broker =>
                broker.GetType(It.IsAny<object>()),
                    Times.Once);

            this.typeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(GetDependencyExceptions))]
        private void ShouldThrowDependencyExceptionOnRetrieveTypeIfErrorOccurs(
        Exception dependencyException)
        {
            // given
            var someObject = new object();

            var failedTypeDependencyException =
                new FailedTypeDependencyException(
                    message: "Type dependency error occurred, contact support.",
                    innerException: dependencyException);

            var expectedTypeDependencyException =
                new TypeDependencyException(
                    message: "Type dependency error occurred, contact support.",
                    innerException: failedTypeDependencyException);

            this.typeBrokerMock.Setup(broker =>
                broker.GetType(It.IsAny<object>()))
                    .Throws(dependencyException);

            // when
            Action retrieveTypeAction = () =>
                this.typeService.RetrieveType(someObject);

            TypeDependencyException actualTypeDependencyException =
                Assert.Throws<TypeDependencyException>(retrieveTypeAction);

            // then
            actualTypeDependencyException.Should().BeEquivalentTo(
                expectedTypeDependencyException);

            this.typeBrokerMock.Verify(broker =>
                broker.GetType(It.IsAny<object>()),
                    Times.Once);

            this.typeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        private void ShouldThrowTypeServiceExceptionIfExceptionOccurs()
        {
            // given
            var someObject = new object();
            var someException = new Exception();

            var failedTypeServiceException =
                new FailedTypeServiceException(
                    message: "Failed Type Service Exception occurred, please contact support for assistance.",
                    innerException: someException);

            var expectedTypeServiceException =
                new TypeServiceException(
                    message: "Type service error occurred, contact support.",
                    innerException: failedTypeServiceException);

            this.typeBrokerMock.Setup(broker =>
                broker.GetType(It.IsAny<object>()))
                    .Throws(someException);

            // when
            Action retrieveTypeAction = () =>
                this.typeService.RetrieveType(someObject);

            TypeServiceException actualTypeServiceException =
                Assert.Throws<TypeServiceException>(retrieveTypeAction);

            // then
            actualTypeServiceException.Should().BeEquivalentTo(
                expectedTypeServiceException);

            this.typeBrokerMock.Verify(broker =>
                broker.GetType(It.IsAny<object>()),
                    Times.Once);

            this.typeBrokerMock.VerifyNoOtherCalls();
        }
    }
}
