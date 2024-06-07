// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using System.Reflection;
using RESTFulSense.Models.Foundations.Attributes.Exceptions;
using RESTFulSense.Models.Foundations.Properties.Exceptions;

namespace RESTFulSense.Services.Foundations.Attributes
{
    internal partial class AttributeService : IAttributeService
    {
        private delegate TAttribute ReturningAttributeFunction<TAttribute>()
            where TAttribute : Attribute;

        private TAttribute TryCatch<TAttribute>(ReturningAttributeFunction<TAttribute> returningAttributeFunction)
            where TAttribute : Attribute
        {
            try
            {
                return returningAttributeFunction();
            }
            catch (ArgumentNullException argumentNullException)
            {
                var nullPropertyInfoException =
                    new NullPropertyInfoException(
                        message: "PropertyInfo is null, fix errors and try again.",
                        innerException:argumentNullException);

                var attributeValidationException =
                    new AttributeValidationException(
                        message: "Attribute validation error occurred, fix errors and try again.",
                        innerException: nullPropertyInfoException);

                throw attributeValidationException;
            }
            catch (NotSupportedException notSupportedException)
            {
                var failedAttributeServiceException =
                    new FailedAttributeServiceException(
                        message: "Failed Attribute Service Exception occurred, please contact support for assistance.",
                        innerException:notSupportedException);

                var attributeDependencyValidationException =
                    new AttributeDependencyValidationException(
                        message: "Attribute dependency validation error occurred, fix errors and try again.",
                        innerException:failedAttributeServiceException);

                throw attributeDependencyValidationException;
            }
            catch (AmbiguousMatchException ambiguousMatchException)
            {
                var failedAttributeServiceException =
                    new FailedAttributeServiceException(
                        message: "Failed Attribute Service Exception occurred, please contact support for assistance.",
                        innerException: ambiguousMatchException);

                var attributeDependencyValidationException =
                    new AttributeDependencyValidationException(
                        message: "Attribute dependency validation error occurred, fix errors and try again.",
                        innerException: failedAttributeServiceException);

                throw attributeDependencyValidationException;
            }
            catch (TypeLoadException typeLoadException)
            {
                var failedAttributeServiceException =
                    new FailedAttributeServiceException(
                        message: "Failed Attribute Service Exception occurred, please contact support for assistance.",
                        innerException: typeLoadException);

                var attributeDependencyValidationException =
                    new AttributeDependencyValidationException(
                        message: "Attribute dependency validation error occurred, fix errors and try again.",
                    innerException: failedAttributeServiceException); 

                throw attributeDependencyValidationException;
            }
            catch (Exception exception)
            {
                var failedAttributeServiceException =
                    new FailedAttributeServiceException(
                        message: "Failed Attribute Service Exception occurred, please contact support for assistance.",
                        innerException: exception);

                var attributeServiceException =
                    new AttributeServiceException(
                        message: "Attribute service error occurred, contact support.",
                        innerException: failedAttributeServiceException);

                throw attributeServiceException;
            }
        }
    }
}
