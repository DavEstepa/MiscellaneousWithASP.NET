using BasicWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Http;
using System.Xml.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace BasicWebAPI.Controllers
{
    public class PDFController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage GetExample()
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StringContent("Hola", Encoding.UTF8, "text/plain");

            return response;
        }

        [HttpPost]
        public HttpResponseMessage GenerarPDF([FromBody] Cliente persona)
        {
            // Crear el documento PDF
            MemoryStream stream = new MemoryStream();
            Document pdfDoc = new Document(PageSize.A4, 50, 50, 15, 15);
            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
            pdfDoc.Open();

            // Agregar el contenido al PDF
            Paragraph paragraph = new Paragraph($"Nombre: {persona.Name}\nDocumento: {persona.Document}\nDirección: {persona.Address}");
            pdfDoc.Add(paragraph);

            pdfDoc.Close();

            // Convertir el PDF a base64
            byte[] pdfBytes = stream.ToArray();
            string base64String = Convert.ToBase64String(pdfBytes);

            // Preparar la respuesta con el PDF en base64
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StringContent(base64String, Encoding.UTF8, "application/pdf");
            response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
            {
                FileName = "informacion_persona.pdf"
            };

            return response;
        }
    }
}
