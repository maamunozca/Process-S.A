using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.DataAccess.Client;

namespace ProcessSA.Controlador
{
    public class ControladorUsuario
    {
        // validar si el usuario existe mediante el correo y contraseña para el login
        public Boolean verificarUsuario(string email, string password)
        {
            Boolean existe = false;

            Conexion conexion = new Conexion();
            OracleConnection conn = new OracleConnection();
            conn = conexion.getConn();

            conn.Open();
            OracleCommand comando = new OracleCommand("SELECT * FROM USUARIO WHERE EMAIL_USUARIO = :email AND CLAVE_USUARIO = :password", conn);

            comando.Parameters.Add(":email", email);
            comando.Parameters.Add(":password", password);

            OracleDataReader lector = comando.ExecuteReader();

            if (lector.Read())
            {
                existe = true;
            }

            conn.Close();
            return existe;

        }

        // validar si el usuario existe y que traiga los datos a la carpeta modelo y aloje los datos en usuarios 
        public Modelo.Usuarios getUsuario(string email)
        {
            Modelo.Usuarios usuario = new Modelo.Usuarios();

            Conexion conexion = new Conexion();
            OracleConnection conn = new OracleConnection();
            conn = conexion.getConn();

            conn.Open();
            OracleCommand comando = new OracleCommand("SELECT * FROM USUARIO WHERE Email_Usuario = :email", conn);

            comando.Parameters.Add(":email", email);

            OracleDataReader lector = comando.ExecuteReader();

            if (lector.Read())
            {
                usuario.Run1 = lector["Run"].ToString();
                usuario.Nombre_Usuario1 = lector["Nombre_Usuario"].ToString();
                usuario.Numero_Usuario1 = Convert.ToInt32(lector["Numero_Usuario"].ToString());
                usuario.Email_Usuario1 = lector["Email_Usuario"].ToString();
                usuario.Clave_Usuario1 = lector["Clave_Usuario"].ToString();
                usuario.ID_Rol1 = Convert.ToInt32(lector["ID_Rol"].ToString());
            }
            return usuario;
        }

        // Valida que el email exista en la base de datos 
        public Boolean ValidarEmail(string email)
        {
            Boolean validar = false;

            Conexion conexion = new Conexion();
            OracleConnection conn = new OracleConnection();
            conn = conexion.getConn();

            conn.Open();

            OracleCommand comando = new OracleCommand("SELECT * FROM USUARIO WHERE EMAIL_USUARIO = :Email", conn);
            comando.Parameters.Add(":Email", email);

            OracleDataReader lector = comando.ExecuteReader();

            if (lector.Read())
            {
                validar = true;
            }
            conn.Close();
            return validar;
        }

        public Modelo.Usuarios GetRun(int idflujo, int idtarea)
        {
            Modelo.Usuarios usuario = new Modelo.Usuarios();

            Conexion conexion = new Conexion();
            OracleConnection conn = new OracleConnection();
            conn = conexion.getConn();

            conn.Open();
            OracleCommand comando = new OracleCommand("GetRun", conn);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add("Obtener", OracleDbType.RefCursor).Direction = System.Data.ParameterDirection.Output;
            comando.Parameters.Add("@idflujo", OracleDbType.Int32).Value = idflujo;
            comando.Parameters.Add("@idtarea", OracleDbType.Int32).Value = idtarea;

            OracleDataReader lector = comando.ExecuteReader();

            if (lector.Read())
            {
                usuario.Run1 = lector["RUN"].ToString();

            }
            return usuario;
        }
    }
}