using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace HeerlenMurals
{
    [Activity(Label = "Heerlen Murals", MainLauncher = true, Icon = "@drawable/mural", Theme = "@android:style/Theme.NoTitleBar")]
    public class MenuActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.hoofdmenu);

            Button btnVasteRoute = FindViewById<Button>(Resource.Id.button_vaste_route);
            btnVasteRoute.Click += delegate
            {
                StartActivity(typeof(MapActivity));
            };
            Button btnEigenRoute = FindViewById<Button>(Resource.Id.button_eigen_route);
            btnEigenRoute.Click += delegate
            {
                StartActivity(typeof(EigenActivity));
            };
            Button btnInstellingen = FindViewById<Button>(Resource.Id.button_instellingen);
            btnInstellingen.Click += delegate
            {
                StartActivity(typeof(InstellingenActivity));
            };
        }
    }
}