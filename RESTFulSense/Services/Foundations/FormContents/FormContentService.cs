// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using FluentAssertions.Equivalency;
using RESTFulSense.Brokers.Reflections;
using RESTFulSense.Models.Attributes;

namespace RESTFulSense.Services.Foundations.FormContents
{
    internal class FormContentService : IFormContentService
    {
        private readonly IReflectionBroker reflectionBroker;

        public FormContentService(IReflectionBroker reflectionBroker)
        {
            this.reflectionBroker = reflectionBroker;
        }

        public MultipartFormDataContent GetFormContent(object @object)
        {
            List<PropertyInfo> properties = this.reflectionBroker.GetProperties(@object).ToList();

            Dictionary<string, string> stringContents = GetStringContents(@object, properties);
            Dictionary<string, Stream> streamContents = GetStreamContents(@object, properties);
            Dictionary<string, string> streamFileNames = GetStreamFileNames(@object, properties);

            MultipartFormDataContent multipartFormDataContent = new MultipartFormDataContent();

            AddStringContents(stringContents, multipartFormDataContent);
            AddStreamContents(streamContents, streamFileNames, multipartFormDataContent);

            return multipartFormDataContent;

        }

        private Dictionary<string, string> GetStringContents(object @object, List<PropertyInfo> properties)
        {
            Dictionary<string, string> stringContents = new Dictionary<string, string>();

            foreach (PropertyInfo property in properties)
            {
                RESTFulStringContentAttribute stringContentAttribute =
                    reflectionBroker.GetStringContentAttribute(property);

                if (stringContentAttribute != null)
                {
                    string key = stringContentAttribute.Name;
                    string stringValue = reflectionBroker.GetStringPropertyValue(@object, property);
                    stringContents[key] = stringValue;
                }
            }

            return stringContents;
        }

        private Dictionary<string, Stream> GetStreamContents(object @object, List<PropertyInfo> properties)
        {
            Dictionary<string, Stream> streamContents = new Dictionary<string, Stream>();

            foreach (PropertyInfo property in properties)
            {
                RESTFulFileContentStreamAttribute fileContentStreamAttribute =
                    reflectionBroker.GetFileContentStreamAttribute(property);

                if (fileContentStreamAttribute != null)
                {
                    string key = fileContentStreamAttribute.Name;
                    Stream stream = reflectionBroker.GetStreamPropertyValue(@object, property);
                    streamContents[key] = stream;
                }

            }

            return streamContents;
        }

        private Dictionary<string, string> GetStreamFileNames(object @object, List<PropertyInfo> properties)
        {
            Dictionary<string, string> streamFileNames = new Dictionary<string, string>();

            foreach (PropertyInfo property in properties)
            {
                RESTFulFileContentNameAttribute fileContentNameAttribute =
                    reflectionBroker.GetFileContentNameAttribute(property);

                if (fileContentNameAttribute != null)
                {
                    string key = fileContentNameAttribute.Name;
                    string fileName = reflectionBroker.GetStringPropertyValue(@object, property);
                    streamFileNames[key] = fileName;
                }

            }

            return streamFileNames;
        }

        private static void AddStringContents(Dictionary<string, string> stringContents, MultipartFormDataContent multipartFormDataContent)
        {
            foreach (var stringContent in stringContents)
            {
                multipartFormDataContent.Add(
                    content: new StringContent(stringContent.Value),
                    name: stringContent.Key);
            }
        }

        private static void AddStreamContents(Dictionary<string, Stream> streamContents, Dictionary<string, string> streamFileNames, MultipartFormDataContent multipartFormDataContent)
        {
            foreach (var streamContent in streamContents)
            {
                string key = streamContent.Key;
                string fileName = null;
                streamFileNames.TryGetValue(key, out fileName);

                if(fileName == null)
                {
                    multipartFormDataContent.Add(
                        content: new StreamContent(streamContent.Value),
                        name: streamContent.Key);
                }
                else
                {
                    multipartFormDataContent.Add(
                        content: new StreamContent(streamContent.Value),
                        name: streamContent.Key,
                        fileName: fileName);
                }
            }
        }
    }
}
