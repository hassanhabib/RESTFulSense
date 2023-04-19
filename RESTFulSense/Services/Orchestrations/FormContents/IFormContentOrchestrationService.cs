// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Net.Http;

namespace RESTFulSense.Services.Orchestrations.FormContents
{
    internal interface IFormContentOrchestrationService
    {
        MultipartFormDataContent ConvertToMultipartFormDataContent<T>(T @object) where T : class;
    }
}
