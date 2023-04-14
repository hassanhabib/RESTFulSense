// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Reflection;
using FluentAssertions;
using Moq;
using RESTFulSense.Models.Foundations.StringContents.Exceptions;
using Xunit;

namespace RESTFulSense.Tests.Services.Foundations.StringContents
{
    public partial class StringContentServiceTests
    {
        [Fact]
        public void ShouldThrowValidationExceptionOnRetrieveStringContentIfPropertyInfoIsNull()
        {
            PropertyInfo someProperty = null;

            var nullPropertyInfoException = new NullPropertyInfoException();

            var expectedStringContentValidationException =
                new StringContentValidationException(nullPropertyInfoException);

            // when
            StringContentValidationException actualStringContentValidationException =
                Assert.Throws<StringContentValidationException>(() => this.stringContentService.RetrieveStringContent(someProperty));

            // then
            actualStringContentValidationException.Should()
              .BeEquivalentTo(expectedStringContentValidationException);

            this.reflectionBrokerMock.Verify(reflectionBroker =>
                reflectionBroker.GetStringContentAttribute(It.IsAny<PropertyInfo>()), Times.Never);

            this.reflectionBrokerMock.VerifyNoOtherCalls();
        }
    }
}
