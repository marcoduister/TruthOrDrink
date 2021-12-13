using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using System.IO;
using Plugin.Media;

namespace TruthOrDrink.Droid
{
    [Activity(Label = "TruthOrDrink", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override async void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);

            Window.SetStatusBarColor(Android.Graphics.Color.Rgb(79, 69, 69));
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            _ = CrossMedia.Current.Initialize();

            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            string DbName = "TruthOrDrink.db.sqlLite";
            string Folderpath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string FullPath = Path.Combine(Folderpath, DbName);

            LoadApplication(new App(FullPath));
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}