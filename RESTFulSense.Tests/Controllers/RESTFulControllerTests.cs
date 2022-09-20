// ---------------------------------------------------------------
// Copyright (c) Hassan Habib
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;
using Tynamix.ObjectFiller;
using Xunit;

namespace RESTFulSense.Tests.Controllers
{
    public partial class RESTFulControllerTests
    {
        private readonly RESTFulController restfulController;

        public RESTFulControllerTests() =>
            this.restfulController = new RESTFulController(new JsonSerializerOptions());

        public static TheoryData<JsonSerializerOptions> SerializationCases => new()
        {
            { new JsonSerializerOptions() },
            { new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    DictionaryKeyPolicy = JsonNamingPolicy.CamelCase,
                    WriteIndented = true
                }
            }
        };

        private void SetupInputAndExpectedCriteria(
            Dictionary<string, List<string>> randomDictionary,
            Exception inputException,
            ValidationProblemDetails expectedProblemDetail)
        {
            this.SetupInputAndExpectedCriteria(
                randomDictionary,
                inputException,
                expectedProblemDetail,
                jsonSerializerOptions: new JsonSerializerOptions());
        }

        private void SetupInputAndExpectedCriteria(
            Dictionary<string, List<string>> randomDictionary,
            Exception inputException,
            ValidationProblemDetails expectedProblemDetail,
            JsonSerializerOptions jsonSerializerOptions)
        {
            foreach (KeyValuePair<string, List<string>> item in randomDictionary)
            {
                inputException.Data.Add(item.Key, item.Value);

                string serializedKey = ApplySerialization(
                    error: new DictionaryEntry(item.Key, item.Value),
                    jsonSerializerOptions: jsonSerializerOptions);

                expectedProblemDetail.Errors.Add(
                    key: serializedKey,
                    value: item.Value.ToArray());
            }
        }

        private static string ApplySerialization(DictionaryEntry error, JsonSerializerOptions jsonSerializerOptions)
        {
            return jsonSerializerOptions.PropertyNamingPolicy == JsonNamingPolicy.CamelCase
                ? error.Key.ToString().Substring(0, 1).ToLower() + error.Key.ToString().Substring(1)
                : error.Key.ToString().Substring(0, 1).ToUpper() + error.Key.ToString().Substring(1);
        }

        private static string GetRandomMessage() =>
            new MnemonicString().GetValue();
    }
}