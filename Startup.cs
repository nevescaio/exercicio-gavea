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
            const string rootFolder = ".";
            var fileSystem = new PhysicalFileSystem(rootFolder);
            var options = new FileServerOptions
            {
                EnableDefaultFiles = true,
                FileSystem = fileSystem,
                EnableDirectoryBrowsing = true
            };

            appBuilder.UseFileServer(options);

            // Configure Web API for self-host.  
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
