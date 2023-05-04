// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System.Net.Http;

namespace RESTFulSense.Services.Coordinations.Forms
{
    internal interface IFormCoordinationService
    {
        MultipartFormDataContent ConvertToMultipartFormDataContent<T>(T @object)
            where T : class;
    }
}
