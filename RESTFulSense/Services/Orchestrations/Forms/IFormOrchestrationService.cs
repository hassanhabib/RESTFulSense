// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using RESTFulSense.Models.Orchestrations.Forms;

namespace RESTFulSense.Services.Orchestrations.Forms
{
    internal interface IFormOrchestrationService
    {
        FormModel BuildFormModel(FormModel formModel);
    }
}
