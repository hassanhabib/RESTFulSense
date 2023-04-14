// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Xeptions;

namespace RESTFulSense.Models.Foundations.StreamContents.Exceptions
{
    public class StreamContentServiceException : Xeption
    {
        public StreamContentServiceException(Xeption innerException)
            : base(message: "StreamContent service error occurred, contact support.",
                  innerException)
        { }
    }
}
