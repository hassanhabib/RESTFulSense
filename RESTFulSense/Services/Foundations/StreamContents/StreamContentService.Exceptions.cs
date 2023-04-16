// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using RESTFulSense.Models.Attributes;
using RESTFulSense.Models.Foundations.StreamContents.Exceptions;

namespace RESTFulSense.Services.Foundations.StreamContents
{
    internal partial class StreamContentService
    {
        private delegate RESTFulFileContentStreamAttribute ReturningRESTFulFileContentStreamAttributeFunction();

        private static RESTFulFileContentStreamAttribute TryCatch(
            ReturningRESTFulFileContentStreamAttributeFunction returningRESTFulFileContentStreamAttributeFunction)
        {
            try
            {
                return returningRESTFulFileContentStreamAttributeFunction();
            }
            catch (NullPropertyInfoException nullPropertyInfoException)
            {
                throw new StreamContentValidationException(nullPropertyInfoException);
            }
            catch (Exception exception)
            {
                var failedStringContentServiceException =
                   new FailedStreamContentServiceException(exception);

                throw new StreamContentServiceException(failedStringContentServiceException);
            }
        }
    }
}
