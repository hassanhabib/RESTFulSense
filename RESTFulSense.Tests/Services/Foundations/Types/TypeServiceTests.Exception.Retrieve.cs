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
    }
}
