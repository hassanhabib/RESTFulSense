// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using Xeptions;

namespace RESTFulSense.Models.Foundations.Values.Exceptions
{
    public class ValueDependencyException : Xeption
    {
        public ValueDependencyException(Xeption innerException)
            : base(
                message: "Value dependency error occurred, contact support.",
                innerException: innerException)
        { }

        public ValueDependencyException(string message, Xeption innerException)
            : base(message, innerException)
        { }
    }
}