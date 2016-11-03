using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XtrFastListViewSample.DataProvider;
using XtrFastListViewSample.Helpers;
using XtrFastListViewSample.Models;

namespace XtrFastListViewSample.Pages
{
    public partial class ListItemsPage : ContentPage
    {
        public ListItemsPage()
        {
            InitializeComponent();
            MediaItemsListView.ItemsSource = SampleDataProvider.GetCustomListItems();
        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as CustomListItem;
            DisplayAlert("you selected an item", item.Name, "Ok");
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            FastListViewHelper.FastCellCache.FlushAllCaches();
        }

    }
}
