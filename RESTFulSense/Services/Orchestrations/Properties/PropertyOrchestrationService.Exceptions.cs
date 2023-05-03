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
                    new PropertyOrchestrationValidationException(nullPropertyModelException);

                throw propertyOrchestrationValidationException;
            }
            catch (Models.Orchestrations.Properties.Exceptions.NullObjectException nullObjectException)
            {
                var propertyOrchestrationValidationException =
                    new PropertyOrchestrationValidationException(nullObjectException);

                throw propertyOrchestrationValidationException;
            }
            catch (TypeValidationException typeValidationException)
            {
                var propertyOrchestrationDependencyValidationException =
                    new PropertyOrchestrationDependencyValidationException(typeValidationException);

                throw propertyOrchestrationDependencyValidationException;
            }
            catch (TypeDependencyValidationException typeDependencyValidationException)
            {
                var propertyOrchestrationDependencyValidationException =
                    new PropertyOrchestrationDependencyValidationException(typeDependencyValidationException);

                throw propertyOrchestrationDependencyValidationException;
            }
            catch (PropertyValidationException propertyValidationException)
            {
                var propertyOrchestrationDependencyValidationException =
                    new PropertyOrchestrationDependencyValidationException(propertyValidationException);

                throw propertyOrchestrationDependencyValidationException;
            }
            catch (PropertyDependencyValidationException propertyDependencyValidationException)
            {
                var propertyOrchestrationDependencyValidationException =
                    new PropertyOrchestrationDependencyValidationException(propertyDependencyValidationException);

                throw propertyOrchestrationDependencyValidationException;
            }
            catch (TypeDependencyException typeDependencyException)
            {
                var propertyOrchestrationDependencyException =
                    new PropertyOrchestrationDependencyException(typeDependencyException);

                throw propertyOrchestrationDependencyException;
            }
            catch (TypeServiceException typeServiceException)
            {
                var propertyOrchestrationDependencyException =
                    new PropertyOrchestrationDependencyException(typeServiceException);

                throw propertyOrchestrationDependencyException;
            }
            catch (PropertyDependencyException propertyDependencyException)
            {
                var propertyOrchestrationDependencyException =
                    new PropertyOrchestrationDependencyException(propertyDependencyException);

                throw propertyOrchestrationDependencyException;
            }
            catch (PropertyServiceException propertyServiceException)
            {
                var propertyOrchestrationDependencyException =
                    new PropertyOrchestrationDependencyException(propertyServiceException);

                throw propertyOrchestrationDependencyException;
            }
            catch (Exception exception)
            {
                var failedPropertyOrchestrationException =
                    new FailedPropertyOrchestrationException(exception);

                var propertyPropertyOrchestrationException =
                    new PropertyOrchestrationServiceException(failedPropertyOrchestrationException);

                throw propertyPropertyOrchestrationException;
            }
        }
    }
}
