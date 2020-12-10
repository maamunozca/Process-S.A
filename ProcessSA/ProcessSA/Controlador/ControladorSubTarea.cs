using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Oracle.DataAccess.Client;

namespace ProcessSA.Controlador
{
    public class ControladorSubTarea
    {
        public bool AgregarSubTarea(Modelo.SubTarea subtarea)
        {
            try
            {
                Conexion conexion = new Conexion();
                OracleConnection conn = new OracleConnection();
                conn = conexion.getConn();

                conn.Open();

                OracleCommand comando = new OracleCommand("AgregarSubTarea",conn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("NOMBRE_SUBTAREA", OracleDbType.Varchar2).Value = subtarea.Nombre_SubTarea1;
                comando.Parameters.Add("ID_TAREA", OracleDbType.Int32).Value = subtarea.ID_Tarea1;
                comando.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception)
            {

                return false;
            }

            return true;

        }

        public DataTable ListarSubTarea(int IDTAREA)
        {
            Conexion conexion = new Conexion();
            OracleConnection conn = new OracleConnection();
            conn = conexion.getConn();

            conn.Open();
            OracleCommand comando = new OracleCommand("ListarSubTarea", conn);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add("Listar", OracleDbType.RefCursor).Direction = System.Data.ParameterDirection.Output;
            comando.Parameters.Add("@idtarea", OracleDbType.Int32).Value = IDTAREA;
            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = comando;

            DataTable i = new DataTable();

            adaptador.Fill(i);
            conn.Close();

            return i;

        }

        public bool ComenzarSubTarea(int idsubtarea)
        {
            try
            {
                Conexion conexion = new Conexion();
                OracleConnection conn = new OracleConnection();
                conn = conexion.getConn();

                conn.Open();

                OracleCommand comando = new OracleCommand("ComenzarSubTarea",conn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("@idsubtarea", OracleDbType.Int32).Value = idsubtarea;
                OracleDataAdapter adaptador = new OracleDataAdapter();
                adaptador.SelectCommand = comando;

                comando.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception)
            {

                return false;
            }

            return true;
        }


        public bool TerminarSubTarea(int idsubtarea)
        {
            try
            {
                Conexion conexion = new Conexion();
                OracleConnection conn = new OracleConnection();
                conn = conexion.getConn();

                conn.Open();

                OracleCommand comando = new OracleCommand("TerminarSubTarea", conn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("@idsubtarea", OracleDbType.Int32).Value = idsubtarea;
                OracleDataAdapter adaptador = new OracleDataAdapter();
                adaptador.SelectCommand = comando;

                comando.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception)
            {

                return false;
            }

            return true;
        }


        public bool RechazarSubTarea(int idsubtarea)
        {
            try
            {
                Conexion conexion = new Conexion();
                OracleConnection conn = new OracleConnection();
                conn = conexion.getConn();

                conn.Open();

                OracleCommand comando = new OracleCommand("RechazarSubTarea", conn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("@idsubtarea", OracleDbType.Int32).Value = idsubtarea;
                OracleDataAdapter adaptador = new OracleDataAdapter();
                adaptador.SelectCommand = comando;

                comando.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception)
            {

                return false;
            }

            return true;
        }

        public DataTable FiltrarSubtareaID(int idtarea, int idsubtarea)
        {
            Conexion conexion = new Conexion();
            OracleConnection conn = new OracleConnection();
            conn = conexion.getConn();

            conn.Open();
            OracleCommand comando = new OracleCommand("FiltrarSubTarea", conn);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add("Filtrar", OracleDbType.RefCursor).Direction = System.Data.ParameterDirection.Output;
            comando.Parameters.Add("@idtarea", OracleDbType.Int32).Value = idtarea;
            comando.Parameters.Add("@idSubTarea", OracleDbType.Int32).Value = idsubtarea;
            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = comando;

            DataTable i = new DataTable();

            adaptador.Fill(i);
            conn.Close();

            return i;

        }


        public DataTable ListarSubTareaFuncionario(int IDTAREA, string email)
        {
            Conexion conexion = new Conexion();
            OracleConnection conn = new OracleConnection();
            conn = conexion.getConn();

            conn.Open();
            OracleCommand comando = new OracleCommand("ListarSubTareaFuncionario", conn);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add("Listar", OracleDbType.RefCursor).Direction = System.Data.ParameterDirection.Output;
            comando.Parameters.Add("@idtarea", OracleDbType.Int32).Value = IDTAREA;
            comando.Parameters.Add("@email", OracleDbType.Varchar2).Value = email;
            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = comando;

            DataTable i = new DataTable();

            adaptador.Fill(i);
            conn.Close();

            return i;

        }
    }
}