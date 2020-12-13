using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace ProcessSA.Vista
{
    public partial class FormularioTareaFuncionarioAdministrador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AlertaID.Visible = false;
            AlertaIDNoExiste.Visible = false;
            AlertaSemaforo.Visible = false;

            if (Request.Params["parametro"] != null && Controlador.Inseguridad.Variable.Length > 0)
            {
                EmailTransferido.Text = Request.Params["parametro"];
                EmailTransferido.Visible = false;
            }
            else
            {
                Response.Redirect("Login.aspx");
            }


            ListarTarea();

        }


        public void ListarTarea()
        {


            Controlador.ControladorTareas AuxControladorTarea = new Controlador.ControladorTareas();

            DataTable dt = new DataTable();
            dt = AuxControladorTarea.ListarTareaAdministrador();

            GridTarea.DataSource = dt;
            GridTarea.DataBind();

        }

        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            Controlador.ControladorTareas auxControladorTarea = new Controlador.ControladorTareas();
            if (TXTBuscar.Text.Trim() == string.Empty)
            {
                TXTBuscar.BorderColor = System.Drawing.Color.Red;
                AlertaID.Visible = true;
                ListarTarea();
            }
            else
            {

                if (auxControladorTarea.verificarTarea(Convert.ToInt32(TXTBuscar.Text)))
                {

                    TXTBuscar.BorderColor = System.Drawing.Color.Green;
                    AlertaIDNoExiste.Visible = false;
                    DataTable dt = new DataTable();
                    dt = auxControladorTarea.BuscarTareaIDEmail((EmailTransferido.Text), Convert.ToInt32(TXTBuscar.Text));
                    GridTarea.DataSource = dt;
                    GridTarea.DataBind();
                    AlertaID.Visible = false;


                }
                else
                {
                    TXTBuscar.BorderColor = System.Drawing.Color.Red;
                    AlertaIDNoExiste.Visible = true;
                }
            }
        }

        protected void BtnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminVista.aspx?parametro=" + EmailTransferido.Text);
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



        protected void BtnSubTarea_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormularioSubTareaFuncionarioAdministrador.aspx?parametro=" + TXTBuscar.Text + "&parametro2=" + EmailTransferido.Text);
        }

        
    }
}