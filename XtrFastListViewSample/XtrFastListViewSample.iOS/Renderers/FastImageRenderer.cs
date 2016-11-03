using Foundation;
using System;
using System.Collections.Generic;
using System.Text;
using TwinTechs.Controls;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XtrFastListViewSample.iOS.Renderers;
using SDWebImage;

[assembly: ExportRenderer(typeof(FastImage), typeof(FastImageRenderer))]
namespace XtrFastListViewSample.iOS.Renderers
{
    public class FastImageRenderer : ImageRenderer, IFastImageProvider
    {
        public FastImageRenderer()
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
        {
            base.OnElementChanged(e);
            //			if (e.OldElement != null) {
            //				((FastImage)e.OldElement).ImageProvider = null;
            //			}
            if (e.NewElement != null)
            {
                var fastImage = e.NewElement as FastImage;
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

        #region FastImageProvider implementation

        public void SetImageUrl(string imageUrl)
        {
            if (Control == null)
            {
                return;
            }
            if (imageUrl != null)
            {
                Control.SetImage(
                    url: new NSUrl(imageUrl),
                    placeholder: UIImage.FromBundle("placeholder.png")
                );
            }
            else
            {
                //				Control.Image = UIImage.FromBundle ("placeholder.png");
            }
        }

        #endregion
    }
}
