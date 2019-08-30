using System;
using Android.App;
using Android.Content;
using Com.Mercadopago.Android.PX.Core;
using Com.Mercadopago.Android.PX.Model;
using MercadoPagoCrossPlatform;
using MercadoPagoCrossPlatform.Droid.Service;
using MercadoPagoCrossPlatform.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(MercadoPagoService))]
namespace MercadoPagoCrossPlatform.Droid.Service
{
    public class MercadoPagoService : IMercadoPagoService
    {
        private static EventHandler OnPaymentResult;
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
                var result = (Payment)data.GetSerializableExtra(MercadoPagoCheckout.ExtraPaymentResult);
                MercadoPagoCrossPlatform.Support.MercadoPagoPaymentResponse response = null;
                if ((int)resultCode == 7)
                {
                    if (result != null)
                    {
                        response = new MercadoPagoCrossPlatform.Support.MercadoPagoPaymentResponse
                        {
                            PaymentId = result.Id.ToString(),
                            PaymentDescription = result.PaymentStatusDetail
                        };

                        switch (result.PaymentStatus)
                        {
                            case "approved":
                                response.PaymentStatus = MercadoPagoCrossPlatform.Support.PaymentStatus.APPROVED;
                                break;
                            case "in_process":
                                response.PaymentStatus = MercadoPagoCrossPlatform.Support.PaymentStatus.INPROCESS;
                                break;
                            case "rejected":
                                response.PaymentStatus = MercadoPagoCrossPlatform.Support.PaymentStatus.REJECTED;
                                break;
                            case "pending":
                                response.PaymentStatus = MercadoPagoCrossPlatform.Support.PaymentStatus.PENDING;
                                break;
                            case "cancelled":
                                response.PaymentStatus = MercadoPagoCrossPlatform.Support.PaymentStatus.CANCELLED;
                                break;
                            case "expired":
                                response.PaymentStatus = MercadoPagoCrossPlatform.Support.PaymentStatus.EXPIRED;
                                break;
                        }
                    }

                }
                else
                {

                }

                OnPaymentResult?.Invoke(response, EventArgs.Empty);
            }   
        }

        public static void Init(Context context)
        {
            Context = context;
        }



    }
}