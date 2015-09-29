using System;
using System.IO;

namespace CardsXmlGenerator
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			if (args.Length == 2)
			{

				string[] lines = File.ReadAllLines(args[0]);

				string output = "<cards>";

				foreach (var item in lines)
				{
					string[] items = item.Split(';');
					output += "<card><native><item type=\"master\">" + items[0] + "</item></native>" +
						"<foreign><item type=\"master\">" + items[1] + "</item></foreign></card>";
				}

				output += "</cards>";

				File.WriteAllText(args[1], output);

			} else
			{
				Console.WriteLine("zla liczba parametrow");
			}
		}
	}
}
