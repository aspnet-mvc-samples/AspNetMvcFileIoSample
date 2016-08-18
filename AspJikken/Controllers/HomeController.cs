using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspJikken.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			string dirpath = Server.MapPath("~/App_Data");
			string filepath = Server.MapPath("~/App_Data/hoge.txt");

			// Check and create directory
			string dirinfo = "";
			if (!Directory.Exists(dirpath))
			{
				dirinfo += "Directory not found: " + dirpath + "\n";

				// Create
				Directory.CreateDirectory(dirpath);
				dirinfo += "Created directory.\n";
			}
			else{
				dirinfo += "Directory already exists: " + dirpath + "\n";
			}
			ViewBag.DirInfo = dirinfo;

			// Write file (append)
			using (var fout = new StreamWriter(filepath, true))
			{
				fout.WriteLine("---");
				fout.WriteLine("DateTime: " + DateTime.Now.ToString());
				fout.WriteLine("Path: " + filepath);
				fout.WriteLine("");
			}

			// Read file
			using (var fin = new StreamReader(filepath))
			{
				ViewBag.FileInfo = fin.ReadToEnd();
			}

			// Remove file if reach the limit
			if (new FileInfo(filepath).Length > 1000)
			{
				System.IO.File.Delete(filepath);
			}
	
			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}