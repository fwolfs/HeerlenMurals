using Android.App;
using Android.OS;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.Widget;
using Android.Views;
using Android.Locations;
using Android.Runtime;
using System;
using Android.Content;
using Android.Support.V4.Content;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HeerlenMurals
{
    [Activity(Label = "Heerlen Murals")]
    public class MapActivity : Activity, IOnMapReadyCallback
    {
        private GoogleMap GMap;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Map);
            SetUpMap();
            SetUpToolbar();
        }
        private void SetUpMap()
        {
            if (GMap == null)
            {
                FragmentManager.FindFragmentById<MapFragment>(Resource.Id.googlemap).GetMapAsync(this);
            }
        }
        private void SetUpToolbar()
        {
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetActionBar(toolbar);
            ActionBar.Title = "Heerlen Murals";
            ActionBar.SetDisplayHomeAsUpEnabled(true);
            ActionBar.SetHomeButtonEnabled(true);
        }
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Layout.top_menu, menu);
            return base.OnCreateOptionsMenu(menu);
        }
        public override bool OnOptionsItemSelected(IMenuItem item)
        {

            if (item.ItemId == Android.Resource.Id.Home)
            {
                base.OnBackPressed();
            }
            if (item.ItemId == Resource.Id.kortste_route)
            {
                Toast.MakeText(this, item.TitleFormatted + "Geselecteerd", ToastLength.Short).Show();
                drawShortRoute();
                return base.OnOptionsItemSelected(item);
            }
            if (item.ItemId == Resource.Id.winkel_route)
            {
                Toast.MakeText(this, "Action selected: " + item.TitleFormatted, ToastLength.Short).Show();
                return base.OnOptionsItemSelected(item);
            }
            if (item.ItemId == Resource.Id.natuur_route)
            {
                Toast.MakeText(this, "Action selected: " + item.TitleFormatted, ToastLength.Short).Show();
                return base.OnOptionsItemSelected(item);
            }
            else
            {
                return base.OnOptionsItemSelected(item);
            }
        }
        public void OnMapReady(GoogleMap googleMap)
        {
            //init
            this.GMap = googleMap;
            GMap.UiSettings.ZoomControlsEnabled = true;
            GMap.MyLocationEnabled = true;
            GMap.UiSettings.MyLocationButtonEnabled = true;
            GMap.UiSettings.MapToolbarEnabled = false;
            GMap.UiSettings.CompassEnabled = true;

            //locatie
            LatLng latLng = new LatLng(50.88749555703811, 5.978665351867676);
            GMap.MoveCamera(CameraUpdateFactory.NewLatLngZoom(latLng,15));

            //teken murals op kaart
            drawMuralMarkers();

            GMap.MarkerClick += MapOnMarkerClick;  
        }
        private void MapOnMarkerClick(object sender, GoogleMap.MarkerClickEventArgs markerClickEventArgs)
        {
            markerClickEventArgs.Handled = true;
            Marker marker = markerClickEventArgs.Marker;
            var ID = marker.Id.Remove(0, 1);
            var Mural = new Intent(this, typeof(InfoActivity));
            Mural.PutExtra("ID", ID);
            StartActivityForResult(Mural, 0);   
        }
        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            if (resultCode == Result.Ok)
            {
                string title = data.GetStringExtra("Title") ?? "Data not available";
                string info = data.GetStringExtra("Info") ?? "Data not available";
                string maker = data.GetStringExtra("Maker") ?? "Data not available";
                string make_date = data.GetStringExtra("Make_date") ?? "Data not available";
                string website = data.GetStringExtra("Website") ?? "Data not available";
                string maker_info = GetString(Resource.String.Creator) + " " + maker;
                string make_date_info =  GetString(Resource.String.Creation_date) + " " + make_date;
                AlertDialog.Builder alert = new AlertDialog.Builder(this);
                alert.SetTitle(title);
                alert.SetMessage(maker_info + "\n" + make_date_info + "\n"+ website + "\n" + info);
                alert.SetPositiveButton("Okay", (senderAlert, args) =>
                {
                
                });
                
                Dialog dialog = alert.Create();
                dialog.Show();
            }
        }
        private void drawMuralMarkers()
        {
            //Locatie Murals

            //Stationstraat 13, 6411 NH Heerlen
            MarkerOptions Mural_1 = new MarkerOptions();
            Mural_1.SetPosition(new LatLng(50.8897834, 5.977796300000023));
            GMap.AddMarker(Mural_1);

            //Gasthuisstraat 2, 6411 KE Heerlen
            MarkerOptions Mural_2 = new MarkerOptions();
            Mural_2.SetPosition(new LatLng(50.88751269999999, 5.981181500000048));
            GMap.AddMarker(Mural_2);

            //Plaarstraat 14, 6411 JV Heerlen
            MarkerOptions Mural_3 = new MarkerOptions();
            Mural_3.SetPosition(new LatLng(50.8871116, 5.981422199999997));
            GMap.AddMarker(Mural_3);

            //Spoorsingel 60, 6412 AA Heerlen
            MarkerOptions Mural_4 = new MarkerOptions();
            Mural_4.SetPosition(new LatLng(50.891703, 5.976202999999941));
            GMap.AddMarker(Mural_4);

            //Spoorsingel 50, 6412 AC Heerlen
            MarkerOptions Mural_5 = new MarkerOptions();
            Mural_5.SetPosition(new LatLng(50.89182419999999, 5.976532600000041));
            GMap.AddMarker(Mural_5);

            //Spoorsingel 44, 6412 AC Heerlen
            MarkerOptions Mural_6 = new MarkerOptions();
            Mural_6.SetPosition(new LatLng(50.8911625, 5.977618500000062));
            GMap.AddMarker(Mural_6);

            //Kempkensweg 3, 6412 Heerlen
            MarkerOptions Mural_7 = new MarkerOptions();
            Mural_7.SetPosition(new LatLng(50.8921635, 5.976991699999985));
            GMap.AddMarker(Mural_7);

            //Robroekergats 79, 6412 AX Heerlen
            MarkerOptions Mural_8 = new MarkerOptions();
            Mural_8.SetPosition(new LatLng(50.8912132, 5.97824449999996));
            GMap.AddMarker(Mural_8);

            //Spoorsingel 4, 6412 AA Heerlen
            MarkerOptions Mural_9 = new MarkerOptions();
            Mural_9.SetPosition(new LatLng(50.8906907, 5.978479399999969));
            GMap.AddMarker(Mural_9);

            //Spoorsingel 2, 6412 AA Heerlen
            MarkerOptions Mural_10 = new MarkerOptions();
            Mural_10.SetPosition(new LatLng(50.8905998, 5.978662999999983));
            GMap.AddMarker(Mural_10);

            //Pancratiusstraat 44, 6411 KC Heerlen
            MarkerOptions Mural_11 = new MarkerOptions();
            Mural_11.SetPosition(new LatLng(50.8873042, 5.979772000000025));
            GMap.AddMarker(Mural_11);

            //Nobelstraat 16, 6411 EM Heerlen
            MarkerOptions Mural_12 = new MarkerOptions();
            Mural_12.SetPosition(new LatLng(50.8853896, 5.97976170000004));
            GMap.AddMarker(Mural_12);

            //Coriovallumstraat 7, 6411 CA Heerlen
            MarkerOptions Mural_13 = new MarkerOptions();
            Mural_13.SetPosition(new LatLng(50.8856446, 5.977349099999969));
            GMap.AddMarker(Mural_13);

            //Kruisstraat 51, 6411 BR Heerlen
            MarkerOptions Mural_14 = new MarkerOptions();
            Mural_14.SetPosition(new LatLng(50.8843429, 5.977019899999959));
            GMap.AddMarker(Mural_14);

            //Coriovallumstraat 26, 6411 CC Heerlen
            MarkerOptions Mural_15 = new MarkerOptions();
            Mural_15.SetPosition(new LatLng(50.8855164, 5.976054400000066));
            GMap.AddMarker(Mural_15);

            //Honigmannstraat 2, 6411 LL Heerlen
            MarkerOptions Mural_16 = new MarkerOptions();
            Mural_16.SetPosition(new LatLng(50.8869963, 5.976698499999998));
            GMap.AddMarker(Mural_16);

            //Geerstraat 2, 6411 NR Heerlen
            MarkerOptions Mural_17 = new MarkerOptions();
            Mural_17.SetPosition(new LatLng(50.8869257, 5.974665400000049));
            GMap.AddMarker(Mural_17);

            //Laanderstraat 27, 6411 VA Heerlen
            MarkerOptions Mural_18 = new MarkerOptions();
            Mural_18.SetPosition(new LatLng(50.8879613, 5.972532699999988));
            GMap.AddMarker(Mural_18);

            //Groene Boord Heerlen
            MarkerOptions Mural_19 = new MarkerOptions();
            Mural_19.SetPosition(new LatLng(50.887077, 5.985465));
            GMap.AddMarker(Mural_19);
        }
        public void drawShortRoute()
        {
            PolylineOptions rectOptions = new PolylineOptions();
            rectOptions.Add(new LatLng(50.890609, 5.973794));
            rectOptions.Add(new LatLng(50.890717, 5.972582));
            rectOptions.Add(new LatLng(50.892128, 5.973258));
            rectOptions.Add(new LatLng(50.892236, 5.973714));
            rectOptions.Add(new LatLng(50.891874, 5.975581));
            rectOptions.Add(new LatLng(50.892179, 5.976691));
            rectOptions.Add(new LatLng(50.891959, 5.976241));
            rectOptions.Add(new LatLng(50.891262, 5.977287));
            rectOptions.Add(new LatLng(50.8909, 5.977796));
            rectOptions.Add(new LatLng(50.891198, 5.978306));
            rectOptions.Add(new LatLng(50.8909, 5.977796)); ;
            rectOptions.Add(new LatLng(50.890504, 5.978419));
            rectOptions.Add(new LatLng(50.890203, 5.979931));
            rectOptions.Add(new LatLng(50.88979, 5.979915));
            rectOptions.Add(new LatLng(50.889847, 5.977646));
            rectOptions.Add(new LatLng(50.889766, 5.978322));
            rectOptions.Add(new LatLng(50.888227, 5.979357));
            rectOptions.Add(new LatLng(50.888315, 5.980715));
            rectOptions.Add(new LatLng(50.887607, 5.98102));
            rectOptions.Add(new LatLng(50.887604, 5.981358));
            rectOptions.Add(new LatLng(50.88647, 5.982066));
            rectOptions.Add(new LatLng(50.887293, 5.984207));
            rectOptions.Add(new LatLng(50.887468, 5.985033));
            rectOptions.Add(new LatLng(50.887106, 5.985355));
            rectOptions.Add(new LatLng(50.887468, 5.985033));
            rectOptions.Add(new LatLng(50.886484, 5.982013));
            rectOptions.Add(new LatLng(50.887039, 5.97976));
            rectOptions.Add(new LatLng(50.887086, 5.979674));
            rectOptions.Add(new LatLng(50.887039, 5.97976));
            rectOptions.Add(new LatLng(50.886007, 5.980173));
            rectOptions.Add(new LatLng(50.885235, 5.979829));
            rectOptions.Add(new LatLng(50.885174, 5.978644));
            rectOptions.Add(new LatLng(50.885015, 5.97793));
            rectOptions.Add(new LatLng(50.88448, 5.976589));
            rectOptions.Add(new LatLng(50.884832, 5.976133));
            rectOptions.Add(new LatLng(50.885262, 5.975951));
            rectOptions.Add(new LatLng(50.885851, 5.977769));
            rectOptions.Add(new LatLng(50.886924, 5.977158));
            rectOptions.Add(new LatLng(50.886822, 5.976686));
            rectOptions.Add(new LatLng(50.887309, 5.976364));
            rectOptions.Add(new LatLng(50.886771, 5.974599));
            rectOptions.Add(new LatLng(50.887763, 5.973553));
            rectOptions.Add(new LatLng(50.887844, 5.973081));
            rectOptions.Add(new LatLng(50.888044, 5.97255));
            rectOptions.Add(new LatLng(50.887827, 5.973199));
            rectOptions.Add(new LatLng(50.888869, 5.97321));
            rectOptions.Add(new LatLng(50.890088, 5.974572));
            rectOptions.Add(new LatLng(50.890355, 5.974374));
            rectOptions.Add(new LatLng(50.89045, 5.973918));
                
            Polyline kortsteroute = GMap.AddPolyline(rectOptions);
        }

    }
}

