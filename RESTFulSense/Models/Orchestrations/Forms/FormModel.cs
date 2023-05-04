// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System.Net.Http;
using System.Reflection;

namespace RESTFulSense.Models.Orchestrations.Forms
{
    internal class FormModel
    {
        public object Object { get; set; }
        public PropertyInfo[] Properties { get; set; }
        public MultipartFormDataContent MultipartFormDataContent { get; set; }
    }
}
