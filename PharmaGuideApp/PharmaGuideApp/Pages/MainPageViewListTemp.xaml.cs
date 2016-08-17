using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaGuideApp.ViewModels;

using Xamarin.Forms;

namespace PharmaGuideApp.Pages
{
    public partial class MainPageViewListTemp : ContentPage
    {
        public MainPageViewListTemp(MainPageViewModel _mainViewModel)
        {
            BindingContext = _mainViewModel;
            InitializeComponent();
        }
    }
}
