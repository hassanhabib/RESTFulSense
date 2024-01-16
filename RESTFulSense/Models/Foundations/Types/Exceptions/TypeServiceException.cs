// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using Xeptions;

namespace RESTFulSense.Models.Foundations.Types.Exceptions
{
    public class TypeServiceException : Xeption
    {
        public TypeServiceException(Xeption innerException)
            : base(
                message: "Type service error occurred, contact support.",
                innerException: innerException)
        { }
        
        public TypeServiceException(string message, Xeption innerException)
            : base(message, innerException)
        { }
    }
}