using System;
using Microsoft.Owin.Hosting;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.FileSystems;
using Microsoft.Owin.StaticFiles;
using Owin;
using System.IO;

namespace Exercício_Gávea
{
	class Program
	{
		static void Main(string[] args)
		{
            // Copiar index.html, JS e CSS para mesmo diretorio do executavel
            string sourcePath = "../../front";
            string targetPath = ".";

            foreach (string directoryPath in Directory.GetDirectories(sourcePath, "*", SearchOption.AllDirectories))
                Directory.CreateDirectory(directoryPath.Replace(sourcePath, targetPath));

            foreach (string newPath in Directory.GetFiles(sourcePath, "*.*",SearchOption.AllDirectories))
                File.Copy(newPath, newPath.Replace(sourcePath, targetPath), true);

            // Iniciar API
            string url = "http://localhost:9000/";
            WebApp.Start<Startup>(url: url);
            Console.WriteLine("Rodando em " + url);
            Console.ReadLine();
		}
	}
}
