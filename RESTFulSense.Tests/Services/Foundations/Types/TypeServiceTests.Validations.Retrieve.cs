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
        [Fact]
        private void ShouldThrowValidationExceptionOnRetrieveTypeIfTypeIsNull()
        {
            // given
            object nullObject = null;
            object inputObject = nullObject;

            NullObjectException nullObjectException =
                new NullObjectException(
                    message: "Object is null.");

            var expectedTypeValidationException =
                new TypeValidationException(
                    message: "Type validation errors occurred, fix errors and try again.",
                    innerException: nullObjectException);

            // when
            Action retrieveTypeAction = () =>
                this.typeService.RetrieveType(inputObject);

            TypeValidationException actualTypeValidationException =
                Assert.Throws<TypeValidationException>(retrieveTypeAction);

            // then
            actualTypeValidationException.Should().BeEquivalentTo(
                expectedTypeValidationException);

            this.typeBrokerMock.Verify(broker =>
                broker.GetType(inputObject),
                    Times.Never());

            this.typeBrokerMock.VerifyNoOtherCalls();
        }
    }
}
