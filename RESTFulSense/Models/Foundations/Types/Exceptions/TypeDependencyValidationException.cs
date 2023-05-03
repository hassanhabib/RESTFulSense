// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using Xeptions;

namespace RESTFulSense.Models.Foundations.Types.Exceptions
{
    internal class TypeDependencyValidationException : Xeption
    {
        public TypeDependencyValidationException(Xeption innerException)
            : base(message: "Type dependency validation occurred, fix errors and try again.", innerException)
        { }
    }
}
