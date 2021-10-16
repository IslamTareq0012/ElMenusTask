using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Services.DTOs.PaymentRequestsModel
{
    public class OrderRegistrationRequest
    {
        public string auth_token { get; set; }
        public string delivery_needed { get; set; }

        public int amount_cents { get; set; }

        public string currency { get; set; }

        public List<RequestItems> items { get; set; }
        public class RequestItems
        {
            public string name { get; set; }
            public string amount_cents { get; set; }

            public string description { get; set; }

            public int quantity { get; set; }
        }

        public PaymentRequest paymentRequest { get; set; }
    }

    public class PaymentKeyRequest
    {
        public string auth_token { get; set; }
        public int amount_cents { get; set; }
        public int expiration { get; set; }
        public int order_id { get; set; }

        public string currency { get; set; }
        public int integration_id { get; set; }
        public BillingData billing_data { get; set; }
        public class BillingData
        {
            public int apartment { get; set; }
            public string email { get; set; }
            public int floor { get; set; }
            public string first_name { get; set; }
            public string street { get; set; }
            public string building { get; set; }
            public string phone_number { get; set; }
            public string shipping_method { get; set; }
            public int postal_code { get; set; }
            public string city { get; set; }
            public string country { get; set; }
            public string last_name { get; set; }
            public string state { get; set; }
        }
    }


    public class PaymentRequest
    {
        public string Payempayment_token { get; set; }

        public PaymentSource source { get; set; }

        public class PaymentSource
        {
            public string identifier { get; set; }
            public string subtype { get; set; }
        }
    }

}
