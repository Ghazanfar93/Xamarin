using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using PharmaGuideApp.Models;

namespace PharmaGuideApp.Pages
{
    public partial class MasterDetail : Xamarin.Forms.MasterDetailPage
    {
        public MasterDetail()
        {
            InitializeComponent();
            //ToolbarItems.Add(new ToolbarItem
            //{ 
            //    Text = "Menu",
            //    Icon = "Menu.png",
            //    Order = ToolbarItemOrder.Primary,
            //});
            
            masterPage.ListView.ItemSelected += OnItemSelected;

            if (Device.OS == TargetPlatform.Windows)
            {
                Master.Icon = "swap.png";
            }

          

        }
        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MasterPageItem;
            if (item != null)
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
                masterPage.ListView.SelectedItem = null;
                IsPresented = false;
            }
        }
    }
}
