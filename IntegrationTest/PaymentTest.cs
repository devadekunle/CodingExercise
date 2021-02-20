using FluentAssertions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WebUI;
using WebUI.Models.Requests;
using Xunit;

namespace IntegrationTest
{
    public class PaymentTest : IClassFixture<CustomFactory<Startup>>
    {
        private readonly HttpClient _client;
        private readonly CustomFactory<Startup> _factory;
        public PaymentTest(CustomFactory<Startup> factory)
        {
            _factory = factory;
            _client = _factory.CreateClient(new Microsoft.AspNetCore.Mvc.Testing.WebApplicationFactoryClientOptions()
            {
                AllowAutoRedirect = false
            });

        }
        [Fact]
        public async Task ShouldBeSuccessStatusCodeIfRequestIsValid()
        {
            var request = new PaymentRequest
            {
                Amount = 500,
                CardHolder = "Adekunle Adebisi",
                CreditCardNumber = "5242276492874624",
                ExpirationDate = DateTime.Now.Date.AddDays(4),
                SecurityCode = "029"
            };

            var json = JsonConvert.SerializeObject(request);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client    .PostAsync("/payments", data);
            response.IsSuccessStatusCode.Should().BeTrue();

        }

      
        [Fact]
        public async Task ShouldNotBeSuccessStatusCodeifRequestIsInvalid()
        {
            var request = new PaymentRequest
            {
                Amount = 500,
                CardHolder = "Adekunle Adebisi",
                CreditCardNumber = "1142276492874624",
                ExpirationDate = DateTime.Now.Date.AddDays(-4),
                SecurityCode = "029"
            };

            var json = JsonConvert.SerializeObject(request);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("/payments", data);
            response.IsSuccessStatusCode.Should().BeFalse();

        }
    }
}
