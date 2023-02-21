using AccesoDeDatos.Configuration;
using OBJ;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AccesoDeDatos.Afiliacion
{
    public class Afiliacion_AD : IAfiliacion_AD
    {
        private readonly string DBConnectString;
        private readonly string UrlWallet;
        public Afiliacion_AD(Properties properties)
        {
            var datos = properties.ConexionDB();
            DBConnectString = datos.DBConnectString;
            UrlWallet = datos.UrlWallet;
        }
        public string AgregarAfiliado(DatosAfiliacionOBJ datos)
        {

            using (OracleConnection con = new OracleConnection(@DBConnectString))
            {
                string query = "INSERT INTO AFILIADO (ID, NOMBRE, APELLIDO, DIRECCION, TELEFONO) VALUES (SEQ_AFILIADO.NEXTVAL,'"+datos.Nombre+"','"+datos.Apellido+"','"+datos.Direccion+"','"+datos.Telefono+"')";
                con.TnsAdmin = UrlWallet;
                con.WalletLocation = con.TnsAdmin;
                using OracleCommand cmd = con.CreateCommand();
                try
                {
                    con.Open();
                    //Retrieve database version info
                    cmd.CommandText = query;
                    OracleDataReader reader = cmd.ExecuteReader();
                    
                    con.Close();
                    return "OK";
                }
                catch (Exception ex)
                {
                    con.Close();
                   return ex.Message;   
                }
            }
           
        }

        public string ActualizarAfiliado(DatosAfiliacionOBJ datos)
        {

            using (OracleConnection con = new OracleConnection(@DBConnectString))
            {
                string query = "UPDATE AFILIADO SET NOMBRE='" + datos.Nombre +"', APELLIDO='"+datos.Apellido+"', DIRECCION='"+datos.Direccion+"', TELEFONO='"+datos.Telefono+"' WHERE ID="+datos.ID;
                con.TnsAdmin = UrlWallet;
                con.WalletLocation = con.TnsAdmin;
                using OracleCommand cmd = con.CreateCommand();
                try
                {
                    con.Open();
                    //Retrieve database version info
                    cmd.CommandText = query;
                    cmd.ExecuteNonQuery();

                    con.Close();
                    return "OK";
                }
                catch (Exception ex)
                {
                    con.Close();
                    return ex.Message;
                }
            }

        }

        public List<DatosAfiliacionOBJ> BuscarAfiliados()
        {
            using (OracleConnection con = new OracleConnection(@DBConnectString))
            {
                string query = "SELECT ID, NOMBRE, APELLIDO, DIRECCION, TELEFONO FROM AFILIADO";
                con.TnsAdmin = UrlWallet;
                con.WalletLocation = con.TnsAdmin;
                using OracleCommand cmd = new OracleCommand(query, con);
               List<DatosAfiliacionOBJ> list = new List<DatosAfiliacionOBJ>();
                try
                {
                    con.Open();
                    //Retrieve database version info
                    cmd.ExecuteNonQuery();
                    OracleDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        var obj = new DatosAfiliacionOBJ();

                        obj.ID = Convert.ToInt32(reader["Id"]);
                        obj.Nombre= reader["NOMBRE"] as string;
                        obj.Apellido = reader["APELLIDO"] as string;
                        obj.Direccion = reader["DIRECCION"] as string;
                        obj.Telefono = reader["TELEFONO"] as string;

                        list.Add(obj);
                    }

                    con.Close();
                    return list;
                }
                catch (Exception ex)
                {
                    var obj = new DatosAfiliacionOBJ();
                    obj.Error = ex.Message;
                    list.Add(obj);
                    con.Close();
           
                    return list;
                }
            }
        }

        public List<DatosAfiliacionOBJ> BuscarUnAfiliado(int id)
        {
            using (OracleConnection con = new OracleConnection(@DBConnectString))
            {
                string query = "SELECT ID, NOMBRE, APELLIDO, DIRECCION, TELEFONO FROM AFILIADO WHERE ID="+id;
                con.TnsAdmin = UrlWallet;
                con.WalletLocation = con.TnsAdmin;
                using OracleCommand cmd = new OracleCommand(query, con);
                List<DatosAfiliacionOBJ> list = new List<DatosAfiliacionOBJ>();
                try
                {
                    con.Open();
                    //Retrieve database version info
                    cmd.ExecuteNonQuery();
                    OracleDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        var obj = new DatosAfiliacionOBJ();

                        obj.ID = Convert.ToInt32(reader["Id"]);
                        obj.Nombre = reader["NOMBRE"] as string;
                        obj.Apellido = reader["APELLIDO"] as string;
                        obj.Direccion = reader["DIRECCION"] as string;
                        obj.Telefono = reader["TELEFONO"] as string;

                        list.Add(obj);
                    }

                    con.Close();
                    return list;
                }
                catch (Exception ex)
                {
                    var obj = new DatosAfiliacionOBJ();
                    obj.Error = ex.Message;
                    list.Add(obj);
                    con.Close();

                    return list;
                }
            }
        }

        public string EliminarAfiliado(DatosAfiliacionOBJ datos)
        {

            using (OracleConnection con = new OracleConnection(@DBConnectString))
            {
                string query = "DELETE FROM AFILIADO WHERE ID="+datos.ID;
                con.TnsAdmin = UrlWallet;
                con.WalletLocation = con.TnsAdmin;
                using OracleCommand cmd = con.CreateCommand();
                try
                {
                    con.Open();
                    //Retrieve database version info
                    cmd.CommandText = query;
                    cmd.ExecuteNonQuery();

                    con.Close();
                    return "OK";
                }
                catch (Exception ex)
                {
                    con.Close();
                    return ex.Message;
                }
            }

        }



    }
}
