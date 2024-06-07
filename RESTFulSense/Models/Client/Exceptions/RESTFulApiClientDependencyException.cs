// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using Xeptions;

namespace RESTFulSense.Models.Client.Exceptions
{
    public class RESTFulApiClientDependencyException : Xeption
    {
        public RESTFulApiClientDependencyException(string message, Xeption innerException)
            : base(message, innerException)
        { }
    }
}