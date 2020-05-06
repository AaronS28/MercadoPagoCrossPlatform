using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MercadoPagoCrossPlatform
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Support.MercadoPagoService.Instance.StartPayment("Put your public_key here", "put your checkout_preference_id here", OnFinish);
        }

        private void OnFinish(object sender, EventArgs e)
        {
            InitializeComponent();
        }
    }
}
