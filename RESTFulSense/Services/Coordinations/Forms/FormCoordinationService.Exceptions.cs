// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System.Net.Http;
using RESTFulSense.Models.Coordinations.Forms.Exceptions;

namespace RESTFulSense.Services.Coordinations.Forms
{
    internal partial class FormCoordinationService
    {
        private delegate MultipartFormDataContent ReturningMultipartFormDataContentFunction();

        private MultipartFormDataContent TryCatch(ReturningMultipartFormDataContentFunction
            returningMultipartFormDataContentFunction)
        {
            try
            {
                return returningMultipartFormDataContentFunction();
            }
            catch (NullObjectException nullObjectException)
            {
                var formCoordinationValidationException =
                    new FormCoordinationValidationException(nullObjectException);

                throw formCoordinationValidationException;
            }
        }
    }
}
