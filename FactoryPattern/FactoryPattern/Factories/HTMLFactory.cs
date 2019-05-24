﻿using FactoryPattern.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern.Factories
{
    public class HTMLFactory
    {
		public void ExportToFile(List<WindowData> data)
		{
			StringBuilder code = new StringBuilder();
			code.AppendLine("<!--Begin Generated Code-->");
			foreach(var element in data)
			{
				code.AppendLine("ctx.fillRect(0, 0, 150, 75);");
			}
			code.AppendLine("<!--End Generated Code-->");
			string file = File.OpenText("../../HtmlTemplate.html").ReadToEnd();
			string finished = file.Replace("<!--CodeHere-->", code.ToString());
			File.WriteAllText("Output.html", finished);
			System.Diagnostics.Process.Start("Output.html");
		}
    }
}
