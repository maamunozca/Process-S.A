using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProcessSA.Vista
{
    public partial class FormularioAtrasoTareaAdministrador : System.Web.UI.Page
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

            if (!IsPostBack)
            {
                Alerta.Visible = false;
                AlertaExito.Visible = false;
                AlertaID.Visible = false;
                AlertaIDNoExiste.Visible = false;

                ListarAtraso();
            }
        }


        public void ListarAtraso()
        {
            Controlador.ControladorTareas AuxControladorTarea = new Controlador.ControladorTareas();
            int idrecibido = Convert.ToInt32(IDTRANSFERIDO.Text);

            DataTable dt = new DataTable();
            dt = AuxControladorTarea.ListarAtrasoTarea(idrecibido);

            GridAtraso.DataSource = dt;
            GridAtraso.DataBind();
        }

        public void FiltrarAtraso()
        {

            int idrecibido = Convert.ToInt32(IDTRANSFERIDO.Text);
            int idatraso = Convert.ToInt32(TXTBuscar.Text);

            Controlador.ControladorTareas AuxControladorTarea = new Controlador.ControladorTareas();

            DataTable dt = new DataTable();

            dt = AuxControladorTarea.ListarAtrasoTarea2(idatraso, idrecibido);

            GridAtraso.DataSource = dt;
            GridAtraso.DataBind();
        }

        protected void BtnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminVista.aspx");
        }

        protected void BtnAgregarMotivo_Click(object sender, EventArgs e)
        {
            if (TXTMotivo.Text.Trim() == string.Empty)
            {
                TXTBuscar.BorderColor = System.Drawing.Color.Red;
                Alerta.Visible = true;

            }
            else
            {
                TXTBuscar.BorderColor = System.Drawing.Color.Green;
                Alerta.Visible = false;

                int idrecibido = Convert.ToInt32(IDTRANSFERIDO.Text);

                Controlador.ControladorTareas AuxControladorTarea = new Controlador.ControladorTareas();
                Modelo.AtrasoTarea AuxAtrasoTarea = new Modelo.AtrasoTarea();

                AuxAtrasoTarea.ID_Tarea1 = idrecibido;
                AuxAtrasoTarea.Motivo1 = TXTMotivo.Text;
                AuxAtrasoTarea.Fecha_Hoy1 = DateTime.Today;

                AuxControladorTarea.AgregarAtrasoTarea(AuxAtrasoTarea);

                ListarAtraso();

            }
        }



        protected void BtnBuscar_Click(object sender, EventArgs e)
        {



            if (TXTBuscar.Text.Trim() == string.Empty)
            {
                TXTBuscar.BorderColor = System.Drawing.Color.Red;
                AlertaID.Visible = true;
                AlertaIDNoExiste.Visible = false;
                ListarAtraso();
            }
            else
            {
                Controlador.ControladorTareas AuxControladorTarea = new Controlador.ControladorTareas();
                Modelo.AtrasoTarea ATRASO = new Modelo.AtrasoTarea();
                ATRASO = AuxControladorTarea.ObtenerIDAtrasoTarea(Convert.ToInt32(TXTBuscar.Text));

                if (ATRASO.ID_Tarea1 != Convert.ToInt32(TXTBuscar.Text))
                {
                    TXTBuscar.BorderColor = System.Drawing.Color.Red;
                    AlertaID.Visible = false;
                    AlertaIDNoExiste.Visible = true;

                }
                else
                {
                    TXTBuscar.BorderColor = System.Drawing.Color.Green;
                    AlertaID.Visible = false;
                    AlertaIDNoExiste.Visible = false;
                    FiltrarAtraso();
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


    }
}