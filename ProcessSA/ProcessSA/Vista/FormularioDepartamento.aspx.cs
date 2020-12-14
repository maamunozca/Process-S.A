using Oracle.DataAccess.Client;
using ProcessSA.Controlador;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProcessSA.Vista
{
    public partial class FormularioDepartamento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                tablaDV();
                ListarFlujo();
                GenerarID();


            }

            if (Request.Params["parametro"] != null && Controlador.Inseguridad.Variable.Length > 0)
            {
                EmailTransferido.Text = Request.Params["parametro"];
                EmailTransferido.Visible = false;
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }
        OracleConnection conn = new OracleConnection("DATA SOURCE = xe; PASSWORD = 123; USER ID = portafolio");



        private void GenerarID()
        {
            Controlador.Conexion conexion = new Controlador.Conexion();
            OracleConnection conn = new OracleConnection();
            conn = conexion.getConn();

            conn.Open();

            OracleCommand comando = new OracleCommand("SELECT COUNT(ID_DEPARTAMENTO) FROM DEPARTAMENTO", conn);


            int i = Convert.ToInt32(comando.ExecuteScalar());
            conn.Close();
            i++;

            TxtId.Text = i.ToString();

        }
        private void tablaDV()
        {
            string qr = "SELECT * FROM departamento;";
            OracleDataAdapter oda = new OracleDataAdapter(qr, conn);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            gview.DataSource = ds;
            gview.DataBind();
        }

        private void buscar()
        {
            OracleDataAdapter adaptador = new OracleDataAdapter("SELECT * FROM DEPARTAMENTO WHERE Id_departamento ='" + TxtBuscar.Text + "'", conn);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "DEPARTAMENTO");
        }

        private void ListarFlujo()
        {
            Conexion conexion = new Conexion();
            OracleConnection conn = new OracleConnection();
            conn = conexion.getConn();

            conn.Open();


            OracleCommand comando = new OracleCommand("ListarDepartamento", conn);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add("ListarD", OracleDbType.RefCursor).Direction = System.Data.ParameterDirection.Output;
            OracleDataAdapter da = new OracleDataAdapter(comando);
            DataSet ds = new DataSet();

            da.Fill(ds);
            conn.Clone();

            gview.DataSource = ds;
            gview.DataBind();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            if (TxtBuscar.Text.Trim() == string.Empty)
            {
                lbMensajeError.Text = "Debe de llenar los campos solicitados";
                lbMensajeError.Visible = true;
            }
            else
            {
                try
                {
                    conn.Open();
                    OracleCommand comando = new OracleCommand("borrar", conn);
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.Add("id_departamento", OracleDbType.Int32).Value = TxtBuscar.Text;
                    comando.ExecuteNonQuery();
                    conn.Close();
                    tablaDV();

                    lbMensajeError.Text = "Departamento Eliminado Exitosamente";
                    lbMensajeError.Visible = true;
                }
                catch (Exception)
                {

                    lbMensajeError.Text = "No se pudo eliminar, Este Departamento tiene tareas Asignadas";
                    lbMensajeError.Visible = true;
                }
                
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (TxtId.Text.Trim() == string.Empty || TxtNombreDepartamento.Text.Trim() == string.Empty)
            {
                lbMensajeError.Text = "Debe de llenar los campos solicitados";
                lbMensajeError.Visible = true;
            }
            else
            {
                conn.Open();
                OracleCommand comando = new OracleCommand("insertar", conn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("id_departamento", OracleDbType.Varchar2).Value = TxtId.Text;
                comando.Parameters.Add("nombreDepartamento", OracleDbType.Varchar2).Value = TxtNombreDepartamento.Text;
                comando.ExecuteNonQuery();
                conn.Close();
                tablaDV();

                lbMensajeExito.Text = "Departamento Ingresados Correctamente";
                lbMensajeExito.Visible = true;
            }

        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            if (TxtBuscar.Text.Trim() == string.Empty || TxtNombreDepartamento.Text.Trim() == string.Empty)
            {
                lbMensajeError.Text = "Debe de llenar los campos solicitados";
                lbMensajeError.Visible = true;
            }
            else
            {
                try
                {
                    conn.Open();
                    OracleCommand comando = new OracleCommand("actualizar", conn);
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.Add("id_departamento", OracleDbType.Int32).Value = TxtBuscar.Text;
                    comando.Parameters.Add("nombreDepartamento", OracleDbType.Varchar2).Value = TxtNombreDepartamento.Text;
                    comando.ExecuteNonQuery();
                    conn.Close();
                    tablaDV();

                    lbMensajeExito.Text = "Departamento Modificados Correctamente";
                    lbMensajeExito.Visible = true;
                }
                catch (Exception)
                {

                    lbMensajeExito.Text = "No se puede modificar este departamento, Porque tiene Tareas Asignadas";
                    lbMensajeExito.Visible = true;
                }
                
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            if (TxtBuscar.Text.Trim() == string.Empty)
            {
                ListarFlujo();

            }
            else
            {
                Conexion conexion = new Conexion();
                OracleConnection conn = new OracleConnection();
                conn = conexion.getConn();

                conn.Open();

                OracleCommand comando = new OracleCommand("SELECT * FROM DEPARTAMENTO WHERE Id_departamento = '" + TxtBuscar.Text + "'", conn);
                OracleDataAdapter da = new OracleDataAdapter(comando);
                DataSet ds = new DataSet();
                da.Fill(ds);
                conn.Clone();

                gview.DataSource = ds;
                gview.DataBind();
            } 
        }

        protected void BtnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminVista.aspx?parametro=" + EmailTransferido.Text);
        }

        protected void BtnFlujo_Click(object sender, EventArgs e)
        {
            Response.Redirect("VistaGestionTareasAdministrador.aspx?parametro=" + EmailTransferido.Text);
        }

        protected void BtnTodasLasTareasRechazadas_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormularioTodasLasTareasRechazadasAdministrador.aspx?parametro=" + EmailTransferido.Text);
        }
        protected void BtnTareasFuncionario_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormularioTareaFuncionarioAdministrador.aspx?parametro=" + EmailTransferido.Text);
        }

        protected void BtnDepartamento_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormularioDepartamento.aspx?parametro=" + EmailTransferido.Text);
        }

        protected void BtnCerrarSesion_Click(object sender, EventArgs e)
        {
            Controlador.Inseguridad.Variable = "";

            Response.Redirect("Login.aspx");
        }


    }
}