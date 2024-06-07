// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using System.Reflection;
using RESTFulSense.Models.Foundations.Types.Exceptions;

namespace RESTFulSense.Services.Foundations.Types
{
    internal partial class TypeService : ITypeService
    {
        private delegate Type ReturningTypeFunction();

        private Type TryCatch(ReturningTypeFunction returningTypeFunction)
        {
            try
            {
                return returningTypeFunction();
            }
            catch (NullObjectException nullObjectException)
            {
                var typeValidationException = new TypeValidationException(
                    message: "Type validation errors occurred, fix errors and try again.",
                    innerException: nullObjectException);
                throw typeValidationException;
            }
            catch (ArgumentNullException argumentNullException)
            {
                throw CreateDependencyValidationException(argumentNullException);
            }
            catch (MethodAccessException methodAccessException)
            {
                throw CreateDependencyException(methodAccessException);
            }
            catch (TargetInvocationException targetInvocationException)
            {
                throw CreateDependencyException(targetInvocationException);
            }
            catch (TypeLoadException typeLoadException)
            {
                throw CreateDependencyException(typeLoadException);
            }
            catch (NotSupportedException notSupportedException)
            {
                throw CreateDependencyException(notSupportedException);
            }
            catch (MissingMethodException missingMethodException)
            {
                throw CreateDependencyException(missingMethodException);
            }
            catch (Exception exception)
            {
                throw CreateServiceException(exception);
            }
        }

        private static TypeDependencyValidationException CreateDependencyValidationException(
            Exception exception)
        {
            var failedTypeDependencyValidationException =
                                new FailedTypeDependencyValidationException(
                                    message: "Failed type dependency validation error occurred, fix errors and try again.",
                                    innerException: exception);

            var typeDependencyValidationException =
                new TypeDependencyValidationException(
                    message: "Type dependency validation occurred, fix errors and try again.", 
                    innerException: failedTypeDependencyValidationException);

            return typeDependencyValidationException;
        }

        private static TypeDependencyException CreateDependencyException(Exception exception)
        {
            var failedTypeDependencyException =
                new FailedTypeDependencyException(
                    message: "Type dependency error occurred, contact support.",
                    innerException: exception);

            var typeDependencyException =
                new TypeDependencyException(
                    message: "Type dependency error occurred, contact support.",
                    innerException: failedTypeDependencyException);

            return typeDependencyException;
        }

        private static TypeServiceException CreateServiceException(Exception exception)
        {
            var failedTypeServiceException =
                new FailedTypeServiceException(
                    message: "Failed Type Service Exception occurred, please contact support for assistance.",
                    innerException: exception);

            var typeServiceException =
                new TypeServiceException(
                    message: "Type service error occurred, contact support.",
                    innerException : failedTypeServiceException);

            return typeServiceException;
        }
    }
}
