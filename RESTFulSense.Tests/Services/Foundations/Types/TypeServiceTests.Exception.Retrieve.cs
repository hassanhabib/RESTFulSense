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
        public void ShouldThrowDependencyValidationExceptionOnRetrieveTypeIfErrorOccurs(
            Exception dependencyValidationException)
        {
            // given
            var someObject = new object();

            var failedTypeDependencyValidationException =
                new FailedTypeDependencyValidationException(dependencyValidationException);

            var expectedTypeDependencyValidationException =
                new TypeDependencyValidationException(failedTypeDependencyValidationException);

            this.typeBrokerMock.Setup(broker =>
                broker.GetType(It.IsAny<object>()))
                    .Throws(dependencyValidationException);

            // when
            Action retrieveTypeAction = () => this.typeService.RetrieveType(someObject);

            TypeDependencyValidationException actualTypeDependencyValidationException =
                Assert.Throws<TypeDependencyValidationException>(retrieveTypeAction);

            // then
            actualTypeDependencyValidationException.Should().BeEquivalentTo(expectedTypeDependencyValidationException);

            this.typeBrokerMock.Verify(broker =>
                broker.GetType(It.IsAny<object>()),
                    Times.Once);

            this.typeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(GetDependencyExceptions))]
        public void ShouldThrowDependencyExceptionOnRetrieveTypeIfErrorOccurs(
        Exception dependencyException)
        {
            // given
            var someObject = new object();

            var failedTypeDependencyException =
                new FailedTypeDependencyException(dependencyException);

            var expectedTypeDependencyException =
                new TypeDependencyException(failedTypeDependencyException);

            this.typeBrokerMock.Setup(broker =>
                broker.GetType(It.IsAny<object>()))
                    .Throws(dependencyException);

            // when
            Action retrieveTypeAction = () => this.typeService.RetrieveType(someObject);

            TypeDependencyException actualTypeDependencyException =
                Assert.Throws<TypeDependencyException>(retrieveTypeAction);

            // then
            actualTypeDependencyException.Should().BeEquivalentTo(expectedTypeDependencyException);

            this.typeBrokerMock.Verify(broker =>
                broker.GetType(It.IsAny<object>()),
                    Times.Once);

            this.typeBrokerMock.VerifyNoOtherCalls();
        }
        
        [Fact]
        public void ShouldThrowTypeServiceExceptionIfExceptionOccurs()
        {
            // given
            var someObject = new object();
            var someException = new Exception();
            var failedTypeServiceException = new FailedTypeServiceException(someException);
            var expectedTypeServiceException = new TypeServiceException(failedTypeServiceException);

            this.typeBrokerMock.Setup(broker =>
                broker.GetType(It.IsAny<object>()))
                    .Throws(someException);

            // when
            Action retrieveTypeAction = () => this.typeService.RetrieveType(someObject);

            TypeServiceException actualTypeServiceException =
                Assert.Throws<TypeServiceException>(retrieveTypeAction);

            // then
            actualTypeServiceException.Should().BeEquivalentTo(expectedTypeServiceException);

            this.typeBrokerMock.Verify(broker =>
                broker.GetType(It.IsAny<object>()),
                    Times.Once);

            this.typeBrokerMock.VerifyNoOtherCalls();
        }
    }
}
