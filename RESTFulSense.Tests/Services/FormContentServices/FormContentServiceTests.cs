// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.IO;
using System.Net.Http;
using System.Text;
using RESTFulSense.Brokers.Reflections;
using RESTFulSense.Models.Attributes;
using RESTFulSense.Services.Foundations.FormContents;
using Tynamix.ObjectFiller;
using Xunit;

namespace RESTFulSense.Tests.Services.FormContentServices
{
    public partial class FormContentServiceTests
    {
        [Fact]
        public void DeleteMe()
        {
            IReflectionBroker broker = new ReflectionBroker();
            string content = CreateRandomString();
            string completion = CreateRandomString();
            string stringContent = $"{{\"prompt\" : \"{content}\", \"completion\" : \"{completion}\" }}";
            SomeModel model = new SomeModel
            {
                FileName = "Test.jsonl",
                FileStream = new MemoryStream(Encoding.UTF8.GetBytes(s: stringContent)),
                Purpose = "fine-tune"
            };

            IFormContentService formContentService = new FormContentService(broker);

            MultipartFormDataContent formContent = formContentService.GetFormContent(model);
        }
        private static string CreateRandomString() =>
            new MnemonicString().GetValue();

        public class SomeModel
        {
            [RESTFulFileContentStream(name: "file")]
            public Stream FileStream { get; set; }

            [RESTFulFileContentName(name: "file")]
            public string FileName { get; set; }

            [RESTFulStringContent(name: "purpose")]
            public string Purpose { get; set; }
        }
    }
}
