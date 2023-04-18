// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Collections.Generic;
using RESTFulSense.Models.Processings.StreamContents;

namespace RESTFulSense.Services.Processings.StreamContents
{
    internal partial class StreamContentProcessingService
    {
        private delegate IEnumerable<NamedStreamContent>
            ReturningNamedStreamContentsFunction();

        private static IEnumerable<NamedStreamContent> TryCatch(
            ReturningNamedStreamContentsFunction returningNamedStreamContentsFunction)
        {
            return returningNamedStreamContentsFunction();
        }
    }
}
