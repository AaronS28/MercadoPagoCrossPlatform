using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using MercadoPagoSDK;
using UIKit;

namespace MercadoPagoCrossPlatform.iOS.Service
{
    public class LifeCycleProtocol : MercadoPagoSDK.PXLifeCycleProtocol
    {
        public override Action<PXResult> FinishCheckout
        {
            get
            {
                var result = base.FinishCheckout;
                return result;
            }
        }

        public override Action CancelCheckout => base.CancelCheckout;
    }
}