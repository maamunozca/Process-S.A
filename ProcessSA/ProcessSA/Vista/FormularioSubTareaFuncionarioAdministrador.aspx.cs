using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProcessSA.Vista
{
    public partial class FormularioSubTareaFuncionarioAdministrador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["parametro"] != null && Controlador.Inseguridad.Variable.Length > 0)
            {
                IDTRANSFERIDO.Text = Request.Params["parametro"];
                IDTRANSFERIDO.Visible = false;

                if (Request.Params["parametro2"] != null)
                {
                    EmailTransferido.Text = Request.Params["parametro2"];
                    EmailTransferido.Visible = false;
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }

            AlertaID.Visible = false;
            AlertaIDNoExiste.Visible = false;

            ListarSubTarea();

            ActualizarPorcentajeTarea();
        }

        public void ActualizarPorcentajeTarea()
        {
            Controlador.ControladorFuncionario AuxControladorFuncionario = new Controlador.ControladorFuncionario();

            int idrecibido = Convert.ToInt32(IDTRANSFERIDO.Text);

            AuxControladorFuncionario.ActualizarPorcentajeTarea(idrecibido);

        }

        public void FiltrarSubtarea()
        {
            int idRecibido = Convert.ToInt32(IDTRANSFERIDO.Text);
            Controlador.ControladorSubTarea auxControladorSubTarea = new Controlador.ControladorSubTarea();

            DataTable dt = new DataTable();
            dt = auxControladorSubTarea.FiltrarSubtareaAdministrador(idRecibido, Convert.ToInt32(TXTBuscar.Text));
            GridSubtarea.DataSource = dt;
            GridSubtarea.DataBind();

        }

        private void ListarSubTarea()
        {
            int idRecibido = Convert.ToInt32(IDTRANSFERIDO.Text);
            Controlador.ControladorSubTarea auxControladorSubTarea = new Controlador.ControladorSubTarea();

            DataTable dt = new DataTable();
            dt = auxControladorSubTarea.ListarSubTareaAdministrador(idRecibido);
            GridSubtarea.DataSource = dt;
            GridSubtarea.DataBind();
        }

        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            Controlador.ControladorSubTarea AuxControladorSubTarea = new Controlador.ControladorSubTarea();

            if (TXTBuscar.Text.Trim() == string.Empty)
            {
                TXTBuscar.BorderColor = System.Drawing.Color.Red;
                AlertaID.Visible = true;
                AlertaIDNoExiste.Visible = false;
                ListarSubTarea();

            }
            else
            {

                try
                {
                    if (AuxControladorSubTarea.VerificarSubTareaAdministrador(Convert.ToInt32(TXTBuscar.Text), Convert.ToInt32(IDTRANSFERIDO.Text)))
                    {
                        TXTBuscar.BorderColor = System.Drawing.Color.Green;
                        AlertaID.Visible = false;
                        AlertaIDNoExiste.Visible = false;
                        FiltrarSubtarea();
                    }
                    else
                    {
                        TXTBuscar.BorderColor = System.Drawing.Color.Red;
                        AlertaIDNoExiste.Visible = true;
                        AlertaID.Visible = false;
                    }
                }
                catch (Exception)
                {

                    TXTBuscar.BorderColor = System.Drawing.Color.Red;

                    AlertaID.Visible = true;
                    AlertaIDNoExiste.Visible = false;


                }

                
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

        protected void BtnVolver_Click(object sender, EventArgs e)
        {
            ActualizarPorcentajeTarea();
            Response.Redirect("FormularioTareaFuncionarioAdministrador.aspx?parametro=" + EmailTransferido.Text);
        }

        protected void BtnCerrarSesion_Click(object sender, EventArgs e)
        {
            Controlador.Inseguridad.Variable = "";

            Response.Redirect("Login.aspx");
        }

        protected void BtnComenzar_Click(object sender, EventArgs e)
        {

        }
    }
}