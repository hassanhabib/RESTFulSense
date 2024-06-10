// ---------------------------------------------------------------
// Copyright (c) Hassan Habib
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text.Json;
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
        private void ShouldReturnValidationProblemDetailMatchingPascalCaseSerialization()
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

            SetupInputAndExpectedCriteria(
                randomDictionary,
                inputException,
                expectedProblemDetail);

            var restfulController = new RESTFulController();

            // when
            BadRequestObjectResult badRequestObjectResult =
                restfulController.BadRequest(inputException);

            // then
            badRequestObjectResult.Should()
                .BeEquivalentTo(expectedBadRequestObjectResult);
        }

        [Fact]
        private void ShouldReturnValidationProblemDetailMatchingCamelCaseSerialization()
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

            var jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                DictionaryKeyPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };

            SetupInputAndExpectedCriteria(
                randomDictionary,
                inputException,
                expectedProblemDetail,
                jsonSerializerOptions);

            var restfulController = new RESTFulController(jsonSerializerOptions);

            // when
            BadRequestObjectResult badRequestObjectResult =
                restfulController.BadRequest(inputException);

            // then
            badRequestObjectResult.Should()
                .BeEquivalentTo(expectedBadRequestObjectResult);
        }

        [Theory]
        [MemberData(nameof(SerializationCases))]
        private void ShouldReturnValidationProblemDetailOnBadRequest(
            JsonSerializerOptions jsonSerializerOptions)
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

            SetupInputAndExpectedCriteria(
                randomDictionary,
                inputException,
                expectedProblemDetail,
                jsonSerializerOptions);

            var restfulController = new RESTFulController(jsonSerializerOptions);

            // when
            BadRequestObjectResult badRequestObjectResult =
                restfulController.BadRequest(inputException);

            // then
            badRequestObjectResult.Should()
                .BeEquivalentTo(expectedBadRequestObjectResult);
        }

        [Theory]
        [MemberData(nameof(SerializationCases))]
        private void ShouldReturnValidationProblemDetailOnUnathorized(
            JsonSerializerOptions jsonSerializerOptions)
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

            SetupInputAndExpectedCriteria(
                randomDictionary,
                inputException,
                expectedProblemDetail,
                jsonSerializerOptions);

            var restfulController = new RESTFulController(jsonSerializerOptions);

            // when
            UnauthorizedObjectResult unauthorizedObjectResult =
                restfulController.Unauthorized(inputException);

            // then
            unauthorizedObjectResult.Should()
                .BeEquivalentTo(expectedUnauthorizedObjectResult);
        }

        [Theory]
        [MemberData(nameof(SerializationCases))]
        private void ShouldReturnValidationProblemDetailOnPaymentRequired(
            JsonSerializerOptions jsonSerializerOptions)
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

            SetupInputAndExpectedCriteria(
                randomDictionary,
                inputException,
                expectedProblemDetail,
                jsonSerializerOptions);

            var restfulController = new RESTFulController(jsonSerializerOptions);


            // when
            PaymentRequiredObjectResult paymentRequiredObjectResult =
                restfulController.PaymentRequired(inputException);

            // then
            paymentRequiredObjectResult.Should()
                .BeEquivalentTo(expectedPaymentRequiredObjectResult);
        }

        [Theory]
        [MemberData(nameof(SerializationCases))]
        private void ShouldReturnValidationProblemDetailOnForbidden(
            JsonSerializerOptions jsonSerializerOptions)
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

            SetupInputAndExpectedCriteria(
                randomDictionary,
                inputException,
                expectedProblemDetail,
                jsonSerializerOptions);

            var restfulController = new RESTFulController(jsonSerializerOptions);

            // when
            ForbiddenObjectResult forbiddenObjectResult =
                restfulController.Forbidden(inputException);

            // then
            forbiddenObjectResult.Should()
                .BeEquivalentTo(expectedForbiddenObjectResult);
        }

        [Theory]
        [MemberData(nameof(SerializationCases))]
        private void ShouldReturnValidationProblemDetailOnNotFound(
            JsonSerializerOptions jsonSerializerOptions)
        {
            // given
            Dictionary<string, List<string>> randomDictionary =
                CreateRandomDictionary();

            var inputException = new Exception();

            var expectedProblemDetail = new ValidationProblemDetails
            {
                Status = StatusCodes.Status404NotFound,
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.4",
                Title = inputException.Message,
            };

            var expectedNotFoundObjectResult =
                new NotFoundObjectResult(expectedProblemDetail);

            SetupInputAndExpectedCriteria(
                randomDictionary,
                inputException,
                expectedProblemDetail,
                jsonSerializerOptions);

            var restfulController = new RESTFulController(jsonSerializerOptions);

            // when
            NotFoundObjectResult notFoundObjectResult =
                restfulController.NotFound(inputException);

            // then
            notFoundObjectResult.Should()
                .BeEquivalentTo(expectedNotFoundObjectResult);
        }

        [Theory]
        [MemberData(nameof(SerializationCases))]
        private void ShouldReturnValidationProblemDetailOnMethodNotAllowed(
            JsonSerializerOptions jsonSerializerOptions)
        {
            // given
            Dictionary<string, List<string>> randomDictionary =
                CreateRandomDictionary();

            var inputException = new Exception();

            var expectedProblemDetail = new ValidationProblemDetails
            {
                Status = StatusCodes.Status405MethodNotAllowed,
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.5",
                Title = inputException.Message,
            };

            var expectedMethodNotAllowedObjectResult =
                new MethodNotAllowedObjectResult(expectedProblemDetail);

            SetupInputAndExpectedCriteria(
                randomDictionary,
                inputException,
                expectedProblemDetail,
                jsonSerializerOptions);

            var restfulController = new RESTFulController(jsonSerializerOptions);

            // when
            MethodNotAllowedObjectResult methodNotAllowedObjectResult =
                restfulController.MethodNotAllowed(inputException);

            // then
            methodNotAllowedObjectResult.Should()
                .BeEquivalentTo(expectedMethodNotAllowedObjectResult);
        }

        [Theory]
        [MemberData(nameof(SerializationCases))]
        private void ShouldReturnValidationProblemDetailOnNotAcceptable(
            JsonSerializerOptions jsonSerializerOptions)
        {
            // given
            Dictionary<string, List<string>> randomDictionary =
                CreateRandomDictionary();

            var inputException = new Exception();

            var expectedProblemDetail = new ValidationProblemDetails
            {
                Status = StatusCodes.Status406NotAcceptable,
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.6",
                Title = inputException.Message,
            };

            var expectedNotAcceptableObjectResult =
                new NotAcceptableObjectResult(expectedProblemDetail);

            SetupInputAndExpectedCriteria(
                randomDictionary,
                inputException,
                expectedProblemDetail,
                jsonSerializerOptions);

            var restfulController = new RESTFulController(jsonSerializerOptions);

            // when
            NotAcceptableObjectResult notAcceptableObjectResult =
                restfulController.NotAcceptable(inputException);

            // then
            notAcceptableObjectResult.Should()
                .BeEquivalentTo(expectedNotAcceptableObjectResult);
        }

        [Theory]
        [MemberData(nameof(SerializationCases))]
        private void ShouldReturnValidationProblemDetailOnProxyAuthenticationRequired(
            JsonSerializerOptions jsonSerializerOptions)
        {
            // given
            Dictionary<string, List<string>> randomDictionary =
                CreateRandomDictionary();

            var inputException = new Exception();

            var expectedProblemDetail = new ValidationProblemDetails
            {
                Status = StatusCodes.Status407ProxyAuthenticationRequired,
                Type = "https://tools.ietf.org/html/rfc7235#section-3.2",
                Title = inputException.Message,
            };

            var expectedProxyAuthenticationRequiredObjectResult =
                new ProxyAuthenticationRequiredObjectResult(expectedProblemDetail);

            SetupInputAndExpectedCriteria(
                randomDictionary,
                inputException,
                expectedProblemDetail,
                jsonSerializerOptions);

            var restfulController = new RESTFulController(jsonSerializerOptions);

            // when
            ProxyAuthenticationRequiredObjectResult proxyAuthenticationRequiredObjectResult =
                restfulController.ProxyAuthenticationRequired(inputException);

            // then
            proxyAuthenticationRequiredObjectResult.Should()
                .BeEquivalentTo(expectedProxyAuthenticationRequiredObjectResult);
        }

        [Theory]
        [MemberData(nameof(SerializationCases))]
        private void ShouldReturnValidationProblemDetailOnRequestTimeout(
            JsonSerializerOptions jsonSerializerOptions)
        {
            // given
            Dictionary<string, List<string>> randomDictionary =
                CreateRandomDictionary();

            var inputException = new Exception();

            var expectedProblemDetail = new ValidationProblemDetails
            {
                Status = StatusCodes.Status408RequestTimeout,
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.7",
                Title = inputException.Message,
            };

            var expectedRequestTimeoutObjectResult =
                new RequestTimeoutObjectResult(expectedProblemDetail);

            SetupInputAndExpectedCriteria(
                randomDictionary,
                inputException,
                expectedProblemDetail,
                jsonSerializerOptions);

            var restfulController = new RESTFulController(jsonSerializerOptions);

            // when
            RequestTimeoutObjectResult requestTimeoutObjectResult =
                restfulController.RequestTimeout(inputException);

            // then
            requestTimeoutObjectResult.Should()
                .BeEquivalentTo(expectedRequestTimeoutObjectResult);
        }

        [Theory]
        [MemberData(nameof(SerializationCases))]
        private void ShouldReturnValidationProblemDetailOnConflict(
            JsonSerializerOptions jsonSerializerOptions)
        {
            // given
            Dictionary<string, List<string>> randomDictionary =
                CreateRandomDictionary();

            var inputException = new Exception();

            var expectedProblemDetail = new ValidationProblemDetails
            {
                Status = StatusCodes.Status409Conflict,
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.8",
                Title = inputException.Message,
            };

            var expectedConflictObjectResult =
                new ConflictObjectResult(expectedProblemDetail);

            SetupInputAndExpectedCriteria(
                randomDictionary,
                inputException,
                expectedProblemDetail,
                jsonSerializerOptions);

            var restfulController = new RESTFulController(jsonSerializerOptions);

            // when
            ConflictObjectResult conflictObjectResult =
                restfulController.Conflict(inputException);

            // then
            conflictObjectResult.Should()
                .BeEquivalentTo(expectedConflictObjectResult);
        }

        [Theory]
        [MemberData(nameof(SerializationCases))]
        private void ShouldReturnValidationProblemDetailOnGone(
            JsonSerializerOptions jsonSerializerOptions)
        {
            // given
            Dictionary<string, List<string>> randomDictionary =
                CreateRandomDictionary();

            var inputException = new Exception();

            var expectedProblemDetail = new ValidationProblemDetails
            {
                Status = StatusCodes.Status410Gone,
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.9",
                Title = inputException.Message,
            };

            var expectedGoneObjectResult =
                new GoneObjectResult(expectedProblemDetail);

            SetupInputAndExpectedCriteria(
                randomDictionary,
                inputException,
                expectedProblemDetail,
                jsonSerializerOptions);

            var restfulController = new RESTFulController(jsonSerializerOptions);

            // when
            GoneObjectResult goneObjectResult =
                restfulController.Gone(inputException);

            // then
            goneObjectResult.Should()
                .BeEquivalentTo(expectedGoneObjectResult);
        }

        [Theory]
        [MemberData(nameof(SerializationCases))]
        private void ShouldReturnValidationProblemDetailOnLengthRequired(
            JsonSerializerOptions jsonSerializerOptions)
        {
            // given
            Dictionary<string, List<string>> randomDictionary =
                CreateRandomDictionary();

            var inputException = new Exception();

            var expectedProblemDetail = new ValidationProblemDetails
            {
                Status = StatusCodes.Status411LengthRequired,
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.10",
                Title = inputException.Message,
            };

            var expectedLengthRequiredObjectResult =
                new LengthRequiredObjectResult(expectedProblemDetail);

            SetupInputAndExpectedCriteria(
                randomDictionary,
                inputException,
                expectedProblemDetail,
                jsonSerializerOptions);

            var restfulController = new RESTFulController(jsonSerializerOptions);

            // when
            LengthRequiredObjectResult lengthRequiredObjectResult =
                restfulController.LengthRequired(inputException);

            // then
            lengthRequiredObjectResult.Should()
                .BeEquivalentTo(expectedLengthRequiredObjectResult);
        }

        [Theory]
        [MemberData(nameof(SerializationCases))]
        private void ShouldReturnValidationProblemDetailOnPreconditionFailed(
            JsonSerializerOptions jsonSerializerOptions)
        {
            // given
            Dictionary<string, List<string>> randomDictionary =
                CreateRandomDictionary();

            var inputException = new Exception();

            var expectedProblemDetail = new ValidationProblemDetails
            {
                Status = StatusCodes.Status412PreconditionFailed,
                Type = "https://tools.ietf.org/html/rfc7232#section-4.2",
                Title = inputException.Message,
            };

            var expectedPreconditionFailedObjectResult =
                new PreconditionFailedObjectResult(expectedProblemDetail);

            SetupInputAndExpectedCriteria(
                randomDictionary,
                inputException,
                expectedProblemDetail,
                jsonSerializerOptions);

            var restfulController = new RESTFulController(jsonSerializerOptions);

            // when
            PreconditionFailedObjectResult preconditionFailedObjectResult =
                restfulController.PreconditionFailed(inputException);

            // then
            preconditionFailedObjectResult.Should()
                .BeEquivalentTo(expectedPreconditionFailedObjectResult);
        }

        [Theory]
        [MemberData(nameof(SerializationCases))]
        private void ShouldReturnValidationProblemDetailOnRequestEntityTooLarge(
            JsonSerializerOptions jsonSerializerOptions)
        {
            // given
            Dictionary<string, List<string>> randomDictionary =
                CreateRandomDictionary();

            var inputException = new Exception();

            var expectedProblemDetail = new ValidationProblemDetails
            {
                Status = StatusCodes.Status413RequestEntityTooLarge,
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.11",
                Title = inputException.Message,
            };

            var expectedRequestEntityTooLargeObjectResult =
                new RequestEntityTooLargeObjectResult(expectedProblemDetail);

            SetupInputAndExpectedCriteria(
                randomDictionary,
                inputException,
                expectedProblemDetail,
                jsonSerializerOptions);

            var restfulController = new RESTFulController(jsonSerializerOptions);

            // when
            RequestEntityTooLargeObjectResult requestEntityTooLargeObjectResult =
                restfulController.RequestEntityTooLarge(inputException);

            // then
            requestEntityTooLargeObjectResult.Should()
                .BeEquivalentTo(expectedRequestEntityTooLargeObjectResult);
        }

        [Theory]
        [MemberData(nameof(SerializationCases))]
        private void ShouldReturnValidationProblemDetailOnRequestUriTooLong(
            JsonSerializerOptions jsonSerializerOptions)
        {
            // given
            Dictionary<string, List<string>> randomDictionary =
                CreateRandomDictionary();

            var inputException = new Exception();

            var expectedProblemDetail = new ValidationProblemDetails
            {
                Status = StatusCodes.Status414RequestUriTooLong,
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.12",
                Title = inputException.Message,
            };

            var expectedRequestUriTooLongObjectResult =
                new RequestUriTooLongObjectResult(expectedProblemDetail);

            SetupInputAndExpectedCriteria(
                randomDictionary,
                inputException,
                expectedProblemDetail,
                jsonSerializerOptions);

            var restfulController = new RESTFulController(jsonSerializerOptions);

            // when
            RequestUriTooLongObjectResult requestUriTooLongObjectResult =
                restfulController.RequestUriTooLong(inputException);

            // then
            requestUriTooLongObjectResult.Should()
                .BeEquivalentTo(expectedRequestUriTooLongObjectResult);
        }

        [Theory]
        [MemberData(nameof(SerializationCases))]
        private void ShouldReturnValidationProblemDetailOnUnsupportedMediaType(
            JsonSerializerOptions jsonSerializerOptions)
        {
            // given
            Dictionary<string, List<string>> randomDictionary =
                CreateRandomDictionary();

            var inputException = new Exception();

            var expectedProblemDetail = new ValidationProblemDetails
            {
                Status = StatusCodes.Status415UnsupportedMediaType,
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.13",
                Title = inputException.Message,
            };

            var expectedUnsupportedMediaTypeObjectResult =
                new UnsupportedMediaTypeObjectResult(expectedProblemDetail);

            SetupInputAndExpectedCriteria(
                randomDictionary,
                inputException,
                expectedProblemDetail,
                jsonSerializerOptions);

            var restfulController = new RESTFulController(jsonSerializerOptions);

            // when
            UnsupportedMediaTypeObjectResult unsupportedMediaTypeObjectResult =
                restfulController.UnsupportedMediaType(inputException);

            // then
            unsupportedMediaTypeObjectResult.Should()
                .BeEquivalentTo(expectedUnsupportedMediaTypeObjectResult);
        }

        [Theory]
        [MemberData(nameof(SerializationCases))]
        private void ShouldReturnValidationProblemDetailOnRequestedRangeNotSatisfiable(
            JsonSerializerOptions jsonSerializerOptions)
        {
            // given
            Dictionary<string, List<string>> randomDictionary =
                CreateRandomDictionary();

            var inputException = new Exception();

            var expectedProblemDetail = new ValidationProblemDetails
            {
                Status = StatusCodes.Status416RequestedRangeNotSatisfiable,
                Type = "https://tools.ietf.org/html/rfc7233#section-4.4",
                Title = inputException.Message,
            };

            var expectedRequestedRangeNotSatisfiableObjectResult =
                new RequestedRangeNotSatisfiableObjectResult(expectedProblemDetail);

            SetupInputAndExpectedCriteria(
                randomDictionary,
                inputException,
                expectedProblemDetail,
                jsonSerializerOptions);

            var restfulController = new RESTFulController(jsonSerializerOptions);

            // when
            RequestedRangeNotSatisfiableObjectResult requestedRangeNotSatisfiableObjectResult =
                restfulController.RequestedRangeNotSatisfiable(inputException);

            // then
            requestedRangeNotSatisfiableObjectResult.Should()
                .BeEquivalentTo(expectedRequestedRangeNotSatisfiableObjectResult);
        }

        [Theory]
        [MemberData(nameof(SerializationCases))]
        private void ShouldReturnValidationProblemDetailOnExpectationFailed(
            JsonSerializerOptions jsonSerializerOptions)
        {
            // given
            Dictionary<string, List<string>> randomDictionary =
                CreateRandomDictionary();

            var inputException = new Exception();

            var expectedProblemDetail = new ValidationProblemDetails
            {
                Status = StatusCodes.Status417ExpectationFailed,
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.14",
                Title = inputException.Message,
            };

            var expectedExpectationFailedObjectResult =
                new ExpectationFailedObjectResult(expectedProblemDetail);

            SetupInputAndExpectedCriteria(
                randomDictionary,
                inputException,
                expectedProblemDetail,
                jsonSerializerOptions);

            var restfulController = new RESTFulController(jsonSerializerOptions);

            // when
            ExpectationFailedObjectResult expectationFailedObjectResult =
                restfulController.ExpectationFailed(inputException);

            // then
            expectationFailedObjectResult.Should()
                .BeEquivalentTo(expectedExpectationFailedObjectResult);
        }

        [Theory]
        [MemberData(nameof(SerializationCases))]
        private void ShouldReturnValidationProblemDetailOnMisdirectedRequest(
            JsonSerializerOptions jsonSerializerOptions)
        {
            // given
            Dictionary<string, List<string>> randomDictionary =
                CreateRandomDictionary();

            var inputException = new Exception();

            var expectedProblemDetail = new ValidationProblemDetails
            {
                Status = StatusCodes.Status421MisdirectedRequest,
                Type = "https://tools.ietf.org/html/rfc7540#section-9.1.2",
                Title = inputException.Message,
            };

            var expectedMisdirectedRequestObjectResult =
                new MisdirectedRequestObjectResult(expectedProblemDetail);

            SetupInputAndExpectedCriteria(
                randomDictionary,
                inputException,
                expectedProblemDetail,
                jsonSerializerOptions);

            var restfulController = new RESTFulController(jsonSerializerOptions);

            // when
            MisdirectedRequestObjectResult misdirectedRequestObjectResult =
                restfulController.MisdirectedRequest(inputException);

            // then
            misdirectedRequestObjectResult.Should()
                .BeEquivalentTo(expectedMisdirectedRequestObjectResult);
        }

        [Theory]
        [MemberData(nameof(SerializationCases))]
        private void ShouldReturnValidationProblemDetailOnUnprocessableEntity(
            JsonSerializerOptions jsonSerializerOptions)
        {
            // given
            Dictionary<string, List<string>> randomDictionary =
                CreateRandomDictionary();

            var inputException = new Exception();

            var expectedProblemDetail = new ValidationProblemDetails
            {
                Status = StatusCodes.Status422UnprocessableEntity,
                Type = "https://tools.ietf.org/html/rfc4918#section-11.2",
                Title = inputException.Message,
            };

            var expectedUnprocessableEntityObjectResult =
                new UnprocessableEntityObjectResult(expectedProblemDetail);

            SetupInputAndExpectedCriteria(
                randomDictionary,
                inputException,
                expectedProblemDetail,
                jsonSerializerOptions);

            var restfulController = new RESTFulController(jsonSerializerOptions);

            // when
            UnprocessableEntityObjectResult unprocessableEntityObjectResult =
                restfulController.UnprocessableEntity(inputException);

            // then
            unprocessableEntityObjectResult.Should()
                .BeEquivalentTo(expectedUnprocessableEntityObjectResult);
        }

        [Theory]
        [MemberData(nameof(SerializationCases))]
        private void ShouldReturnValidationProblemDetailOnLocked(
            JsonSerializerOptions jsonSerializerOptions)
        {
            // given
            Dictionary<string, List<string>> randomDictionary =
                CreateRandomDictionary();

            var inputException = new Exception();

            var expectedProblemDetail = new ValidationProblemDetails
            {
                Status = StatusCodes.Status423Locked,
                Type = "https://tools.ietf.org/html/rfc4918#section-11.3",
                Title = inputException.Message,
            };

            var expectedLockedObjectResult =
                new LockedObjectResult(expectedProblemDetail);

            SetupInputAndExpectedCriteria(
                randomDictionary,
                inputException,
                expectedProblemDetail,
                jsonSerializerOptions);

            var restfulController = new RESTFulController(jsonSerializerOptions);

            // when
            LockedObjectResult lockedObjectResult =
                restfulController.Locked(inputException);

            // then
            lockedObjectResult.Should()
                .BeEquivalentTo(expectedLockedObjectResult);
        }

        [Theory]
        [MemberData(nameof(SerializationCases))]
        private void ShouldReturnValidationProblemDetailOnFailedDependency(
            JsonSerializerOptions jsonSerializerOptions)
        {
            // given
            Dictionary<string, List<string>> randomDictionary =
                CreateRandomDictionary();

            var inputException = new Exception();

            var expectedProblemDetail = new ValidationProblemDetails
            {
                Status = StatusCodes.Status424FailedDependency,
                Type = "https://tools.ietf.org/html/rfc4918#section-11.4",
                Title = inputException.Message,
            };

            var expectedFailedDependencyObjectResult =
                new FailedDependencyObjectResult(expectedProblemDetail);

            SetupInputAndExpectedCriteria(
                randomDictionary,
                inputException,
                expectedProblemDetail,
                jsonSerializerOptions);

            var restfulController = new RESTFulController(jsonSerializerOptions);

            // when
            FailedDependencyObjectResult failedDependencyObjectResult =
                restfulController.FailedDependency(inputException);

            // then
            failedDependencyObjectResult.Should()
                .BeEquivalentTo(expectedFailedDependencyObjectResult);
        }

        [Theory]
        [MemberData(nameof(SerializationCases))]
        private void ShouldReturnValidationProblemDetailOnUpgradeRequired(
            JsonSerializerOptions jsonSerializerOptions)
        {
            // given
            Dictionary<string, List<string>> randomDictionary =
                CreateRandomDictionary();

            var inputException = new Exception();

            var expectedProblemDetail = new ValidationProblemDetails
            {
                Status = StatusCodes.Status426UpgradeRequired,
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.15",
                Title = inputException.Message,
            };

            var expectedUpgradeRequiredObjectResult =
                new UpgradeRequiredObjectResult(expectedProblemDetail);

            SetupInputAndExpectedCriteria(
                randomDictionary,
                inputException,
                expectedProblemDetail,
                jsonSerializerOptions);

            var restfulController = new RESTFulController(jsonSerializerOptions);

            // when
            UpgradeRequiredObjectResult upgradeRequiredObjectResult =
                restfulController.UpgradeRequired(inputException);

            // then
            upgradeRequiredObjectResult.Should()
                .BeEquivalentTo(expectedUpgradeRequiredObjectResult);
        }

        [Theory]
        [MemberData(nameof(SerializationCases))]
        private void ShouldReturnValidationProblemDetailOnPreconditionRequired(
            JsonSerializerOptions jsonSerializerOptions)
        {
            // given
            Dictionary<string, List<string>> randomDictionary =
                CreateRandomDictionary();

            var inputException = new Exception();

            var expectedProblemDetail = new ValidationProblemDetails
            {
                Status = StatusCodes.Status428PreconditionRequired,
                Type = "https://tools.ietf.org/html/rfc6585#section-3",
                Title = inputException.Message,
            };

            var expectedPreconditionRequiredObjectResult =
                new PreconditionRequiredObjectResult(expectedProblemDetail);

            SetupInputAndExpectedCriteria(
                randomDictionary,
                inputException,
                expectedProblemDetail,
                jsonSerializerOptions);

            var restfulController = new RESTFulController(jsonSerializerOptions);

            // when
            PreconditionRequiredObjectResult preconditionRequiredObjectResult =
                restfulController.PreconditionRequired(inputException);

            // then
            preconditionRequiredObjectResult.Should()
                .BeEquivalentTo(expectedPreconditionRequiredObjectResult);
        }

        [Theory]
        [MemberData(nameof(SerializationCases))]
        private void ShouldReturnValidationProblemDetailOnTooManyRequests(
            JsonSerializerOptions jsonSerializerOptions)
        {
            // given
            Dictionary<string, List<string>> randomDictionary =
                CreateRandomDictionary();

            var inputException = new Exception();

            var expectedProblemDetail = new ValidationProblemDetails
            {
                Status = StatusCodes.Status429TooManyRequests,
                Type = "https://tools.ietf.org/html/rfc6585#section-4",
                Title = inputException.Message,
            };

            var expectedTooManyRequestsObjectResult =
                new TooManyRequestsObjectResult(expectedProblemDetail);

            SetupInputAndExpectedCriteria(
                randomDictionary,
                inputException,
                expectedProblemDetail,
                jsonSerializerOptions);

            var restfulController = new RESTFulController(jsonSerializerOptions);

            // when
            TooManyRequestsObjectResult tooManyRequestsObjectResult =
                restfulController.TooManyRequests(inputException);

            // then
            tooManyRequestsObjectResult.Should()
                .BeEquivalentTo(expectedTooManyRequestsObjectResult);
        }

        [Theory]
        [MemberData(nameof(SerializationCases))]
        private void ShouldReturnValidationProblemDetailOnRequestHeaderFieldsTooLarge(
            JsonSerializerOptions jsonSerializerOptions)
        {
            // given
            Dictionary<string, List<string>> randomDictionary =
                CreateRandomDictionary();

            var inputException = new Exception();

            var expectedProblemDetail = new ValidationProblemDetails
            {
                Status = StatusCodes.Status431RequestHeaderFieldsTooLarge,
                Type = "https://tools.ietf.org/html/rfc6585#section-5",
                Title = inputException.Message,
            };

            var expectedRequestHeaderFieldsTooLargeObjectResult =
                new RequestHeaderFieldsTooLargeObjectResult(expectedProblemDetail);

            SetupInputAndExpectedCriteria(
                randomDictionary,
                inputException,
                expectedProblemDetail,
                jsonSerializerOptions);

            var restfulController = new RESTFulController(jsonSerializerOptions);

            // when
            RequestHeaderFieldsTooLargeObjectResult requestHeaderFieldsTooLargeObjectResult =
                restfulController.RequestHeaderFieldsTooLarge(inputException);

            // then
            requestHeaderFieldsTooLargeObjectResult.Should()
                .BeEquivalentTo(expectedRequestHeaderFieldsTooLargeObjectResult);
        }

        [Theory]
        [MemberData(nameof(SerializationCases))]
        private void ShouldReturnValidationProblemDetailOnUnavailableForLegalReasons(
            JsonSerializerOptions jsonSerializerOptions)
        {
            // given
            Dictionary<string, List<string>> randomDictionary =
                CreateRandomDictionary();

            var inputException = new Exception();

            var expectedProblemDetail = new ValidationProblemDetails
            {
                Status = StatusCodes.Status451UnavailableForLegalReasons,
                Type = "https://tools.ietf.org/html/rfc7725#section-3",
                Title = inputException.Message,
            };

            var expectedUnavailableForLegalReasonsObjectResult =
                new UnavailableForLegalReasonsObjectResult(expectedProblemDetail);

            SetupInputAndExpectedCriteria(
                randomDictionary,
                inputException,
                expectedProblemDetail,
                jsonSerializerOptions);

            var restfulController = new RESTFulController(jsonSerializerOptions);

            // when
            UnavailableForLegalReasonsObjectResult unavailableForLegalReasonsObjectResult =
                restfulController.UnavailableForLegalReasons(inputException);

            // then
            unavailableForLegalReasonsObjectResult.Should()
                .BeEquivalentTo(expectedUnavailableForLegalReasonsObjectResult);
        }

        [Theory]
        [MemberData(nameof(SerializationCases))]
        private void ShouldReturnValidationProblemDetailOnInternalServerError(
            JsonSerializerOptions jsonSerializerOptions)
        {
            // given
            Dictionary<string, List<string>> randomDictionary =
                CreateRandomDictionary();

            var inputException = new Exception();

            var expectedProblemDetail = new ValidationProblemDetails
            {
                Status = StatusCodes.Status500InternalServerError,
                Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1",
                Title = inputException.Message,
            };

            var expectedInternalServerErrorObjectResult =
                new InternalServerErrorObjectResult(expectedProblemDetail);

            SetupInputAndExpectedCriteria(
                randomDictionary,
                inputException,
                expectedProblemDetail,
                jsonSerializerOptions);

            var restfulController = new RESTFulController(jsonSerializerOptions);

            // when
            InternalServerErrorObjectResult internalServerErrorObjectResult =
                restfulController.InternalServerError(inputException);

            // then
            internalServerErrorObjectResult.Should()
                .BeEquivalentTo(expectedInternalServerErrorObjectResult);
        }

        [Theory]
        [MemberData(nameof(SerializationCases))]
        private void ShouldReturnValidationProblemDetailOnNotImplemented(
            JsonSerializerOptions jsonSerializerOptions)
        {
            // given
            Dictionary<string, List<string>> randomDictionary =
                CreateRandomDictionary();

            var inputException = new Exception();

            var expectedProblemDetail = new ValidationProblemDetails
            {
                Status = StatusCodes.Status501NotImplemented,
                Type = "https://tools.ietf.org/html/rfc7231#section-6.6.2",
                Title = inputException.Message,
            };

            var expectedNotImplementedObjectResult =
                new NotImplementedObjectResult(expectedProblemDetail);

            SetupInputAndExpectedCriteria(
                randomDictionary,
                inputException,
                expectedProblemDetail,
                jsonSerializerOptions);

            var restfulController = new RESTFulController(jsonSerializerOptions);

            // when
            NotImplementedObjectResult notImplementedObjectResult =
                restfulController.NotImplemented(inputException);

            // then
            notImplementedObjectResult.Should()
                .BeEquivalentTo(expectedNotImplementedObjectResult);
        }

        [Theory]
        [MemberData(nameof(SerializationCases))]
        private void ShouldReturnValidationProblemDetailOnBadGateway(
            JsonSerializerOptions jsonSerializerOptions)
        {
            // given
            Dictionary<string, List<string>> randomDictionary =
                CreateRandomDictionary();

            var inputException = new Exception();

            var expectedProblemDetail = new ValidationProblemDetails
            {
                Status = StatusCodes.Status502BadGateway,
                Type = "https://tools.ietf.org/html/rfc7231#section-6.6.3",
                Title = inputException.Message,
            };

            var expectedBadGatewayObjectResult =
                new BadGatewayObjectResult(expectedProblemDetail);

            SetupInputAndExpectedCriteria(
                randomDictionary,
                inputException,
                expectedProblemDetail,
                jsonSerializerOptions);

            var restfulController = new RESTFulController(jsonSerializerOptions);

            // when
            BadGatewayObjectResult badGatewayObjectResult =
                restfulController.BadGateway(inputException);

            // then
            badGatewayObjectResult.Should()
                .BeEquivalentTo(expectedBadGatewayObjectResult);
        }

        [Theory]
        [MemberData(nameof(SerializationCases))]
        private void ShouldReturnValidationProblemDetailOnServiceUnavailable(
            JsonSerializerOptions jsonSerializerOptions)
        {
            // given
            Dictionary<string, List<string>> randomDictionary =
                CreateRandomDictionary();

            var inputException = new Exception();

            var expectedProblemDetail = new ValidationProblemDetails
            {
                Status = StatusCodes.Status503ServiceUnavailable,
                Type = "https://tools.ietf.org/html/rfc7231#section-6.6.4",
                Title = inputException.Message,
            };

            var expectedServiceUnavailableObjectResult =
                new ServiceUnavailableObjectResult(expectedProblemDetail);

            SetupInputAndExpectedCriteria(
                randomDictionary,
                inputException,
                expectedProblemDetail,
                jsonSerializerOptions);

            var restfulController = new RESTFulController(jsonSerializerOptions);

            // when
            ServiceUnavailableObjectResult serviceUnavailableObjectResult =
                restfulController.ServiceUnavailable(inputException);

            // then
            serviceUnavailableObjectResult.Should()
                .BeEquivalentTo(expectedServiceUnavailableObjectResult);
        }

        [Theory]
        [MemberData(nameof(SerializationCases))]
        private void ShouldReturnValidationProblemDetailOnGatewayTimeout(
            JsonSerializerOptions jsonSerializerOptions)
        {
            // given
            Dictionary<string, List<string>> randomDictionary =
                CreateRandomDictionary();

            var inputException = new Exception();

            var expectedProblemDetail = new ValidationProblemDetails
            {
                Status = StatusCodes.Status504GatewayTimeout,
                Type = "https://tools.ietf.org/html/rfc7231#section-6.6.5",
                Title = inputException.Message,
            };

            var expectedGatewayTimeoutObjectResult =
                new GatewayTimeoutObjectResult(expectedProblemDetail);

            SetupInputAndExpectedCriteria(
                randomDictionary,
                inputException,
                expectedProblemDetail,
                jsonSerializerOptions);

            var restfulController = new RESTFulController(jsonSerializerOptions);

            // when
            GatewayTimeoutObjectResult gatewayTimeoutObjectResult =
                restfulController.GatewayTimeout(inputException);

            // then
            gatewayTimeoutObjectResult.Should()
                .BeEquivalentTo(expectedGatewayTimeoutObjectResult);
        }

        [Theory]
        [MemberData(nameof(SerializationCases))]
        private void ShouldReturnValidationProblemDetailOnHttpVersionNotSupported(
            JsonSerializerOptions jsonSerializerOptions)
        {
            // given
            Dictionary<string, List<string>> randomDictionary =
                CreateRandomDictionary();

            var inputException = new Exception();

            var expectedProblemDetail = new ValidationProblemDetails
            {
                Status = StatusCodes.Status505HttpVersionNotsupported,
                Type = "https://tools.ietf.org/html/rfc7231#section-6.6.6",
                Title = inputException.Message,
            };

            var expectedHttpVersionNotSupportedObjectResult =
                new HttpVersionNotSupportedObjectResult(expectedProblemDetail);

            SetupInputAndExpectedCriteria(
                randomDictionary,
                inputException,
                expectedProblemDetail,
                jsonSerializerOptions);

            var restfulController = new RESTFulController(jsonSerializerOptions);

            // when
            HttpVersionNotSupportedObjectResult httpVersionNotSupportedObjectResult =
                restfulController.HttpVersionNotSupported(inputException);

            // then
            httpVersionNotSupportedObjectResult.Should()
                .BeEquivalentTo(expectedHttpVersionNotSupportedObjectResult);
        }

        [Theory]
        [MemberData(nameof(SerializationCases))]
        private void ShouldReturnValidationProblemDetailOnVariantAlsoNegotiates(
            JsonSerializerOptions jsonSerializerOptions)
        {
            // given
            Dictionary<string, List<string>> randomDictionary =
                CreateRandomDictionary();

            var inputException = new Exception();

            var expectedProblemDetail = new ValidationProblemDetails
            {
                Status = StatusCodes.Status506VariantAlsoNegotiates,
                Type = "https://tools.ietf.org/html/rfc2295#section-8.1",
                Title = inputException.Message,
            };

            var expectedVariantAlsoNegotiatesObjectResult =
                new VariantAlsoNegotiatesObjectResult(expectedProblemDetail);

            SetupInputAndExpectedCriteria(
                randomDictionary,
                inputException,
                expectedProblemDetail,
                jsonSerializerOptions);

            var restfulController = new RESTFulController(jsonSerializerOptions);

            // when
            VariantAlsoNegotiatesObjectResult variantAlsoNegotiatesObjectResult =
                restfulController.VariantAlsoNegotiates(inputException);

            // then
            variantAlsoNegotiatesObjectResult.Should()
                .BeEquivalentTo(expectedVariantAlsoNegotiatesObjectResult);
        }

        [Theory]
        [MemberData(nameof(SerializationCases))]
        private void ShouldReturnValidationProblemDetailOnInsufficientStorage(
            JsonSerializerOptions jsonSerializerOptions)
        {
            // given
            Dictionary<string, List<string>> randomDictionary =
                CreateRandomDictionary();

            var inputException = new Exception();

            var expectedProblemDetail = new ValidationProblemDetails
            {
                Status = StatusCodes.Status507InsufficientStorage,
                Type = "https://tools.ietf.org/html/rfc4918#section-11.5",
                Title = inputException.Message,
            };

            var expectedInsufficientStorageObjectResult =
                new InsufficientStorageObjectResult(expectedProblemDetail);

            SetupInputAndExpectedCriteria(
                randomDictionary,
                inputException,
                expectedProblemDetail,
                jsonSerializerOptions);

            var restfulController = new RESTFulController(jsonSerializerOptions);

            // when
            InsufficientStorageObjectResult insufficientStorageObjectResult =
                restfulController.InsufficientStorage(inputException);

            // then
            insufficientStorageObjectResult.Should()
                .BeEquivalentTo(expectedInsufficientStorageObjectResult);
        }

        [Theory]
        [MemberData(nameof(SerializationCases))]
        private void ShouldReturnValidationProblemDetailOnLoopDetected(
            JsonSerializerOptions jsonSerializerOptions)
        {
            // given
            Dictionary<string, List<string>> randomDictionary =
                CreateRandomDictionary();

            var inputException = new Exception();

            var expectedProblemDetail = new ValidationProblemDetails
            {
                Status = StatusCodes.Status508LoopDetected,
                Type = "https://tools.ietf.org/html/rfc5842#section-7.2",
                Title = inputException.Message,
            };

            var expectedLoopDetectedObjectResult =
                new LoopDetectedObjectResult(expectedProblemDetail);

            SetupInputAndExpectedCriteria(
                randomDictionary,
                inputException,
                expectedProblemDetail,
                jsonSerializerOptions);

            var restfulController = new RESTFulController(jsonSerializerOptions);

            // when
            LoopDetectedObjectResult loopDetectedObjectResult =
                restfulController.LoopDetected(inputException);

            // then
            loopDetectedObjectResult.Should()
                .BeEquivalentTo(expectedLoopDetectedObjectResult);
        }

        [Theory]
        [MemberData(nameof(SerializationCases))]
        private void ShouldReturnValidationProblemDetailOnNotExtended(
            JsonSerializerOptions jsonSerializerOptions)
        {
            // given
            Dictionary<string, List<string>> randomDictionary =
                CreateRandomDictionary();

            var inputException = new Exception();

            var expectedProblemDetail = new ValidationProblemDetails
            {
                Status = StatusCodes.Status510NotExtended,
                Type = "https://tools.ietf.org/html/rfc2774#section-7",
                Title = inputException.Message,
            };

            var expectedNotExtendedObjectResult =
                new NotExtendedObjectResult(expectedProblemDetail);

            SetupInputAndExpectedCriteria(
                randomDictionary,
                inputException,
                expectedProblemDetail,
                jsonSerializerOptions);

            var restfulController = new RESTFulController(jsonSerializerOptions);

            // when
            NotExtendedObjectResult notExtendedObjectResult =
                restfulController.NotExtended(inputException);

            // then
            notExtendedObjectResult.Should()
                .BeEquivalentTo(expectedNotExtendedObjectResult);
        }

        [Theory]
        [MemberData(nameof(SerializationCases))]
        private void ShouldReturnValidationProblemDetailOnNetworkAuthenticationRequired(
            JsonSerializerOptions jsonSerializerOptions)
        {
            // given
            Dictionary<string, List<string>> randomDictionary =
                CreateRandomDictionary();

            var inputException = new Exception();

            var expectedProblemDetail = new ValidationProblemDetails
            {
                Status = StatusCodes.Status511NetworkAuthenticationRequired,
                Type = "https://tools.ietf.org/html/rfc6585#section-6",
                Title = inputException.Message,
            };

            var expectedNetworkAuthenticationRequiredObjectResult =
                new NetworkAuthenticationRequiredObjectResult(expectedProblemDetail);

            SetupInputAndExpectedCriteria(
                randomDictionary,
                inputException,
                expectedProblemDetail,
                jsonSerializerOptions);

            var restfulController = new RESTFulController(jsonSerializerOptions);

            // when
            NetworkAuthenticationRequiredObjectResult networkAuthenticationRequiredObjectResult =
                restfulController.NetworkAuthenticationRequired(inputException);

            // then
            networkAuthenticationRequiredObjectResult.Should()
                .BeEquivalentTo(expectedNetworkAuthenticationRequiredObjectResult);
        }

        private static Dictionary<string, List<string>> CreateRandomDictionary()
        {
            var filler = new Filler<Dictionary<string, List<string>>>();

            return filler.Create();
        }
    }
}