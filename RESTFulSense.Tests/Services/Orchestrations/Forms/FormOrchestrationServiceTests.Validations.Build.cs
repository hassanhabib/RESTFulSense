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
        public void ShouldThrowValidationExceptionOnBuildFormModelIfModelIsInvalid()
        {
            // given
            FormModel nullFormModel = null;

            var nullFormModelException = new NullFormModelException();

            var expectedFormOrchestrationValidationException =
                new FormOrchestrationValidationException(nullFormModelException);

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
