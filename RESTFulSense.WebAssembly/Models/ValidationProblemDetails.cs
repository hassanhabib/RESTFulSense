﻿// ---------------------------------------------------------------
// Copyright (c) Brian Parker & Hassan Habib
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace RESTFulSense.WebAssembly.Models
{
    public class ValidationProblemDetails
    {
        public ValidationProblemDetails()
        {
            Data = new Dictionary<string, string[]>(StringComparer.Ordinal);
        }

        public string Title { get; set; }
        public IDictionary<string, string[]> Errors => Data;
        public Dictionary<string, string[]> Data { get; set; }
        public string Type { get; set; }
    }
}