using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Services.DTOs.PaymentRequestsModel
{
    public class TokenResponse
    {
        public string token { get; set; }
    }
    class OrderRegistrationResponse
    {
        public int id { get; set; }
        public DateTime created_at { get; set; }
        public bool delivery_needed { get; set; }

        public merchantData merchant { get; set; }

        public int amount_cents { get; set; }
        public string currency { get; set; }
        public bool is_payment_locked { get; set; }

        public int integration_id { get; set; }
        public class merchantData
        {
            public int id { get; set; }
            public DateTime created_at { get; set; }
            public List<string> phonse { get; set; }
            public List<string> company_emails { get; set; }
            public string company_name { get; set; }

            public string state { get; set; }
            public string country { get; set; }
            public string postal_code { get; set; }
            public string street { get; set; }
        }
    }


    public class PaymobWebHookData
    {
        public string type { get; set; }
        public Obj obj { get; set; }
    }

    public class Merchant
    {
        public int id { get; set; }
        public DateTime created_at { get; set; }
        public List<string> phones { get; set; }
        public List<string> company_emails { get; set; }
        public string company_name { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public string city { get; set; }
        public string postal_code { get; set; }
        public string street { get; set; }
    }

    public class ShippingData
    {
        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string street { get; set; }
        public string building { get; set; }
        public string floor { get; set; }
        public string apartment { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public string email { get; set; }
        public string phone_number { get; set; }
        public string postal_code { get; set; }
        public string extra_description { get; set; }
        public string shipping_method { get; set; }
        public int order_id { get; set; }
        public int order { get; set; }
    }

    public class Item
    {
        public string name { get; set; }
        public string description { get; set; }
        public int amount_cents { get; set; }
        public int quantity { get; set; }
    }

    public class Data
    {
        public string avs_result_code { get; set; }
        public int batch_no { get; set; }
        public string card_type { get; set; }
        public int gateway_integration_pk { get; set; }
        public string message { get; set; }
        public MigsOrder migs_order { get; set; }
        public MigsTransaction migs_transaction { get; set; }
        public DateTime created_at { get; set; }
        public string card_num { get; set; }
        public string authorize_id { get; set; }
        public string migs_result { get; set; }
        public double amount { get; set; }
        public double captured_amount { get; set; }
        public string secure_hash { get; set; }
        public double refunded_amount { get; set; }
        public string klass { get; set; }
        public string merchant { get; set; }
        public string merchant_txn_ref { get; set; }
        public string currency { get; set; }
        public string order_info { get; set; }
        public string acq_response_code { get; set; }
        public string receipt_no { get; set; }
        public double authorised_amount { get; set; }
        public string txn_response_code { get; set; }
        public string avs_acq_response_code { get; set; }
        public string transaction_no { get; set; }
    }

    public class Order
    {
        public int id { get; set; }
        public DateTime created_at { get; set; }
        public bool delivery_needed { get; set; }
        public Merchant merchant { get; set; }
        public object collector { get; set; }
        public int amount_cents { get; set; }
        public ShippingData shipping_data { get; set; }
        public object shipping_details { get; set; }
        public string currency { get; set; }
        public bool is_payment_locked { get; set; }
        public bool is_return { get; set; }
        public bool is_cancel { get; set; }
        public bool is_returned { get; set; }
        public bool is_canceled { get; set; }
        public object merchant_order_id { get; set; }
        public object wallet_notification { get; set; }
        public int paid_amount_cents { get; set; }
        public bool notify_user_with_email { get; set; }
        public List<Item> items { get; set; }
        public string order_url { get; set; }
        public int commission_fees { get; set; }
        public int delivery_fees_cents { get; set; }
        public int delivery_vat_cents { get; set; }
        public string payment_method { get; set; }
        public object merchant_staff_tag { get; set; }
        public string api_source { get; set; }
        public object pickup_data { get; set; }
        public List<object> delivery_status { get; set; }
        public Data data { get; set; }
    }

    public class SourceData
    {
        public string pan { get; set; }
        public object tenure { get; set; }
        public string type { get; set; }
        public string sub_type { get; set; }
    }

    public class MigsOrder
    {
        public double totalAuthorizedAmount { get; set; }
        public double totalRefundedAmount { get; set; }
        public string status { get; set; }
        public DateTime creationTime { get; set; }
        public string id { get; set; }
        public double amount { get; set; }
        public double totalCapturedAmount { get; set; }
        public bool acceptPartialAmount { get; set; }
        public string currency { get; set; }
    }

    public class Acquirer
    {
        public string date { get; set; }
        public string merchantId { get; set; }
        public string timeZone { get; set; }
        public string transactionId { get; set; }
        public string id { get; set; }
        public string settlementDate { get; set; }
        public int batch { get; set; }
    }

    public class MigsTransaction
    {
        public string type { get; set; }
        public string authorizationCode { get; set; }
        public string frequency { get; set; }
        public string terminal { get; set; }
        public double amount { get; set; }
        public string receipt { get; set; }
        public Acquirer acquirer { get; set; }
        public string source { get; set; }
        public string currency { get; set; }
        public string id { get; set; }
    }

    public class BillingData
    {
        public string first_name { get; set; }
        public string building { get; set; }
        public string email { get; set; }
        public string extra_description { get; set; }
        public string last_name { get; set; }
        public string apartment { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string postal_code { get; set; }
        public string country { get; set; }
        public string street { get; set; }
        public string phone_number { get; set; }
        public string floor { get; set; }
    }

    public class PaymentKeyClaims
    {
        public string pmk_ip { get; set; }
        public int user_id { get; set; }
        public BillingData billing_data { get; set; }
        public bool lock_order_when_paid { get; set; }
        public int order_id { get; set; }
        public int exp { get; set; }
        public int integration_id { get; set; }
        public string currency { get; set; }
        public int amount_cents { get; set; }
    }

    public class Obj
    {
        public int id { get; set; }
        public bool pending { get; set; }
        public int amount_cents { get; set; }
        public bool success { get; set; }
        public bool is_auth { get; set; }
        public bool is_capture { get; set; }
        public bool is_standalone_payment { get; set; }
        public bool is_voided { get; set; }
        public bool is_refunded { get; set; }
        public bool is_3d_secure { get; set; }
        public int integration_id { get; set; }
        public int profile_id { get; set; }
        public bool has_parent_transaction { get; set; }
        public Order order { get; set; }
        public DateTime created_at { get; set; }
        public List<object> transaction_processed_callback_responses { get; set; }
        public string currency { get; set; }
        public SourceData source_data { get; set; }
        public string api_source { get; set; }
        public object terminal_id { get; set; }
        public bool is_void { get; set; }
        public bool is_refund { get; set; }
        public Data data { get; set; }
        public bool is_hidden { get; set; }
        public PaymentKeyClaims payment_key_claims { get; set; }
        public bool error_occured { get; set; }
        public bool is_live { get; set; }
        public object other_endpoint_reference { get; set; }
        public int refunded_amount_cents { get; set; }
        public int source_id { get; set; }
        public bool is_captured { get; set; }
        public int captured_amount { get; set; }
        public object merchant_staff_tag { get; set; }
        public int owner { get; set; }
        public object parent_transaction { get; set; }
    }

    public class WalletPaymentResponse
    {
        public int id { get; set; }
        public string pending { get; set; }
        public int amount_cents { get; set; }
        public string success { get; set; }
        public string is_auth { get; set; }
        public string is_capture { get; set; }
        public string is_standalone_payment { get; set; }
        public string is_voided { get; set; }
        public string is_refunded { get; set; }
        public string is_3d_secure { get; set; }
        public int integration_id { get; set; }
        public int profile_id { get; set; }
        public string has_parent_transaction { get; set; }
        public Order order { get; set; }
        public DateTime created_at { get; set; }
        public List<object> transaction_processed_callback_responses { get; set; }
        public string currency { get; set; }
        public SourceData source_data { get; set; }
        public string error_occured { get; set; }
        public int owner { get; set; }
        public string parent_transaction { get; set; }
        public string redirect_url { get; set; }
    }



}
