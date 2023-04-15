// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using FluentAssertions;
using Moq;
using RESTFulSense.Models.Foundations.Properties.Exceptions;
using Xunit;

namespace RESTFulSense.Tests.Services.Foundations.Properties
{
    public partial class PropertyServiceTests
    {
        [Fact]
        public void ShouldThrowValidationExceptionOnRetrievePropertiesIfObjectIsNull()
        {
            // given
            object inputNullObject = CreateNullObject();

            var nullObjectException = new NullObjectException();

            var expectedPropertyValidationException =
                new PropertyValidationException(nullObjectException);

            // when
            PropertyValidationException actualPropertyValidationException =
                Assert.Throws<PropertyValidationException>(
                    () => this.propertyService.RetrieveProperties(inputNullObject));

            // then
            actualPropertyValidationException.Should()
              .BeEquivalentTo(expectedPropertyValidationException);

            this.reflectionBrokerMock.Verify(reflectionBroker =>
                reflectionBroker.GetPropertyValues(It.IsAny<object>()), Times.Never);

            this.reflectionBrokerMock.VerifyNoOtherCalls();
        }
    }
}
