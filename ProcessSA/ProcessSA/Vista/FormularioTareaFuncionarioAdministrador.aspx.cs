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

            if (Request.Params["parametro"] != null)
            {
                EmailTransferido.Text = Request.Params["parametro"];
                EmailTransferido.Visible = false;
            }


            ListarTarea();

        }


        public void ListarTarea()
        {


            Controlador.ControladorTareas AuxControladorTarea = new Controlador.ControladorTareas();

            DataTable dt = new DataTable();
            dt = AuxControladorTarea.ListarTareaFuncionario(EmailTransferido.Text);

            GridTarea.DataSource = dt;
            GridTarea.DataBind();

        }

        protected void BtnComenzar_Click(object sender, EventArgs e)
        {
            Controlador.ControladorTareas AuxControladorTarea = new Controlador.ControladorTareas();
            if (TXTBuscar.Text.Trim() == string.Empty)
            {
                TXTBuscar.BorderColor = System.Drawing.Color.Red;
                AlertaID.Visible = true;

            }
            else
            {
                if (AuxControladorTarea.verificarTarea(Convert.ToInt32(TXTBuscar.Text)))
                {
                    AlertaIDNoExiste.Visible = false; ;
                    TXTBuscar.BorderColor = System.Drawing.Color.Green;
                    AlertaID.Visible = false;


                    int idrecibido = Convert.ToInt32(TXTBuscar.Text);

                    AuxControladorTarea.ComenzarTarea(idrecibido);
                    ListarTarea();
                }
                else
                {
                    TXTBuscar.BorderColor = System.Drawing.Color.Red;
                    AlertaIDNoExiste.Visible = true;
                    ListarTarea();
                }


            }
        }

        protected void BtnTerminar_Click(object sender, EventArgs e)
        {
            Controlador.ControladorTareas AuxControladorTarea = new Controlador.ControladorTareas();


            if (TXTBuscar.Text.Trim() == string.Empty)
            {
                TXTBuscar.BorderColor = System.Drawing.Color.Red;
                AlertaID.Visible = true;

            }
            else
            {
                if (AuxControladorTarea.verificarTarea(Convert.ToInt32(TXTBuscar.Text)))
                {
                    AlertaIDNoExiste.Visible = false;
                    TXTBuscar.BorderColor = System.Drawing.Color.Green;
                    AlertaID.Visible = false;
                    int idrecibido = Convert.ToInt32(TXTBuscar.Text);

                    AuxControladorTarea.TerminarTarea(idrecibido);
                    ListarTarea();
                }
                else
                {
                    TXTBuscar.BorderColor = System.Drawing.Color.Red;
                    AlertaIDNoExiste.Visible = true;
                    ListarTarea();
                }


            }

        }

        protected void BtnRechazar_Click(object sender, EventArgs e)
        {
            Controlador.ControladorTareas AuxControladorTarea = new Controlador.ControladorTareas();

            if (TXTBuscar.Text.Trim() == string.Empty)
            {
                TXTBuscar.BorderColor = System.Drawing.Color.Red;
                AlertaID.Visible = true;

            }
            else
            {
                if (AuxControladorTarea.verificarTarea(Convert.ToInt32(TXTBuscar.Text)))
                {
                    TXTBuscar.BorderColor = System.Drawing.Color.Green;
                    AlertaID.Visible = false;
                    int idrecibido = Convert.ToInt32(TXTBuscar.Text);

                    AuxControladorTarea.RechazarTarea(idrecibido);
                    ListarTarea();

                    Response.Redirect("FormularioRechazoTareaAdministrador.aspx?parametro=" + TXTBuscar.Text + "&parametro2=" + EmailTransferido.Text);

                }
                else
                {
                    TXTBuscar.BorderColor = System.Drawing.Color.Red;
                    AlertaIDNoExiste.Visible = true;
                    ListarTarea();
                }
            }
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

        protected void BtnReportarProblema_Click(object sender, EventArgs e)
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
                    AlertaID.Visible = false;
                    Response.Redirect("FormularioReportarProblemaAdministrador.aspx?parametro=" + TXTBuscar.Text + "&parametro2=" + EmailTransferido.Text);

                }
                else
                {
                    TXTBuscar.BorderColor = System.Drawing.Color.Red;
                    AlertaIDNoExiste.Visible = true;
                }
            }
        }

        protected void BtnSubTarea_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormularioSubTareasFuncionario.aspx?parametro=" + TXTBuscar.Text + "&parametro2=" + EmailTransferido.Text);
        }

        protected void BtnAtrasada_Click(object sender, EventArgs e)
        {
            Controlador.ControladorTareas AuxControladorTarea = new Controlador.ControladorTareas();


            if (TXTBuscar.Text.Trim() == string.Empty)
            {
                TXTBuscar.BorderColor = System.Drawing.Color.Red;
                AlertaID.Visible = true;

            }
            else
            {

                if (AuxControladorTarea.verificarTarea(Convert.ToInt32(TXTBuscar.Text)))
                {
                    AlertaIDNoExiste.Visible = false;

                    Modelo.Tarea AuxTarea = new Modelo.Tarea();

                    int idtarea = Convert.ToInt32(TXTBuscar.Text);

                    AuxTarea = AuxControladorTarea.ObtenerSemaforo(idtarea);

                    if (AuxTarea.ID_Estado1 == 3)
                    {
                        TXTBuscar.BorderColor = System.Drawing.Color.Green;
                        AlertaID.Visible = false;
                        AlertaSemaforo.Visible = false;

                        AuxControladorTarea.AtrasoTarea(idtarea);
                        ListarTarea();

                        Response.Redirect("FormularioAtrasoTareaAdministrador.aspx?parametro=" + TXTBuscar.Text + "&parametro2=" + EmailTransferido.Text);
                    }
                    else
                    {
                        TXTBuscar.BorderColor = System.Drawing.Color.Red;
                        AlertaSemaforo.Visible = true;
                    }
                }
                else
                {
                    TXTBuscar.BorderColor = System.Drawing.Color.Red;
                    AlertaIDNoExiste.Visible = true;
                }


            }

        }
    }
}