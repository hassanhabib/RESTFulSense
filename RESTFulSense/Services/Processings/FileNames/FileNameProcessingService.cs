// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using RESTFulSense.Models.Attributes;
using RESTFulSense.Models.Foundations.Properties;
using RESTFulSense.Models.Processings.StreamContents;
using RESTFulSense.Services.Foundations.FileNames;

namespace RESTFulSense.Services.Processings.FileNames
{
    internal partial class FileNameProcessingService : IFileNameProcessingService
    {
        private readonly IFileNameService fileNameService;

        public FileNameProcessingService(IFileNameService fileNameService) =>
            this.fileNameService = fileNameService;

        public void UpdateFileNames(
            IEnumerable<NamedStreamContent> namedStreamContents,
            IEnumerable<PropertyValue> propertyValues) =>
        TryCatch(() =>
        {
            Dictionary<string, string> fileNamesByName =
              GetFileNamesByName(propertyValues);

            foreach (var namedStreamContent in namedStreamContents)
            {
                if (fileNamesByName.ContainsKey(namedStreamContent.Name))
                {
                    namedStreamContent.FileName =
                        fileNamesByName[namedStreamContent.Name];
                }
            }
        });

        private Dictionary<string, string> GetFileNamesByName(IEnumerable<PropertyValue> propertyValues)
        {
            Dictionary<string, string> fileNamesByName = new Dictionary<string, string>();

            foreach (var propertyValue in propertyValues)
            {
                RESTFulFileContentNameAttribute rESTFulFileContentNameAttribute =
                    this.fileNameService.RetrieveFileName(propertyValue.PropertyInfo);

                if (rESTFulFileContentNameAttribute != null)
                {
                    string fileName = (string)propertyValue.Value;
                    if (String.IsNullOrEmpty(fileName) != true)
                    {
                        fileNamesByName[rESTFulFileContentNameAttribute.Name] = (string)propertyValue.Value;
                    }
                }
            }

            return fileNamesByName;
        }
    }
}
