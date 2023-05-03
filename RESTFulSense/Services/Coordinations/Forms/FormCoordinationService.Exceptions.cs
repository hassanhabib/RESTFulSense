// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System.Net.Http;
using RESTFulSense.Models.Coordinations.Forms.Exceptions;
using RESTFulSense.Models.Orchestrations.Forms.Exceptions;
using RESTFulSense.Models.Orchestrations.Properties.Exceptions;

namespace RESTFulSense.Services.Coordinations.Forms
{
    internal partial class FormCoordinationService
    {
        private delegate MultipartFormDataContent ReturningMultipartFormDataContentFunction();

        private MultipartFormDataContent TryCatch(ReturningMultipartFormDataContentFunction
            returningMultipartFormDataContentFunction)
        {
            try
            {
                return returningMultipartFormDataContentFunction();
            }
            catch (Models.Coordinations.Forms.Exceptions.NullObjectException nullObjectException)
            {
                var formCoordinationValidationException =
                    new FormCoordinationValidationException(nullObjectException);

                throw formCoordinationValidationException;
            }
            catch (FormOrchestrationValidationException formOrchestrationValidationException)
            {
                var formCoordinationDependencyValidationException =
                    new FormCoordinationDependencyValidationException(formOrchestrationValidationException);

                throw formCoordinationDependencyValidationException;
            }
            catch (FormOrchestrationDependencyValidationException formOrchestrationDependencyValidationException)
            {
                var formCoordinationDependencyValidationException =
                    new FormCoordinationDependencyValidationException(formOrchestrationDependencyValidationException);

                throw formCoordinationDependencyValidationException;
            }
            catch (PropertyOrchestrationValidationException propertyOrchestrationValidationException)
            {
                var formCoordinationDependencyValidationException =
                    new FormCoordinationDependencyValidationException(propertyOrchestrationValidationException);

                throw formCoordinationDependencyValidationException;
            }
            catch (PropertyOrchestrationDependencyValidationException propertyOrchestrationDependencyValidationException)
            {
                var formCoordinationDependencyValidationException =
                    new FormCoordinationDependencyValidationException(propertyOrchestrationDependencyValidationException);

                throw formCoordinationDependencyValidationException;
            }
        }
    }
}
