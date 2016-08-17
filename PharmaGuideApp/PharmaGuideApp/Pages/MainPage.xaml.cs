using System;
using Xamarin.Forms;
using PharmaGuideApp.ViewModels;
using PharmaGuideApp.Models;
using PharmaGuideApp.DAL;

namespace PharmaGuideApp.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPageViewModel mainPageViewModel;

        public MainPage()
        {
            init();
        }
        public MainPage(MainPageViewModel _mainPageViewModel)
        {
            init();
            this.BindingContext = _mainPageViewModel;
            mainPageViewModel = _mainPageViewModel;
        }
        public void init()
        {
            InitializeComponent();
        }
        //async void OnEvolveClicked(object sender, EventArgs e)
        //{
        //    await Navigation.PushAsync(null);
        //}

        //async void OnCrudClicked(object sender, EventArgs e)
        //{
        //    await Navigation.PushModalAsync(new CrudOp());
        //}
        protected override void OnAppearing()
        {

            base.OnAppearing();
            var StackChildSize = childStackTwo_1.Width / 2;
            packBtn.WidthRequest = StackChildSize;
            prescribeInfoBtn.WidthRequest = StackChildSize;
        }

        void OnNavigateClicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new BrandListView(mainPageViewModel));
        }
   
        void OnSubmitClicked(object sender, EventArgs e)
        {


            mainPageViewModel.OnSave();

        }

        void OnPackClicked(Object sender, EventArgs e)
        {
            if (prescribeInfoEditor.IsVisible == true)
                prescribeInfoEditor.IsVisible = false;
            if (packEditor.HeightRequest == 0)
            {
                var h = GetEditorHeight();
                packEditor.HeightRequest = h;
            }
            packEditor.IsVisible = true;


        }
        void OnPrescribeInfoClicked(object sender, EventArgs e)
        {
            if (packEditor.IsVisible == true)
                packEditor.IsVisible = false;
            if (prescribeInfoEditor.HeightRequest == 0)
            {
                var h = GetEditorHeight();
                prescribeInfoEditor.HeightRequest = h;
            }
            prescribeInfoEditor.IsVisible = true;

        }
        double GetEditorHeight()
        {
            double editHeight = Content.Height * 0.09633911368;

            var h = Content.Height - (childStackOne.Height + childStackTwo.Height + submit.Height);
            if (h >= editHeight)
                return h;
            else
                return editHeight;
        }





    }
}
