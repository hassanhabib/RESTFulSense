// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using Xeptions;

namespace RESTFulSense.Models.Orchestrations.Forms.Exceptions
{
    internal class FormOrchestrationDependencyException : Xeption
    {
        public FormOrchestrationDependencyException(Exception innerException)
            : base(message: "Form orchestration dependency error occurred, fix errors and try again.", innerException)
        { }
    }
}