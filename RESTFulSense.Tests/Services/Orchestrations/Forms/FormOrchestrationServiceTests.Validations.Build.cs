// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using FluentAssertions;
using RESTFulSense.Models.Orchestrations.Forms;
using RESTFulSense.Models.Orchestrations.Forms.Exceptions;
using Xunit;

namespace RESTFulSense.Tests.Services.Orchestrations.Forms
{
    public partial class FormOrchestrationServiceTests
    {
        [Fact]
        private void ShouldThrowValidationExceptionOnBuildFormModelIfModelIsInvalid()
        {
            // given
            FormModel nullFormModel = null;

            var nullFormModelException =
                new NullFormModelException(
                    message: "Form model is null. Please correct the errors and try again.");

            var expectedFormOrchestrationValidationException =
                new FormOrchestrationValidationException(
                    message: "Form orchestration validation errors occurred, please try again.",
                innerException: nullFormModelException);

            // when
            Action buildFormModelAction = () =>
                formOrchestrationService.BuildFormModel(nullFormModel);

            FormOrchestrationValidationException actualFormOrchestrationValidationException =
                Assert.Throws<FormOrchestrationValidationException>(buildFormModelAction);

            // then
            actualFormOrchestrationValidationException.Should()
                .BeEquivalentTo(expectedFormOrchestrationValidationException);

            attributeServiceMock.VerifyNoOtherCalls();
            valueServiceMock.VerifyNoOtherCalls();
            formServiceMock.VerifyNoOtherCalls();
        }
    }
}
