using Dapper;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
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
                // Agregar el encabezado de autenticación Basic al cliente HTTP
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials);

                // Configurar la cabecera para indicar que estamos enviando JSON
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                // Realizar la petición POST y obtener la respuesta
                HttpResponseMessage response = client.PostAsync(url, new StringContent(json, Encoding.UTF8, "application/json")).Result;

                // Leer el contenido de la respuesta
                string base64Pdf = response.Content.ReadAsStringAsync().Result;
                InsertInfoIntoDb(name_value, document, address, base64Pdf);
                // Aquí podrías realizar alguna acción con el PDF en base64,
                // como descargarlo o mostrarlo en la página.
                // Por ejemplo, para descargarlo:
                Response.ContentType = "application/pdf";
                Response.AddHeader("Content-Disposition", "attachment; filename=informacion_persona.pdf");
                Response.BinaryWrite(Convert.FromBase64String(base64Pdf));
                Response.End();
            }
        }

        private void InsertInfoIntoDb(string Name, string Document, string Address, string PdfBase64)
        {
            string connection_string = "Server=localhost;Database=MuestrasRadiologicas;Trusted_Connection=True;";
            string stored_procedure = "clientes.sp_clientes_BasicInformation_Insert";
            var values = new { Name, Document, Address, PdfBase64};
            using (SqlConnection cnn = new SqlConnection(connection_string))
            {
                var results = cnn.Query(stored_procedure, values, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        private void BasicAuthentication()
        {
            string username = "";
            string password = "";
            string credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));

        }
    }
}