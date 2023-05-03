// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using RESTFulSense.Models.Orchestrations.Properties;
using RESTFulSense.Models.Orchestrations.Properties.Exceptions;

namespace RESTFulSense.Services.Orchestrations.Properties
{
    internal partial class PropertyOrchestrationService
    {
        private delegate PropertyModel ReturningPropertyModelFunction();

        private PropertyModel TryCatch(ReturningPropertyModelFunction returningPropertyModelFunction)
        {
            try
            {
                return returningPropertyModelFunction();
            }
            catch (NullPropertyModelException nullPropertyModelException)
            {
                var propertyOrchestrationValidationException =
                    new PropertyOrchestrationValidationException(nullPropertyModelException);

                throw propertyOrchestrationValidationException;
            }
        }
    }
}
