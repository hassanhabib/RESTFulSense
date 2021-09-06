// ---------------------------------------------------------------
// Copyright (c) Hassan Habib
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;
using RESTFulSense.Models;
using Tynamix.ObjectFiller;
using Xunit;

namespace RESTFulSense.Tests.Controllers
{
    public partial class RESTFulControllerTests
    {
        [Fact]
        public void ShouldReturnValidationProblemDetailOnBadRequest()
        {
            // given
            Dictionary<string, List<string>> randomDictionary =
                CreateRandomDictionary();

            var inputException = new Exception();

            var expectedProblemDetail = new ValidationProblemDetails
            {
                Status = StatusCodes.Status400BadRequest,
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1",
                Title = inputException.Message,
            };

            var expectedBadRequestObjectResult =
                new BadRequestObjectResult(expectedProblemDetail);

            foreach (KeyValuePair<string, List<string>> item in randomDictionary)
            {
                inputException.Data.Add(item.Key, item.Value);
                
                expectedProblemDetail.Errors.Add(
                    key: item.Key, 
                    value: item.Value.ToArray());
            }

            // when
            BadRequestObjectResult badRequestObjectResult =
                this.restfulController.BadRequest(inputException);

            // then
            badRequestObjectResult.Should()
                .BeEquivalentTo(expectedBadRequestObjectResult);
        }

        [Fact]
        public void ShouldReturnValidationProblemDetailOnUnathorized()
        {
            // given
            Dictionary<string, List<string>> randomDictionary =
                CreateRandomDictionary();

            var inputException = new Exception();

            var expectedProblemDetail = new ValidationProblemDetails
            {
                Status = StatusCodes.Status401Unauthorized,
                Type = "https://tools.ietf.org/html/rfc7235#section-3.1",
                Title = inputException.Message,
            };

            var expectedUnauthorizedObjectResult =
                new UnauthorizedObjectResult(expectedProblemDetail);

            foreach (KeyValuePair<string, List<string>> item in randomDictionary)
            {
                inputException.Data.Add(item.Key, item.Value);

                expectedProblemDetail.Errors.Add(
                    key: item.Key,
                    value: item.Value.ToArray());
            }

            // when
            UnauthorizedObjectResult unauthorizedObjectResult =
                this.restfulController.Unauthorized(inputException);

            // then
            unauthorizedObjectResult.Should()
                .BeEquivalentTo(expectedUnauthorizedObjectResult);
        }

        [Fact]
        public void ShouldReturnValidationProblemDetailOnPaymentRequired()
        {
            // given
            Dictionary<string, List<string>> randomDictionary =
                CreateRandomDictionary();

            var inputException = new Exception();

            var expectedProblemDetail = new ValidationProblemDetails
            {
                Status = StatusCodes.Status402PaymentRequired,
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.2",
                Title = inputException.Message,
            };

            var expectedPaymentRequiredObjectResult =
                new PaymentRequiredObjectResult(expectedProblemDetail);

            foreach (KeyValuePair<string, List<string>> item in randomDictionary)
            {
                inputException.Data.Add(item.Key, item.Value);

                expectedProblemDetail.Errors.Add(
                    key: item.Key,
                    value: item.Value.ToArray());
            }

            // when
            PaymentRequiredObjectResult paymentRequiredObjectResult =
                this.restfulController.PaymentRequired(inputException);

            // then
            paymentRequiredObjectResult.Should()
                .BeEquivalentTo(expectedPaymentRequiredObjectResult);
        }

        [Fact]
        public void ShouldReturnValidationProblemDetailOnForbidden()
        {
            // given
            Dictionary<string, List<string>> randomDictionary =
                CreateRandomDictionary();

            var inputException = new Exception();

            var expectedProblemDetail = new ValidationProblemDetails
            {
                Status = StatusCodes.Status403Forbidden,
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.3",
                Title = inputException.Message,
            };

            var expectedForbiddenObjectResult =
                new ForbiddenObjectResult(expectedProblemDetail);

            foreach (KeyValuePair<string, List<string>> item in randomDictionary)
            {
                inputException.Data.Add(item.Key, item.Value);

                expectedProblemDetail.Errors.Add(
                    key: item.Key,
                    value: item.Value.ToArray());
            }

            // when
            ForbiddenObjectResult forbiddenObjectResult =
                this.restfulController.Forbidden(inputException);

            // then
            forbiddenObjectResult.Should()
                .BeEquivalentTo(expectedForbiddenObjectResult);
        }

        public static Dictionary<string, List<string>> CreateRandomDictionary()
        {
            var filler = new Filler<Dictionary<string, List<string>>>();

            return filler.Create();
        }
    }
}