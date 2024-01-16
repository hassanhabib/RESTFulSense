// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using FluentAssertions;
using RESTFulSense.Models.Coordinations.Forms.Exceptions;
using Xunit;

namespace RESTFulSense.Tests.Services.Coordinations.Forms
{
    public partial class FormCoordinationServiceTests
    {
        [Fact]
        private void ShouldThrowValidationExceptionOnConvertIfModelIsInvalid()
        {
            // given
            object nullObject = null;
            var nullObjectException = new NullObjectException();

            var expectedFormCoordinationValidationException =
                new FormCoordinationValidationException(
                    message: "Form coordination validation errors occurred, please try again.",
                    innerException: nullObjectException);

            // when
            Action convertToMultipartFormDataContentAction = () =>
                formCoordinationService.ConvertToMultipartFormDataContent(nullObject);

            FormCoordinationValidationException actualFormCoordinationValidationException =
                Assert.Throws<FormCoordinationValidationException>(convertToMultipartFormDataContentAction);

            // then
            actualFormCoordinationValidationException.Should()
                .BeEquivalentTo(expectedFormCoordinationValidationException);

            propertyOrchestrationServiceMock.VerifyNoOtherCalls();
            formOrchestrationServiceMock.VerifyNoOtherCalls();
        }
    }
}
