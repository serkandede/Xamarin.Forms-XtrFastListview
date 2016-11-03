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
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using TwinTechs.Controls;
using XtrFastListViewSample.Droid.Renderers;
using MonoDroidToolkit.ImageLoader;

[assembly: ExportRenderer(typeof(FastImage), typeof(FastImageRenderer))]

namespace XtrFastListViewSample.Droid.Renderers
{
    public class FastImageRenderer : ImageRenderer
    {
        ImageLoader _imageLoader;

        protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
        {
            base.OnElementChanged(e);
            //			if (e.OldElement != null) {
            //				((FastImage)e.OldElement).ImageProvider = null;
            //			}
            if (e.NewElement != null)
            {
                var fastImage = e.NewElement as FastImage;
                _imageLoader = ImageLoaderCache.GetImageLoader(this);
                SetImageUrl(fastImage.ImageUrl);
            }
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == "ImageUrl")
            {
                var fastImage = Element as FastImage;
                SetImageUrl(fastImage.ImageUrl);
            }
        }


        public void SetImageUrl(string imageUrl)
        {
            if (Control == null)
            {
                return;
            }
            if (imageUrl != null)
            {
                _imageLoader.DisplayImage(imageUrl, Control, -1);

            }
        }
    }
}