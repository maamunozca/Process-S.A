using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.DataAccess.Client;
using System.Data;


namespace ProcessSA.Controlador
{
    public class ControladorFuncionario
    {
        public DataTable ListarTotalTareas(string Email)
        {
            Conexion conexion = new Conexion();
            OracleConnection conn = new OracleConnection();
            conn = conexion.getConn();

            conn.Open();
            OracleCommand comando = new OracleCommand("ListarTotalTareas", conn);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add("Listar", OracleDbType.RefCursor).Direction = System.Data.ParameterDirection.Output;
            comando.Parameters.Add("@Email", OracleDbType.Varchar2).Value = Email;
            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = comando;

            DataTable i = new DataTable();

            adaptador.Fill(i);
            conn.Close();

            return i;

        }

        public DataTable ListarTareasAsignadas(string Email)
        {
            Conexion conexion = new Conexion();
            OracleConnection conn = new OracleConnection();
            conn = conexion.getConn();

            conn.Open();
            OracleCommand comando = new OracleCommand("ListarTareasAsignadas", conn);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add("Listar", OracleDbType.RefCursor).Direction = System.Data.ParameterDirection.Output;
            comando.Parameters.Add("@Email", OracleDbType.Varchar2).Value = Email;
            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = comando;

            DataTable i = new DataTable();

            adaptador.Fill(i);
            conn.Close();

            return i;

        }

        public DataTable ListarTareasEnDesarrollo(string Email)
        {
            Conexion conexion = new Conexion();
            OracleConnection conn = new OracleConnection();
            conn = conexion.getConn();

            conn.Open();
            OracleCommand comando = new OracleCommand("ListarTareasEnDesarrollo", conn);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add("Listar", OracleDbType.RefCursor).Direction = System.Data.ParameterDirection.Output;
            comando.Parameters.Add("@Email", OracleDbType.Varchar2).Value = Email;
            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = comando;

            DataTable i = new DataTable();

            adaptador.Fill(i);
            conn.Close();

            return i;

        }

        public DataTable ListarTareasTerminadas(string Email)
        {
            Conexion conexion = new Conexion();
            OracleConnection conn = new OracleConnection();
            conn = conexion.getConn();

            conn.Open();
            OracleCommand comando = new OracleCommand("ListarTareasTerminadas", conn);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add("Listar", OracleDbType.RefCursor).Direction = System.Data.ParameterDirection.Output;
            comando.Parameters.Add("@Email", OracleDbType.Varchar2).Value = Email;
            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = comando;

            DataTable i = new DataTable();

            adaptador.Fill(i);
            conn.Close();

            return i;

        }

        public DataTable ListarTareasAtrasadas(string Email)
        {
            Conexion conexion = new Conexion();
            OracleConnection conn = new OracleConnection();
            conn = conexion.getConn();

            conn.Open();
            OracleCommand comando = new OracleCommand("ListarTareasAtrasadas", conn);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add("Listar", OracleDbType.RefCursor).Direction = System.Data.ParameterDirection.Output;
            comando.Parameters.Add("@Email", OracleDbType.Varchar2).Value = Email;
            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = comando;

            DataTable i = new DataTable();

            adaptador.Fill(i);
            conn.Close();

            return i;

        }
    }
}