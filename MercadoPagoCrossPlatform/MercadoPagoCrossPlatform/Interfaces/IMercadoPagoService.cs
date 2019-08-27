using System;

namespace MercadoPagoCrossPlatform.Interfaces
{
    public interface IMercadoPagoService
    {
        void StartPayment(string preferenceId, EventHandler onPaymentResult);
    }
}
