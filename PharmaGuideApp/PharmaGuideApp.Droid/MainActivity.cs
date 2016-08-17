using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace PharmaGuideApp.Droid
{
    // Show the splash screen
    [Activity(Theme = "@style/Theme.Splash", MainLauncher = true, NoHistory = true,
    ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            System.Threading.Thread.Sleep(1000);
            this.StartActivity(typeof(MainActivity));
        }
    }

    [Activity(Label = "PharmaGuideApp", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
            var upArrow =   Resources.GetDrawable( Resource.Drawable.Menu);
            upArrow.SetColorFilter(Resources.GetColor(Resource.Color.background_material_light), Android.Graphics.PorterDuff.Mode.SrcIn);
            ActionBar.SetHomeAsUpIndicator(upArrow);
        }
    }
}

