using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;

namespace Cards
{
	[XmlRoot("cards")]
	public class Cards
	{
		[XmlElement("card")]
		public List<Card> Card { get; set; }

		public static Cards CardsFactory(string nativeLang, string foreignLang, string category)
		{
			string path = Path.Combine (
				System.Environment.GetFolderPath (System.Environment.SpecialFolder.Personal), nativeLang, foreignLang, category + ".xml"
			);

			XmlSerializer serializer = new XmlSerializer (typeof(Cards));

			Cards cards;

			using(TextReader reader = new StreamReader(path))
			{
				cards = (Cards) serializer.Deserialize(reader);
			}

			return cards;
		}
	}

	[Serializable]
	public class Card
	{
		[XmlElement("level")]
		public int Level { get; set; }
		[XmlElement("native")]
		public List<Item> Native { get; set; }
		[XmlElement("foreign")]
		public List<Item> Foreign { get; set; }
	}

	[Serializable]
	public class Item
	{
		[XmlElement("item")]
		public ItemElement ItemElement { get; set; }
	}

	[Serializable]
	public class ItemElement {
		[XmlText]
		public String Text {get;set;}

		[XmlAttribute("type")]
		public ItemType Type {get;set;}
	}

	public enum ItemType
	{
		master,
		slave,
		example
	}
}

