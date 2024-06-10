// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using RESTFulSense.Models.Foundations.Attributes.Exceptions;
using RESTFulSense.Models.Foundations.Forms.Exceptions;
using RESTFulSense.Models.Foundations.Values.Exceptions;
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
                    new FormOrchestrationValidationException(
                        message: "Form orchestration validation errors occurred, please try again.",
                        innerException: nullFormModelException);

                throw formOrchestrationValidationException;
            }
            catch (AttributeValidationException attributeValidationException)
            {
                var formOrchestrationDependencyValidationException =
                    new FormOrchestrationDependencyValidationException(
                        message: "Form orchestration dependency validation error occurred, fix the errors and try again.", 
                        innerException: attributeValidationException);

                throw formOrchestrationDependencyValidationException;
            }
            catch (AttributeDependencyValidationException attributeDependencyValidationException)
            {
                var formOrchestrationDependencyValidationException =
                    new FormOrchestrationDependencyValidationException(
                        message: "Form orchestration dependency validation error occurred, fix the errors and try again.",
                        innerException: attributeDependencyValidationException);

                throw formOrchestrationDependencyValidationException;
            }
            catch (ValueValidationException valueValidationException)
            {
                var formOrchestrationDependencyValidationException =
                    new FormOrchestrationDependencyValidationException(
                        message: "Form orchestration dependency validation error occurred, fix the errors and try again.",
                        innerException: valueValidationException);

                throw formOrchestrationDependencyValidationException;
            }
            catch (ValueDependencyValidationException valueDependencyValidationException)
            {
                var formOrchestrationDependencyValidationException =
                    new FormOrchestrationDependencyValidationException(
                        message: "Form orchestration dependency validation error occurred, fix the errors and try again.",
                        innerException: valueDependencyValidationException);

                throw formOrchestrationDependencyValidationException;
            }
            catch (FormValidationException formValidationException)
            {
                var formOrchestrationDependencyValidationException =
                    new FormOrchestrationDependencyValidationException(
                        message: "Form orchestration dependency validation error occurred, fix the errors and try again.",
                        innerException: formValidationException);

                throw formOrchestrationDependencyValidationException;
            }
            catch (FormDependencyValidationException formDependencyValidationException)
            {
                var formOrchestrationDependencyValidationException =
                    new FormOrchestrationDependencyValidationException(
                        message: "Form orchestration dependency validation error occurred, fix the errors and try again.",
                        innerException: formDependencyValidationException);

                throw formOrchestrationDependencyValidationException;
            }
            catch (AttributeDependencyException attributeDependencyException)
            {
                var formOrchestrationDependencyException =
                    new FormOrchestrationDependencyException(
                        message: "Form orchestration dependency validation error occurred, fix the errors and try again.",
                        innerException: attributeDependencyException);

                throw formOrchestrationDependencyException;
            }
            catch (AttributeServiceException attributeServiceException)
            {
                var formOrchestrationDependencyException =
                    new FormOrchestrationDependencyException(
                        message: "Form orchestration dependency validation error occurred, fix the errors and try again.",
                        innerException: attributeServiceException);

                throw formOrchestrationDependencyException;
            }
            catch (ValueDependencyException valueDependencyException)
            {
                var formOrchestrationDependencyException =
                    new FormOrchestrationDependencyException(
                        message: "Form orchestration dependency validation error occurred, fix the errors and try again.",
                        innerException: valueDependencyException);

                throw formOrchestrationDependencyException;
            }
            catch (ValueServiceException valueServiceException)
            {
                var formOrchestrationDependencyException =
                    new FormOrchestrationDependencyException(
                        message: "Form orchestration dependency validation error occurred, fix the errors and try again.",
                        innerException: valueServiceException);

                throw formOrchestrationDependencyException;
            }
            catch (FormDependencyException formDependencyException)
            {
                var formOrchestrationDependencyException =
                    new FormOrchestrationDependencyException(
                        message: "Form orchestration dependency validation error occurred, fix the errors and try again.",
                        innerException: formDependencyException);

                throw formOrchestrationDependencyException;
            }
            catch (FormServiceException formServiceException)
            {
                var formOrchestrationDependencyException =
                    new FormOrchestrationDependencyException(
                        message: "Form orchestration dependency validation error occurred, fix the errors and try again.",
                        innerException: formServiceException);

                throw formOrchestrationDependencyException;
            }
            catch (Exception exception)
            {
                var failedFormOrchestrationServiceException =
                    new FailedFormOrchestrationServiceException(
                        message: "Failed form orchestration service occurred, please contact support",
                        innerException: exception);

                var formOrchestrationServiceException =
                    new FormOrchestrationServiceException(
                        message: "Form orchestration service error occurred, contact support.",
                        innerException: failedFormOrchestrationServiceException);

                throw formOrchestrationServiceException;
            }
        }
    }
}
