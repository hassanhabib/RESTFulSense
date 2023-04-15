// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using RESTFulSense.Models.Attributes;
using RESTFulSense.Models.Foundations.FileNames.Exceptions;

namespace RESTFulSense.Services.Foundations.FileNames
{
    internal partial class FileNameService
    {
        private delegate RESTFulFileContentNameAttribute ReturningRESTFulFileContentNameAttributeFunction();

        private static RESTFulFileContentNameAttribute
            TryCatch(ReturningRESTFulFileContentNameAttributeFunction returningRESTFulFileContentNameAttributeFunction)
        {
            try
            {
                return returningRESTFulFileContentNameAttributeFunction();
            }
            catch (NullPropertyInfoException nullPropertyInfoException)
            {
                throw new FileNameValidationException(nullPropertyInfoException);
            }
            catch (Exception exception)
            {
                var failedFileNameServiceException =
                   new FailedFileNameServiceException(exception);

                throw new FileNameServiceException(failedFileNameServiceException);
            }
        }
    }
}