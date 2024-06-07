// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using System.Reflection;
using System.Security;
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
                var propertyValidationException = new PropertyValidationException(
                    message: "Property validation errors occurred, fix errors and try again.",
                    innerException: nullTypeException);
                throw propertyValidationException;
            }
            catch (ArgumentNullException argumentNullException)
            {
                throw CreateDependencyValidationException(argumentNullException);
            }
            catch (TargetException targetException)
            {
                throw CreateDependencyException(targetException);
            }
            catch (TypeLoadException typeLoadException)
            {
                throw CreateDependencyException(typeLoadException);
            }
            catch (NotSupportedException notSupportedException)
            {
                throw CreateDependencyException(notSupportedException);
            }
            catch (AmbiguousMatchException ambiguousMatchException)
            {
                throw CreateDependencyException(ambiguousMatchException);
            }
            catch (SecurityException securityException)
            {
                throw CreateDependencyException(securityException);
            }
            catch (ReflectionTypeLoadException reflectionTypeLoadException)
            {
                throw CreateDependencyException(reflectionTypeLoadException);
            }
            catch (Exception exception)
            {
                throw CreateServiceException(exception);
            }
        }

        private static PropertyDependencyValidationException CreateDependencyValidationException(
            Exception exception)
        {
            var failedPropertyDependencyValidationException =
                new FailedPropertyDependencyValidationException(
                    message: "Failed property dependency validation error occurred, fix errors and try again.", 
                    innerException: exception);

            var propertyDependencyValidationException =
                new PropertyDependencyValidationException(
                    message: "Property dependency validation occurred, fix errors and try again.",
                    innerException: failedPropertyDependencyValidationException);

            return propertyDependencyValidationException;
        }

        private static PropertyDependencyException CreateDependencyException(
            Exception exception)
        {
            var failedPropertyDependencyException =
                new FailedPropertyDependencyException(
                    message: "Property dependency error occurred, contact support.", 
                    innerException: exception);

            var propertyDependencyException =
                new PropertyDependencyException(
                    message: "Property dependency error occurred, contact support.",
                    innerException: failedPropertyDependencyException);

            return propertyDependencyException;
        }

        private static PropertyServiceException CreateServiceException(Exception exception)
        {
            var failedPropertyServiceException =
                new FailedPropertyServiceException(
                    message: "Failed Property Service Exception occurred, please contact support for assistance.", 
                    innerException: exception);

            var propertyServiceException =
                new PropertyServiceException(
                    message: "Property service error occurred, contact support.",
                    innerException: failedPropertyServiceException);
            return propertyServiceException;
        }
    }
}
