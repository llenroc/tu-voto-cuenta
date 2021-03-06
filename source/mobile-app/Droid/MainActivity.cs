﻿using Android.App;
using Android.Content.PM;
using Android.Views;
using Android.OS;
using ImageCircle.Forms.Plugin.Droid;
using FFImageLoading.Forms.Droid;
using FFImageLoading.Svg.Forms;
using TuVotoCuenta.Controls;
using System.Linq;

namespace TuVotoCuenta.Droid
{
    [Activity(Label = "TuVotoCuenta", Icon = "@mipmap/ic_launcher", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

			var width = Resources.DisplayMetrics.WidthPixels;
            var height = Resources.DisplayMetrics.HeightPixels;
            var density = Resources.DisplayMetrics.Density;

            App.ScreenWidth = (width - 0.5f) / density;
            App.ScreenHeight = (height - 0.5f) / density;

            ImageCircleRenderer.Init();

            CachedImageRenderer.Init(true);
            var ignore = typeof(SvgCachedImage);
                     
            LoadApplication(new App());         
        }

		public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Android.Content.PM.Permission[] grantResults)
        {
            Plugin.Permissions.PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }      
    }
}