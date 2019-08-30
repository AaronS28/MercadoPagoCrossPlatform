namespace MercadoPagoCrossPlatform.Support
{
    public class MercadoPagoPaymentResponse
    {
        public string PaymentId { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public string PaymentDescription { get; set; }
    }
}
