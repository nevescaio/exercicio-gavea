using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Exercício_Gávea
{
	public class LogHandler : DelegatingHandler
	{
		protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
		{

            Console.WriteLine("Request recebido:");
			Console.WriteLine(request.ToString());

            Stopwatch sw = new Stopwatch();
            sw.Start();
            if (request.Content != null)
			{
				Console.WriteLine("Content:");
				Console.WriteLine(await request.Content.ReadAsStringAsync());
			}
			Console.WriteLine();

			HttpResponseMessage response = await base.SendAsync(request, cancellationToken);
            sw.Stop();

            Console.WriteLine("Response enviado:");
			Console.WriteLine(response.ToString());
			if (response.Content != null)
			{
				Console.WriteLine("Content:");
				Console.WriteLine(await response.Content.ReadAsStringAsync());
			}
            Console.WriteLine();
            Console.WriteLine("Tempo de resposta = {0}", sw.Elapsed);
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.WriteLine();

            return response;
		}
	}

}
