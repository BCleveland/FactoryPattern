using FactoryPattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FactoryPattern.Factories
{
    public class WPFFactory
    {
		public void ExportToFile(List<WindowData> data)
		{
			//TODO: Make data open in a WPF window
			XElement element = new XElement("Items");
			foreach(WindowData item in data)
			{
				element.Add(new XElement("Type", item.ElementType));
				element.Add(new XElement("Content", item.ContentText));
				element.Add(new XElement("Height", item.HeightLength));
				element.Add(new XElement("Width", item.WidthLength));
				element.Add(new XElement("Top", item.TopPosition));
				element.Add(new XElement("Left", item.LeftPosition));
			}
			XDocument document = new XDocument();
			document.Add(element);
			document.Save("items.xml", SaveOptions.DisableFormatting);
		}
	}
}
