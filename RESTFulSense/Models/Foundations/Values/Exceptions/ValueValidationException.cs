// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using Xeptions;

namespace RESTFulSense.Models.Foundations.Values.Exceptions
{
    public class ValueValidationException : Xeption
    {
        public ValueValidationException(Xeption innerException)
            : base(
                message: "Value validation errors occurred, fix errors and try again.",
                innerException: innerException)
        { }
        
        public ValueValidationException(string message, Xeption innerException)
            : base(message, innerException)
        { }
    }
}