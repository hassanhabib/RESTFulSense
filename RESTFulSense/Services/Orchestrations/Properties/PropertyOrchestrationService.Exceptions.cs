// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using RESTFulSense.Models.Foundations.Properties.Exceptions;
using RESTFulSense.Models.Foundations.Types.Exceptions;
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
                    new PropertyOrchestrationValidationException(
                        message: "Property validation error occurred, fix errors and try again.",
                        innerException: nullPropertyModelException);

                throw propertyOrchestrationValidationException;
            }
            catch (Models.Orchestrations.Properties.Exceptions.NullObjectException nullObjectException)
            {
                var propertyOrchestrationValidationException =
                    new PropertyOrchestrationValidationException(
                        message: "Property validation error occurred, fix errors and try again.",
                        innerException: nullObjectException);

                throw propertyOrchestrationValidationException;
            }
            catch (TypeValidationException typeValidationException)
            {
                var propertyOrchestrationDependencyValidationException =
                    new PropertyOrchestrationDependencyValidationException(
                        message: "Property orchestration dependency validation error occurred, fix errors and try again.",
                        innerException: typeValidationException);

                throw propertyOrchestrationDependencyValidationException;
            }
            catch (TypeDependencyValidationException typeDependencyValidationException)
            {
                var propertyOrchestrationDependencyValidationException =
                    new PropertyOrchestrationDependencyValidationException(
                        message: "Property orchestration dependency validation error occurred, fix errors and try again.",
                        innerException: typeDependencyValidationException);

                throw propertyOrchestrationDependencyValidationException;
            }
            catch (PropertyValidationException propertyValidationException)
            {
                var propertyOrchestrationDependencyValidationException =
                    new PropertyOrchestrationDependencyValidationException(
                        message: "Property orchestration dependency validation error occurred, fix errors and try again.",
                        innerException: propertyValidationException);

                throw propertyOrchestrationDependencyValidationException;
            }
            catch (PropertyDependencyValidationException propertyDependencyValidationException)
            {
                var propertyOrchestrationDependencyValidationException =
                    new PropertyOrchestrationDependencyValidationException(
                        message: "Property orchestration dependency validation error occurred, fix errors and try again.",
                        innerException: propertyDependencyValidationException);

                throw propertyOrchestrationDependencyValidationException;
            }
            catch (TypeDependencyException typeDependencyException)
            {
                var propertyOrchestrationDependencyException =
                    new PropertyOrchestrationDependencyException(
                        message: "Property orchestration dependency error occurred, fix errors and try again.",
                        innerException: typeDependencyException);

                throw propertyOrchestrationDependencyException;
            }
            catch (TypeServiceException typeServiceException)
            {
                var propertyOrchestrationDependencyException =
                    new PropertyOrchestrationDependencyException(
                        message: "Property orchestration dependency error occurred, fix errors and try again.",
                        innerException: typeServiceException);

                throw propertyOrchestrationDependencyException;
            }
            catch (PropertyDependencyException propertyDependencyException)
            {
                var propertyOrchestrationDependencyException =
                    new PropertyOrchestrationDependencyException(
                        message: "Property orchestration dependency error occurred, fix errors and try again.",
                        innerException: propertyDependencyException);

                throw propertyOrchestrationDependencyException;
            }
            catch (PropertyServiceException propertyServiceException)
            {
                var propertyOrchestrationDependencyException =
                    new PropertyOrchestrationDependencyException(
                        message: "Property orchestration dependency error occurred, fix errors and try again.",
                        innerException: propertyServiceException);

                throw propertyOrchestrationDependencyException;
            }
            catch (Exception exception)
            {
                var failedPropertyOrchestrationException =
                    new FailedPropertyOrchestrationException(
                        message: "Failed property orchestration service exception occurred, please contact support.",
                        innerException: exception);

                var propertyPropertyOrchestrationException =
                    new PropertyOrchestrationServiceException(
                        message: "Property orchestration service error occurred, contact support.",
                        innerException: failedPropertyOrchestrationException);

                throw propertyPropertyOrchestrationException;
            }
        }
    }
}
