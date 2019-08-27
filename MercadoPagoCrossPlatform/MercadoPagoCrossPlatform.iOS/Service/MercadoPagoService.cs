using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using MercadoPagoCrossPlatform.Interfaces;
using MercadoPagoCrossPlatform.iOS.Service;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(MercadoPagoService))]
namespace MercadoPagoCrossPlatform.iOS.Service
{
    public class MercadoPagoService : IMercadoPagoService
    {
        public void StartPayment(string preferenceId, EventHandler onPaymentResult)
        {
            Console.WriteLine("Hello World");
        }
    }
}