// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using Xeptions;

namespace RESTFulSense.Models.Foundations.Types.Exceptions
{
    internal class TypeValidationException : Xeption
    {
        public TypeValidationException(string message, Xeption innerException)
            : base(message, innerException)
        { }
    }
}