// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using Xeptions;

namespace RESTFulSense.Models.Client.Exceptions
{
    public class RESTFulApiClientValidationException : Xeption
    {

        public RESTFulApiClientValidationException(string message, Xeption innerException)
            : base(message, innerException)
        { }
    }
}