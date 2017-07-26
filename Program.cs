using System;
using Microsoft.Owin.Hosting;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.FileSystems;
using Microsoft.Owin.StaticFiles;
using Owin;

namespace Exercício_Gávea
{
	class Program
	{
		static void Main(string[] args)
		{
            /*var url = "http://localhost:8080";
            var root = args.Length > 0 ? args[0] : ".";
            var fileSystem = new PhysicalFileSystem(root);
            var options = new FileServerOptions();

            options.EnableDirectoryBrowsing = true;
            options.FileSystem = fileSystem;

            WebApp.Start(url, builder => builder.UseFileServer(options));
            Console.WriteLine("Listening at " + url);
            Console.ReadLine();*/
            //teste

            string url = "http://localhost:9000/";
            WebApp.Start<Startup>(url: url);
            Console.WriteLine("Rodando em " + url);
            Console.ReadLine();
		}
	}
}
