// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Net.Http;
using RESTFulSense.Models.Orchestrations.FormContents.Exceptions;
using RESTFulSense.Models.Processings.Properties.Exceptions;

namespace RESTFulSense.Services.Orchestrations.FormContents
{
    internal partial class FormContentOrchestrationService
    {
        private delegate MultipartFormDataContent ReturningMultipartFormDataContentFunction();

        private static MultipartFormDataContent TryCatch(
            ReturningMultipartFormDataContentFunction returningMultipartFormDataContentFunction)
        {
            try
            {
                return returningMultipartFormDataContentFunction();
            }
            catch (PropertyProcessingDependencyValidationException propertyProcessingDependencyValidationException)
            {
                throw new FormContentOrchestrationDependencyValidationException(
                    propertyProcessingDependencyValidationException);
            }
        }
    }
}
