using System.Data;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebTesoreria.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string GuardarUsuario()
        {
            string respuesta = "Ok";
            SqlConnection conx = Models.Conexion.Conectar();
            SqlCommand command = new SqlCommand("spGuardarUsuario", conx);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id", Id);
            command.Parameters.AddWithValue("@Nombre", Nombre);
            command.Parameters.AddWithValue("@Telefono", Telefono);
            command.Parameters.AddWithValue("@Direccion", Direccion);
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
        static public List<Usuario> DataUsuario()
        {
            SqlConnection conx = Models.Conexion.Conectar();
            SqlCommand command = new SqlCommand("spDataUsuario", conx);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr;
            Usuario u;
            List<Usuario> lista = new List<Usuario>();
            conx.Open();
            dr = command.ExecuteReader();
            while (dr.Read())
            {
                u = new Usuario();
                u.Id = dr.GetInt32(0);
                u.Nombre = dr.GetString(1);
                u.Telefono = dr.GetString(2);
                u.Direccion = dr.GetString(3);
                lista.Add(u);
            }
            dr.Close();
            conx.Close();
            return lista;
        }
        static public int SiguienteUsuario()
        {
            int siguienteUsuario;
            SqlConnection conx = Models.Conexion.Conectar();
            SqlCommand command = new SqlCommand("spSiguienteUsuario", conx);
            command.CommandType = CommandType.StoredProcedure;
            conx.Open();
            siguienteUsuario = int.Parse(command.ExecuteScalar().ToString());
            conx.Close();
            return siguienteUsuario;
        }
        public string BorrarUsuario(int id)
        {
            string respuesta = "Ok";
            SqlConnection conx = Models.Conexion.Conectar();
            SqlCommand command = new SqlCommand("spBorrarUsuario", conx);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id", id);
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
        public static List<Usuario> ComboBoxUsuario()
        {
            SqlConnection conx = Models.Conexion.Conectar();
            SqlCommand command = new SqlCommand("spComboBoxUsuario", conx);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr;
            Usuario u;
            List<Usuario> lista = new List<Usuario>();
            conx.Open();
            dr = command.ExecuteReader();
            while (dr.Read())
            {
                u = new Usuario();
                u.Id = dr.GetInt32(0);
                u.Nombre = dr.GetString(1);
                lista.Add(u);
            }
            dr.Close();
            conx.Close();
            return lista;
        }
    }
}