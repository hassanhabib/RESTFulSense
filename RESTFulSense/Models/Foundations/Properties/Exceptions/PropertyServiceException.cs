// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using Xeptions;

namespace RESTFulSense.Models.Foundations.Properties.Exceptions
{
    public class PropertyServiceException : Xeption
    {
        public PropertyServiceException(string message, Xeption innerException)
            : base(message, innerException)
        { }
    }
}