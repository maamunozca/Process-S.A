using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProcessSA.Vista
{
    public partial class FormularioReportarProblema : System.Web.UI.Page
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
                ListarProblema();

            } 
        }

        public void ListarProblema()
        {
            Controlador.ControladorTareas AuxControladorTarea = new Controlador.ControladorTareas();

            DataTable dt = new DataTable();

            int idrecibido = Convert.ToInt32(IDTRANSFERIDO.Text);

            dt = AuxControladorTarea.ListarProblema(idrecibido);

            GridReportarProblema.DataSource = dt;
            GridReportarProblema.DataBind();

        }

        public void ListarProblemaConFiltro()
        {
            Controlador.ControladorTareas AuxControladorTarea = new Controlador.ControladorTareas();

            DataTable dt = new DataTable();

            int idrecibido = Convert.ToInt32(IDTRANSFERIDO.Text);
            int idproblema = Convert.ToInt32(TXTBuscar.Text);

            dt = AuxControladorTarea.ListarProblemaConFiltro(idrecibido,idproblema);

            GridReportarProblema.DataSource = dt;
            GridReportarProblema.DataBind();
        }

           
        protected void BtnAgregarMotivo_Click(object sender, EventArgs e)
        {
            if (TXTMotivo.Text.Trim() == string.Empty)
            {
                TXTBuscar.BorderColor = System.Drawing.Color.Red;
                Alerta.Visible = true;
                AlertaExito.Visible = false;
            }
            else
            {
                TXTMotivo.BorderColor = System.Drawing.Color.Green;
                Alerta.Visible = false;
                AlertaExito.Visible = true;

                Controlador.ControladorTareas AuxControladorTarea = new Controlador.ControladorTareas();

                Modelo.Reportar_Problema AuxReportar = new Modelo.Reportar_Problema();

                AuxReportar.ID_TAREA1 = Convert.ToInt32(IDTRANSFERIDO.Text);
                AuxReportar.Motivo1 = TXTMotivo.Text;
                AuxReportar.FechaHoy1 = DateTime.Today;

                AuxControladorTarea.ReportarProblema(AuxReportar);

                ListarProblema();


            }
        }

        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            if (TXTBuscar.Text.Trim() == string.Empty)
            {
                TXTBuscar.BorderColor = System.Drawing.Color.Red;
                AlertaID.Visible = true;
                ListarProblema();
            }
            else
            {
                Controlador.ControladorTareas AuxControladorTarea = new Controlador.ControladorTareas();

                Modelo.Reportar_Problema reportar = new Modelo.Reportar_Problema();

                reportar = AuxControladorTarea.ObtenerIDReportarProblema(Convert.ToInt32(TXTBuscar.Text));


                if (reportar.ID_PROBLEMA1 != Convert.ToInt32(TXTBuscar.Text))
                {
                    TXTBuscar.BorderColor = System.Drawing.Color.Red;
                    AlertaIDNoExiste.Visible = true;
                    AlertaID.Visible = false;
                }
                else
                {
                    TXTBuscar.BorderColor = System.Drawing.Color.Green;
                    AlertaID.Visible = false;
                    AlertaIDNoExiste.Visible = false;
                    ListarProblemaConFiltro();
                }

                
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
            Response.Redirect("FormularioTareasFuncionario.aspx?parametro=" + IDTRANSFERIDO.Text + "&parametro2=" + EmailTransferido.Text);

        }
    }
}