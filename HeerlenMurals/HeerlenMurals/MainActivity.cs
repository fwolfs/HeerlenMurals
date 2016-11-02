using Android.App;
using Android.Widget;
using Android.OS;
using Android.Gms.Maps;

namespace HeerlenMurals
{
    [Activity(Label = "HeerlenMurals", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity, IOnMapReadyCallback
    {
        private GoogleMap GMap;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);
            SetUpMap();
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
            this.GMap = googleMap;
        }
    }
}

