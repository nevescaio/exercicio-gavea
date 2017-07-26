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
            string url = "http://localhost:9000/";
            WebApp.Start<Startup>(url: url);
            Console.WriteLine("Rodando em " + url);
            Console.ReadLine();
		}
	}
}
