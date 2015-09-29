
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
using System.IO;

namespace Cards
{
	[Activity (Label = "SelectCardsActivity")]			
	public class SelectCardsActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.SelectCards);

			ListView listView = FindViewById<ListView> (Resource.Id.listView);

			String mainPath = System.Environment.GetFolderPath (System.Environment.SpecialFolder.Personal);

			String xmlFilesPath = Path.Combine (mainPath, "pl", "de");

			String[] list = Directory.GetFiles (xmlFilesPath);

			for (int i = 0; i < list.Length; i++) {
				list[i] = Path.GetFileNameWithoutExtension(list[i]);
			}

			listView.Adapter = new ArrayAdapter (this, Android.Resource.Layout.SimpleListItem1, list);

			listView.ItemClick += (sender, e) => {
				Intent intent = new Intent(this, typeof(LearnActivity));
				intent.PutExtra("categoryName", list[e.Position]);
				StartActivity(intent);
			};
		}
	}
}

