// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Xeptions;

namespace RESTFulSense.Models.Processings.StreamContents.Exceptions
{
    public class StreamContentProcessingDependencyValidationException : Xeption
    {
        public StreamContentProcessingDependencyValidationException(Xeption innerException)
            : base(message: "String stream validation error occurred, contact support.", innerException)
        { }
    }
}
