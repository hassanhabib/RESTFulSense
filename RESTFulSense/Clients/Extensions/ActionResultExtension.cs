// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using FluentAssertions;
using Microsoft.AspNetCore.Mvc;

namespace RESTFulSense.Clients.Extensions
{
    public static class ActionResultExtension
    {
        public static void ShouldBeEquivalentTo<T>(
            this ActionResult<T> actualActionResult,
            ActionResult<T> expectedActionResult)
        {
            (actualActionResult.Result as ObjectResult).Should().BeEquivalentTo(
                expectedActionResult.Result as ObjectResult);
        }
    }
}
