// ---------------------------------------------------------------
// Copyright (c) Hassan Habib
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using RESTFulSense.Controllers;
using Tynamix.ObjectFiller;

namespace RESTFulSense.Tests.Controllers
{
    public partial class RESTFulControllerTests
    {
        private readonly RESTFulController restfulController;

        public RESTFulControllerTests() =>
            this.restfulController = new RESTFulController();

        private static string GetRandomMessage() =>
            new MnemonicString().GetValue();
    }
}