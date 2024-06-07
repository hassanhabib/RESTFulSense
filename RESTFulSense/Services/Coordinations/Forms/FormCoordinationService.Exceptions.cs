// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
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
                var message = "Form coordination validation errors occurred, please try again.";
                var formCoordinationValidationException =
                    new FormCoordinationValidationException(message, nullObjectException);

                throw formCoordinationValidationException;
            }
            catch (FormOrchestrationValidationException formOrchestrationValidationException)
            {
                var message = "Form coordination dependency validation error occurred, fix the errors and try again.";
                var formCoordinationDependencyValidationException =
                    new FormCoordinationDependencyValidationException(message, formOrchestrationValidationException);

                throw formCoordinationDependencyValidationException;
            }
            catch (FormOrchestrationDependencyValidationException formOrchestrationDependencyValidationException)
            {
                var message = "Form coordination dependency validation error occurred, fix the errors and try again.";
                var formCoordinationDependencyValidationException =
                    new FormCoordinationDependencyValidationException(message, formOrchestrationDependencyValidationException);

                throw formCoordinationDependencyValidationException;
            }
            catch (PropertyOrchestrationValidationException propertyOrchestrationValidationException)
            {
                var message = "Form coordination dependency validation error occurred, fix the errors and try again.";
                var formCoordinationDependencyValidationException =
                    new FormCoordinationDependencyValidationException(message, propertyOrchestrationValidationException);

                throw formCoordinationDependencyValidationException;
            }
            catch (PropertyOrchestrationDependencyValidationException propertyOrchestrationDependencyValidationException)
            {
                var message = "Form coordination dependency validation error occurred, fix the errors and try again.";
                var formCoordinationDependencyValidationException =
                    new FormCoordinationDependencyValidationException(message, propertyOrchestrationDependencyValidationException);

                throw formCoordinationDependencyValidationException;
            }
            catch (FormOrchestrationDependencyException formOrchestrationDependencyException)
            {
                var message = "Form coordination dependency error occurred, fix the errors and try again."; ;
                var formCoordinationDependencyException =
                    new FormCoordinationDependencyException(message,formOrchestrationDependencyException);

                throw formCoordinationDependencyException;
            }
            catch (FormOrchestrationServiceException formOrchestrationServiceException)
            {
                var message = "Form coordination dependency error occurred, fix the errors and try again."; ;
                var formCoordinationDependencyException =
                    new FormCoordinationDependencyException(message, formOrchestrationServiceException);

                throw formCoordinationDependencyException;
            }
            catch (PropertyOrchestrationDependencyException propertyOrchestrationDependencyException)
            {
                var message = "Form coordination dependency error occurred, fix the errors and try again.";
                var formCoordinationDependencyException =
                    new FormCoordinationDependencyException(message, propertyOrchestrationDependencyException);

                throw formCoordinationDependencyException;
            }
            catch (PropertyOrchestrationServiceException propertyOrchestrationServiceException)
            {
                var message = "Form coordination dependency error occurred, fix the errors and try again.";
                var formCoordinationDependencyException =
                    new FormCoordinationDependencyException(message, propertyOrchestrationServiceException);

                throw formCoordinationDependencyException;
            }
            catch (Exception exception)
            {
                var errorMessage = "Form coordination service error occurred, contact support.";
                var failedFormCoordinationServiceException =
                    new FailedFormCoordinationServiceException(errorMessage,exception);

                var formCoordinationServiceException =
                    new FormCoordinationServiceException(errorMessage, failedFormCoordinationServiceException);

                throw formCoordinationServiceException;
            }
        }
    }
}
