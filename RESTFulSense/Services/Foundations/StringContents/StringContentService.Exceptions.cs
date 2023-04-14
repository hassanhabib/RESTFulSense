// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using RESTFulSense.Models.Attributes;
using RESTFulSense.Models.Foundations.StringContents.Exceptions;

namespace RESTFulSense.Services.Foundations.StringContents
{
    internal partial class StringContentService : IStringContentService
    {
        private delegate RESTFulStringContentAttribute ReturningRESTFulStringContentAttributeFunction();

        private static RESTFulStringContentAttribute
            TryCatch(ReturningRESTFulStringContentAttributeFunction returningRESTFulStringContentAttributeFunction)
        {
            try
            {
                return returningRESTFulStringContentAttributeFunction();
            }
            catch (NullPropertyInfoException nullPropertyInfoException)
            {
                throw new StringContentValidationException(nullPropertyInfoException);
            }
            catch (Exception exception)
            {
                var failedStringContentServiceException =
                   new FailedStringContentServiceException(exception);

                throw new StringContentServiceException(failedStringContentServiceException);
            }
        }
    }
}
