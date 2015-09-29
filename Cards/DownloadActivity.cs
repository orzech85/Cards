
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
using System.Net;
using System.IO;

namespace Cards
{
	[Activity (Label = "DownloadActivity")]			
	public class DownloadActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			String mainPath = System.Environment.GetFolderPath (System.Environment.SpecialFolder.Personal);

			String XmlPath = Path.Combine (mainPath, "pl", "de");

			string[] fileList;

			using (WebClient client = new WebClient ())
			{
				fileList = client.DownloadString("http://app4free.pl/cards/index.php").Split(';');
			}

			fileList = fileList.Take(fileList.Length - 1).ToArray();

			SetContentView (Resource.Layout.Download);

			if (fileList.Length > 0) {
				
				ListView listView = FindViewById<ListView> (Resource.Id.listView);
				listView.Adapter = new ArrayAdapter (this, Android.Resource.Layout.SimpleListItem1, fileList);

				listView.ItemClick += (sender, e) => {
					using (WebClient client = new WebClient ()) {
						client.DownloadFile ("http://app4free.pl/cards/" + fileList [e.Position] + ".xml", Path.Combine (XmlPath, fileList [e.Position] + ".xml"));
					}
					Toast.MakeText (this, fileList [e.Position] + " downloaded!", ToastLength.Short).Show ();
				};
			}
		}
	}
}

