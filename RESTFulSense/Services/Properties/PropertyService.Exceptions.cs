// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using System.Reflection;
using RESTFulSense.Models.Foundations.Properties.Exceptions;

namespace RESTFulSense.Services.Properties
{
    internal partial class PropertyService
    {
        private delegate PropertyInfo[] ReturningPropertiesFunction();

        private PropertyInfo[] TryCatch(ReturningPropertiesFunction returningPropertiesFunction)
        {
            try
            {
                return returningPropertiesFunction();
            }
            catch (NullTypeException nullTypeException)
            {
                var propertyValidationException = new PropertyValidationException(nullTypeException);
                throw propertyValidationException;
            }
        }

        private static PropertyDependencyValidationException CreateDependencyValidationException(
            Exception exception)
        {
            var failedPropertyDependencyValidationException =
                new FailedPropertyDependencyValidationException(exception);

            var propertyDependencyValidationException =
                new PropertyDependencyValidationException(failedPropertyDependencyValidationException);

            return propertyDependencyValidationException;
        }

        private static PropertyDependencyException CreateDependencyException(
            Exception exception)
        {
            var failedPropertyDependencyException =
                new FailedPropertyDependencyException(exception);

            var propertyDependencyException =
                new PropertyDependencyException(failedPropertyDependencyException);

            return propertyDependencyException;
        }

        private static PropertyServiceException CreateServiceException(Exception exception)
        {
            var failedPropertyServiceException =
                new FailedPropertyServiceException(exception);

            var propertyServiceException =
                new PropertyServiceException(failedPropertyServiceException);
            return propertyServiceException;
        }
    }
}
