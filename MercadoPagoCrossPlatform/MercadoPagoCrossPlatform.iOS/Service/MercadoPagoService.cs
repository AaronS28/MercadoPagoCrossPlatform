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
    public class MercadoPagoService : PXLifeCycleProtocol, IMercadoPagoService
    {

        private UINavigationController navigationController;

        public void StartPayment(string publicKey, string preferenceId, EventHandler onPaymentResult)
        {
            try
            {
                var mercadoPagoCheckoutBuilder = new MercadoPagoCheckoutBuilder(publicKey, preferenceId);
                var mercadoPagoCheckout = new MercadoPagoCheckout(mercadoPagoCheckoutBuilder);

                var rootViewController = UIApplication.SharedApplication.KeyWindow.RootViewController;
                navigationController = new UINavigationController();
                rootViewController.PresentViewController(navigationController, true, null);
                
                mercadoPagoCheckout.StartWithNavigationController(navigationController, this);
                var result = this.FinishCheckout;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }

        public override Action<PXResult> FinishCheckout => OnResultComes;

        public override Action CancelCheckout => OnCancelCheckout;

        private void OnResultComes(PXResult result)
        {
            Console.WriteLine("Do this with result", result.GetStatus());
        }

        private void OnCancelCheckout()
        {
            Console.WriteLine("Se cancelo el Checkout");
        }
    }
}