// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Xeptions;

namespace RESTFulSense.Models.Processings.Properties.Exceptions
{
    public class PropertyProcessingDependencyValidationException : Xeption
    {
        public PropertyProcessingDependencyValidationException(Xeption innerException)
            : base(message: "Property validation error occurred, contact support.", innerException)
        { }
    }
}
