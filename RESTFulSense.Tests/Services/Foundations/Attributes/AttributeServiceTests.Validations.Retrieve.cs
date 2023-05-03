// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using System.Reflection;
using FluentAssertions;
using Moq;
using RESTFulSense.Models.Foundations.Attributes.Exceptions;
using Xunit;

namespace RESTFulSense.Tests.Services.Foundations.Attributes
{
    public partial class AttributeServiceTests
    {
        [Fact]
        public void ShouldThrowValidationExceptionOnRetrieveIfPropertyInfoIsNull()
        {
            // given
            PropertyInfo nullPropertyInfo = CreateNullPropertyInfo();

            var argumentNullException = new ArgumentNullException();

            var nullPropertyInfoException =
                new NullPropertyInfoException(argumentNullException);

            var expectedAttributeValidationException =
                new AttributeValidationException(nullPropertyInfoException);

            // when
            Action retrieveAttributeAction =
                () => this.attributeService.RetrieveAttribute<TestAttribute>(nullPropertyInfo);

            var actualAttributeValidationException =
                  Assert.Throws<AttributeValidationException>(retrieveAttributeAction);

            // then
            actualAttributeValidationException.Should().BeEquivalentTo(expectedAttributeValidationException);

            this.attributeBrokerMock.Verify(broker =>
                broker.GetPropertyCustomAttribute<TestAttribute>(It.IsAny<PropertyInfo>(), It.IsAny<bool>()),
                    Times.Never());

            this.attributeBrokerMock.VerifyNoOtherCalls();
        }
    }
}
