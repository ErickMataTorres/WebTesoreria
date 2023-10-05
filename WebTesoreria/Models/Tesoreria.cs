using System.Data;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebTesoreria.Models
{
    public class Tesoreria
    {
        public int Id { get; set; }
        public string AhorrarOSacar { get; set; }
        public string Descripcion { get; set; }
        public decimal Cantidad { get; set; }
        public decimal TotalCantidad { get; set; }
        public string FechaAhorrado { get; set; }
        public string FechaModificado { get; set; }
        public string Concepto { get; set; }
        public string QuienCapturo { get; set; }
        public int Usuario { get; set; }
        //----------------------------Ofrenda Matutina----------------------------//
        public string GuardarOfrendaMatutina()
        {
            string respuesta = "Ok";
            SqlConnection conx = Models.Conexion.Conectar();
            SqlCommand command = new SqlCommand("spGuardarOfrendaMatutina", conx);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id", Id);
            command.Parameters.AddWithValue("@Descripcion", Descripcion);
            command.Parameters.AddWithValue("@Cantidad", Cantidad);
            command.Parameters.AddWithValue("@FechaAhorrado", FechaAhorrado);
            command.Parameters.AddWithValue("@FechaModificado", FechaModificado);
            command.Parameters.AddWithValue("@Concepto", Concepto);
            command.Parameters.AddWithValue("@QuienCapturo", Usuario);
            try
            {
                conx.Open();
                command.ExecuteNonQuery();
                conx.Close();
            }
            catch (Exception error)
            {
                respuesta = "Ha ocurrido un error: " + error.Message;
                if (conx.State == ConnectionState.Open)
                {
                    conx.Close();
                }
            }
            return respuesta;
        }
        static public List<Tesoreria> DataMatutino(string concepto)
        {
            SqlConnection conx = Models.Conexion.Conectar();
            SqlCommand command = new SqlCommand("spDataMatutino", conx);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Concepto", concepto);
            SqlDataReader dr;
            List<Tesoreria> lista = new List<Tesoreria>();
            Tesoreria t;
            conx.Open();
            dr = command.ExecuteReader();
            while (dr.Read())
            {
                t = new Tesoreria();
                t.Id = dr.GetInt32(0);
                t.Descripcion = dr.GetString(1);
                t.Cantidad = dr.GetDecimal(2);
                t.TotalCantidad = dr.GetDecimal(3);
                t.FechaAhorrado = dr.GetDateTime(4).ToString();
                t.FechaModificado = dr.GetDateTime(5).ToString();
                t.Concepto = dr.GetString(6);
                t.QuienCapturo = dr.GetString(7);
                lista.Add(t);
            }
            dr.Close();
            conx.Close();
            return lista;
        }
        static public int SiguienteMatutina(string concepto)
        {
            int siguienteMatutina;
            SqlConnection conx = Models.Conexion.Conectar();
            SqlCommand command = new SqlCommand("spSiguienteMatutina", conx);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Concepto", concepto);
            conx.Open();
            siguienteMatutina = int.Parse(command.ExecuteScalar().ToString());
            conx.Close();
            return siguienteMatutina;
        }
        static public decimal TotalesMatutino(string concepto)
        {
            decimal totales;
            SqlConnection conx = Models.Conexion.Conectar();
            SqlCommand command = new SqlCommand("spTotalesMatutino", conx);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Concepto", concepto);
            conx.Open();
            totales = decimal.Parse(command.ExecuteScalar().ToString());
            conx.Close();
            return totales;
        }
        static public decimal TabTotalMatutina(string concepto)
        {
            decimal totales;
            SqlConnection conx = Models.Conexion.Conectar();
            SqlCommand command = new SqlCommand("spTabTotalMatutina", conx);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Concepto", concepto);
            conx.Open();
            totales = decimal.Parse(command.ExecuteScalar().ToString());
            conx.Close();
            return totales;
        }
        static public decimal TotalMatutinoWeb()
        {
            decimal total;
            SqlConnection conx = Models.Conexion.Conectar();
            SqlCommand command = new SqlCommand("spTotalMatutinoWeb", conx);
            command.CommandType = CommandType.StoredProcedure;
            conx.Open();
            total = decimal.Parse(command.ExecuteScalar().ToString());
            conx.Close();
            return total;
        }
        //-------------------------------Termina Ofrenda Matutina------------------------------//

        //-------------------------------Diezmo------------------------------------------------//
        public string GuardarDiezmo()
        {
            string respuesta = "Ok";
            SqlConnection conx = Models.Conexion.Conectar();
            SqlCommand command = new SqlCommand("spGuardarDiezmo", conx);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id", Id);
            command.Parameters.AddWithValue("@Descripcion", Descripcion);
            command.Parameters.AddWithValue("@Cantidad", Cantidad);
            command.Parameters.AddWithValue("@FechaAhorrado", FechaAhorrado);
            command.Parameters.AddWithValue("@FechaModificado", FechaModificado);
            command.Parameters.AddWithValue("@Concepto", Concepto);
            command.Parameters.AddWithValue("@QuienCapturo", Usuario);
            try
            {
                conx.Open();
                command.ExecuteNonQuery();
                conx.Close();
            }
            catch (Exception error)
            {
                respuesta = "Ha ocurrido un error: " + error.Message;
                if (conx.State == ConnectionState.Open)
                {
                    conx.Close();
                }
            }
            return respuesta;
        }
        static public List<Tesoreria> DataDiezmo(string concepto)
        {
            SqlConnection conx = Models.Conexion.Conectar();
            SqlCommand command = new SqlCommand("spDataDiezmo", conx);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Concepto", concepto);
            SqlDataReader dr;
            List<Tesoreria> lista = new List<Tesoreria>();
            Tesoreria t;
            conx.Open();
            dr = command.ExecuteReader();
            while (dr.Read())
            {
                t = new Tesoreria();
                t.Id = dr.GetInt32(0);
                t.Descripcion = dr.GetString(1);
                t.Cantidad = dr.GetDecimal(2);
                t.TotalCantidad = dr.GetDecimal(3);
                t.FechaAhorrado = dr.GetDateTime(4).ToString();
                t.FechaModificado = dr.GetDateTime(5).ToString();
                t.Concepto = dr.GetString(6);
                t.QuienCapturo = dr.GetString(7);
                lista.Add(t);
            }
            dr.Close();
            conx.Close();
            return lista;
        }
        static public int SiguienteDiezmo(string concepto)
        {
            int siguienteMatutina;
            SqlConnection conx = Models.Conexion.Conectar();
            SqlCommand command = new SqlCommand("spSiguienteDiezmo", conx);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Concepto", concepto);
            conx.Open();
            siguienteMatutina = int.Parse(command.ExecuteScalar().ToString());
            conx.Close();
            return siguienteMatutina;
        }
        static public decimal TotalesDiezmo(string concepto)
        {
            decimal totales;
            SqlConnection conx = Models.Conexion.Conectar();
            SqlCommand command = new SqlCommand("spTotalesDiezmo", conx);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Concepto", concepto);
            conx.Open();
            totales = decimal.Parse(command.ExecuteScalar().ToString());
            conx.Close();
            return totales;
        }
        static public decimal TabTotalDiezmo(string concepto)
        {
            decimal totales;
            SqlConnection conx = Models.Conexion.Conectar();
            SqlCommand command = new SqlCommand("spTabTotalDiezmo", conx);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Concepto", concepto);
            conx.Open();
            totales = decimal.Parse(command.ExecuteScalar().ToString());
            conx.Close();
            return totales;
        }
        static public decimal TotalDiezmoWeb()
        {
            decimal total;
            SqlConnection conx = Models.Conexion.Conectar();
            SqlCommand command = new SqlCommand("spTotalDiezmoWeb", conx);
            command.CommandType = CommandType.StoredProcedure;
            conx.Open();
            total = decimal.Parse(command.ExecuteScalar().ToString());
            conx.Close();
            return total;
        }
        //-------------------------------Termina Diezmo----------------------------------------//

        //-------------------------------Ofrenda Vespertina------------------------------------------------//
        public string GuardarOfrendaVespertina()
        {
            string respuesta = "Ok";
            SqlConnection conx = Models.Conexion.Conectar();
            SqlCommand command = new SqlCommand("spGuardarOfrendaVespertina", conx);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id", Id);
            command.Parameters.AddWithValue("@Descripcion", Descripcion);
            command.Parameters.AddWithValue("@Cantidad", Cantidad);
            command.Parameters.AddWithValue("@FechaAhorrado", FechaAhorrado);
            command.Parameters.AddWithValue("@FechaModificado", FechaModificado);
            command.Parameters.AddWithValue("@Concepto", Concepto);
            command.Parameters.AddWithValue("@QuienCapturo", Usuario);
            try
            {
                conx.Open();
                command.ExecuteNonQuery();
                conx.Close();
            }
            catch (Exception error)
            {
                respuesta = "Ha ocurrido un error: " + error.Message;
                if (conx.State == ConnectionState.Open)
                {
                    conx.Close();
                }
            }
            return respuesta;
        }
        static public List<Tesoreria> DataVespertino(string concepto)
        {
            SqlConnection conx = Models.Conexion.Conectar();
            SqlCommand command = new SqlCommand("spDataVespertino", conx);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Concepto", concepto);
            SqlDataReader dr;
            List<Tesoreria> lista = new List<Tesoreria>();
            Tesoreria t;
            conx.Open();
            dr = command.ExecuteReader();
            while (dr.Read())
            {
                t = new Tesoreria();
                t.Id = dr.GetInt32(0);
                t.Descripcion = dr.GetString(1);
                t.Cantidad = dr.GetDecimal(2);
                t.TotalCantidad = dr.GetDecimal(3);
                t.FechaAhorrado = dr.GetDateTime(4).ToString();
                t.FechaModificado = dr.GetDateTime(5).ToString();
                t.Concepto = dr.GetString(6);
                t.QuienCapturo = dr.GetString(7);
                lista.Add(t);
            }
            dr.Close();
            conx.Close();
            return lista;
        }
        static public int SiguienteVespertina(string concepto)
        {
            int siguienteMatutina;
            SqlConnection conx = Models.Conexion.Conectar();
            SqlCommand command = new SqlCommand("spSiguienteVespertina", conx);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Concepto", concepto);
            conx.Open();
            siguienteMatutina = int.Parse(command.ExecuteScalar().ToString());
            conx.Close();
            return siguienteMatutina;
        }
        static public decimal TotalesVespertino(string concepto)
        {
            decimal totales;
            SqlConnection conx = Models.Conexion.Conectar();
            SqlCommand command = new SqlCommand("spTotalesVespertino", conx);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Concepto", concepto);
            conx.Open();
            totales = decimal.Parse(command.ExecuteScalar().ToString());
            conx.Close();
            return totales;
        }
        static public decimal TabTotalVespertina(string concepto)
        {
            decimal totales;
            SqlConnection conx = Models.Conexion.Conectar();
            SqlCommand command = new SqlCommand("spTabTotalVespertina", conx);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Concepto", concepto);
            conx.Open();
            totales = decimal.Parse(command.ExecuteScalar().ToString());
            conx.Close();
            return totales;
        }
        static public decimal TotalVespertinoWeb()
        {
            decimal total;
            SqlConnection conx = Models.Conexion.Conectar();
            SqlCommand command = new SqlCommand("spTotalVespertinoWeb", conx);
            command.CommandType = CommandType.StoredProcedure;
            conx.Open();
            total = decimal.Parse(command.ExecuteScalar().ToString());
            conx.Close();
            return total;
        }
        //-------------------------------Termina Vespertina----------------------------------------//
    }
}