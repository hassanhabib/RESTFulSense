// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using RESTFulSense.Models.Foundations.Types.Exceptions;

namespace RESTFulSense.Services.Types
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
                var typeValidationException = new TypeValidationException(nullObjectException);
                throw typeValidationException;
            }
            //catch (ArgumentNullException argumentNullException)
            //{
            //    throw CreateDependencyValidationException(argumentNullException);
            //}
            //catch (MethodAccessException methodAccessException)
            //{
            //    throw CreateDependencyException(methodAccessException);
            //}
            //catch (TargetInvocationException targetInvocationException)
            //{
            //    throw CreateDependencyException(targetInvocationException);
            //}
            //catch (TypeLoadException typeLoadException)
            //{
            //    throw CreateDependencyException(typeLoadException);
            //}
            //catch (NotSupportedException notSupportedException)
            //{
            //    throw CreateDependencyException(notSupportedException);
            //}
            //catch (MissingMethodException missingMethodException)
            //{
            //    throw CreateDependencyException(missingMethodException);
            //}
            //catch (Exception exception)
            //{
            //    throw CreateServiceException(exception);
            //}
        }

        private static TypeDependencyValidationException CreateDependencyValidationException(
            Exception exception)
        {
            var failedTypeDependencyValidationException =
                                new FailedTypeDependencyValidationException(exception);

            var typeDependencyValidationException =
                new TypeDependencyValidationException(failedTypeDependencyValidationException);

            return typeDependencyValidationException;
        }

        private static TypeDependencyException CreateDependencyException(Exception exception)
        {
            var failedTypeDependencyException =
                new FailedTypeDependencyException(exception);

            var typeDependencyException =
                new TypeDependencyException(failedTypeDependencyException);

            return typeDependencyException;
        }

        private static TypeServiceException CreateServiceException(Exception exception)
        {
            var failedTypeServiceException =
                new FailedTypeServiceException(exception);

            var typeServiceException =
                new TypeServiceException(failedTypeServiceException);

            return typeServiceException;
        }
    }
}
