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
    [Activity(Label = "InfoActivity")]
    public class InfoActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            string Id = Intent.GetStringExtra("ID") ?? "Data not available";
            string[] Title = new string[]
            {
                "Struggle",
                "Dedication",
                "Swinging birds",
                "Creed",
                "Pinata",
                "Kinetic",
                "Abyss & No boundaries",
                "Black and Yellow",
                "Movement of Ideas",
                "Diversiteit",
                "Ne knien",
                "Here Now",
                "Alas! how pitiful",
                "A miracle elixir",
                "Self Portrait",
                "Koolpiet - forward in time",
                "Let the good times roll",
                "Untitled",
                "Trópicos"
            };
            string[] Maker = new string[]
                {
                "Cyrcle",
                "Rookie (The Weird Crew)",
                "Collin van der Sluijs",
                "Inti",
                "Super A",
                "Felipe Pantone",
                "1010",
                "Mr June",
                "Cristian Riffel",
                "Dourone",
                "Dzia",
                "Stohead",
                "Faith47",
                "Case",
                "Daleast",
                "Super A & Collin van der Sluijs",
                "Johan Moorman",
                "Ethos",
                "Finok"
           };
            string[] Make_date = new string[]
                {
                "2014",
                "2013",
                "2013",
                "2014",
                "2014",
                "2015",
                "2015",
                "2015",
                "2015",
                "2015",
                "2015",
                "2014",
                "2013",
                "2014",
                "2013",
                "2013",
                "2015",
                "2015",
                "2014",
           };
            string[] Website = new string[]
                {
                "http://cyrcle.com",
                "http://liquidluck.de/",
                "http://collinvandersluijs.com",
                "--",
                "http://super-a.nl",
                "http://felipepantone.com",
                "http://1010.biz",
                "http://mrjune.com",
                "http://christianriffel.com",
                "http://dourone.com",
                "http://dzia.be",
                "http://stohead.com",
                "http://faith47.com",
                "--",
                "http://daleast.com",
                "http://super-a.nl" + " " + "http://collinvandersluijs.com",
                "http://spielerei.nl",
                "http://claudioethos.blogspot.nl",
                "http://finok.com"
            };
            string[] Info = new string[]
                 {
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                ""
            };
            int i = Convert.ToInt32(Id);
            var Mural = new Intent(this, typeof(MapActivity));
            Mural.PutExtra("Title", Title[i]);
            Mural.PutExtra("Maker", Maker[i]);
            Mural.PutExtra("Make_date", Make_date[i]);
            Mural.PutExtra("Website", Website[i]);
            Mural.PutExtra("Info", Info[i]);
            SetResult(Result.Ok, Mural);
            Finish();
        }
    }
}