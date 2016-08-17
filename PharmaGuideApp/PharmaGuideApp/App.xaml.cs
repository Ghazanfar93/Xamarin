using PharmaGuideApp.Pages;
using PharmaGuideApp.ViewModels;
using PharmaGuideApp.Models;
using PharmaGuideApp.DAL;
using PharmaGuideApp.Data;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
//[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace PharmaGuideApp
{
    public partial class App : Application
    {

        static DataAccess dbUtils;
        public App()
        {
            //var mainpage = new BrandInfo
            //{
            //    BrandName = "",
            //    TherapeuticCategory = "",
            //    DrugCategory = "",
            //    ContentTitle = "",
            //    Pack = "",
            //    PrescribingInformation = ""
            //};
            // The root page of your application
            //var _mainPage = new MainPage (new MainPageViewModel(mainpage));
            //var navigation = new AppNavigationPage();
            //MainPage = navigation;
            // MainPage = new Evolve();
            //MainPage = new CrudOp();

            //MainPage = new BrandListView();
            try
            {

                // MainPage = new NavigationPage(new MainPage(new MainPageViewModel(new BrandInfo())));
                MainPage= new MasterDetail()
                {
                    Icon="Menu.png"
                };

                //{
                //    BarBackgroundColor = Color.Blue,
                //    BarTextColor = Color.Pink
                //};
                // MainPage = new MainPage(new MainPageViewModel(mainpage));
                // MainPage = new BrandListView();     
                //{
                //    BrandName = "CG",
                //    BrandId = 101,
                //    ContentTitle = "Pharmacy",
                //    DrugCategory = "Normal"

                //}));
                //GetMainPage();
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        //public static Page GetMainPage()
        //{
        //    return new NavigationPage(new MainPageListView());
        //}
        public static DataAccess DAUtil
        {
            get
            {
                if (dbUtils == null)
                {
                    dbUtils = new DataAccess(new RestService());
                }
                return dbUtils;
            }
        }
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
