using Application.Infrastructure.Gateways.Implementations;
using Application.Services;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests
{
    public class PaymentServiceHelperTest
    {
        [Theory]
        [InlineData(5)]
        [InlineData(10)]
        public void ShouldSuggestCheapPaymentGateway(decimal amount)
        {

            var result = (PaymentServiceHelper.GetPaymentGateway(amount)) is CheapPaymentGateway;
            result.Should().BeTrue();
        }

        [Theory]
        [InlineData(21)]
        [InlineData(499)]
        public void ShouldSuggestExpensivePaymentGateway(decimal amount)
        {

            var result = (PaymentServiceHelper.GetPaymentGateway(amount))  is ExpensivePaymentGateway;
            result.Should().BeTrue();
        }

        [Theory]
        [InlineData(800)]
        [InlineData(1000)]
        public void ShouldSuggestPremiumPaymentGateway(decimal amount)
        {

            var result = (PaymentServiceHelper.GetPaymentGateway(amount)) is PremiumPaymentGateway;
            result.Should().BeTrue();

        }


        [Theory]
        [InlineData(20)]
        public void ShouldSuggestNullifAmountis20(decimal amount)
        {

            var result = PaymentServiceHelper.GetPaymentGateway(amount);
            result.Should().BeNull();
        }

    }
}
