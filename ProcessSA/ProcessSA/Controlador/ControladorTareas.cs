using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ProcessSA.Controlador
{
    public class ControladorTareas
    {
        public bool AgregarTarea(Modelo.Tarea tarea)
        {
         

            try
            {
                Conexion conexion = new Conexion();
                OracleConnection conn = new OracleConnection();
                conn = conexion.getConn();

                conn.Open();
                OracleCommand comando = new OracleCommand("AGREGARTAREA", conn);

                comando.CommandType = System.Data.CommandType.StoredProcedure;

                comando.Parameters.Add("ID_TAREA", OracleDbType.Int32).Value = tarea.ID_Tarea1;
                comando.Parameters.Add("NOMBRE_TAREA", OracleDbType.Varchar2).Value = tarea.Nombre_Tarea1;
                comando.Parameters.Add("DESC_TAREA", OracleDbType.Varchar2).Value = tarea.Desc_Tarea1;
                comando.Parameters.Add("ID_ESTADO", OracleDbType.Int32).Value = tarea.ID_Estado1;
                comando.Parameters.Add("ID_TIPO_TAREA", OracleDbType.Int32).Value = tarea.ID_Tipo_Tarea1;
                comando.Parameters.Add("ID_DEPARTAMENTO", OracleDbType.Int32).Value = tarea.ID_Departamento1;

                comando.ExecuteNonQuery();
                conn.Close();

                
            }
            catch (Exception)
            {

                return false;
            }

            return true;

        }
        /*
        public bool AgregarPlazo(Modelo.Plazos plazo)
        {
            
            try
            {
                Conexion conexion = new Conexion();
                OracleConnection conn = new OracleConnection();
                conn = conexion.getConn();

                conn.Open();
                OracleCommand comando = new OracleCommand("AGREGARPLAZO", conn);

                comando.CommandType = System.Data.CommandType.StoredProcedure;

                comando.Parameters.Add("ID_PLAZO", OracleDbType.Int32).Value = plazo.ID_Plazo1;
                comando.Parameters.Add("FECHA_INICIO", OracleDbType.Date).Value = plazo.Fecha_Inicio1;
                comando.Parameters.Add("FECHA_TERMINO", OracleDbType.Date).Value = plazo.Fecha_Termino1;
                comando.Parameters.Add("ID_TAREA", OracleDbType.Int32).Value = plazo.ID_TAREA1;
                comando.ExecuteNonQuery();
                conn.Close();
                
            }
            catch (Exception)
            {

                return false;
            }

            return true;

        }
        */

        public bool AgregarPlazos(Modelo.Plazos plazo)
        {
            try
            {
                Conexion conexion = new Conexion();
                OracleConnection conn = new OracleConnection();

                conn = conexion.getConn();

                conn.Open();

                OracleCommand comando = new OracleCommand("AGREGARPLAZO", conn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;

                comando.Parameters.Add("ID_PLAZO", OracleDbType.Int32).Value = plazo.ID_Plazo1;
                comando.Parameters.Add("FECHA_INICIO", OracleDbType.Date).Value = plazo.Fecha_Inicio1;
                comando.Parameters.Add("FECHA_TERMINO", OracleDbType.Date).Value = plazo.Fecha_Termino1;
                comando.Parameters.Add("ID_TAREA", OracleDbType.Int32).Value = plazo.ID_TAREA1;

                comando.ExecuteNonQuery();

                conn.Clone();
            }
            catch (Exception)
            {

                return false;
            }
                

            return true;
        }

        public Boolean AgregarDetalleTarea(Modelo.Detalle_Tarea detalle)
        {
            Boolean confirmo;

            try
            {
                Conexion conexion = new Conexion();
                OracleConnection conn = new OracleConnection();
                conn = conexion.getConn();

                conn.Open();
                OracleCommand comando = new OracleCommand("AGREGARDETALLETAREA", conn);

                comando.CommandType = System.Data.CommandType.StoredProcedure;

                comando.Parameters.Add("ID_TAREA", OracleDbType.Int32).Value = detalle.ID_Tarea1 ;
                comando.Parameters.Add("ID_FLUJO_TAREA", OracleDbType.Int32).Value = detalle.ID_Flujo_Tarea1;
                comando.Parameters.Add("RUN", OracleDbType.Varchar2).Value = detalle.Run1;
                comando.ExecuteNonQuery();
                conn.Close();
                confirmo = true;
            }
            catch (Exception)
            {

                confirmo = false;
            }

            return confirmo;

        }

        public DataTable ListarTarea(int idflujo)
        {
            Conexion conexion = new Conexion();
            OracleConnection conn = new OracleConnection();
            conn = conexion.getConn();

            conn.Open();
            OracleCommand comando = new OracleCommand("ListarTareaPrincipal", conn);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add("ListarTarea", OracleDbType.RefCursor).Direction = System.Data.ParameterDirection.Output;
            comando.Parameters.Add("@idflujo", OracleDbType.Int32).Value = idflujo;
            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = comando;

            DataTable i = new DataTable();

            adaptador.Fill(i);
            conn.Close();

            return i;

        }

        public DataTable BuscarTarea(int idflujo, string NombreTarea)
        {
            Conexion conexion = new Conexion();
            OracleConnection conn = new OracleConnection();
            conn = conexion.getConn();

            conn.Open();
            OracleCommand comando = new OracleCommand("BuscarTareaPrincipal", conn);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add("BuscarTarea", OracleDbType.RefCursor).Direction = System.Data.ParameterDirection.Output;
            comando.Parameters.Add("@idflujo", OracleDbType.Int32).Value = idflujo;
            comando.Parameters.Add("@NombreTarea", OracleDbType.Varchar2).Value = NombreTarea;
            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = comando;

            DataTable i = new DataTable();

            adaptador.Fill(i);
            conn.Close();

            return i;

        }

        public DataTable BuscarTareaID(int idflujo, int idtarea)
        {
            Conexion conexion = new Conexion();
            OracleConnection conn = new OracleConnection();
            conn = conexion.getConn();

            conn.Open();
            OracleCommand comando = new OracleCommand("BuscarTareaPrincipalID", conn);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add("BuscarTarea", OracleDbType.RefCursor).Direction = System.Data.ParameterDirection.Output;
            comando.Parameters.Add("@idflujo", OracleDbType.Int32).Value = idflujo;
            comando.Parameters.Add("@idtarea", OracleDbType.Int32).Value = idtarea;
            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = comando;

            DataTable i = new DataTable();

            adaptador.Fill(i);
            conn.Close();

            return i;

        }



        public bool ComenzarTarea(int idtarea)
        {
            try
            {
                Conexion conexion = new Conexion();
                OracleConnection conn = new OracleConnection();
                conn = conexion.getConn();

                conn.Open();

                OracleCommand comando = new OracleCommand("ComenzarTarea", conn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("@idtarea", OracleDbType.Int32).Value = idtarea;
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


        public bool TerminarTarea(int idtarea)
        {
            try
            {
                Conexion conexion = new Conexion();
                OracleConnection conn = new OracleConnection();
                conn = conexion.getConn();

                conn.Open();

                OracleCommand comando = new OracleCommand("TerminarTarea", conn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("@idtarea", OracleDbType.Int32).Value = idtarea;
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


        public bool RechazarTarea(int idtarea)
        {
            try
            {
                Conexion conexion = new Conexion();
                OracleConnection conn = new OracleConnection();
                conn = conexion.getConn();

                conn.Open();

                OracleCommand comando = new OracleCommand("RechazarTarea", conn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("@idtarea", OracleDbType.Int32).Value = idtarea;
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


        public Modelo.Tarea ObtenerSemaforo(int idtarea)
        {
            Modelo.Tarea tarea = new Modelo.Tarea();

            Conexion conexion = new Conexion();
            OracleConnection conn = new OracleConnection();
            conn = conexion.getConn();

            conn.Open();
            OracleCommand comando = new OracleCommand("SELECT * FROM TAREA WHERE ID_TAREA = :IDTAREA", conn);
            comando.Parameters.Add(":IDTAREA", idtarea);

            OracleDataReader lector = comando.ExecuteReader();

            if (lector.Read())
            {
                tarea.ID_Estado1 = Convert.ToInt32(lector["ID_ESTADO"].ToString());
            }
            return tarea;
        }


        public Boolean verificarTarea(int idtarea)
        {
            Boolean existe = false;

            Conexion conexion = new Conexion();
            OracleConnection conn = new OracleConnection();
            conn = conexion.getConn();

            conn.Open();
            OracleCommand comando = new OracleCommand("SELECT * FROM TAREA WHERE ID_TAREA = :idtarea", conn);

            comando.Parameters.Add(":idtarea", idtarea);

            OracleDataReader lector = comando.ExecuteReader();

            if (lector.Read())
            {
                existe = true;
            }

            conn.Close();
            return existe;

        }

        public Boolean verificarTareaNombre(string nombre)
        {
            Boolean existe = false;

            Conexion conexion = new Conexion();
            OracleConnection conn = new OracleConnection();
            conn = conexion.getConn();

            conn.Open();
            OracleCommand comando = new OracleCommand("SELECT * FROM TAREA WHERE NOMBRE_TAREA = :nombre", conn);

            comando.Parameters.Add(":nombre", nombre);

            OracleDataReader lector = comando.ExecuteReader();

            if (lector.Read())
            {
                existe = true;
            }

            conn.Close();
            return existe;

        }

        public bool AtrasoTarea(int idtarea)
        {
            try
            {
                Conexion conexion = new Conexion();
                OracleConnection conn = new OracleConnection();
                conn = conexion.getConn();

                conn.Open();

                OracleCommand comando = new OracleCommand("ESTADOATRASOTAREA", conn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("@idtarea", OracleDbType.Int32).Value = idtarea;
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

        public bool AgregarAtrasoTarea(Modelo.AtrasoTarea atraso )
        {


            try
            {
                Conexion conexion = new Conexion();
                OracleConnection conn = new OracleConnection();
                conn = conexion.getConn();

                conn.Open();
                OracleCommand comando = new OracleCommand("AGREGARATRASOTAREA", conn);

                comando.CommandType = System.Data.CommandType.StoredProcedure;

                comando.Parameters.Add("ID_TAREA", OracleDbType.Int32).Value = atraso.ID_Tarea1;
                comando.Parameters.Add("MOTIVO_ATRASO", OracleDbType.Varchar2).Value = atraso.Motivo1;
                comando.Parameters.Add("FECHA_ATRASO", OracleDbType.Date).Value = atraso.Fecha_Hoy1;
                

                comando.ExecuteNonQuery();
                conn.Close();


            }
            catch (Exception)
            {

                return false;
            }

            return true;

        }

        public DataTable ListarAtrasoTarea(int idtarea)
        {
            Conexion conexion = new Conexion();
            OracleConnection conn = new OracleConnection();
            conn = conexion.getConn();

            conn.Open();
            OracleCommand comando = new OracleCommand("ListarAtrasoTarea", conn);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add("ListarTarea", OracleDbType.RefCursor).Direction = System.Data.ParameterDirection.Output;
            comando.Parameters.Add("@idtarea", OracleDbType.Int32).Value = idtarea;
            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = comando;

            DataTable i = new DataTable();

            adaptador.Fill(i);
            conn.Close();

            return i;

        }


        public DataTable ListarAtrasoTarea2(int idatraso,int idtarea)
        {
            Conexion conexion = new Conexion();
            OracleConnection conn = new OracleConnection();
            conn = conexion.getConn();

            conn.Open();
            OracleCommand comando = new OracleCommand("FILTRARATRASOTAREA", conn);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add("FiltrarAtraso", OracleDbType.RefCursor).Direction = System.Data.ParameterDirection.Output;
            comando.Parameters.Add("@idatraso", OracleDbType.Int32).Value = idatraso;
            comando.Parameters.Add("@idtarea", OracleDbType.Int32).Value = idtarea;
            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = comando;

            DataTable i = new DataTable();

            adaptador.Fill(i);
            conn.Close();

            return i;

        }

        public bool ActualizarTarea(int idtarea, string nombre, string desc, int idtipo, int iddepartamento)
        {
            try
            {
                Conexion conexion = new Conexion();
                OracleConnection conn = new OracleConnection();
                conn = conexion.getConn();

                conn.Open();

                OracleCommand comando = new OracleCommand("ACTUALIZARTAREA", conn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("@idtarea", OracleDbType.Int32).Value = idtarea;
                comando.Parameters.Add("@nombre", OracleDbType.Varchar2).Value = nombre;
                comando.Parameters.Add("@descripcion", OracleDbType.Varchar2).Value = desc;
                comando.Parameters.Add("@idtipo", OracleDbType.Int32).Value = idtipo;
                comando.Parameters.Add("@iddepartamento", OracleDbType.Int32).Value = iddepartamento;
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

        public bool ActualizarResponsable(int idtarea,string  run)
        {
            try
            {
                Conexion conexion = new Conexion();
                OracleConnection conn = new OracleConnection();
                conn = conexion.getConn();

                conn.Open();

                OracleCommand comando = new OracleCommand("ACTUALIZARRESPONSABLE", conn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("@idtarea", OracleDbType.Int32).Value = idtarea;
                comando.Parameters.Add("@runu", OracleDbType.Varchar2).Value = run;
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

        public void EliminarTarea(int idtarea)
        {

            Conexion conexion = new Conexion();
            OracleConnection conn = new OracleConnection();
            conn = conexion.getConn();

            conn.Open();

            OracleCommand comando = new OracleCommand("EliminarMasivoTarea", conn);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add("Eliminar", OracleDbType.RefCursor).Direction = System.Data.ParameterDirection.Output;
            comando.Parameters.Add("@idtarea", OracleDbType.Int32).Value = idtarea;
            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = comando;

            comando.ExecuteNonQuery();
            conn.Close();


        }

        public bool ReportarProblema(Modelo.Reportar_Problema reportar)
        {
            try
            {
                Conexion conexion = new Conexion();
                OracleConnection conn = new OracleConnection();
                conn = conexion.getConn();

                conn.Open();

                OracleCommand comando = new OracleCommand("AGREGARREPORTARPROBLEMA", conn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;

                comando.Parameters.Add("@idtarea", OracleDbType.Int32).Value = reportar.ID_TAREA1;
                comando.Parameters.Add("@motivo", OracleDbType.Varchar2).Value = reportar.Motivo1;
                comando.Parameters.Add("@fecha", OracleDbType.Date).Value = reportar.FechaHoy1;

                comando.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception)
            {

                return false;
            }

            return true;

        }


        public DataTable ListarProblema(int idtarea)
        {
            Conexion conexion = new Conexion();
            OracleConnection conn = new OracleConnection();
            conn = conexion.getConn();

            conn.Open();
            OracleCommand comando = new OracleCommand("LISTARREPORTARPROBLEMA", conn);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add("ListarProblema", OracleDbType.RefCursor).Direction = System.Data.ParameterDirection.Output;
            comando.Parameters.Add("@idtarea", OracleDbType.Int32).Value = idtarea;
            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = comando;

            DataTable i = new DataTable();

            adaptador.Fill(i);
            conn.Close();

            return i;

        }

        public DataTable ListarProblemaConFiltro(int idtarea, int Idproblema)
        {
            Conexion conexion = new Conexion();
            OracleConnection conn = new OracleConnection();
            conn = conexion.getConn();

            conn.Open();
            OracleCommand comando = new OracleCommand("LISTARPROBLEMACONFILTRO", conn);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add("ListarProblema", OracleDbType.RefCursor).Direction = System.Data.ParameterDirection.Output;
            comando.Parameters.Add("@idtarea", OracleDbType.Int32).Value = idtarea;
            comando.Parameters.Add("@Idproblema", OracleDbType.Int32).Value = Idproblema;
            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = comando;

            DataTable i = new DataTable();

            adaptador.Fill(i);
            conn.Close();

            return i;

        }

        public Modelo.AtrasoTarea ObtenerIDAtrasoTarea(int idatraso)
        {
            Modelo.AtrasoTarea atraso = new Modelo.AtrasoTarea();

            Conexion conexion = new Conexion();
            OracleConnection conn = new OracleConnection();
            conn = conexion.getConn();

            conn.Open();
            OracleCommand comando = new OracleCommand("SELECT * FROM ATRASO WHERE ID_ATRASO = :IDATRASO", conn);
            comando.Parameters.Add(":IDATRASO", idatraso);

            OracleDataReader lector = comando.ExecuteReader();

            if (lector.Read())
            {

                atraso.ID_Tarea1 = Convert.ToInt32(lector["ID_ATRASO"].ToString());
                 
            }
            conn.Close();

            return atraso;
        }

        public Modelo.Reportar_Problema ObtenerIDReportarProblema(int idproblema)
        {
            Modelo.Reportar_Problema reportar = new Modelo.Reportar_Problema();

            Conexion conexion = new Conexion();
            OracleConnection conn = new OracleConnection();
            conn = conexion.getConn();

            conn.Open();
            OracleCommand comando = new OracleCommand("SELECT * FROM REPORTAR_PROBLEMA WHERE ID_PROBLEMA = :IDPROBLEMA", conn);
            comando.Parameters.Add(":IDPROBLEMA", idproblema);

            OracleDataReader lector = comando.ExecuteReader();

            if (lector.Read())
            {

                reportar.ID_PROBLEMA1 = Convert.ToInt32(lector["ID_PROBLEMA"].ToString());

            }
            conn.Close();

            return reportar;
        }

        public Modelo.RechazoTarea ObtenerIDRechazoTarea(int idmotivo)
        {
            Modelo.RechazoTarea rechazo = new Modelo.RechazoTarea();

            Conexion conexion = new Conexion();
            OracleConnection conn = new OracleConnection();
            conn = conexion.getConn();

            conn.Open();
            OracleCommand comando = new OracleCommand("SELECT * FROM MOTIVO_TAREA WHERE ID_MOTIVO = :IDMOTIVO", conn);
            comando.Parameters.Add(":IDMOTIVO", idmotivo);

            OracleDataReader lector = comando.ExecuteReader();

            if (lector.Read())
            {

                rechazo.ID_TAREA1 = Convert.ToInt32(lector["ID_MOTIVO"].ToString());

            }
            conn.Close();

            return rechazo;
        }

        public DataTable ListarTareaFuncionario(string Email)
        {
            Conexion conexion = new Conexion();
            OracleConnection conn = new OracleConnection();
            conn = conexion.getConn();

            conn.Open();
            OracleCommand comando = new OracleCommand("ListarTareasFuncionario", conn);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add("ListarTarea", OracleDbType.RefCursor).Direction = System.Data.ParameterDirection.Output;
            comando.Parameters.Add("@Email", OracleDbType.Varchar2).Value = Email;
            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = comando;

            DataTable i = new DataTable();

            adaptador.Fill(i);
            conn.Close();

            return i;

        }


        public DataTable ListarTareaAdministrador()
        {
            Conexion conexion = new Conexion();
            OracleConnection conn = new OracleConnection();
            conn = conexion.getConn();

            conn.Open();
            OracleCommand comando = new OracleCommand("ListarTareasAdministrador", conn);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add("ListarTarea", OracleDbType.RefCursor).Direction = System.Data.ParameterDirection.Output;
            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = comando;

            DataTable i = new DataTable();

            adaptador.Fill(i);
            conn.Close();

            return i;

        }

        public DataTable BuscarTareaIDEmail(string Email, int idtarea)
        {
            Conexion conexion = new Conexion();
            OracleConnection conn = new OracleConnection();
            conn = conexion.getConn();

            conn.Open();
            OracleCommand comando = new OracleCommand("BuscarTareaPrincipalIDEmail", conn);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add("BuscarTarea", OracleDbType.RefCursor).Direction = System.Data.ParameterDirection.Output;
            comando.Parameters.Add("@Email", OracleDbType.Varchar2).Value = Email;
            comando.Parameters.Add("@idtarea", OracleDbType.Int32).Value = idtarea;
            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = comando;

            DataTable i = new DataTable();

            adaptador.Fill(i);
            conn.Close();

            return i;

        }

        public Modelo.Tarea GetTarea(int idflujo, int idtarea)
        {
            Modelo.Tarea Tarea = new Modelo.Tarea();

            Conexion conexion = new Conexion();
            OracleConnection conn = new OracleConnection();
            conn = conexion.getConn();

            conn.Open();
            OracleCommand comando = new OracleCommand("GetTarea", conn);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add("Obtener", OracleDbType.RefCursor).Direction = System.Data.ParameterDirection.Output;
            comando.Parameters.Add("@idflujo", OracleDbType.Int32).Value = idflujo;
            comando.Parameters.Add("@idtarea", OracleDbType.Int32).Value = idtarea;

            OracleDataReader lector = comando.ExecuteReader();

            if (lector.Read())
            {
                Tarea.Nombre_Tarea1 = lector["NOMBRE_TAREA"].ToString();
                Tarea.Desc_Tarea1 = lector["DESC_TAREA"].ToString();
                Tarea.ID_Estado1 = Convert.ToInt32(lector["ID_ESTADO"].ToString());
                Tarea.ID_Tipo_Tarea1 = Convert.ToInt32(lector["ID_TIPO_TAREA"].ToString());
                Tarea.ID_Departamento1 = Convert.ToInt32(lector["ID_DEPARTAMENTO"].ToString());
            }
            return Tarea;
        }


        public Modelo.Plazos GetPlazo(int idflujo, int idtarea)
        {
            Modelo.Plazos plazo = new Modelo.Plazos();

            Conexion conexion = new Conexion();
            OracleConnection conn = new OracleConnection();
            conn = conexion.getConn();

            conn.Open();
            OracleCommand comando = new OracleCommand("GetPlazo", conn);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add("Obtener", OracleDbType.RefCursor).Direction = System.Data.ParameterDirection.Output;
            comando.Parameters.Add("@idflujo", OracleDbType.Int32).Value = idflujo;
            comando.Parameters.Add("@idtarea", OracleDbType.Int32).Value = idtarea;

            OracleDataReader lector = comando.ExecuteReader();

            if (lector.Read())
            {
                plazo.Fecha_Inicio1 = Convert.ToDateTime(lector["FECHA_INICIO"].ToString());
                plazo.Fecha_Termino1 = Convert.ToDateTime(lector["FECHA_TERMINO"].ToString());

            }
            return plazo;
        }

        public bool ActualizarFechas(int idtarea, int idestado, DateTime fechahoy, DateTime fechatermino)
        {
            try
            {
                Conexion conexion = new Conexion();
                OracleConnection conn = new OracleConnection();
                conn = conexion.getConn();

                conn.Open();

                OracleCommand comando = new OracleCommand("ActualizarFechas", conn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("@idtarea", OracleDbType.Int32).Value = idtarea;
                comando.Parameters.Add("@idestado", OracleDbType.Int32).Value = idestado;
                comando.Parameters.Add("@fechahoy", OracleDbType.Date).Value = fechahoy;
                comando.Parameters.Add("@fechatermino", OracleDbType.Date).Value = fechatermino;
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


    }
}