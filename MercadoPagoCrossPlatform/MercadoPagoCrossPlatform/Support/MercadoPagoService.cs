using System;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Text;
using MercadoPagoCrossPlatform.Interfaces;

namespace MercadoPagoCrossPlatform.Support
{
    public class MercadoPagoService
    {
        private MercadoPagoService()
        {

        }

        private static MercadoPagoService instance;
        public static MercadoPagoService Instance
        {
            get 
            {
                if (instance == null)
                    instance = new MercadoPagoService();
                return instance;
            }
        }

        public void StartPayment(string preferenceId, EventHandler onPaymentResult)
        {
            DependencyService.Get<IMercadoPagoService>().StartPayment(preferenceId, onPaymentResult);
        }
    }
}
