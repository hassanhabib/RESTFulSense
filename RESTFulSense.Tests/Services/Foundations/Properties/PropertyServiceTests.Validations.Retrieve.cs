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
        public void ShouldThrowValidationExceptionOnRetrieveTypeIfTypeIsNull()
        {
            // given
            Type nullType = null;

            NullTypeException nullTypeException = new NullTypeException();

            var expectedPropertyValidationException =
                new PropertyValidationException(
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
