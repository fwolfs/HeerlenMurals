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
using Android.Text;
using Android.Graphics;

namespace HeerlenMurals
{
    [Activity(Label = "InformatieActivity")]
    public class InformatieActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.about);
            SetUpToolbar();

            TextView titel = FindViewById<TextView>(Resource.Id.titel);
            titel.SetTextColor(Color.ParseColor("#1B5E20"));

            TextView informatie = FindViewById<TextView>(Resource.Id.informatie);

            TextView signature = FindViewById<TextView>(Resource.Id.signature);

        }
        private void SetUpToolbar()
        {
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetActionBar(toolbar);
            ActionBar.Title = "Instellingen";
            ActionBar.SetDisplayHomeAsUpEnabled(true);
            ActionBar.SetHomeButtonEnabled(true);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            base.OnBackPressed();
            return base.OnOptionsItemSelected(item);
        }
    }
}