// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Collections.Generic;
using RESTFulSense.Models.Foundations.StreamContents.Exceptions;
using RESTFulSense.Models.Processings.StreamContents;
using RESTFulSense.Models.Processings.StreamContents.Exceptions;

namespace RESTFulSense.Services.Processings.StreamContents
{
    internal partial class StreamContentProcessingService
    {
        private delegate IEnumerable<NamedStreamContent>
            ReturningNamedStreamContentsFunction();

        private static IEnumerable<NamedStreamContent> TryCatch(
            ReturningNamedStreamContentsFunction returningNamedStreamContentsFunction)
        {
            try
            {
                return returningNamedStreamContentsFunction();
            }
            catch(StreamContentValidationException streamContentValidationException)
            {
                throw new StreamContentProcessingDependencyValidationException(streamContentValidationException);
            }
        }
    }
}
