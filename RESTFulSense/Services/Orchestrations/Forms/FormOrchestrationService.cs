// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System.Collections.Generic;
using System.IO;
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
                    string value = (string)this.valueService.RetrievePropertyValue(formModel.Object, property);
                    this.formService.AddStringContent(formModel.MultipartFormDataContent, value, attribute.Name);
                }
            }
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
