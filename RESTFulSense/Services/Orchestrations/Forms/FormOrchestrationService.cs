// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using RESTFulSense.Models.Attributes;
using RESTFulSense.Models.Orchestrations.Forms;
using RESTFulSense.Services.Foundations.Attributes;
using RESTFulSense.Services.Foundations.Forms;
using RESTFulSense.Services.Foundations.Values;

namespace RESTFulSense.Services.Orchestrations.Forms
{
    internal partial class FormOrchestrationService : IFormOrchestrationService
    {
        private readonly IAttributeService attributeService;
        private readonly IValueService valueService;
        private readonly IFormService formService;

        public FormOrchestrationService(
            IAttributeService attributeService,
            IValueService valueService,
            IFormService formService)
        {
            this.attributeService = attributeService;
            this.valueService = valueService;
            this.formService = formService;
        }

        public FormModel BuildFormModel(FormModel formModel) =>
            TryCatch(() =>
            {
                ValidateFormModelIsNotNull(formModel);

                var nameToFileNameMap = CreateNameToFileNameMap(formModel);
                AddStringContents(formModel);
                AddByteArrayContents(formModel, nameToFileNameMap);
                AddStreamContents(formModel, nameToFileNameMap);

                return formModel;
            });

        private Dictionary<string, string> CreateNameToFileNameMap(FormModel formModel)
        {
            var nameToFileNameMap = new Dictionary<string, string>();

            foreach (var property in formModel.Properties)
            {
                RESTFulFileNameAttribute fileNameAttribute =
                    this.attributeService.RetrieveAttribute<RESTFulFileNameAttribute>(property);

                if (fileNameAttribute != null)
                {
                    object propertyValue =
                        this.valueService.RetrievePropertyValue(formModel.Object, property);

                    ValidatePropertyValue(propertyValue);
                    string fileName = (string)propertyValue;
                    ValidateFileName(fileName);
                    nameToFileNameMap[fileNameAttribute.Name] = fileName;
                }
            }

            return nameToFileNameMap;
        }

        private void AddStringContents(FormModel formModel)
        {
            foreach (var property in formModel.Properties)
            {
                RESTFulStringContentAttribute attribute =
                    this.attributeService.RetrieveAttribute<RESTFulStringContentAttribute>(property);

                if (attribute != null)
                {
                    bool ignoreDefaultValues = attribute.IgnoreDefaultValues;
                    object propertyValue = this.valueService.RetrievePropertyValue(formModel.Object, property);

                    bool isDefaultValue = IsDefaultValue(property.PropertyType, propertyValue);

                    if (isDefaultValue is false || ignoreDefaultValues is false)
                    {
                        string value = ConvertToString(propertyValue, attribute.MediaType, ignoreDefaultValues);

                        this.formService.AddStringContent(formModel.MultipartFormDataContent, value, attribute.Name);
                    }
                }
            }
        }

        private static bool IsDefaultValue(Type type, object value)
        {
            if (type.IsValueType)
            {
                object defaultValue = Activator.CreateInstance(type);

                return value.Equals(defaultValue);
            }
            else
            {
                return value is null;
            }
        }

        private static string ConvertToString(object propertyValue, string mediaType, bool ignoreDefaultValues)
        {
            return mediaType switch
            {
                "text/json" => ConvertToJsonString(propertyValue, ignoreDefaultValues),
                "application/json" => ConvertToJsonString(propertyValue, ignoreDefaultValues),
                _ => propertyValue.ToString()
            };
        }

        private static string ConvertToJsonString<T>(T content, bool ignoreDefaultValues)
        {
            JsonSerializerSettings jsonSerializerSettings = CreateJsonSerializerSettings(ignoreDefaultValues);

            string serializedRestrictionRequest = JsonConvert.SerializeObject(
                content,
                formatting: Formatting.None,
                settings: jsonSerializerSettings);

            return serializedRestrictionRequest;
        }

        private static JsonSerializerSettings CreateJsonSerializerSettings(bool ignoreDefaultValues)
        {
            var defaultValueHandling = ignoreDefaultValues ? DefaultValueHandling.Ignore : DefaultValueHandling.Include;
            var jsonSerializerSettings = new JsonSerializerSettings { DefaultValueHandling = defaultValueHandling };
            return jsonSerializerSettings;
        }

        private void AddByteArrayContents(FormModel formModel, Dictionary<string, string> fileNames)
        {
            foreach (var property in formModel.Properties)
            {
                RESTFulByteArrayContentAttribute attribute =
                    this.attributeService.RetrieveAttribute<RESTFulByteArrayContentAttribute>(property);

                if (attribute != null)
                {
                    byte[] value = (byte[])this.valueService.RetrievePropertyValue(formModel.Object, property);
                    string name = attribute.Name;

                    if (fileNames.ContainsKey(name))
                    {
                        this.formService.AddByteArrayContent(
                            formModel.MultipartFormDataContent,
                            value,
                            attribute.Name,
                            fileNames[name]);
                    }
                    else
                    {
                        this.formService.AddByteArrayContent(
                            formModel.MultipartFormDataContent,
                            value,
                            attribute.Name);
                    }
                }
            }
        }

        private void AddStreamContents(FormModel formModel, Dictionary<string, string> fileNames)
        {
            foreach (var property in formModel.Properties)
            {
                RESTFulStreamContentAttribute attribute =
                    this.attributeService.RetrieveAttribute<RESTFulStreamContentAttribute>(property);

                if (attribute != null)
                {
                    Stream value = (Stream)this.valueService.RetrievePropertyValue(formModel.Object, property);
                    string name = attribute.Name;

                    if (fileNames.ContainsKey(name))
                    {
                        this.formService.AddStreamContent(
                            formModel.MultipartFormDataContent,
                            value,
                            attribute.Name,
                            fileNames[name]);
                    }
                    else
                    {
                        this.formService.AddStreamContent(
                            formModel.MultipartFormDataContent,
                            value,
                            attribute.Name);
                    }
                }
            }
        }
    }
}
