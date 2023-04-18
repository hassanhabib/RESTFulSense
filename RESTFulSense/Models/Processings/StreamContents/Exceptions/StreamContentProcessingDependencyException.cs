// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Xeptions;

namespace RESTFulSense.Models.Processings.StreamContents.Exceptions
{
    public class StreamContentProcessingDependencyException : Xeption
    {
        public StreamContentProcessingDependencyException(Xeption innerException)
            : base(message: "String stream dependency error occurred, contact support.", innerException)
        { }
    }
}
