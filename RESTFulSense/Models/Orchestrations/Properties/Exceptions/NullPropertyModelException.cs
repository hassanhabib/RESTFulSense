// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using Xeptions;

namespace RESTFulSense.Models.Orchestrations.Properties.Exceptions
{
    public class NullPropertyModelException : Xeption
    {
        public NullPropertyModelException(Exception innerException)
            : base(message: "PropertyModel is null, fix errors and try again.", innerException)
        { }
    }
}
