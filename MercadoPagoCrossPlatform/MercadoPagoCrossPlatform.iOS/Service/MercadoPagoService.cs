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
            try
            {
                var mercadoPagoCheckoutBuilder = new MercadoPagoCheckoutBuilder(publicKey, preferenceId);
                var mercadoPagoCheckout = new MercadoPagoCheckout(mercadoPagoCheckoutBuilder);

                var rootViewController = AppDelegate.Context.KeyWindow.RootViewController;
                UINavigationController navigationController = new UINavigationController();
                rootViewController.PresentViewController(navigationController, true, null);
                LifeCycleProtocol lifeCycle = new LifeCycleProtocol();
                
                mercadoPagoCheckout.StartWithNavigationController(navigationController, lifeCycle);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }
    }
}