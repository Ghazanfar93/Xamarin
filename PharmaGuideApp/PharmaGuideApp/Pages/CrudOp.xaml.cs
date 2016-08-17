using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace PharmaGuideApp.Pages
{
    public partial class CrudOp : ContentPage
    {
        public CrudOp()
        {
            InitializeComponent();
        }
        async void goBackButton(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}
