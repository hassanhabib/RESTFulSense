// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Xeptions;

namespace RESTFulSense.Models.Processings.Properties.Exceptions
{
    public class PropertyProcessingDependencyException : Xeption
    {
        public PropertyProcessingDependencyException(Xeption innerException)
            : base(message: "Property dependency error occurred, contact support.", innerException)
        { }
    }
}
