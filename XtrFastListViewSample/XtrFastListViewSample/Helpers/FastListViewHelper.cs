using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinTechs.Controls;
using Xamarin.Forms;

namespace XtrFastListViewSample.Helpers
{
    public static class FastListViewHelper
    {
        public static IFastCellCache FastCellCache { get; set; }

        public static Size ScreenSize { get; set; }
    }
}
