using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasicWebAPI.Entities
{
    public class ClientesBasicInformation
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }
        public string Address { get; set; }
        public string PdfBase64 { get; set; }
    }
}