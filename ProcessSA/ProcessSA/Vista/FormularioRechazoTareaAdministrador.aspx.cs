using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace ProcessSA.Vista
{
    public partial class FormularioRechazoTareaAdministrador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
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


                Alerta.Visible = false;
                AlertaExito.Visible = false;
                AlertaID.Visible = false;
                AlertaIDNoExiste.Visible = false;
                ListarRechazo();
            }

        }

        public void ListarRechazo()
        {

            int idrecibida = Convert.ToInt32(IDTRANSFERIDO.Text);
            Controlador.ControladorRechazo AuxControladorRechazo = new Controlador.ControladorRechazo();

            DataTable dt = new DataTable();
            dt = AuxControladorRechazo.ListarRechazo(idrecibida);

            GridRechazo.DataSource = dt;
            GridRechazo.DataBind();

        }

        public void ListarRechazoConFiltro()
        {

            int idrecibida = Convert.ToInt32(IDTRANSFERIDO.Text);
            int IDMOTIVO = Convert.ToInt32(TXTBuscar.Text);
            Controlador.ControladorRechazo AuxControladorRechazo = new Controlador.ControladorRechazo();

            DataTable dt = new DataTable();
            dt = AuxControladorRechazo.ListarRechazoConFiltro2(idrecibida, IDMOTIVO);

            GridRechazo.DataSource = dt;
            GridRechazo.DataBind();

        }


        protected void BtnAgregarMotivo_Click(object sender, EventArgs e)
        {
            if (TXTMotivo.Text.Trim() == string.Empty)
            {
                TXTMotivo.BackColor = System.Drawing.Color.Red;
                Alerta.Visible = true;
                AlertaExito.Visible = false;
                ListarRechazo();
            }
            else
            {
                TXTMotivo.BorderColor = System.Drawing.Color.Green;
                AlertaExito.Visible = true;
                Alerta.Visible = false;

                Modelo.RechazoTarea Rechazo = new Modelo.RechazoTarea();
                Controlador.ControladorRechazo AuxControladorRechazo = new Controlador.ControladorRechazo();

                Rechazo.ID_TAREA1 = Convert.ToInt32(IDTRANSFERIDO.Text);
                Rechazo.Motivo1 = TXTMotivo.Text;
                Rechazo.FechaRechazo1 = DateTime.Today;

                AuxControladorRechazo.AgregarMotivoRechazoTarea(Rechazo);

                ListarRechazo();
            }
        }

        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            if (TXTBuscar.Text.Trim() == string.Empty)
            {
                TXTBuscar.BorderColor = System.Drawing.Color.Red;
                AlertaID.Visible = true;
                ListarRechazo();
            }
            else
            {
                Controlador.ControladorTareas AuxControladorTarea = new Controlador.ControladorTareas();

                Modelo.RechazoTarea RECHAZO = new Modelo.RechazoTarea();

                RECHAZO = AuxControladorTarea.ObtenerIDRechazoTarea(Convert.ToInt32(TXTBuscar.Text));


                if (RECHAZO.ID_TAREA1 != Convert.ToInt32(TXTBuscar.Text))
                {
                    TXTBuscar.BorderColor = System.Drawing.Color.Red;
                    AlertaIDNoExiste.Visible = true;
                    AlertaID.Visible = false;
                    ListarRechazo();
                }
                else
                {
                    TXTBuscar.BorderColor = System.Drawing.Color.Green;
                    AlertaID.Visible = false;
                    AlertaIDNoExiste.Visible = false;
                    ListarRechazoConFiltro();
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
            Response.Redirect("FormularioTareasFuncionarioAdministrador.aspx?parametro=" + EmailTransferido.Text);
        }
    }
}