// ---------------------------------------------------------------
// Copyright (c) Hassan Habib
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

namespace RESTFulSense.WebAssembly.Models
{
    public class ObjectResult
    {
        public ObjectResult(object value)
        {
            Value = value;
        }

        public int StatusCode { get; set; }
        public object Value { get; set; }
    }
}