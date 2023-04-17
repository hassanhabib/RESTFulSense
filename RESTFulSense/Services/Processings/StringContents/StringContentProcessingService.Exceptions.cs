// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using RESTFulSense.Models.Foundations.StringContents.Exceptions;
using RESTFulSense.Models.Processings.StringContents;
using RESTFulSense.Models.Processings.StringContents.Exceptions;

namespace RESTFulSense.Services.Processings.StringContents
{
    internal partial class StringContentProcessingService
    {
        private delegate IEnumerable<NamedStringContent> ReturningNamedStringContentsFunction();

        private static IEnumerable<NamedStringContent> TryCatch(
           ReturningNamedStringContentsFunction returningNamedStringContentsFunction)
        {
            try
            {
                return returningNamedStringContentsFunction();
            }
            catch (StringContentValidationException stringContentValidationException)
            {
                throw new StringContentProcessingDependencyValidationException(stringContentValidationException);
            }
            catch (StringContentServiceException stringContentServiceException)
            {
                throw new StringContentProcessingDependencyException(stringContentServiceException);
            }
            catch (Exception exception)
            {
                var failedStringContentProcessingServiceException =
                    new FailedStringContentProcessingServiceException(exception);

                throw new StringContentProcessingServiceException(failedStringContentProcessingServiceException);
            }
        }
    }
}
