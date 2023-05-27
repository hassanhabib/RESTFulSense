// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using RESTFulSense.Models.Orchestrations.Forms;
using RESTFulSense.Models.Orchestrations.Forms.Exceptions;

namespace RESTFulSense.Services.Orchestrations.Forms
{
    internal partial class FormOrchestrationService
    {
        private void ValidateFormModelIsNotNull(FormModel formModel)
        {
            if (formModel is null)
            {
                throw new NullFormModelException();
            }
        }

        private static void ValidatePropertyValue(object value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(paramName: nameof(value), message: "Name Property value is null.");
            }

            if (!typeof(string).IsAssignableFrom(value.GetType()))
            {
                throw new ArgumentException(message: "Name Property value is not assignable to type string.");
            }
        }

        private static void ValidateFileName(string fileName)
        {
            if (String.IsNullOrWhiteSpace(fileName))
            {
                throw new ArgumentException(message: "FileName is invalid.");
            }
        }

        private static void ValidateStringContent(object value)
        {
            if (value is null)
            {
                var argumentException = new ArgumentException(message: "String Content is null.");

                throw new NullStringContentException(argumentException);
            }
        }
    }
}
