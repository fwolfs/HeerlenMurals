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
using Android.Graphics;

namespace HeerlenMurals
{
    [Activity(Label = "EigenActivity")]
    public class EigenActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.eigen_route);
            SetUpToolbar();

            TextView txteigenroute = FindViewById<TextView>(Resource.Id.textview1);
            txteigenroute.SetTextColor(Color.ParseColor("#1B5E20"));
        }
        private void SetUpToolbar()
        {
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetActionBar(toolbar);
            ActionBar.Title = GetString(Resource.String.Make_own_route);
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