using Ordering.Services.DTOs.PaymentRequestsModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static Ordering.Services.DTOs.PaymentRequestsModel.PayemntMethodsLookUPs;

namespace Ordering.Services.Payment.Services
{
    public class WalletPayment : BasePaymentService
    {
        //Dynamic / Runtime Polymorphism

        public override async Task<string> PayAsync(OrderRegistrationRequest order, HttpClient client)
        {

            var PlaceOrderRequest = new StringContent(
        JsonSerializer.Serialize(order),
        Encoding.UTF8,
        "application/json");
            var PlaceOrderResponse = await client.PostAsync("https://accept.paymobsolutions.com/api/ecommerce/orders", PlaceOrderRequest);

            using var PlaceOrderResponseResponseStream = await PlaceOrderResponse.Content.ReadAsStreamAsync();

            var PlaceOrderResponseSerialized = await JsonSerializer.DeserializeAsync
                <OrderRegistrationResponse>(PlaceOrderResponseResponseStream);

            var AuthToken = await GetAuthTokenAsync(client);
            order.paymentRequest.Payempayment_token = await GetPaymentKeyAsync(client, new PaymentKeyRequest()
            {
                auth_token = AuthToken,
                amount_cents = order.amount_cents,
                expiration = 3600,
                order_id = PlaceOrderResponseSerialized.id,
                currency = order.currency,
                integration_id = (int)IntegrationsLookUp.WALLET,
                billing_data = new PaymentKeyRequest.BillingData()
                {
                    apartment = 803,
                    email = "claudette09@exa.com",
                    floor = 42,
                    first_name = "Clifford",
                    state = "Ethan Land",
                    building = "building",
                    phone_number = "+86(8)9135210487",
                    shipping_method = "PKG",
                    street = "Utah",
                    city = "Jaskolskiburgh",
                    country = "CR",
                    postal_code = 01898,
                    last_name = "Nicolas"
                }
            });
            var PaymentRequest = new StringContent(
                    JsonSerializer.Serialize(order.paymentRequest),
                    Encoding.UTF8,
                    "application/json");

            var PaymentResponse = await client.PostAsync("https://accept.paymobsolutions.com/api/acceptance/payments/pay", PaymentRequest);

            using var PaymentResponseStream = await PaymentResponse.Content.ReadAsStreamAsync();

            var DesrializedWalletPaymentReponse = await JsonSerializer.DeserializeAsync<WalletPaymentResponse>(PaymentResponseStream);
            return DesrializedWalletPaymentReponse.redirect_url;
        }
    }
}
