// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using Moq.Protected;
using RESTFulSense.Models.Attributes;
using Xunit;

namespace RESTFulSense.Tests.Controllers
{
#nullable enable
    public partial class RESTFulApiFactoryClientTests
    {
        [Theory]
        [MemberData(nameof(GetValidFormModelsData))]
        public async Task ApiFactoryClient_Should_PostFormAsync(Person person)
        {
            // given
            const string expectedResponseContent = "Done";
            object requestContent = person;

            this.httpMessageHandlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
               .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK,
                        Content = new StringContent($"\"{expectedResponseContent}\"")
                    }
                );

            // when
            string actualResponse =
                await this.apiClient.PostFormAsync<object, string>("/", requestContent);

            // then
            Assert.Equal(expectedResponseContent, actualResponse);
        }

        public static IEnumerable<object[]> GetValidFormModelsData()
        {
            foreach (var entity in GetValidFormModels())
            {
                yield return new object[] { entity };
            }
        }

        private static IEnumerable<Person> GetValidFormModels()
        {
            string personName = CreateRandomString();
            var people = new List<Person>();

            var entityWithoutNullableProperties = new Person(personName)
            {
                Age = GetRandomNumber(),
                Salary = GetRandomMoney()
            };
            people.Add(entityWithoutNullableProperties);

            foreach (Person person in people)
            {
                yield return person;
            }
        }

        public sealed class Person
        {
            public Person(string name)
            {
                if (string.IsNullOrEmpty(name))
                {
                    throw new ArgumentException($"'{nameof(name)}' cannot be null or empty.", nameof(name));
                }

                Name = name;
            }

            [RESTFulStringContent(name: "name")]
            public string Name { get; set; }

            [RESTFulStringContent(name: "age")]
            public int? Age { get; set; }

            [RESTFulStringContent(name: "salary")]
            public Money? Salary { get; set; }
        }

        public class Money
        {
            public readonly decimal Amount;
            public readonly string Currency;

            public Money(decimal amount, string currency)
            {
                Amount = amount;
                Currency = currency;
            }

            public override string ToString()
                => $"{Amount}{Currency}";
        }
    }
}
