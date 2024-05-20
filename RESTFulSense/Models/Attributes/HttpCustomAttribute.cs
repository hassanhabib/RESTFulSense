// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using Microsoft.AspNetCore.Mvc.Routing;

namespace RESTFulSense.Models.Attributes
{
    public class HttpCustomAttribute : HttpMethodAttribute
    {
        public HttpCustomAttribute(string httpVerb)
            : base(new[] { httpVerb }) { }
    }
}
