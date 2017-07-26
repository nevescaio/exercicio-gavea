using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Xml.Serialization;

namespace Exercício_Gávea
{
	public class PortfolioController : ApiController
	{
        // GET api/portfolio/5 
        public Portfolio Get(int day)
		{
            if(day < 1 || day > 7)
            {
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.BadRequest);
                response.ReasonPhrase = "Dia inválido";
                response.Content = new StringContent("O dia informado é inválido, o valor deve estar entre 1 e 7.");
                throw new HttpResponseException(response);
            }

            Portfolio portfolio = new Portfolio(day);
			return portfolio;
		}
	}
}
