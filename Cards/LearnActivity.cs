
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

namespace Cards
{
	[Activity (Label = "LearnActivity")]			
	public class LearnActivity : Activity
	{
		string nativeLang = "pl";
		string foreignLang = "de";
		string categoryName = "example";

		Cards cards;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			categoryName = Intent.GetStringExtra ("categoryName");

			cards = Cards.CardsFactory (nativeLang, foreignLang, categoryName);

			SetContentView (Resource.Layout.Learn);

			CardLayout cardView = FindViewById<CardLayout> (Resource.Id.cardView);

			cardView.Cards = cards;
		}
	}
}

