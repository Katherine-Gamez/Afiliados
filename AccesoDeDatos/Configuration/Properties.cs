using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDeDatos.Configuration
{
    public class Properties
    {
        public ParametrosDB ConexionDB()
        {

            var DBConnectString = $"User Id=ADMIN;Password=ADylan1303Alex; Data Source=kathy_medium;";
            string urlBaseproject = Directory.GetCurrentDirectory() + "/wallet";

            ParametrosDB parametros = new ParametrosDB();
            parametros.DBConnectString = DBConnectString;
            parametros.UrlWallet = urlBaseproject;

            return parametros;
        }


    }
    public class ParametrosDB
    {
        public string? DBConnectString { get; set; }
        public string? UrlWallet { get; set; }
    }
}

