using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProcessSA.Vista
{
    public partial class FormularioSubTareasFuncionario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["parametro"] != null)
            {
                IDTRANSFERIDO.Text = Request.Params["parametro"];
                IDTRANSFERIDO.Visible = false;
            }

            if (Request.Params["parametro2"] != null)
            {
                EmailTransferido.Text = Request.Params["parametro2"];
                EmailTransferido.Visible = false;
            }

            AlertaID.Visible = false;
            AlertaIDNoExiste.Visible = false;

            ListarSubTarea();
        }

        private void ListarSubTarea()
        {
            int idRecibido = Convert.ToInt32(IDTRANSFERIDO.Text);
            Controlador.ControladorSubTarea auxControladorSubTarea = new Controlador.ControladorSubTarea();

            DataTable dt = new DataTable();
            dt = auxControladorSubTarea.ListarSubTareaFuncionario(idRecibido,EmailTransferido.Text);
            GridSubtarea.DataSource = dt;
            GridSubtarea.DataBind();
        }

        protected void BtnComenzar_Click(object sender, EventArgs e)
        {
            if (TXTBuscar.Text.Trim() == string.Empty)
            {
                TXTBuscar.BorderColor = System.Drawing.Color.Red;
                AlertaID.Visible = true;

            }
            else
            {
                TXTBuscar.BorderColor = System.Drawing.Color.Green;
                AlertaID.Visible = false;

                Controlador.ControladorSubTarea auxControladorSubTarea = new Controlador.ControladorSubTarea();

                auxControladorSubTarea.ComenzarSubTarea(Convert.ToInt32(TXTBuscar.Text));
                ListarSubTarea();
            }
        }

        protected void BtnTerminar_Click(object sender, EventArgs e)
        {
            if (TXTBuscar.Text.Trim() == string.Empty)
            {
                TXTBuscar.BorderColor = System.Drawing.Color.Red;
                AlertaID.Visible = true;

            }
            else
            {
                TXTBuscar.BorderColor = System.Drawing.Color.Green;
                AlertaID.Visible = false;

                Controlador.ControladorSubTarea auxControladorSubTarea = new Controlador.ControladorSubTarea();

                auxControladorSubTarea.TerminarSubTarea(Convert.ToInt32(TXTBuscar.Text));
                ListarSubTarea();
            }
        }

        protected void BtnRechazar_Click(object sender, EventArgs e)
        {
            if (TXTBuscar.Text.Trim() == string.Empty)
            {
                TXTBuscar.BorderColor = System.Drawing.Color.Red;
                AlertaID.Visible = true;

            }
            else
            {
                TXTBuscar.BorderColor = System.Drawing.Color.Green;
                AlertaID.Visible = false;

                Controlador.ControladorSubTarea auxControladorSubTarea = new Controlador.ControladorSubTarea();

                auxControladorSubTarea.RechazarSubTarea(Convert.ToInt32(TXTBuscar.Text));
                ListarSubTarea();

                Response.Redirect("FormularioRechazoSubTarea.aspx?parametro=" + IDTRANSFERIDO.Text + "&parametro2=" + EmailTransferido.Text + "&parametro3=" + TXTBuscar.Text);
            }
        }

        protected void BtnBuscar_Click(object sender, EventArgs e)
        {

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

        protected void BtnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormularioTareasFuncionario.aspx?parametro=" + EmailTransferido.Text);
        }
    }
}