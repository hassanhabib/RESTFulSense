// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using FluentAssertions;
using RESTFulSense.Models.Foundations.Properties.Exceptions;
using Xunit;

namespace RESTFulSense.Tests.Services.Properties
{
    public partial class PropertyServiceTests
    {
        [Fact]
        private void ShouldThrowValidationExceptionOnRetrieveTypeIfTypeIsNull()
        {
            // given
            Type nullType = null;

            NullTypeException nullTypeException =
                new NullTypeException(
                    message: "Type is null.");

            var expectedPropertyValidationException =
                new PropertyValidationException(
                    message: "Property validation errors occurred, fix errors and try again.",
                    innerException: nullTypeException);

            // when
            Action retrievePropertiesAction = () =>
                this.propertyService.RetrieveProperties(nullType);

            PropertyValidationException actualPropertyValidationException =
                Assert.Throws<PropertyValidationException>(retrievePropertiesAction);

            // then
            actualPropertyValidationException.Should()
                .BeEquivalentTo(expectedPropertyValidationException);

            this.propertyBrokerMock.VerifyNoOtherCalls();
        }
    }
}
