using System;
using MercadoPagoCrossPlatform.Droid.Service;
using MercadoPagoCrossPlatform.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(MercadoPagoService))]
namespace MercadoPagoCrossPlatform.Droid.Service
{
    public class MercadoPagoService : IMercadoPagoService
    {
        public void StartPayment(string publicKey, string preferenceId, EventHandler onPaymentResult)
        {
            new Com.Mercadopago.Android.PX.Core.MercadoPagoCheckout.Builder(publicKey, preferenceId)
                .Build()
                .StartPayment(Android.App.Application.Context, 15);
        }
    }
}