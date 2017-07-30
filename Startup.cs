using System;
using Owin;
using System.Web.Http;
using Microsoft.Owin.FileSystems;
using Microsoft.Owin.StaticFiles;

namespace Exercício_Gávea
{
	class Startup
	{
		// This code configures Web API. The Startup class is specified as a type 
         // parameter in the WebApp.Start method. 
         public void Configuration(IAppBuilder appBuilder)
         {
            // Permitir acessar o arquivo index.html e definir como padrao.
            var fileSystem = new PhysicalFileSystem(".");
            var options = new FileServerOptions
            {
                EnableDefaultFiles = true,
                FileSystem = fileSystem,
                EnableDirectoryBrowsing = true
            };

            appBuilder.UseFileServer(options);

            // Configurar Web API para self-host.
            HttpConfiguration config = new HttpConfiguration(); 
 
             config.MapHttpAttributeRoutes(); 
             config.MessageHandlers.Add(new LogHandler());
             config.Routes.MapHttpRoute(
                 name: "DefaultApi", 
                 routeTemplate: "api/{controller}/{day}", 
                 defaults: new {day = RouteParameter.Optional} 
             );

            appBuilder.UseWebApi(config);

            
        } 

	}
}
