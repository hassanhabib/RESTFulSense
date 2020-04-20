// ---------------------------------------------------------------
// Copyright (c) Hassan Habib & Alice Luo  All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using RESTFulSense.Models;

namespace RESTFulSense.Controllers
{
    public interface IRESTFulController
    {
        LockedObjectResult Locked(object value);
    }
}
