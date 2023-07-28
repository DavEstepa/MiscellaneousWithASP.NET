using BasicWebAPI.Entities;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using Dapper;

namespace BasicWebAPI.Repository
{
    public class ClientesRepository
    {
        private readonly string _connectionString;
        public ClientesRepository()
        {
            _connectionString = "Server=localhost;Database=MuestrasRadiologicas;Trusted_Connection=True;";
        }

        public ClientesBasicInformation GetByDocument(string document)
        {
            string stored_procedure = "clientes.sp_clientes_BasicInformation_GetByDocument";
            var values = new { Document = document };
            ClientesBasicInformation result;
            using (SqlConnection cnn = new SqlConnection(this._connectionString))
            {
                result = cnn.Query<ClientesBasicInformation>(stored_procedure, values, commandType: CommandType.StoredProcedure).ToList().FirstOrDefault();
            }
            return result;
        }
    }
}