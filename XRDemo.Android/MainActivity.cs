using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Forms;
using Plugin.LocalNotifications;
using Android;

namespace XRDemo.Droid
{
    [Activity(Label = "XRDemo", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            DependencyService.Register<Plugin.BluetoothLE.IAdapter, Plugin.BluetoothLE.Adapter>();
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            DependencyService.Register<LocalNotificationsImplementation>();

            //====================================
            int uiOptions = (int)Window.DecorView.SystemUiVisibility;

            uiOptions |= (int)SystemUiFlags.LowProfile;
            uiOptions |= (int)SystemUiFlags.Fullscreen;
            uiOptions |= (int)SystemUiFlags.HideNavigation;
            uiOptions |= (int)SystemUiFlags.ImmersiveSticky;

            Window.DecorView.SystemUiVisibility = (StatusBarVisibility)uiOptions;
            //====================================


            LoadApplication(new App());

            this.RequestPermissions(new[]
            {
                Manifest.Permission.AccessCoarseLocation,
                Manifest.Permission.BluetoothPrivileged
            }, 0);
        }
    }
}