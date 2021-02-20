using Application.Infrastructure.Gateways.Implementations;
using Application.Services.DTOs;
using FluentAssertions;
using System;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests
{
    public class CheapPaymentGatewayTest
    {
        [Fact]
        public void ShouldThrowExceptionIfAmountAbove20()
        {
           
            var paymentDto = new PaymentDto()
            {
                Amount = 500
            };
            var cheapGateway = new CheapPaymentGateway();

            Action act = () => cheapGateway.ProcessPaymentAsync(paymentDto);

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void ShouldReturnBooleanIfNotMoreThan20()
        {

            var paymentDto = new PaymentDto()
            {
                Amount = 19
            };
            var cheapGateway = new CheapPaymentGateway();

            var result =  cheapGateway.ProcessPaymentAsync(paymentDto).Result;

            result.GetType().Should().Equals(typeof(bool));
        }


    }
}
