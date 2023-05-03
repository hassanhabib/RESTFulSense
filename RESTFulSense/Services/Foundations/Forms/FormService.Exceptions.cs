// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

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
        }
    }
}
