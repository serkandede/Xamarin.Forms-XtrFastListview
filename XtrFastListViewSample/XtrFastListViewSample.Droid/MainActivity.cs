using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using XtrFastListViewSample.Helpers;
using XtrFastListViewSample.Droid.Renderers;

namespace XtrFastListViewSample.Droid
{
    [Activity(Label = "XtrFastListViewSample", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            FastListViewHelper.FastCellCache = FastCellCache.Instance;

            var metrics = Resources.DisplayMetrics;
            FastListViewHelper.ScreenSize = new Xamarin.Forms.Size(ConvertPixelsToDp(metrics.WidthPixels), ConvertPixelsToDp(metrics.HeightPixels));

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }

        private int ConvertPixelsToDp(float pixelValue)
        {
            var dp = (int)((pixelValue) / Resources.DisplayMetrics.Density);
            return dp;
        }

    }
}

