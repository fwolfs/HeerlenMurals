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

        private void SetUpToolbar()
        {
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetActionBar(toolbar);
            ActionBar.Title = "Heerlen Murals";
            ActionBar.SetDisplayHomeAsUpEnabled(true);
            ActionBar.SetHomeButtonEnabled(true);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            base.OnBackPressed();
            return base.OnOptionsItemSelected(item);
        }

        private void SetUpMap()
        {
            if (GMap == null)
            {
                FragmentManager.FindFragmentById<MapFragment>(Resource.Id.googlemap).GetMapAsync(this);
            }
        }

        public void OnMapReady(GoogleMap googleMap)
        {
            //init
            this.GMap = googleMap;
            GMap.UiSettings.ZoomControlsEnabled = true;
            //GMap.MyLocationEnabled = true;
            GMap.UiSettings.MyLocationButtonEnabled = true;
            GMap.UiSettings.MapToolbarEnabled = false;
            GMap.UiSettings.CompassEnabled = true;

            //locatie
            LatLng latLng = new LatLng(50.88749555703811, 5.978665351867676);
            GMap.MoveCamera(CameraUpdateFactory.NewLatLngZoom(latLng,15));

            //Locaties Murals
            //Stationstraat 13, 6411 NH Heerlen
            MarkerOptions Mural_1 = new MarkerOptions();
            Mural_1.SetPosition(new LatLng(50.8897834, 5.977796300000023));
            Mural_1.SetTitle("Struggle");
            Mural_1.SetSnippet("Info hier");
            GMap.AddMarker(Mural_1);

            //Gasthuisstraat 2, 6411 KE Heerlen
            MarkerOptions Mural_2 = new MarkerOptions();
            Mural_2.SetPosition(new LatLng(50.88751269999999, 5.981181500000048));
            Mural_2.SetTitle("Dedication");
            Mural_2.SetSnippet("Info hier");
            GMap.AddMarker(Mural_2);

            //Plaarstraat 14, 6411 JV Heerlen
            MarkerOptions Mural_3 = new MarkerOptions();
            Mural_3.SetPosition(new LatLng(50.8871116, 5.981422199999997));
            Mural_3.SetTitle("Swining birds");
            Mural_3.SetSnippet("Info hier");
            GMap.AddMarker(Mural_3);

            //Spoorsingel 60, 6412 AA Heerlen
            MarkerOptions Mural_4 = new MarkerOptions();
            Mural_4.SetPosition(new LatLng(50.891703, 5.976202999999941));
            Mural_4.SetTitle("Creed");
            Mural_4.SetSnippet("Info hier");
            GMap.AddMarker(Mural_4);

            //Spoorsingel 50, 6412 AC Heerlen
            MarkerOptions Mural_5 = new MarkerOptions();
            Mural_5.SetPosition(new LatLng(50.89182419999999, 5.976532600000041));
            Mural_5.SetTitle("Pinata");
            Mural_5.SetSnippet("Info hier");
            GMap.AddMarker(Mural_5);

            //Spoorsingel 44, 6412 AC Heerlen
            MarkerOptions Mural_6 = new MarkerOptions();
            Mural_6.SetPosition(new LatLng(50.8911625, 5.977618500000062));
            Mural_6.SetTitle("Kinetic");
            Mural_6.SetSnippet("Info hier");
            GMap.AddMarker(Mural_6);

            //Kempkensweg 3, 6412 Heerlen
            MarkerOptions Mural_7 = new MarkerOptions();
            Mural_7.SetPosition(new LatLng(50.8921635, 5.976991699999985));
            Mural_7.SetTitle("Abyss & No boundaries");
            Mural_7.SetSnippet("Info hier");
            GMap.AddMarker(Mural_7);

            //Robroekergats 79, 6412 AX Heerlen
            MarkerOptions Mural_8 = new MarkerOptions();
            Mural_8.SetPosition(new LatLng(50.8912132, 5.97824449999996));
            Mural_8.SetTitle("Black and Yellow");
            Mural_8.SetSnippet("Info hier");
            GMap.AddMarker(Mural_8);

            //Spoorsingel 4, 6412 AA Heerlen
            MarkerOptions Mural_9 = new MarkerOptions();
            Mural_9.SetPosition(new LatLng(50.8906907, 5.978479399999969));
            Mural_9.SetTitle("Movement of Ideas");
            Mural_9.SetSnippet("Info hier");
            GMap.AddMarker(Mural_9);

            //Spoorsingel 2, 6412 AA Heerlen
            MarkerOptions Mural_10 = new MarkerOptions();
            Mural_10.SetPosition(new LatLng(50.8905998, 5.978662999999983));
            Mural_10.SetTitle("Diversiteit");
            Mural_10.SetSnippet("Info hier");
            GMap.AddMarker(Mural_10);

            //Pancratiusstraat 44, 6411 KC Heerlen
            MarkerOptions Mural_11 = new MarkerOptions();
            Mural_11.SetPosition(new LatLng(50.8873042, 5.979772000000025));
            Mural_11.SetTitle("Ne knien");
            Mural_11.SetSnippet("Info hier");
            GMap.AddMarker(Mural_11);

            //Nobelstraat 16, 6411 EM Heerlen
            MarkerOptions Mural_12 = new MarkerOptions();
            Mural_12.SetPosition(new LatLng(50.8853896, 5.97976170000004));
            Mural_12.SetTitle("Here Now");
            Mural_12.SetSnippet("Info hier");
            GMap.AddMarker(Mural_12);

            //Coriovallumstraat 7, 6411 CA Heerlen
            MarkerOptions Mural_13 = new MarkerOptions();
            Mural_13.SetPosition(new LatLng(50.8856446, 5.977349099999969));
            Mural_13.SetTitle("Alas! how pitiful");
            Mural_13.SetSnippet("Info hier");
            GMap.AddMarker(Mural_13);

            //Kruisstraat 51, 6411 BR Heerlen
            MarkerOptions Mural_14 = new MarkerOptions();
            Mural_14.SetPosition(new LatLng(50.8843429, 5.977019899999959));
            Mural_14.SetTitle("A miracle elixir");
            Mural_14.SetSnippet("Info hier");
            GMap.AddMarker(Mural_14);

            //Coriovallumstraat 26, 6411 CC Heerlen
            MarkerOptions Mural_15 = new MarkerOptions();
            Mural_15.SetPosition(new LatLng(50.8855164, 5.976054400000066));
            Mural_15.SetTitle("Self Portrait");
            Mural_15.SetSnippet("Info hier");
            GMap.AddMarker(Mural_15);

            //Honigmannstraat 2, 6411 LL Heerlen
            MarkerOptions Mural_16 = new MarkerOptions();
            Mural_16.SetPosition(new LatLng(50.8869963, 5.976698499999998));
            Mural_16.SetTitle("Koolpiet - forward in time");
            Mural_16.SetSnippet("Info hier");
            GMap.AddMarker(Mural_16);

            //Geerstraat 2, 6411 NR Heerlen
            MarkerOptions Mural_17 = new MarkerOptions();
            Mural_17.SetPosition(new LatLng(50.8869257, 5.974665400000049));
            Mural_17.SetTitle("Let the good times roll");
            Mural_17.SetSnippet("Info hier");
            GMap.AddMarker(Mural_17);

            //Laanderstraat 27, 6411 VA Heerlen
            MarkerOptions Mural_18 = new MarkerOptions();
            Mural_18.SetPosition(new LatLng(50.8879613, 5.972532699999988));
            Mural_18.SetTitle("Untitled");
            Mural_18.SetSnippet("Info hier");
            GMap.AddMarker(Mural_18);

            DrawShortRoute();
        }

        private void DrawShortRoute()
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

            Polyline polyLine = GMap.AddPolyline(rectOptions);
        }
    }
}

