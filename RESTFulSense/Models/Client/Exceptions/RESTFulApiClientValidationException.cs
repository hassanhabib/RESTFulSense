// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using Xeptions;

namespace RESTFulSense.Models.Client.Exceptions
{
    public class RESTFulApiClientValidationException : Xeption
    {
        public RESTFulApiClientValidationException(Xeption innerException)
            : base(
                message: "Api Client validation errors occurred, please try again.",
                innerException: innerException)
        { }

        public RESTFulApiClientValidationException(string message, Xeption innerException)
            : base(message, innerException)
        { }
    }
}