﻿using System;
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
            Support.MercadoPagoService.Instance.StartPayment("TEST-9b2e8c0e-5d7f-4064-9202-b5d7810dbb9a", "460720358-b7a79911-7b65-4376-ae34-2d575fd3d840", OnFinish);
        }

        private void OnFinish(object sender, EventArgs e)
        {
            InitializeComponent();
        }
    }
}
