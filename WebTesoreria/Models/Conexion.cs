using System.Data;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebTesoreria.Models
{
    public class Conexion
    {
        public static SqlConnection Conectar()
        {
            string conx = "DATA SOURCE=A; INITIAL CATALOG=BDTesoreria; INTEGRATED SECURITY=YES;";
            SqlConnection s = new SqlConnection(conx);
            return s;
        }
    }
}