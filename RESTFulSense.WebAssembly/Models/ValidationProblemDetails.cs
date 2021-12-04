// ---------------------------------------------------------------
// Copyright (c) Hassan Habib
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace RESTFulSense.WebAssembly.Exceptions
{
    public class ValidationProblemDetails
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        public IDictionary<string, string[]> Errors { get; set; }
    }
}