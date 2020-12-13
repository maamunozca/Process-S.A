using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProcessSA.Vista
{
    public partial class FormularioRechazoSubTareaAdministrador : System.Web.UI.Page
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

                    if (Request.Params["parametro3"] != null)
                    {
                        Filtro.Text = Request.Params["parametro3"];
                        Filtro.Visible = false;
                    }
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }

            



            if (!IsPostBack)
            {
                Alerta.Visible = false;
                AlertaExito.Visible = false;
                AlertaID.Visible = false;
                AlertaIDNoExiste.Visible = false;

                ListarRechazoSubTarea();
            }

        }

        public void ListarRechazoSubTarea()
        {
            Controlador.ControladorRechazo AuxControladorRechazo = new Controlador.ControladorRechazo();

            int idrecibido = Convert.ToInt32(Filtro.Text);

            DataTable dt = new DataTable();

            dt = AuxControladorRechazo.ListarRechazSubTarea(idrecibido);
            GridRechazoSubTarea.DataSource = dt;
            GridRechazoSubTarea.DataBind();

        }

        public void FiltrarRechazoSubTarea()
        {
            Controlador.ControladorRechazo AuxControladorRechazo = new Controlador.ControladorRechazo();

            int idrecibido = Convert.ToInt32(Filtro.Text);
            int idrechazo = Convert.ToInt32(TXTBuscar.Text);

            DataTable dt = new DataTable();

            dt = AuxControladorRechazo.FiltrarRechazSubTarea(idrecibido, idrechazo);
            GridRechazoSubTarea.DataSource = dt;
            GridRechazoSubTarea.DataBind();
        }

        protected void BtnAgregarMotivo_Click(object sender, EventArgs e)
        {
            if (TXTMotivo.Text.Trim() == string.Empty)
            {
                TXTMotivo.BorderColor = System.Drawing.Color.Red;
                Alerta.Visible = true;
                AlertaExito.Visible = false;
            }
            else
            {
                TXTMotivo.BorderColor = System.Drawing.Color.Green;
                Alerta.Visible = false;
                AlertaExito.Visible = true;

                Controlador.ControladorRechazo AuxControladorRechazo = new Controlador.ControladorRechazo();

                Modelo.RechazoSubTarea rechazo = new Modelo.RechazoSubTarea();

                rechazo.ID_SubTarea1 = Convert.ToInt32(Filtro.Text);
                rechazo.Motivo1 = TXTMotivo.Text;
                rechazo.Fecha_Hoy1 = DateTime.Today;

                AuxControladorRechazo.AgregarRechazoSubTarea(rechazo);

                ListarRechazoSubTarea();
            }
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

                FiltrarRechazoSubTarea();
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