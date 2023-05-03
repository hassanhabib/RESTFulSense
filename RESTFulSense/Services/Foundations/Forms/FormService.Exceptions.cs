// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using System.Net.Http;
using RESTFulSense.Models.Foundations.Forms.Exceptions;

namespace RESTFulSense.Services.Foundations.Forms
{
    internal partial class FormService : IFormService
    {
        private delegate MultipartFormDataContent ReturningMultipartFormDataContentFunction();

        private MultipartFormDataContent TryCatch(ReturningMultipartFormDataContentFunction returningMultipartFormDataContentFunction)
        {
            try
            {
                return returningMultipartFormDataContentFunction();
            }
            catch (InvalidFormArgumentException invalidFormArgumentException)
            {
                var formValidationException =
                    new FormValidationException(invalidFormArgumentException);

                throw formValidationException;
            }
            catch (ArgumentOutOfRangeException argumentOutOfRangeException)
            {
                var formDependencyValidationException =
                    new FormDependencyValidationException(argumentOutOfRangeException);

                var formValidationException =
                    new FormValidationException(formDependencyValidationException);

                throw formValidationException;
            }
            catch (ArgumentNullException argumentNullException)
            {
                var formDependencyValidationException =
                    new FormDependencyValidationException(argumentNullException);

                var formValidationException =
                    new FormValidationException(formDependencyValidationException);

                throw formValidationException;
            }
            catch (ArgumentException argumentException)
            {
                var formDependencyValidationException =
                    new FormDependencyValidationException(argumentException);

                var formValidationException =
                    new FormValidationException(formDependencyValidationException);

                throw formValidationException;
            }
        }
    }
}
