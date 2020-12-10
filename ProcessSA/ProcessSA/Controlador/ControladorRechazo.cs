using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ProcessSA.Controlador
{
    public class ControladorRechazo
    {
        public bool AgregarMotivoRechazoTarea(Modelo.RechazoTarea rechazartarea)
        {
            try
            {
                Conexion conexion = new Conexion();
                OracleConnection conn = new OracleConnection();
                conn = conexion.getConn();

                conn.Open();
                OracleCommand comando = new OracleCommand("AGREGARMOTIVORECHAZOTAREA", conn);

                comando.CommandType = System.Data.CommandType.StoredProcedure;

                comando.Parameters.Add("ID_TAREA", OracleDbType.Int32).Value = rechazartarea.ID_TAREA1;
                comando.Parameters.Add("MOTIVO", OracleDbType.Varchar2).Value = rechazartarea.Motivo1;
                comando.Parameters.Add("FECHA", OracleDbType.Date).Value = rechazartarea.FechaRechazo1;
                comando.ExecuteNonQuery();
                conn.Close();


            }
            catch (Exception)
            {

                return false;
            }

            return true;
        }

        public DataTable ListarRechazo(int idtarea)
        {
            Conexion conexion = new Conexion();
            OracleConnection conn = new OracleConnection();
            conn = conexion.getConn();

            conn.Open();
            OracleCommand comando = new OracleCommand("LISTARRECHAZO", conn);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add("Rechazo", OracleDbType.RefCursor).Direction = System.Data.ParameterDirection.Output;
            comando.Parameters.Add("@idtarea", OracleDbType.Int32).Value = idtarea;
            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = comando;

            DataTable i = new DataTable();

            adaptador.Fill(i);
            conn.Close();

            return i;

        }
        
        public DataTable ListarRechazoSinFiltro()
        {
            Conexion conexion = new Conexion();
            OracleConnection conn = new OracleConnection();
            conn = conexion.getConn();

            conn.Open();
            OracleCommand comando = new OracleCommand("LISTARRECHAZOSINFILTRO", conn);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add("Rechazo", OracleDbType.RefCursor).Direction = System.Data.ParameterDirection.Output;
            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = comando;

            DataTable i = new DataTable();

            adaptador.Fill(i);
            conn.Close();

            return i;

        }
        

        public DataTable ListarRechazoConFiltro(int idmotivo)
        {
            Conexion conexion = new Conexion();
            OracleConnection conn = new OracleConnection();
            conn = conexion.getConn();

            conn.Open();
            OracleCommand comando = new OracleCommand("LISTARRECHAZoCONFILTRO", conn);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add("Rechazo", OracleDbType.RefCursor).Direction = System.Data.ParameterDirection.Output;
            comando.Parameters.Add("@IDMOTIVO", OracleDbType.Int32).Value = idmotivo;
            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = comando;

            DataTable i = new DataTable();

            adaptador.Fill(i);
            conn.Close();

            return i;

        }

        public DataTable ListarRechazoConFiltro2(int idtarea,int idmotivo)
        {
            Conexion conexion = new Conexion();
            OracleConnection conn = new OracleConnection();
            conn = conexion.getConn();

            conn.Open();
            OracleCommand comando = new OracleCommand("LISTARRECHAZoCONFILTRO2", conn);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add("Rechazo", OracleDbType.RefCursor).Direction = System.Data.ParameterDirection.Output;
            comando.Parameters.Add("@idtarea", OracleDbType.Int32).Value = idtarea;
            comando.Parameters.Add("@idmotivo", OracleDbType.Int32).Value = idmotivo;
            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = comando;

            DataTable i = new DataTable();

            adaptador.Fill(i);
            conn.Close();

            return i;

        }

        public bool AgregarRechazoSubTarea(Modelo.RechazoSubTarea rechazo )
        {


            try
            {
                Conexion conexion = new Conexion();
                OracleConnection conn = new OracleConnection();
                conn = conexion.getConn();

                conn.Open();
                OracleCommand comando = new OracleCommand("AGREGARRECHAZOSUBTAREA", conn);

                comando.CommandType = System.Data.CommandType.StoredProcedure;

                comando.Parameters.Add("ID_SUBTAREA", OracleDbType.Int32).Value = rechazo.ID_SubTarea1;
                comando.Parameters.Add("MOTIVO_RECHAZO", OracleDbType.Varchar2).Value = rechazo.Motivo1;
                comando.Parameters.Add("FECHA_RECHAZO", OracleDbType.Date).Value = rechazo.Fecha_Hoy1;


                comando.ExecuteNonQuery();
                conn.Close();


            }
            catch (Exception)
            {

                return false;
            }

            return true;

        }

        public DataTable ListarRechazSubTarea(int idsubtarea)
        {
            Conexion conexion = new Conexion();
            OracleConnection conn = new OracleConnection();
            conn = conexion.getConn();

            conn.Open();
            OracleCommand comando = new OracleCommand("LISTARRRECHAZOSUBTAREA", conn);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add("ListarRechazo", OracleDbType.RefCursor).Direction = System.Data.ParameterDirection.Output;
            comando.Parameters.Add("@idsubtarea", OracleDbType.Int32).Value = idsubtarea;
            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = comando;

            DataTable i = new DataTable();

            adaptador.Fill(i);
            conn.Close();

            return i;

        }

        public DataTable FiltrarRechazSubTarea(int idsubtarea, int idrechazo)
        {
            Conexion conexion = new Conexion();
            OracleConnection conn = new OracleConnection();
            conn = conexion.getConn();

            conn.Open();
            OracleCommand comando = new OracleCommand("FILTRARRRECHAZOSUBTAREA", conn);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add("FiltrarRechazo", OracleDbType.RefCursor).Direction = System.Data.ParameterDirection.Output;
            comando.Parameters.Add("@idsubtarea", OracleDbType.Int32).Value = idsubtarea;
            comando.Parameters.Add("@idrechazo", OracleDbType.Int32).Value = idrechazo;
            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = comando;

            DataTable i = new DataTable();

            adaptador.Fill(i);
            conn.Close();

            return i;

        }


    }
}