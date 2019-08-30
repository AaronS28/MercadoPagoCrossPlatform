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

        private UINavigationController NavigationController;
        private EventHandler OnPaymentResult;
        private UIViewController OldViewController;

        public void StartPayment(string publicKey, string preferenceId, EventHandler onPaymentResult)
        {
            try
            {
                OnPaymentResult = onPaymentResult;

                var mercadoPagoCheckoutBuilder = new MercadoPagoCheckoutBuilder(publicKey, preferenceId);
                var mercadoPagoCheckout = new MercadoPagoCheckout(mercadoPagoCheckoutBuilder);

                OldViewController = UIApplication.SharedApplication.KeyWindow.RootViewController;
                NavigationController = new UINavigationController();
                OldViewController.PresentViewController(NavigationController, true, null);
                mercadoPagoCheckout.StartWithNavigationController(NavigationController, this);

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
            Support.MercadoPagoPaymentResponse response = null;
            if (result != null)
            {
                response = new Support.MercadoPagoPaymentResponse
                {
                    PaymentId = result.PaymentId,
                    PaymentDescription = result.StatusDetail
                };

                switch (result.Status)
                {
                    case "approved":
                        response.PaymentStatus = Support.PaymentStatus.APPROVED;
                        break;
                    case "in_process":
                        response.PaymentStatus = Support.PaymentStatus.INPROCESS;
                        break;
                    case "rejected":
                        response.PaymentStatus = Support.PaymentStatus.REJECTED;
                        break;
                    case "pending":
                        response.PaymentStatus = Support.PaymentStatus.PENDING;
                        break;
                    case "cancelled":
                        response.PaymentStatus = Support.PaymentStatus.CANCELLED;
                        break;
                    case "expired":
                        response.PaymentStatus = Support.PaymentStatus.EXPIRED;
                        break;
                }
            }

            //NavigationController.ShowViewController(OldViewController, null);
            
            OnPaymentResult?.Invoke(response, EventArgs.Empty);
        }

        private void OnCancelCheckout()
        {
            Console.WriteLine("Se cancelo el Checkout");
        }
    }
}