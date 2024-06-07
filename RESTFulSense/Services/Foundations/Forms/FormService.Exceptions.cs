// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using System.Net.Http;
using RESTFulSense.Models.Foundations.Forms.Exceptions;
using Xeptions;

namespace RESTFulSense.Services.Foundations.Forms
{
    internal partial class FormService : IFormService
    {
        private delegate MultipartFormDataContent ReturningMultipartFormDataContentFunction();

        private MultipartFormDataContent TryCatch(
            ReturningMultipartFormDataContentFunction returningMultipartFormDataContentFunction)
        {
            try
            {
                return returningMultipartFormDataContentFunction();
            }
            catch (InvalidFormArgumentException invalidFormArgumentException)
            {
                var formValidationException =
                    new FormValidationException(
                        message: "Form validation error occurred, fix errors and try again.",
                        innerException: invalidFormArgumentException);

                throw formValidationException;
            }
            catch (ArgumentOutOfRangeException argumentOutOfRangeException)
            {
                var formDependencyValidationException =
                    new FormDependencyValidationException(
                        message: "Form dependency validation error occurred, fix errors and try again.",
                        innerException: argumentOutOfRangeException);

                var formValidationException =
                    new FormValidationException(
                        message: "Form validation error occurred, fix errors and try again.",
                        innerException: formDependencyValidationException);

                throw formValidationException;
            }
            catch (ArgumentNullException argumentNullException)
            {
                var formDependencyValidationException =
                    new FormDependencyValidationException(
                        message: "Form dependency validation error occurred, fix errors and try again.",
                        innerException: argumentNullException);

                var formValidationException =
                    new FormValidationException(
                        message: "Form validation error occurred, fix errors and try again.",
                        innerException: formDependencyValidationException);

                throw formValidationException;
            }
            catch (ArgumentException argumentException)
            {
                var formDependencyValidationException =
                    new FormDependencyValidationException(message: "Form dependency validation error occurred, fix errors and try again.",
                        innerException: argumentException);

                var formValidationException =
                    new FormValidationException(
                        message: "Form validation error occurred, fix errors and try again.",
                        innerException: formDependencyValidationException);

                throw formValidationException;
            }
            catch (Exception exception)
            {
                 var formServiceException = new FormServiceException(
                     message: "Form service error occurred, contact support.",
                     

                     new FailedFormServiceException(
                         message: "Failed Form Service Exception occurred, please contact support for assistance.", 
                         innerException :exception));

                throw formServiceException;
            }
        }
    }
}
