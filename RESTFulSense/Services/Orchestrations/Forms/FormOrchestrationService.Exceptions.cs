// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using RESTFulSense.Models.Orchestrations.Forms;
using RESTFulSense.Models.Orchestrations.Forms.Exceptions;

namespace RESTFulSense.Services.Orchestrations.Forms
{
    internal partial class FormOrchestrationService
    {
        private delegate FormModel ReturningFormModelFunction();

        private FormModel TryCatch(ReturningFormModelFunction returningFormModelFunction)
        {
            try
            {
                return returningFormModelFunction();
            }
            catch (NullFormModelException nullFormModelException)
            {
                var formOrchestrationValidationException =
                    new FormOrchestrationValidationException(nullFormModelException);

                throw formOrchestrationValidationException;
            }
        }
    }
}
