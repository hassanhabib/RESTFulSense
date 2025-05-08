// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using Xeptions;

namespace RESTFulSense.Models.Foundations.Values.Exceptions
{
    public class ValueDependencyException : Xeption
    {
        public ValueDependencyException(string message, Xeption innerException)
            : base(message, innerException)
        { }
    }
}