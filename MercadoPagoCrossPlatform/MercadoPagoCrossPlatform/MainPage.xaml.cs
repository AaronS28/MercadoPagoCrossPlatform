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
            Support.MercadoPagoService.Instance.StartPayment("APP_USR-89fc92e4-5a84-497f-bd53-248228d396cb", null);
        }
    }
}
