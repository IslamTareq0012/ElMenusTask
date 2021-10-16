using Ordering.Services.DTOs.PaymentRequestsModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Ordering.Services.Payment.Services
{
    public abstract class BasePaymentService
    {
        public async Task<string> GetPaymentKeyAsync(HttpClient client, PaymentKeyRequest PaymentRequestObject)
        {
            var PaymenKeyRequest = new StringContent(
                    JsonSerializer.Serialize(PaymentRequestObject),
                    Encoding.UTF8,
                    "application/json");

            var PaymentKeyResponse = await client.PostAsync(ConfigsAccessor._Configuration.GetSection("AppSettings").GetSection("PaymentKey").Value, PaymenKeyRequest);
            using var PaymentKeyResponseResponseStream = await PaymentKeyResponse.Content.ReadAsStreamAsync();
            var PaymentToken = await JsonSerializer.DeserializeAsync
                <TokenResponse>(PaymentKeyResponseResponseStream);
            return PaymentToken.token;
        }

        public async Task<string> GetAuthTokenAsync(HttpClient client)
        {
            var GetPaymobTokenRequest = new StringContent(
                    JsonSerializer.Serialize(new
                    {
                        api_key = ConfigsAccessor._Configuration.GetSection("AppSettings").GetSection("Paymob_Secret").Value
                    }),
                    Encoding.UTF8,
                    "application/json");
            var TokenResponse_ = await client.PostAsync(ConfigsAccessor._Configuration.GetSection("AppSettings").GetSection("TokenEndpoint").Value, GetPaymobTokenRequest);
            TokenResponse_.EnsureSuccessStatusCode();
            using var responseStream = await TokenResponse_.Content.ReadAsStreamAsync();

            var Token = await JsonSerializer.DeserializeAsync
                <TokenResponse>(responseStream);
            return Token.token;
        }

        public virtual async Task<string> PayAsync(OrderRegistrationRequest order, HttpClient client)
        {
            return "";
        }
    }
}
