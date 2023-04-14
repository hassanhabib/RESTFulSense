// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Net.Http;

namespace RESTFulSense.Services.Foundations.FormContents
{
    internal interface IFormContentService
    {
        MultipartFormDataContent GetFormContent(object @object);
    }
}
