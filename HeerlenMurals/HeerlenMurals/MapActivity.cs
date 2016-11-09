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
                Toast.MakeText(this, item.TitleFormatted + " Geselecteerd", ToastLength.Short).Show();
                drawShortRoute();
                return base.OnOptionsItemSelected(item);
            }
            if (item.ItemId == Resource.Id.winkel_route)
            {
                Toast.MakeText(this, item.TitleFormatted + " Geselecteerd", ToastLength.Short).Show();
                return base.OnOptionsItemSelected(item);
            }
            if (item.ItemId == Resource.Id.natuur_route)
            {
                Toast.MakeText(this, item.TitleFormatted + " Geselecteerd", ToastLength.Short).Show();
                drawNatureRoute();
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

            //GPS controle
            LocationManager mlocManager = (LocationManager)GetSystemService(LocationService); ;
            bool enabled = mlocManager.IsProviderEnabled(LocationManager.GpsProvider);
            if (enabled == false)
            {
                AlertDialog.Builder alert = new AlertDialog.Builder(this);
                alert.SetTitle("GPS");
                alert.SetMessage(GetString(Resource.String.GPS_disabled) + "\n" + GetString(Resource.String.GPS_question));
                alert.SetNegativeButton(GetString(Resource.String.No), (senderAlert, args) =>
                {

                });
                alert.SetPositiveButton(GetString(Resource.String.Yes), (senderAlert, args) =>
                {
                    var intent = new Intent(Android.Provider.Settings.ActionLocationSourceSettings);
                    StartActivity(intent);
                });

                Dialog dialog = alert.Create();
                dialog.Show();
            }

            //Maakt mogelijk dat je op marker kan klikken
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
                alert.SetMessage(maker_info + "\n" + make_date_info + "\n"+ website + "\n" + "\n" + info);
                alert.SetPositiveButton(GetString(Resource.String.Close), (senderAlert, args) =>
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
            MarkerOptions Mural_markers = new MarkerOptions();
            Mural_markers.SetPosition(new LatLng(50.8897834, 5.977796300000023));
            GMap.AddMarker(Mural_markers);
            //Gasthuisstraat 2, 6411 KE Heerlen
            Mural_markers.SetPosition(new LatLng(50.88751269999999, 5.981181500000048));
            GMap.AddMarker(Mural_markers);
            //Plaarstraat 14, 6411 JV Heerlen
            Mural_markers.SetPosition(new LatLng(50.8871116, 5.981422199999997));
            GMap.AddMarker(Mural_markers);
            //Spoorsingel 60, 6412 AA Heerlen
            Mural_markers.SetPosition(new LatLng(50.891703, 5.976202999999941));
            GMap.AddMarker(Mural_markers);
            //Spoorsingel 50, 6412 AC Heerlen
            Mural_markers.SetPosition(new LatLng(50.89182419999999, 5.976532600000041));
            GMap.AddMarker(Mural_markers);
            //Spoorsingel 44, 6412 AC Heerlen
            Mural_markers.SetPosition(new LatLng(50.8911625, 5.977618500000062));
            GMap.AddMarker(Mural_markers);
            //Kempkensweg 3, 6412 Heerlen
            Mural_markers.SetPosition(new LatLng(50.8921635, 5.976991699999985));
            GMap.AddMarker(Mural_markers);
            //Robroekergats 79, 6412 AX Heerlen
            Mural_markers.SetPosition(new LatLng(50.8912132, 5.97824449999996));
            GMap.AddMarker(Mural_markers);
            //Spoorsingel 4, 6412 AA Heerlen
            Mural_markers.SetPosition(new LatLng(50.8906907, 5.978479399999969));
            GMap.AddMarker(Mural_markers);
            //Spoorsingel 2, 6412 AA Heerlen
            Mural_markers.SetPosition(new LatLng(50.8905998, 5.978662999999983));
            GMap.AddMarker(Mural_markers);
            //Pancratiusstraat 44, 6411 KC Heerlen
            Mural_markers.SetPosition(new LatLng(50.8873042, 5.979772000000025));
            GMap.AddMarker(Mural_markers);
            //Nobelstraat 16, 6411 EM Heerlen
            Mural_markers.SetPosition(new LatLng(50.8853896, 5.97976170000004));
            GMap.AddMarker(Mural_markers);
            //Coriovallumstraat 7, 6411 CA Heerlen
            Mural_markers.SetPosition(new LatLng(50.8856446, 5.977349099999969));
            GMap.AddMarker(Mural_markers);
            //Kruisstraat 51, 6411 BR Heerlen
            Mural_markers.SetPosition(new LatLng(50.8843429, 5.977019899999959));
            GMap.AddMarker(Mural_markers);
            //Coriovallumstraat 26, 6411 CC Heerlen
            Mural_markers.SetPosition(new LatLng(50.8855164, 5.976054400000066));
            GMap.AddMarker(Mural_markers);
            //Honigmannstraat 2, 6411 LL Heerlen
            Mural_markers.SetPosition(new LatLng(50.8869963, 5.976698499999998));
            GMap.AddMarker(Mural_markers);
            //Geerstraat 2, 6411 NR Heerlen
            Mural_markers.SetPosition(new LatLng(50.8869257, 5.974665400000049));
            GMap.AddMarker(Mural_markers);
            //Laanderstraat 27, 6411 VA Heerlen
            Mural_markers.SetPosition(new LatLng(50.8879613, 5.972532699999988));
            GMap.AddMarker(Mural_markers);
            //Groene Boord Heerlen
            Mural_markers.SetPosition(new LatLng(50.887077, 5.985465));
            GMap.AddMarker(Mural_markers);
        }
        public void drawShortRoute()
        {
            PolylineOptions route = new PolylineOptions();

            route.Add(new LatLng(50.890609, 5.973794));
            route.Add(new LatLng(50.890717, 5.972582));
            route.Add(new LatLng(50.892128, 5.973258));
            route.Add(new LatLng(50.892236, 5.973714));
            route.Add(new LatLng(50.891874, 5.975581));
            route.Add(new LatLng(50.892179, 5.976691));
            route.Add(new LatLng(50.891959, 5.976241));
            route.Add(new LatLng(50.891262, 5.977287));
            route.Add(new LatLng(50.8909, 5.977796));
            route.Add(new LatLng(50.891198, 5.978306));
            route.Add(new LatLng(50.8909, 5.977796)); ;
            route.Add(new LatLng(50.890504, 5.978419));
            route.Add(new LatLng(50.890203, 5.979931));
            route.Add(new LatLng(50.88979, 5.979915));
            route.Add(new LatLng(50.889847, 5.977646));
            route.Add(new LatLng(50.889766, 5.978322));
            route.Add(new LatLng(50.888227, 5.979357));
            route.Add(new LatLng(50.888315, 5.980715));
            route.Add(new LatLng(50.887607, 5.98102));
            route.Add(new LatLng(50.887604, 5.981358));
            route.Add(new LatLng(50.88647, 5.982066));
            route.Add(new LatLng(50.887293, 5.984207));
            route.Add(new LatLng(50.887468, 5.985033));
            route.Add(new LatLng(50.887106, 5.985355));
            route.Add(new LatLng(50.887468, 5.985033));
            route.Add(new LatLng(50.886484, 5.982013));
            route.Add(new LatLng(50.887039, 5.97976));
            route.Add(new LatLng(50.887086, 5.979674));
            route.Add(new LatLng(50.887039, 5.97976));
            route.Add(new LatLng(50.886007, 5.980173));
            route.Add(new LatLng(50.885235, 5.979829));
            route.Add(new LatLng(50.885174, 5.978644));
            route.Add(new LatLng(50.885015, 5.97793));
            route.Add(new LatLng(50.88448, 5.976589));
            route.Add(new LatLng(50.884832, 5.976133));
            route.Add(new LatLng(50.885262, 5.975951));
            route.Add(new LatLng(50.885851, 5.977769));
            route.Add(new LatLng(50.886924, 5.977158));
            route.Add(new LatLng(50.886822, 5.976686));
            route.Add(new LatLng(50.887309, 5.976364));
            route.Add(new LatLng(50.886771, 5.974599));
            route.Add(new LatLng(50.887763, 5.973553));
            route.Add(new LatLng(50.887844, 5.973081));
            route.Add(new LatLng(50.888044, 5.97255));
            route.Add(new LatLng(50.887827, 5.973199));
            route.Add(new LatLng(50.888869, 5.97321));
            route.Add(new LatLng(50.890088, 5.974572));
            route.Add(new LatLng(50.890355, 5.974374));
            route.Add(new LatLng(50.89045, 5.973918));
                
            Polyline kortsteroute = GMap.AddPolyline(route);
        }
        public void drawNatureRoute()
        {
            PolylineOptions route = new PolylineOptions();

            route.Add(new LatLng(50.890443, 5.973676));
            route.Add(new LatLng(50.890727, 5.972528));
            route.Add(new LatLng(50.892229, 5.973322));
            route.Add(new LatLng(50.892283, 5.973730));
            route.Add(new LatLng(50.891891, 5.975704));
            route.Add(new LatLng(50.892270, 5.976584));
            route.Add(new LatLng(50.891823, 5.976069));
            route.Add(new LatLng(50.890889, 5.977678));
            route.Add(new LatLng(50.891160, 5.978172));
            route.Add(new LatLng(50.890889, 5.977678));
            route.Add(new LatLng(50.890483, 5.978429));
            route.Add(new LatLng(50.890172, 5.979974));
            route.Add(new LatLng(50.889630, 5.979846));
            route.Add(new LatLng(50.889915, 5.977657));
            route.Add(new LatLng(50.889630, 5.979846));
            route.Add(new LatLng(50.890158, 5.980167));
            route.Add(new LatLng(50.890023, 5.983751));
            route.Add(new LatLng(50.888087, 5.984609));
            route.Add(new LatLng(50.887140, 5.985403));
            route.Add(new LatLng(50.887559, 5.985403));
            route.Add(new LatLng(50.887302, 5.986691));
            route.Add(new LatLng(50.886246, 5.987549));
            route.Add(new LatLng(50.886097, 5.987871));
            route.Add(new LatLng(50.885678, 5.988021));
            route.Add(new LatLng(50.885461, 5.987442));
            route.Add(new LatLng(50.884446, 5.987399));
            route.Add(new LatLng(50.884527, 5.988836));
            route.Add(new LatLng(50.884076, 5.988815));
            route.Add(new LatLng(50.883717, 5.988622));
            route.Add(new LatLng(50.883487, 5.988632));
            route.Add(new LatLng(50.883358, 5.989029));
            route.Add(new LatLng(50.883487, 5.990220));
            route.Add(new LatLng(50.883358, 5.990714));
            route.Add(new LatLng(50.883040, 5.990907));
            route.Add(new LatLng(50.882742, 5.990789));
            route.Add(new LatLng(50.882668, 5.990596));
            route.Add(new LatLng(50.882641, 5.989759));
            route.Add(new LatLng(50.882979, 5.988311));
            route.Add(new LatLng(50.883141, 5.988032));
            route.Add(new LatLng(50.883338, 5.987839));
            route.Add(new LatLng(50.883656, 5.987839));
            route.Add(new LatLng(50.884055, 5.988804));
            route.Add(new LatLng(50.884543, 5.988879));
            route.Add(new LatLng(50.884285, 5.986240));
            route.Add(new LatLng(50.884265, 5.985972));
            route.Add(new LatLng(50.883717, 5.984266));
            route.Add(new LatLng(50.883791, 5.984073));
            route.Add(new LatLng(50.883473, 5.983000));
            route.Add(new LatLng(50.885003, 5.981498));
            route.Add(new LatLng(50.884624, 5.980489));
            route.Add(new LatLng(50.884983, 5.980146));
            route.Add(new LatLng(50.885098, 5.979792));
            route.Add(new LatLng(50.885226, 5.979803));
            route.Add(new LatLng(50.885192, 5.978622));
            route.Add(new LatLng(50.885131, 5.978247));
            route.Add(new LatLng(50.885010, 5.977925));
            route.Add(new LatLng(50.884468, 5.976605));
            route.Add(new LatLng(50.884136, 5.975672));
            route.Add(new LatLng(50.883900, 5.975726));
            route.Add(new LatLng(50.883676, 5.975876));
            route.Add(new LatLng(50.883561, 5.975447));
            route.Add(new LatLng(50.884346, 5.974782));
            route.Add(new LatLng(50.884495, 5.975264));
            route.Add(new LatLng(50.885219, 5.975715));
            route.Add(new LatLng(50.885883, 5.977786));
            route.Add(new LatLng(50.886167, 5.977603));
            route.Add(new LatLng(50.886499, 5.978858));
            route.Add(new LatLng(50.886709, 5.979803));
            route.Add(new LatLng(50.887081, 5.981637));
            route.Add(new LatLng(50.887622, 5.981390));
            route.Add(new LatLng(50.887588, 5.981047));
            route.Add(new LatLng(50.887169, 5.980403));
            route.Add(new LatLng(50.887115, 5.980114));
            route.Add(new LatLng(50.887176, 5.979674));
            route.Add(new LatLng(50.887345, 5.979502));
            route.Add(new LatLng(50.887270, 5.978644));
            route.Add(new LatLng(50.886837, 5.976723));
            route.Add(new LatLng(50.886797, 5.976691));
            route.Add(new LatLng(50.887311, 5.976359));
            route.Add(new LatLng(50.886763, 5.974588));
            route.Add(new LatLng(50.887846, 5.973494));
            route.Add(new LatLng(50.887798, 5.973140));
            route.Add(new LatLng(50.888170, 5.972346));
            route.Add(new LatLng(50.887798, 5.973140));
            route.Add(new LatLng(50.887859, 5.973451));
            route.Add(new LatLng(50.888604, 5.973183));
            route.Add(new LatLng(50.889050, 5.973365));
            route.Add(new LatLng(50.890147, 5.974621));
            route.Add(new LatLng(50.890417, 5.973891));

            Polyline mooisteroute = GMap.AddPolyline(route);
        }
    }
}

