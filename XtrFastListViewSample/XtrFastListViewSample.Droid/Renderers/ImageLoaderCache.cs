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
using MonoDroidToolkit.ImageLoader;

namespace XtrFastListViewSample.Droid.Renderers
{
    /**
	 * caches available image loaders.
	 * TODO this needs to be written
	 */
    public static class ImageLoaderCache
    {
        //TODO change to a proper dictionary
        static ImageLoader _onlyLoader;

        public static ImageLoader GetImageLoader(FastImageRenderer imageRenderer)
        {
            //TODO
            if (_onlyLoader == null)
            {
                _onlyLoader = new ImageLoader(Android.App.Application.Context, 64, 40);
            }
            return _onlyLoader;
        }
    }
}