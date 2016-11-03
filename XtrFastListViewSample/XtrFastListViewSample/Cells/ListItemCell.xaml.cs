using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinTechs.Controls;
using Xamarin.Forms;
using XtrFastListViewSample.Models;

namespace XtrFastListViewSample.Cells
{
    public partial class ListItemCell : FastCell
    {

        protected override void InitializeCell()
        {
            InitializeComponent();
        }

        protected override void SetupCell(bool isRecycled)
        {
            var listItem = BindingContext as CustomListItem;
            if (listItem != null)
            {
                UserThumbnailView.ImageUrl = listItem.ImagePath ?? "";
                ImageView.ImageUrl = listItem.ThumbnailImagePath ?? "";
                NameLabel.Text = listItem.Name;
                DescriptionLabel.Text = listItem.Description;
            }
        }
    }
}
