using Application.Infrastructure.Gateways.Implementations;
using Application.Services.DTOs;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests
{
    public class PremiumPaymentGatewayTest
    {
         [Theory]
        [InlineData(499)]
        [InlineData(500)]
        public void ShouldThrowExceptionIfAmountlessThan500(decimal amount)
        {

            var paymentDto = new PaymentDto()
            {
                Amount = amount
            };
            var premiumPaymentGateway = new PremiumPaymentGateway();

            Action act = () => premiumPaymentGateway.ProcessPaymentAsync(paymentDto);

            act.Should().Throw<ArgumentException>();
        }

        [Theory]
        [InlineData(5000)]
        [InlineData(875)]
        public void ShouldReturnBooleanIfGreaterThan500(decimal amount)
        {

            var paymentDto = new PaymentDto()
            {
                Amount = amount
            };
            var premiumPaymentGateway = new PremiumPaymentGateway();

            var result = premiumPaymentGateway.ProcessPaymentAsync(paymentDto).Result;

            result.GetType().Should().Equals(typeof(bool));
        }
    
    }
}
