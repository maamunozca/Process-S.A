using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProcessSA.Vista
{
    public partial class FormularioTodasLasTareasRechazadas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ListarRechazo();
                AlertaID.Visible = false;
                AlertaIDNoExiste.Visible = false;

            }


            if (Request.Params["parametro"] != null)
            {
                EmailTransferido.Text = Request.Params["parametro"];
                EmailTransferido.Visible = false;
            }

        }

        public void ListarRechazo()
        { 
            Controlador.ControladorRechazo AuxControladorRechazo = new Controlador.ControladorRechazo();

            DataTable dt = new DataTable();
            dt = AuxControladorRechazo.ListarRechazoSinFiltro();

            GridRechazo.DataSource = dt;
            GridRechazo.DataBind();
        }

        public void ListarRechazoConFiltro()
        {
            int idmotivo = Convert.ToInt32(TXTBuscar.Text);
            Controlador.ControladorRechazo AuxControladorRechazo = new Controlador.ControladorRechazo();

            DataTable dt = new DataTable();
            dt = AuxControladorRechazo.ListarRechazoConFiltro(idmotivo);

            GridRechazo.DataSource = dt;
            GridRechazo.DataBind();
        }

        protected void BtnBuscar_Click(object sender, EventArgs e)
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
                ListarRechazoConFiltro();


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

        protected void BtnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("VistaFuncionario.aspx?parametro=" + EmailTransferido.Text);
        }
    }
}