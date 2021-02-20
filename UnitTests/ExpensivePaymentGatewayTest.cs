using Application.Infrastructure.Gateways.Implementations;
using Application.Services.DTOs;
using FluentAssertions;
using System;
using Xunit;

namespace UnitTests
{
    public class ExpensivePaymentGatewayTest
    {
        [Theory]
        [InlineData(20)]
        [InlineData(999)]
        public void ShouldThrowExceptionIfAmountlessThan21orGreaterThan500(decimal amount)
        {

            var paymentDto = new PaymentDto()
            {
                Amount = amount
            };
            var expensivePaymentGateway = new ExpensivePaymentGateway();

            Action act = () => expensivePaymentGateway.ProcessPaymentAsync(paymentDto);

            act.Should().Throw<ArgumentException>();
        }

        [Theory]
        [InlineData(21)]
        [InlineData(499)]
        public void ShouldReturnBooleanIfNotLessThan21OrGreaterThan500(decimal amount)
        {

            var paymentDto = new PaymentDto()
            {
                Amount = amount
            };
            var expensivePaymentGateway = new ExpensivePaymentGateway();

            var result = expensivePaymentGateway.ProcessPaymentAsync(paymentDto).Result;

            result.GetType().Should().Equals(typeof(bool));
        }
    }
}
