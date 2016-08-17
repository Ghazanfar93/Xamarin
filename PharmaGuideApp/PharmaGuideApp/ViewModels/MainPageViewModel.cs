
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using PharmaGuideApp.Models;
using System.Collections.ObjectModel;
using PharmaGuideApp.DAL;

namespace PharmaGuideApp.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged

    {
        private BrandInfo mainPage;
        private bool check;

        //private ObservableCollection<string> pageDetails;

        public event PropertyChangedEventHandler PropertyChanged;

        public MainPageViewModel(BrandInfo _mainPage)
        {
            mainPage = _mainPage;
            //pageDetails = new ObservableCollection<string>(mainPage.pageDetails);
        }
        public string BrandName
        {
            get
            {
                return mainPage != null ? mainPage.BrandName : null;
            }
            set
            {
                mainPage.BrandName = value;

                //if (mainPage.BrandName != null)
                //{
                //    mainPage.BrandName = value;

                //    OnPropertyChanged(BrandName);
                //}
            }
        }
        public string TherapeuticCategory
        {
            get
            {
                return mainPage != null ? mainPage.TherapeuticCategory : null;
            }
            set
            {
                if (mainPage != null)
                {
                    mainPage.TherapeuticCategory = value;
                    OnPropertyChanged(TherapeuticCategory);
                }

            }
        }
        public string DrugCategory
        {
            get
            {
                return mainPage != null ? mainPage.DrugCategory : null;
            }
            set
            {
                if (mainPage != null)
                {
                    mainPage.DrugCategory = value;
                    OnPropertyChanged(DrugCategory);
                }

            }
        }
        public string ContentTitle
        {
            get
            {
                return mainPage != null ? mainPage.ContentTitle : null;
            }
            set
            {
                if (mainPage != null)
                {
                    mainPage.ContentTitle = value;
                    OnPropertyChanged(ContentTitle);
                }

            }
        }
        public string Pack
        {
            get
            {
                return mainPage != null ? mainPage.Pack : null;
            }
            set
            {
                if (mainPage != null)
                {
                    mainPage.Pack = value;
                    OnPropertyChanged(Pack);
                }

            }
        }
        public string PrescribingInformation
        {
            get
            {
                return mainPage != null ? mainPage.PrescribingInformation : null;
            }
            set
            {
                if (mainPage != null)
                {
                    mainPage.PrescribingInformation = value;
                    OnPropertyChanged(PrescribingInformation);
                }

            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            var changed = PropertyChanged;
            if (changed != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public bool OnSave()
        {
            App.DAUtil.SaveBrandInfo(mainPage);
         //   App.DAUtil.SaveTaskAsync(mainPage, mainPage.Status);
            //App.DAUtil.GetTasksAsync();
            check = true;
            return check;
        }
        public bool Status
        {
            get; set;
        }


    }
}
