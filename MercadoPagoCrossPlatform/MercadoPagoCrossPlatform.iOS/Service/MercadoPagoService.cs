using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using MercadoPagoCrossPlatform.Interfaces;
using MercadoPagoCrossPlatform.iOS.Service;
using MercadoPagoSDK;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(MercadoPagoService))]
namespace MercadoPagoCrossPlatform.iOS.Service
{
    public class MercadoPagoService : IMercadoPagoService
    {
        public void StartPayment(string publicKey, string preferenceId, EventHandler onPaymentResult)
        {
            var mercadoPagoCheckoutBuilder = new MercadoPagoCheckoutBuilder(publicKey, preferenceId);
            var mercadoPagoCheckout = new MercadoPagoCheckout(mercadoPagoCheckoutBuilder);

            var window = UIApplication.SharedApplication.KeyWindow;
            var vc = (UINavigationController)window.RootViewController;
            mercadoPagoCheckout.StartWithNavigationController(vc, null);
        }
    }
}