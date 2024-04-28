// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using Xeptions;

namespace RESTFulSense.Models.Foundations.Values.Exceptions
{
    public class ValueDependencyValidationException : Xeption
    {
        public ValueDependencyValidationException(Xeption innerException)
            : base(
                message: "Value dependency validation occurred, fix errors and try again.",
                innerException: innerException)
        { }

        public ValueDependencyValidationException(string message, Xeption innerException)
            : base(message, innerException)
        { }
    }
}