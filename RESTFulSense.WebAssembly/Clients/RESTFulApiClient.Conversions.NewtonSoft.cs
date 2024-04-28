// ---------------------------------------------------------------
// Copyright (c) Hassan Habib
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using Newtonsoft.Json;

namespace RESTFulSense.WebAssembly.Clients
{
    public partial class RESTFulApiClient
    {
        private static JsonSerializerSettings CreateJsonSerializerSettings(bool ignoreDefaultValues)
        {
            var defaultValueHandling = ignoreDefaultValues ? DefaultValueHandling.Ignore : DefaultValueHandling.Include;
            var jsonSerializerSettings = new JsonSerializerSettings { DefaultValueHandling = defaultValueHandling };
            return jsonSerializerSettings;
        }

        private static string ConvertToJsonNewtonSoftStringContent<T>(T content, bool ignoreDefaultValues)
        {
            JsonSerializerSettings jsonSerializerSettings = CreateJsonSerializerSettings(ignoreDefaultValues);

            return JsonConvert.SerializeObject(
                content,
                formatting: Formatting.None,
                settings: jsonSerializerSettings);
        }
    }
}
