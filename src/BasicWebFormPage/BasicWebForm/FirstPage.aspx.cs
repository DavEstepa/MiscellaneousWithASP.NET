using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BasicWebForm
{
    public partial class FirstPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void EnviarButton_Click(object sender, EventArgs e)
        {
            string name_value = Name.Text;
            string document = Document.Text;
            string address = Address.Text;

            var persona = new
            {
                Name = name_value,
                Document = document,
                Address = address
            };

            // Convertir el objeto a formato JSON
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(persona);

            // URL del endpoint del controlador para generar el PDF
            string url = "https://localhost:44361/api/PDF/GenerarPDF";

            // Realizar la petición POST al endpoint
            using (HttpClient client = new HttpClient())
            {
                // Configurar la cabecera para indicar que estamos enviando JSON
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                // Realizar la petición POST y obtener la respuesta
                HttpResponseMessage response = client.PostAsync(url, new StringContent(json, Encoding.UTF8, "application/json")).Result;

                // Leer el contenido de la respuesta
                string base64Pdf = response.Content.ReadAsStringAsync().Result;

                // Aquí podrías realizar alguna acción con el PDF en base64,
                // como descargarlo o mostrarlo en la página.
                // Por ejemplo, para descargarlo:
                Response.ContentType = "application/pdf";
                Response.AddHeader("Content-Disposition", "attachment; filename=informacion_persona.pdf");
                Response.BinaryWrite(Convert.FromBase64String(base64Pdf));
                Response.End();
            }
        }
    }
}