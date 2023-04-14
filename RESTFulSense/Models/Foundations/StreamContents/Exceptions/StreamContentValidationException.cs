// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Xeptions;

namespace RESTFulSense.Models.Foundations.StreamContents.Exceptions
{
    public class StreamContentValidationException : Xeption
    {
        public StreamContentValidationException(Xeption innerException)
            : base(message: "StreamContent validation error occurred, fix errors and try again.",
                  innerException)
        { }
    }
}
