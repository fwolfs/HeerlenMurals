//Gemaakt door Pascal Vos, Dani Truijen, Folkert Wolfs
//Gemaak in 2016 op Hogeschool Zuyd

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
        //Hier worden de functie Toolbar aangeroepen.
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
        //Hier wordt de toolbar functies aangezet/uitgezet en een title toegewezen
        private void SetUpToolbar()
        {
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetActionBar(toolbar);
            ActionBar.Title = GetString(Resource.String.Information);
            ActionBar.SetDisplayHomeAsUpEnabled(true);
            ActionBar.SetHomeButtonEnabled(true);
        }
        //Hier worden de functies aan de knoppen van de toolbar menu toegewezen
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            base.OnBackPressed();
            return base.OnOptionsItemSelected(item);
        }
    }
}