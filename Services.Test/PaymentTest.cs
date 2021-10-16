using Ordering.Services.Payment.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Services.Test
{
    public class PaymentTest
    {
        private readonly CardPayment _cardPayment;

        public PaymentTest()
        {
            _cardPayment = new CardPayment();
        }

        [Fact]
        public async Task TestWalletPayment()
        {
            await _cardPayment.PayAsync(new Ordering.Services.DTOs.PaymentRequestsModel.OrderRegistrationRequest()
            {
                amount_cents = 100,
                delivery_needed = "false",
                currency = "EGP",
                paymentRequest = new Ordering.Services.DTOs.PaymentRequestsModel.PaymentRequest()
                {
                    source = new Ordering.Services.DTOs.PaymentRequestsModel.PaymentRequest.PaymentSource()
                    {
                        subtype = "WALLET"
                    }
                },
                items = new List<Ordering.Services.DTOs.PaymentRequestsModel.OrderRegistrationRequest.RequestItems>() { new Ordering.Services.DTOs.PaymentRequestsModel.OrderRegistrationRequest.RequestItems() {
                                    amount_cents = "100",
                                    quantity = 1,
                                    name = "Fake Paymob Order"
                                } }
            }, new HttpClient());
        }
        [Fact]
        public async Task TestCardPayment()
        {
            await _cardPayment.PayAsync(new Ordering.Services.DTOs.PaymentRequestsModel.OrderRegistrationRequest()
            {
                amount_cents = 100,
                delivery_needed = "false",
                currency = "EGP",
                paymentRequest = new Ordering.Services.DTOs.PaymentRequestsModel.PaymentRequest()
                {
                    source = new Ordering.Services.DTOs.PaymentRequestsModel.PaymentRequest.PaymentSource()
                    {
                        subtype = "CARD"
                    }
                },
                items = new List<Ordering.Services.DTOs.PaymentRequestsModel.OrderRegistrationRequest.RequestItems>() { new Ordering.Services.DTOs.PaymentRequestsModel.OrderRegistrationRequest.RequestItems() {
                                    amount_cents = "100",
                                    quantity = 1,
                                    name = "Fake Paymob Order"
                                } }
            }, new HttpClient());
        }
    }
}
