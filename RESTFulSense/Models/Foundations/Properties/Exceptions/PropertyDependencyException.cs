// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using Xeptions;

namespace RESTFulSense.Models.Foundations.Properties.Exceptions
{
    public class PropertyDependencyException : Xeption
    {
        public PropertyDependencyException(Xeption innerException) :
            base(message: "Property dependency error occurred, contact support.", innerException)
        { }
    }
}
