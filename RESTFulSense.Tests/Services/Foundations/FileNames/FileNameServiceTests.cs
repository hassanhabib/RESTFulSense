// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Moq;
using RESTFulSense.Brokers.Reflections;
using RESTFulSense.Models.Attributes;
using RESTFulSense.Services.Foundations.FileNames;
using Tynamix.ObjectFiller;

namespace RESTFulSense.Tests.Services.Foundations.FileNames
{
    public partial class FileNameServiceTests
    {
        private readonly Mock<IReflectionBroker> reflectionBrokerMock;
        private readonly IFileNameService fileNameService;

        public FileNameServiceTests()
        {
            reflectionBrokerMock = new Mock<IReflectionBroker>();
            fileNameService = new FileNameService(reflectionBrokerMock.Object);
        }

        private RESTFulFileContentNameAttribute CreateRandomFileNameContent() =>
            new RESTFulFileContentNameAttribute(name: CreateRandomString());

        private static string CreateRandomString() =>
            new MnemonicString().GetValue();

    }
}
