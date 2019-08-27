using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MercadoPagoCrossPlatform.Droid.Service;
using MercadoPagoCrossPlatform.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(MercadoPagoService))]
namespace MercadoPagoCrossPlatform.Droid.Service
{
    public class MercadoPagoService : IMercadoPagoService
    {
        public void StartPayment(string preferenceId, EventHandler onPaymentResult)
        {
            Console.WriteLine("Hello World");
        }
    }
}