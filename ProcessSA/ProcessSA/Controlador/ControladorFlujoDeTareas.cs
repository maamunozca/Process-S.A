using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Web;
using Oracle.DataAccess.Client;

namespace ProcessSA.Controlador
{
    public class ControladorFlujoDeTareas
    {
        public Boolean AgregarFlujoTareas(string NombreTarea)
        {
            Boolean confirmo;

            try
            {
                Conexion conexion = new Conexion();
                OracleConnection conn = new OracleConnection();
                conn = conexion.getConn();

                conn.Open();
                OracleCommand comando = new OracleCommand("AGREGARFLUJOTAREA", conn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("@NOMBRE", OracleDbType.Varchar2).Value = NombreTarea;
                
                comando.ExecuteNonQuery();
                conn.Clone();
                confirmo = true;
            }
            catch (Exception e)
            {

                confirmo = false;
            }

            return confirmo;
        }

        public DataTable ListarFlujo()
        {
            Conexion conexion = new Conexion();
            OracleConnection conn = new OracleConnection();
            conn = conexion.getConn();

            conn.Open();
            OracleCommand comando = new OracleCommand("ListarFlujoTarea", conn);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add("Listar", OracleDbType.RefCursor).Direction = System.Data.ParameterDirection.Output;
            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = comando;

            DataTable i = new DataTable();

            adaptador.Fill(i);
            conn.Close();

            return i;

        }

        public void EliminarFlujo(int id)
        {

                Conexion conexion = new Conexion();
                OracleConnection conn = new OracleConnection();
                conn = conexion.getConn();

                conn.Open();

                OracleCommand comando = new OracleCommand("EliminarFlujo", conn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("Eliminar", OracleDbType.RefCursor).Direction = System.Data.ParameterDirection.Output;
                comando.Parameters.Add("@ID", id);
                OracleDataAdapter adaptador = new OracleDataAdapter();
                adaptador.SelectCommand = comando;

                comando.ExecuteNonQuery();
                conn.Close();

            
        }

        public Boolean validarID(int id)
        {
            Boolean validar = false;

            Conexion conexion = new Conexion();
            OracleConnection conn = new OracleConnection();
            conn = conexion.getConn();

            conn.Open();

            OracleCommand comando = new OracleCommand("SELECT * FROM FLUJO_TAREA WHERE ID_FLUJO_TAREA = :ID", conn);
            comando.Parameters.Add(":ID", id);

            OracleDataReader lector = comando.ExecuteReader();

            if (lector.Read())
            {
                validar = true;
            }
            conn.Close();
            return validar;
        }

        public DataSet filtrar(string filtro )
        {
            Conexion conexion = new Conexion();
            OracleConnection conn = new OracleConnection();
            conn = conexion.getConn();

            
            DataSet ds = new DataSet();

            OracleCommand comando = new OracleCommand("SELECT * FROM FLUJO_TAREA WHERE NOMBRE_FLUJO_TAREA LIKE '%"+filtro+"%'",conn);

            OracleDataAdapter da = new OracleDataAdapter();
            da.SelectCommand = comando;

            conn.Open();

            da.Fill(ds);

            conn.Clone();

            return ds;



        }
      
    }
}