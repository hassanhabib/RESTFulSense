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

        [Fact]
        public void ShouldReturnValidationProblemDetailOnNotFound()
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

            foreach (KeyValuePair<string, List<string>> item in randomDictionary)
            {
                inputException.Data.Add(item.Key, item.Value);

                expectedProblemDetail.Errors.Add(
                    key: item.Key,
                    value: item.Value.ToArray());
            }

            // when
            NotFoundObjectResult notFoundObjectResult =
                this.restfulController.NotFound(inputException);

            // then
            notFoundObjectResult.Should()
                .BeEquivalentTo(expectedNotFoundObjectResult);
        }

        [Fact]
        public void ShouldReturnValidationProblemDetailOnMethodNotAllowed()
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

            foreach (KeyValuePair<string, List<string>> item in randomDictionary)
            {
                inputException.Data.Add(item.Key, item.Value);

                expectedProblemDetail.Errors.Add(
                    key: item.Key,
                    value: item.Value.ToArray());
            }

            // when
            MethodNotAllowedObjectResult methodNotAllowedObjectResult =
                this.restfulController.MethodNotAllowed(inputException);

            // then
            methodNotAllowedObjectResult.Should()
                .BeEquivalentTo(expectedMethodNotAllowedObjectResult);
        }

        [Fact]
        public void ShouldReturnValidationProblemDetailOnNotAcceptable()
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

            foreach (KeyValuePair<string, List<string>> item in randomDictionary)
            {
                inputException.Data.Add(item.Key, item.Value);

                expectedProblemDetail.Errors.Add(
                    key: item.Key,
                    value: item.Value.ToArray());
            }

            // when
            NotAcceptableObjectResult notAcceptableObjectResult =
                this.restfulController.NotAcceptable(inputException);

            // then
            notAcceptableObjectResult.Should()
                .BeEquivalentTo(expectedNotAcceptableObjectResult);
        }

        [Fact]
        public void ShouldReturnValidationProblemDetailOnProxyAuthenticationRequired()
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

            foreach (KeyValuePair<string, List<string>> item in randomDictionary)
            {
                inputException.Data.Add(item.Key, item.Value);

                expectedProblemDetail.Errors.Add(
                    key: item.Key,
                    value: item.Value.ToArray());
            }

            // when
            ProxyAuthenticationRequiredObjectResult proxyAuthenticationRequiredObjectResult =
                this.restfulController.ProxyAuthenticationRequired(inputException);

            // then
            proxyAuthenticationRequiredObjectResult.Should()
                .BeEquivalentTo(expectedProxyAuthenticationRequiredObjectResult);
        }

        [Fact]
        public void ShouldReturnValidationProblemDetailOnRequestTimeout()
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

            foreach (KeyValuePair<string, List<string>> item in randomDictionary)
            {
                inputException.Data.Add(item.Key, item.Value);

                expectedProblemDetail.Errors.Add(
                    key: item.Key,
                    value: item.Value.ToArray());
            }

            // when
            RequestTimeoutObjectResult requestTimeoutObjectResult =
                this.restfulController.RequestTimeout(inputException);

            // then
            requestTimeoutObjectResult.Should()
                .BeEquivalentTo(expectedRequestTimeoutObjectResult);
        }

        [Fact]
        public void ShouldReturnValidationProblemDetailOnConflict()
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

            foreach (KeyValuePair<string, List<string>> item in randomDictionary)
            {
                inputException.Data.Add(item.Key, item.Value);

                expectedProblemDetail.Errors.Add(
                    key: item.Key,
                    value: item.Value.ToArray());
            }

            // when
            ConflictObjectResult conflictObjectResult =
                this.restfulController.Conflict(inputException);

            // then
            conflictObjectResult.Should()
                .BeEquivalentTo(expectedConflictObjectResult);
        }

        [Fact]
        public void ShouldReturnValidationProblemDetailOnGone()
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

            foreach (KeyValuePair<string, List<string>> item in randomDictionary)
            {
                inputException.Data.Add(item.Key, item.Value);

                expectedProblemDetail.Errors.Add(
                    key: item.Key,
                    value: item.Value.ToArray());
            }

            // when
            GoneObjectResult goneObjectResult =
                this.restfulController.Gone(inputException);

            // then
            goneObjectResult.Should()
                .BeEquivalentTo(expectedGoneObjectResult);
        }

        [Fact]
        public void ShouldReturnValidationProblemDetailOnLengthRequired()
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

            foreach (KeyValuePair<string, List<string>> item in randomDictionary)
            {
                inputException.Data.Add(item.Key, item.Value);

                expectedProblemDetail.Errors.Add(
                    key: item.Key,
                    value: item.Value.ToArray());
            }

            // when
            LengthRequiredObjectResult lengthRequiredObjectResult =
                this.restfulController.LengthRequired(inputException);

            // then
            lengthRequiredObjectResult.Should()
                .BeEquivalentTo(expectedLengthRequiredObjectResult);
        }

        [Fact]
        public void ShouldReturnValidationProblemDetailOnPreconditionFailed()
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

            foreach (KeyValuePair<string, List<string>> item in randomDictionary)
            {
                inputException.Data.Add(item.Key, item.Value);

                expectedProblemDetail.Errors.Add(
                    key: item.Key,
                    value: item.Value.ToArray());
            }

            // when
            PreconditionFailedObjectResult preconditionFailedObjectResult =
                this.restfulController.PreconditionFailed(inputException);

            // then
            preconditionFailedObjectResult.Should()
                .BeEquivalentTo(expectedPreconditionFailedObjectResult);
        }

        [Fact]
        public void ShouldReturnValidationProblemDetailOnRequestEntityTooLarge()
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

            foreach (KeyValuePair<string, List<string>> item in randomDictionary)
            {
                inputException.Data.Add(item.Key, item.Value);

                expectedProblemDetail.Errors.Add(
                    key: item.Key,
                    value: item.Value.ToArray());
            }

            // when
            RequestEntityTooLargeObjectResult requestEntityTooLargeObjectResult =
                this.restfulController.RequestEntityTooLarge(inputException);

            // then
            requestEntityTooLargeObjectResult.Should()
                .BeEquivalentTo(expectedRequestEntityTooLargeObjectResult);
        }

        [Fact]
        public void ShouldReturnValidationProblemDetailOnRequestUriTooLong()
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

            foreach (KeyValuePair<string, List<string>> item in randomDictionary)
            {
                inputException.Data.Add(item.Key, item.Value);

                expectedProblemDetail.Errors.Add(
                    key: item.Key,
                    value: item.Value.ToArray());
            }

            // when
            RequestUriTooLongObjectResult requestUriTooLongObjectResult =
                this.restfulController.RequestUriTooLong(inputException);

            // then
            requestUriTooLongObjectResult.Should()
                .BeEquivalentTo(expectedRequestUriTooLongObjectResult);
        }

        [Fact]
        public void ShouldReturnValidationProblemDetailOnUnsupportedMediaType()
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

            foreach (KeyValuePair<string, List<string>> item in randomDictionary)
            {
                inputException.Data.Add(item.Key, item.Value);

                expectedProblemDetail.Errors.Add(
                    key: item.Key,
                    value: item.Value.ToArray());
            }

            // when
            UnsupportedMediaTypeObjectResult unsupportedMediaTypeObjectResult =
                this.restfulController.UnsupportedMediaType(inputException);

            // then
            unsupportedMediaTypeObjectResult.Should()
                .BeEquivalentTo(expectedUnsupportedMediaTypeObjectResult);
        }

        [Fact]
        public void ShouldReturnValidationProblemDetailOnRequestedRangeNotSatisfiable()
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

            foreach (KeyValuePair<string, List<string>> item in randomDictionary)
            {
                inputException.Data.Add(item.Key, item.Value);

                expectedProblemDetail.Errors.Add(
                    key: item.Key,
                    value: item.Value.ToArray());
            }

            // when
            RequestedRangeNotSatisfiableObjectResult requestedRangeNotSatisfiableObjectResult =
                this.restfulController.RequestedRangeNotSatisfiable(inputException);

            // then
            requestedRangeNotSatisfiableObjectResult.Should()
                .BeEquivalentTo(expectedRequestedRangeNotSatisfiableObjectResult);
        }

        [Fact]
        public void ShouldReturnValidationProblemDetailOnExpectationFailed()
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

            foreach (KeyValuePair<string, List<string>> item in randomDictionary)
            {
                inputException.Data.Add(item.Key, item.Value);

                expectedProblemDetail.Errors.Add(
                    key: item.Key,
                    value: item.Value.ToArray());
            }

            // when
            ExpectationFailedObjectResult expectationFailedObjectResult =
                this.restfulController.ExpectationFailed(inputException);

            // then
            expectationFailedObjectResult.Should()
                .BeEquivalentTo(expectedExpectationFailedObjectResult);
        }

        [Fact]
        public void ShouldReturnValidationProblemDetailOnMisdirectedRequest()
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

            foreach (KeyValuePair<string, List<string>> item in randomDictionary)
            {
                inputException.Data.Add(item.Key, item.Value);

                expectedProblemDetail.Errors.Add(
                    key: item.Key,
                    value: item.Value.ToArray());
            }

            // when
            MisdirectedRequestObjectResult misdirectedRequestObjectResult =
                this.restfulController.MisdirectedRequest(inputException);

            // then
            misdirectedRequestObjectResult.Should()
                .BeEquivalentTo(expectedMisdirectedRequestObjectResult);
        }

        [Fact]
        public void ShouldReturnValidationProblemDetailOnUnprocessableEntity()
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

            foreach (KeyValuePair<string, List<string>> item in randomDictionary)
            {
                inputException.Data.Add(item.Key, item.Value);

                expectedProblemDetail.Errors.Add(
                    key: item.Key,
                    value: item.Value.ToArray());
            }

            // when
            UnprocessableEntityObjectResult unprocessableEntityObjectResult =
                this.restfulController.UnprocessableEntity(inputException);

            // then
            unprocessableEntityObjectResult.Should()
                .BeEquivalentTo(expectedUnprocessableEntityObjectResult);
        }

        [Fact]
        public void ShouldReturnValidationProblemDetailOnLocked()
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

            foreach (KeyValuePair<string, List<string>> item in randomDictionary)
            {
                inputException.Data.Add(item.Key, item.Value);

                expectedProblemDetail.Errors.Add(
                    key: item.Key,
                    value: item.Value.ToArray());
            }

            // when
            LockedObjectResult lockedObjectResult =
                this.restfulController.Locked(inputException);

            // then
            lockedObjectResult.Should()
                .BeEquivalentTo(expectedLockedObjectResult);
        }

        [Fact]
        public void ShouldReturnValidationProblemDetailOnFailedDependency()
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

            foreach (KeyValuePair<string, List<string>> item in randomDictionary)
            {
                inputException.Data.Add(item.Key, item.Value);

                expectedProblemDetail.Errors.Add(
                    key: item.Key,
                    value: item.Value.ToArray());
            }

            // when
            FailedDependencyObjectResult failedDependencyObjectResult =
                this.restfulController.FailedDependency(inputException);

            // then
            failedDependencyObjectResult.Should()
                .BeEquivalentTo(expectedFailedDependencyObjectResult);
        }

        [Fact]
        public void ShouldReturnValidationProblemDetailOnUpgradeRequired()
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

            foreach (KeyValuePair<string, List<string>> item in randomDictionary)
            {
                inputException.Data.Add(item.Key, item.Value);

                expectedProblemDetail.Errors.Add(
                    key: item.Key,
                    value: item.Value.ToArray());
            }

            // when
            UpgradeRequiredObjectResult upgradeRequiredObjectResult =
                this.restfulController.UpgradeRequired(inputException);

            // then
            upgradeRequiredObjectResult.Should()
                .BeEquivalentTo(expectedUpgradeRequiredObjectResult);
        }

        public static Dictionary<string, List<string>> CreateRandomDictionary()
        {
            var filler = new Filler<Dictionary<string, List<string>>>();

            return filler.Create();
        }
    }
}