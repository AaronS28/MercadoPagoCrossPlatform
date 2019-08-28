using System;

namespace MercadoPagoCrossPlatform.Interfaces
{
    public interface IMercadoPagoService
    {
        void StartPayment(string publicKey, string preferenceId, EventHandler onPaymentResult);
    }
}
