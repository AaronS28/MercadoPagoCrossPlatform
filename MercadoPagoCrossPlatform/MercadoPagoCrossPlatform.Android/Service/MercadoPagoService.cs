using System;
using Android.App;
using Android.Content;
using Com.Mercadopago.Android.PX.Core;
using MercadoPagoCrossPlatform.Droid.Service;
using MercadoPagoCrossPlatform.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(MercadoPagoService))]
namespace MercadoPagoCrossPlatform.Droid.Service
{
    public class MercadoPagoService : IMercadoPagoService
    {
        private EventHandler OnPaymentResult;
        private static Context Context;
        private static MercadoPagoCheckout mercadoPagoCheckout;

        public void StartPayment(string publicKey, string preferenceId, EventHandler onPaymentResult)
        {
            OnPaymentResult = onPaymentResult;
            mercadoPagoCheckout = new MercadoPagoCheckout.Builder(publicKey, preferenceId).Build();
            mercadoPagoCheckout.StartPayment(Context, MercadoPagoCheckout.PaymentResultCode);
        }

        public static void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            if (requestCode == MercadoPagoCheckout.PaymentResultCode)
            {
                var result = data.GetSerializableExtra(MercadoPagoCheckout.ExtraPaymentResult);
                if ((int)resultCode == 7)
                {
                    
                }
                else
                {

                }
            }   
        }

        public static void Init(Context context)
        {
            Context = context;
        }



    }
}