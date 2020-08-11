using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RESTFulSense.Clients;

namespace TryingThingsOut
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var client = new RESTFulApiClient();
            client.BaseAddress = new Uri("https://estimizor-dev.azurewebsites.net");

            List<Profile> profiles = 
                await client.GetContentAsync<List<Profile>>($"api/profiles/{Guid.NewGuid()}");

            Console.WriteLine(profiles.Count);
        }
    }

    public class Profile
    {
        public Guid Id { get; set; }
    }
}
