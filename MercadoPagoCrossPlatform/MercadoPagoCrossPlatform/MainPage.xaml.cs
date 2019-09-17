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
            Support.MercadoPagoService.Instance.StartPayment("TEST-45db3582-d48a-4fac-8a19-e31e0fb7b18c", "467865563-ae4a3ff4-676d-4bb2-83ee-a3c06cb55d23", OnFinish);
        }

        private void OnFinish(object sender, EventArgs e)
        {
            InitializeComponent();
        }
    }
}
