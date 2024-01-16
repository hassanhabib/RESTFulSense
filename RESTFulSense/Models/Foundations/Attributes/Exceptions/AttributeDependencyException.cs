// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using Xeptions;

namespace RESTFulSense.Models.Foundations.Attributes.Exceptions
{
    public class AttributeDependencyException : Xeption
    {
        public AttributeDependencyException(Xeption innerException) :
            base(
                message: "Attribute dependency error occurred, contact support.",
                innerException: innerException)
        { }
        
        public AttributeDependencyException(string message, Xeption innerException) :
            base(message, innerException)
        { }
    }
}