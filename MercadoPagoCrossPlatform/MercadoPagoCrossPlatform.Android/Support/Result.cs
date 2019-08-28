using Android.Content;

namespace MercadoPagoCrossPlatform.Droid.Support
{
    public class Result
    {
        public int RequestCode { get; set; }
        public Android.App.Result ResultValue { get; set; }
        public Intent Data { get; set; }
    }
}