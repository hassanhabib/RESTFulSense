// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using Xeptions;

namespace RESTFulSense.Models.Client.Exceptions
{
    public class RESTFulApiClientServiceException : Xeption
    {
        public RESTFulApiClientServiceException(string message, Xeption innerException)
            : base(message, innerException)
        { }
    }
}