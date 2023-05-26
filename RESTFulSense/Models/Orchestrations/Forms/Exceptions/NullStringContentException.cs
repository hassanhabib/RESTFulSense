// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using Xeptions;

namespace RESTFulSense.Models.Orchestrations.Forms.Exceptions
{
    public class NullStringContentException : Xeption
    {
        public NullStringContentException()
            : base(message: "String Content is null. Please correct the errors and try again.")
        { }
    }
}
