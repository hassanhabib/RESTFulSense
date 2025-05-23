﻿// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RESTFulSense.Models.Attributes;
using Xunit;

namespace RESTFulSense.Tests.Models.Attributes.RESTFulRestrictHeaderAttributes
{
    public partial class RESTFulRestrictHeaderAttributeTests
    {
        [Fact]
        public void ShouldNotSetResultWhenHeaderMatches()
        {
            // given
            string randomName = GetRandomString();
            string inputName = randomName;
            string randomValue = GetRandomString();
            string inputValue = randomValue;

            var expectedRestfulRestrictHeaderAttribute =
                new RESTFulRestrictHeaderAttribute
                {
                    Name = inputName,
                    Value = inputValue
                };

            var defaultHttpContext = new DefaultHttpContext();

            defaultHttpContext.Request.Headers[key: inputName] =
                inputValue;

            ActionContext inputActionContext =
                CreateRandomActionContext(defaultHttpContext);

            ActionExecutingContext inputActionExecutingContext =
                CreateRandomActionExecutingContext(
                    inputActionContext);

            // when
            expectedRestfulRestrictHeaderAttribute
                .OnActionExecuting(inputActionExecutingContext);

            // then
            inputActionExecutingContext.Result.Should().BeNull();
        }

        [Fact]
        public void ShouldSetUnauthorizedResultWhenHeaderDoesNotMatch()
        {
            // given
            string randomName = GetRandomString();
            string inputName = randomName;
            string randomValue = GetRandomString();
            string inputValue = randomValue;
            string mismatchedValue = GetRandomString();

            var expectedRestfulRestrictHeaderAttribute =
                new RESTFulRestrictHeaderAttribute
                {
                    Name = inputName,
                    Value = inputValue
                };

            var defaultHttpContext = new DefaultHttpContext();

            defaultHttpContext.Request.Headers[key: inputName] =
                mismatchedValue;

            ActionContext inputActionContext =
                CreateRandomActionContext(defaultHttpContext);

            ActionExecutingContext inputActionExecutingContext =
                CreateRandomActionExecutingContext(
                    inputActionContext);

            // when
            expectedRestfulRestrictHeaderAttribute
                .OnActionExecuting(inputActionExecutingContext);

            // then
            inputActionExecutingContext.Result.Should()
                .BeOfType<UnauthorizedResult>();
        }

        [Fact]
        public void ShouldSetUnauthorizedResultWhenHeaderIsMissing()
        {
            // given
            string randomName = GetRandomString();
            string inputName = randomName;
            string randomValue = GetRandomString();
            string inputValue = randomValue;

            var expectedRestfulRestrictHeaderAttribute =
                new RESTFulRestrictHeaderAttribute
                {
                    Name = inputName,
                    Value = inputValue
                };

            var defaultHttpContext = new DefaultHttpContext();

            ActionContext inputActionContext =
                CreateRandomActionContext(defaultHttpContext);

            ActionExecutingContext inputActionExecutingContext =
                CreateRandomActionExecutingContext(
                    inputActionContext);

            // when
            expectedRestfulRestrictHeaderAttribute
                .OnActionExecuting(inputActionExecutingContext);

            // then
            inputActionExecutingContext.Result.Should()
                .BeOfType<UnauthorizedResult>();
        }
    }
}
