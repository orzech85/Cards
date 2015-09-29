using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Xml.Serialization;
using System.IO;

namespace Cards
{
	[Activity (Label = "Cards", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.Main);

			Cards result;

			String mainPath = System.Environment.GetFolderPath (System.Environment.SpecialFolder.Personal);

			Directory.CreateDirectory (Path.Combine (mainPath, "pl", "de"));

			String exampleXmlFile = Path.Combine (mainPath, "pl", "de", "example.xml");


			using (var fileStream = new FileStream(exampleXmlFile, FileMode.Create, FileAccess.Write))
			{
				Resources.OpenRawResource (Resource.Raw.example).CopyTo(fileStream);
			}

//			exampleXmlFile = Path.Combine (mainPath, "pl", "de", "pl_en.xml");
//
//			using (var fileStream = new FileStream(exampleXmlFile, FileMode.Create, FileAccess.Write))
//			{
//				Resources.OpenRawResource (Resource.Raw.pl_en).CopyTo(fileStream);
//			}

			Button buttonStart = FindViewById<Button> (Resource.Id.buttonStart);
			Button buttonDownload = FindViewById<Button> (Resource.Id.buttonDownload);

			buttonStart.Click += (sender, e) => {
				StartActivity(typeof(SelectCardsActivity));
			};

			buttonDownload.Click += (sender, e) => {
				StartActivity(typeof(DownloadActivity));
			};


		}
	}
}


