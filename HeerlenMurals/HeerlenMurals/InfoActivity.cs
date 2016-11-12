//Gemaakt door Pascal Vos, Dani Truijen, Folkert Wolfs
//Gemaakt in 2016 op Hogeschool Zuyd

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
        //In deze Activity worden er lijsten gecreëerd met informatie van de Murals
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            //Hier wordt de ID ontvangen die vanuit MapActivity naar InfoActivity zijn gestuurd
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
                "http://liquidluck.de",
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
                "http://super-a.nl" + "\n" + "http://collinvandersluijs.com",
                "http://spielerei.nl",
                "http://claudioethos.blogspot.nl",
                "http://finok.com"
            };
            string[] Info = new string[]
                 {
                "Cyrcle is a two-man collective of multidisciplinary artists born out of Los Angeles, California in 2010. Their work focuses on life, duality, and the human condition. Those concepts, combined with the aesthetic consideration of form, typeface, color, and balance are what creates their signature style. Refusing to constrain themselves to a particular definition- street artists, graphic designers, traditional fine artists- the collective is interested in what the function and form of the work itself demands. Through street campaigns, design, fine art, murals, and collaborations, their work blurs the lines within the contemporary art world. Cyrcle reveals complex ideologies in their simplest forms.",
                "Robert Matzke, AKA “Rookie” is no stranger to humour and sarcasm in his artwork. As with all members of THE WEIRD crew. A little bit of pop culture, a dash of the grotesque, a dab of low brow art, add pressure apply cap and shake well..",
                "His work can be disciribed as personal pleasures and struggles in daily life. Translated in his own visual language. The work from Collin van der Sluijs has been publicated in magazines, books, and shown in galleries and project-spaces or walls in The Netherlands, Germany, France, England, Belgium, The U.S.A, Luxembourg, Italy, United Kingdom, Spain.",
                "Inti is the figure flagship of the new generation of Chilean artists, he leaves behind a trail of graffiti unrepentant today to reveal the richness of Latin American culture, in which he draws his inspiration. So he revives the iconic character “Kusillo” has now become a key figure in the four corners of the world and in the middle of urban art. For Inti, the Kusillo is also a perfect allegory of his thinking, his art and his identity.",
                "Super A (Goes, NL) never falls short of baffling the spectator with his high metaphoric scenarios rendered in a supreme (hyper)realist style. Often his works resemble a Pandora’s box giving rise to an endlessly detailed flood of visual references. While most of is his paintings are of a dreamy-surreal atmosphere they may also communicate a subtle, but nevertheless harsh critique of world politics. Yet no matter how melancholic or political his paintings may be, one will always spot one or two of his cartoonish characters in them that seem to set a comic counterpoint to an overall earnest atmosphere. In both his studio works and his works in public space (murals, sculptures).",
                "Felipe Pantone’s body of work spans from graffiti to kinetic art. Strong contrasts, vivid colors, effects, and the use of mixed medium and varied technique combine to impact strongly on the viewer. What really intrigues is not the striking nature of his work, but the artist’s journey to discover this aesthetic. We live in a time where more images are produced than can possibly be seen, and the impetus for an artist to stand out from the others is stronger than ever. Information flows at an exponentially increasing rate, a leitmotif recurrent in Felipe Pantone’s compositions, his hyperactivity, working methods and his constant traveling around the world. Someone who aspires to do something important in art must understand the world and time they inhabit. Felipe Pantone understands perfectly.",
                "1010 is a Hamburg-based contemporary artist known for his enigmatic, portal-like street art illusions on walls around the world. 1010 has been creating these mysterious, portal-like street art illusions on walls around the world since 2009 “His technique creates a certain depth to a plain wall simply by painting concentric layers of color.",
                "Mr. June started graffiti in 1985. Still having fun. playing with letters and dimensions.",
                "I am inspired in Heerlen by the literary realism of Dosteyevski. In this case I wanted to emphasize a way of life, ¨ be positive ¨. This mural I made in Heerlen Netherlands, a beautiful city that had its boom in the XX century thanks to coal mining, in 1965 the Mines were ordered to shut down and discontinue to extract the mineral. This generated a symptom of distress and left much of the society insecure in their economic and well-being. This negative outlook was transmitted through to the working class generations of the region, whereby the current crisis is having it’s heyday and all the anguish feels relevant again. Heerlen is today a city that wears its order, beautiful homes with society with a rise of senior citizens and a high index of empty spaces(premises, hotels, houses, churches). I believe that the “Transition” would be a positive one for the people who believe and are not afraid of a change.A good start is a “movement of ideas” towards the positive and constructive. The change is real and only just begun, and it is happening now. Stay Positive.",
                "The artist describes his artwork as: “It can be said that it is a constant evolution with a goal thought and done specifically for a place/ time. It is a visual impact that is used for sowing awareness linking respect, diversity and freedom”. DOURONE started with graffiti in Madrid, Spain in 1999. His style is defined as SENTIPENSANTE*. In 2012, he starts working with Elodieloll forming a team and living in several countries. Today they continue with their world tour: “ART FOR THE PEOPLE” *Contraction of the word feeling and thinking. Style created by Uruguayan journalist and writer Eduardo Galeano.",
                "Dzia is a Belgian artist and something of an enigma in the Antwerp area. A fine artist in every sense, the creations of Dzia range from paintings, through sculpture to taxidermy and street works and among other things he is also creator of copyzine KRANK.",
                "Stohead is bridging the gap between urban calligraphy and contempory abstraction.The artist is living and working in Berlin. “My motivation is to win the challenge with myself”",
                "Faith47 is an internationally acclaimed visual artist from South Africa who has been applauded for her ability to resonate with people around the world. Through her work, Faith47 attempts to disarm the strategies of global realpolitik, in order to advance the expression of personal truth. In this way, her work is both an internal and spiritual release that speaks to the complexities of the human condition, its deviant histories and existential search. Channelling the international destinations that have been imprinted on her after two decades of interacting with urban environments as one of the most renowned and prolific muralists, she continues to examine our place in the world. Using a wide range of media intended for gallery settings, her approach is explorative and substrate appropriate, including found and rescued objects, shrine construction, painting, projection mapping, video installation, printmaking and drawings. The seeds for Faith47’s works begin with a raw intimacy.Exploring the duality of human relationships, her imagery carries the profound weight of our interconnectedness. While some people see a dilapidated building as proof that the world is purging itself of the unwanted, Faith47 is reclaiming these forgotten elements with a sensuality of her own and presenting them with a virtuoso’s skill - set.",
                "Case is the alias of Andreas von Chrzanowski an artist from the German graffiti scene who was born and raised East Germany. As early as 1995, he began painting with spray cans, and he uses this medium to make photorealistic images of body forms and portraits. Case is one of four members of the Maclaim Crew, founded in the year 2000. Maclaim is known for having established photorealistic works with spray cans in Germany.",
                "DaLeast was born in Wuhan, China and is currently based in Cape Town, South Africa. He studied Sculpture at the Institute of Fine Arts and began making art in public spaces in 2004. His murals can be found in cities around the world including the U.S., Switzerland, Namibia, France, Israel, Australia, China and Heerlen.",
                "Dutch artist Super A never falls short of baffling the spectator with his high metaphoric scenarios rendered in a supreme (hyper)realist style. Often his works resemble a Pandora’s box giving rise to an endlessly detailed flood of visual references. While most of is his paintings are of a dreamy-surreal atmosphere they may also communicate a subtle, but nevertheless harsh critique of world politics. Yet no matter how melancholic or political his paintings may be, one will always spot one or two of his cartoonish characters in them that seem to set a comic counterpoint to an overall earnest atmosphere. In both his studio works and his works in public space (murals, sculptures) Collin van der Sluijs. His work can be disciribed as personal pleasures and struggles in daily life. Translated in his own visual language. The work from Collin van der Sluijs has been publicated in magazines, books, and shown in galleries and project-spaces or walls in The Netherlands, Germany, France, England, Belgium, The U.S.A, Luxembourg, Italy, United Kingdom, Spain.",
                "Johan Moorman’s work is colorful and has clear lines. Retro-futuristic designs of, for instance, cities and products inspire him. His illustrations are demonstrated in murals, animations or prints. Johan Moorman is also owner and creative director of Spielerei concept & design.",
                "Ethos was born in São Paulo in 1982 and currently lives and work there. He began putting in work around the age of 15 with spray paint as well as ballpoint pen, which to this day serves as his primary tools. The content this work, both indoors and outdoors, is inevitably related to the struggle of day-to-day existence that Sao Paulistas experience. Population density and the constant strain of urban anxiety become the subjects for many of Ethos’ narratives.Ethos’ characters have undeniably become some of the most recognized all throughout Brazil with his ephemeral work at times straddling the line of the figurative and abstract. His elongated, flexible, and strained figures have an almost liquid quality to them; one foot firmly in the school of the surrealists.He also displays a solid grasp of textiles in the use of patterns.Huge black balls serve as eyes for the exhausted and maligned residents of the concrete jungle.These characters are a mixture of dreams and fragments of everyday life within the city.",
                "Finok (Sao Paulo) noticed some kids painting graffiti in the street back in 2002. He was intrigued by this creative but illegal activity and quickly got into the”graffiti game” himself. A few years later he became a member of the infamous Vlok crew consisting of graffiti legends like Os Gemeos, Nunca, lse, Vino, Remio and many others. The cultural diversity and ethnic composition of his motherland have great influence on his work. He tries to capture the daily life in a poetic way with humor, and uses hereby elements that people can easily overlook in his art."
            };
            //Nadat de Id is ontvangen wordt uit alle lijsten de juiste informatie gehaald
            //Hierna wordt alle informatie van de betreffende marker naar de MapActivity gestuurd
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