// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using FluentAssertions;
using Moq;
using RESTFulSense.Models.Foundations.StreamContents.Exceptions;
using System.Reflection;
using Xunit;

namespace RESTFulSense.Tests.Services.Foundations.StreamContents
{
    public partial class StreamContentServiceTests
    {
        [Fact]
        public void ShouldThrowValidationExceptionOnRetrieveStreamContentIfPropertyInfoIsNull()
        {
            PropertyInfo someProperty = null;

            var nullPropertyInfoException = new NullPropertyInfoException();

            var expectedStreamContentValidationException =
                new StreamContentValidationException(nullPropertyInfoException);

            // when
            StreamContentValidationException actualStreamContentValidationException =
                Assert.Throws<StreamContentValidationException>(() => this.streamContentService.RetrieveStreamContent(someProperty));

            // then
            actualStreamContentValidationException.Should()
              .BeEquivalentTo(expectedStreamContentValidationException);

            this.reflectionBrokerMock.Verify(reflectionBroker =>
                reflectionBroker.GetFileContentStreamAttribute(It.IsAny<PropertyInfo>()), Times.Never);

            this.reflectionBrokerMock.VerifyNoOtherCalls();
        }
    }
}
