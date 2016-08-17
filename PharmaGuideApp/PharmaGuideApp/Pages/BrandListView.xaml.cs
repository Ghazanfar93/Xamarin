using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaGuideApp.ViewModels;
using PharmaGuideApp.Models;
using PharmaGuideApp.DAL;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace PharmaGuideApp.Pages
{
    public partial class BrandListView  :ContentPage
    {
        public ObservableCollection<Grouping<string,BrandInfo>> BrandInfoGroup;
        MainPageViewModel mainPageViewModel;
        public BrandListView()
        {
            InitializeComponent();

        }



        public BrandListView(MainPageViewModel _mainPageViewModel)
        {
            mainPageViewModel = _mainPageViewModel;
            var brandList    = App.DAUtil.GetBrandsInfo();
            var listOfBrands = brandList;

            var sorted =
                from c in brandList
                where c.BrandName!=null
                orderby c.BrandName
                group c by c.BrandName[0].ToString()
                into theGroup
                select new Grouping<string, BrandInfo>(theGroup.Key,theGroup);
            BrandInfoGroup = new ObservableCollection<Grouping<string, BrandInfo>>(sorted);
            //BrandInfo getbrands = App.DAUtil.GetBrandInfo(4);

            //Padding = new Thickness(0, Device.OnPlatform(0, 20, 0), 0, 0);
            //var listView = new ListView();
            //listView.ItemsSource = listOfBrands;
            //listView.ItemTapped += OnItemSelected;
            //var cell = new DataTemplate(typeof(TextCell));
            //cell.SetBinding(TextCell.TextProperty, new Binding("BrandName"));
            //cell.SetValue(TextCell.TextColorProperty, Color.Blue);
            //listView.ItemTemplate = cell;
            //Content = listView;
            BindingContext= BrandInfoGroup;
            InitializeComponent();

        }

        private void OnItemSelected(object sender, ItemTappedEventArgs e)
        {
            var brandInfo = e.Item as BrandInfo;
            if (brandInfo == null)
                return;
            Navigation.PushModalAsync(new NavigationPage(new MainPageViewListTemp(new MainPageViewModel(brandInfo))));
            listview.SelectedItem = null;
        }
        //public void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        //{
        //    var brandInfo = args.SelectedItem as BrandInfo;
        //    if (brandInfo == null)
        //        return;
        //    Navigation.PushModalAsync(new MainPageViewListTemp(mainPageViewModel));
        //    //   listView.SelectedItem = null;
        //}
    }

    public class Grouping<K,T>:ObservableCollection<T>
    {
        private string key;
        private IGrouping<string, BrandInfo> theGroup;

        public K Key { get; private set; }
        public Grouping(K key, IEnumerable<T> items)
        {
            Key = key;
            foreach (var k in items)
            {
                Items.Add(k);
            }
        }

        //public Grouping(string key, IGrouping<string, BrandInfo> theGroup)
        //{
        //    this.key = key;
        //    this.theGroup = theGroup;
        //}
    }
}
