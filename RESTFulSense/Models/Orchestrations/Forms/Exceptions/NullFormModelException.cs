// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using Xeptions;

namespace RESTFulSense.Models.Orchestrations.Forms.Exceptions
{
    internal class NullFormModelException : Xeption
    {
        public NullFormModelException()
            : base(message: "Form model is null. Please correct the errors and try again.")
        { }
    }
}
