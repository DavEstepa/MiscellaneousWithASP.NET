using BasicWebAPI.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace BasicWebAPI.Controllers
{
    public class ClientesController : ApiController
    {
        [HttpGet]
        [Route("api/Clientes/{document}")]
        public HttpResponseMessage Get(string document)
        {
            var repository = new ClientesRepository();

            string content = JsonConvert.SerializeObject(repository.GetByDocument(document));
            // Crear una respuesta HTTP con contenido JSON
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StringContent(content, System.Text.Encoding.UTF8, "application/json");

            return response;
        }
    }
}
