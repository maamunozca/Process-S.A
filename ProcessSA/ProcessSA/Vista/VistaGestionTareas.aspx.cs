using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.DataAccess.Client;
using ProcessSA.Controlador;

namespace ProcessSA.Vista
{
    public partial class VistaGestionTareas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Alerta.Visible = false;
            AlertaExito.Visible = false;
            IDPiola.Visible = false;
            lblError.Visible = false;
            lblExito.Visible = false;
            lblvacio.Visible = false;
            lbID.Visible = false;


            GenerarID();
            if (!IsPostBack)
            {
                ListarFlujo();
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

        private void GenerarID()
        {
           
                Controlador.Conexion conexion = new Controlador.Conexion();
                OracleConnection conn = new OracleConnection();
                conn = conexion.getConn();

                conn.Open();

                OracleCommand comando = new OracleCommand("SELECT COUNT(ID_FLUJO_TAREA) FROM FLUJO_TAREA", conn);


                int i = Convert.ToInt32(comando.ExecuteScalar());
                conn.Close();
                i++;

                IDPiola.Text = i.ToString();
          

        }


        // Boton Crear Flujo de tarea 
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TXTNombreFlujo.Text.Trim() == string.Empty)
            {
                Alerta.Visible = true;
                AlertaExito.Visible = false;
               
            }
            else
            {
               
                Alerta.Visible = false;

                Controlador.ControladorFlujoDeTareas AuxFlujo = new Controlador.ControladorFlujoDeTareas();

                AuxFlujo.AgregarFlujoTareas(TXTNombreFlujo.Text);
                AlertaExito.Visible = true;
                ListarFlujo();



            }
        }

        public void ListarFlujo()
        {
            
            Controlador.ControladorFlujoDeTareas controlador1 = new Controlador.ControladorFlujoDeTareas();

            DataTable dt = new DataTable();
            dt = controlador1.ListarFlujo();

            GridFlujoTarea.DataSource = dt;
            GridFlujoTarea.DataBind();

        }

        protected void GridFlujoTarea_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void BtnEliminar_Click(object sender, EventArgs e)
        {
            Controlador.ControladorFlujoDeTareas auxControlador = new Controlador.ControladorFlujoDeTareas();
            

            if (TXTBuscar.Text.Trim() == string.Empty)
            {
                lblvacio.Visible = true;
                lblExito.Visible = false;
                lblError.Visible = false;
                lbID.Visible = false;
            }
            else if (!auxControlador.validarID(Convert.ToInt32(TXTBuscar.Text)))
            {
                TXTBuscar.BorderColor = System.Drawing.Color.Red;
                lblError.Visible = true;
                lblExito.Visible = false;
                lblvacio.Visible = false;
                lbID.Visible = false;

            }
            else
            {
                try
                {

                    TXTBuscar.BorderColor = System.Drawing.Color.Green;
                    lblError.Visible = false;
                    lblvacio.Visible = false;
                    auxControlador.EliminarFlujo(Convert.ToInt32(TXTBuscar.Text));
                    lblExito.Visible = true;
                    lbID.Visible = false;
                    ListarFlujo();

                }
                catch (Exception)
                {

                    lblError.Visible = false;
                    lblvacio.Visible = false;
                    lblExito.Visible = false;
                    lbID.Visible = true;
                }
               
            }
        }

        public void FiltrarFLujoTarea()
        {
            Conexion conexion = new Conexion();
            OracleConnection conn = new OracleConnection();
            conn = conexion.getConn();

            conn.Open();

            OracleCommand comando = new OracleCommand("SELECT * FROM FLUJO_TAREA WHERE ID_FLUJO_TAREA = '" + TXTBuscar.Text + "'", conn);
            OracleDataAdapter da = new OracleDataAdapter(comando);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Clone();

            GridFlujoTarea.DataSource = ds;
            GridFlujoTarea.DataBind();
        }

        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            Controlador.ControladorFlujoDeTareas AuxControladorFlujoTarea = new ControladorFlujoDeTareas();


            if (TXTBuscar.Text.Trim() == string.Empty)
            {
                ListarFlujo();
                lblvacio.Visible = true;
               
                lblError.Visible = false;
                lbID.Visible = false;

            }
            else if (!AuxControladorFlujoTarea.validarID(Convert.ToInt32(TXTBuscar.Text)))
            {
                TXTBuscar.BorderColor = System.Drawing.Color.Red;

                lblError.Visible = true;
              
                lblvacio.Visible = false;

                lbID.Visible = false;
            }
            else
            {
                lblError.Visible = false;
                lblvacio.Visible = false;

                lbID.Visible = false;

                FiltrarFLujoTarea();
            }
        }

        protected void BtnAgregar_Click(object sender, EventArgs e)
        {

        }

        protected void BtnAgregarTarea_Click(object sender, EventArgs e)
        {
            Controlador.ControladorFlujoDeTareas AuxControladorFlujoTarea = new ControladorFlujoDeTareas();

            if (TXTBuscar.Text.Trim() == string.Empty)
            {
                TXTBuscar.BorderColor = System.Drawing.Color.Red;
                lblvacio.Visible = true;
                lblError.Visible = false;
                lbID.Visible = false;

            }
            else if (!AuxControladorFlujoTarea.validarID(Convert.ToInt32(TXTBuscar.Text)))
            {
                lblvacio.Visible = false;
                lblError.Visible = true;
                lbID.Visible = false;
            }
            else
            {
                lblvacio.Visible = false;
                lblError.Visible = false;
                lbID.Visible = false;

                Response.Redirect("FormularioAgregarTarea.aspx?parametro=" + TXTBuscar.Text+ "&parametro2=" + EmailTransferido.Text);
            }
           
        }

        protected void BtnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("VistaFuncionario.aspx?parametro=" + EmailTransferido.Text);
        }
        protected void BtnFlujo_Click(object sender, EventArgs e)
        {
            Response.Redirect("VistaGestionTareas.aspx?parametro=" + EmailTransferido.Text);
        }

        protected void BtnTodasLasTareasRechazadas_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormularioTodasLasTareasRechazadas.aspx?parametro=" + EmailTransferido.Text);
        }
        protected void BtnTareasFuncionario_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormularioTareasFuncionario.aspx?parametro=" + EmailTransferido.Text);
        }


        protected void BtnCerrarSesion_Click(object sender, EventArgs e)
        {
            Controlador.Inseguridad.Variable = "";

            Response.Redirect("Login.aspx");
        }


    }
}