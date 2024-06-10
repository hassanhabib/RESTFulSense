// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using RESTFulSense.Models.Coordinations.Forms.Exceptions;

namespace RESTFulSense.Services.Coordinations.Forms
{
    internal partial class FormCoordinationService
    {
        private void ValidateOnConvertToMultipartFormDataContent<T>(T @object) where T : class
        {
            if (@object == null)
            {
                var errorMessage = "Object is null.";
                throw new NullObjectException(errorMessage);
            }
        }
    }
}
