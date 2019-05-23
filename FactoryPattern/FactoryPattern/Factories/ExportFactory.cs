using FactoryPattern.Factories;
using FactoryPattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern
{
    public static class ExportFactory
    {
		public static void Export(string type, List<WindowData> data)
		{
			switch(type)
			{
				case "WPF":
					ToWPF(data);
					break;
				case "HTML":
					ToHTML(data);
					break;
				default:
					throw new ArgumentException(type + " is not an implemented export type.");
			}
		}
		private static void ToWPF(List<WindowData> data)
		{
			WPFFactory factory = new WPFFactory();
			factory.ExportToFile(data);
		}
		private static void ToHTML(List<WindowData> data)
		{
			HTMLFactory factory = new HTMLFactory();
			factory.ExportToFile(data);
		}
    }
}
