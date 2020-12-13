﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProcessSA.Vista
{
    public partial class FormularioSubTarea : System.Web.UI.Page
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
                        NuevoID.Text = Request.Params["parametro3"];
                        NuevoID.Visible = false;
                    }
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }

            IDTRANSFERIDO.Visible = false;
            Alerta.Visible = false;
            AlertaExito.Visible = false;
            AlertaIDNoExiste.Visible = false;
            if (!IsPostBack)
            {
                ListarSubTarea();
            }
            AlertaID.Visible = false;
        }

        private void ListarSubTarea()
        {
            int idRecibido = Convert.ToInt32(NuevoID.Text);
            Controlador.ControladorSubTarea auxControladorSubTarea = new Controlador.ControladorSubTarea();

            DataTable dt = new DataTable();
            dt = auxControladorSubTarea.ListarSubTarea(idRecibido);
            GridSubtarea.DataSource = dt;
            GridSubtarea.DataBind();
        }

        protected void BtnAgregarSubTarea_Click(object sender, EventArgs e)
        {
            if (TXTNombreSubTarea.Text.Trim() == string.Empty)
            {
                TXTNombreSubTarea.BorderColor = System.Drawing.Color.Red;
                Alerta.Visible = true;
                AlertaExito.Visible = false;
            }
            else
            {
                TXTNombreSubTarea.BorderColor = System.Drawing.Color.Green;
                AlertaExito.Visible = true;
                Alerta.Visible = false;

                Controlador.ControladorSubTarea auxControladorSubTarea = new Controlador.ControladorSubTarea();
                Modelo.SubTarea Subtarea = new Modelo.SubTarea();

                Subtarea.Nombre_SubTarea1 = TXTNombreSubTarea.Text;
                Subtarea.ID_Tarea1 = Convert.ToInt32(NuevoID.Text);

                auxControladorSubTarea.AgregarSubTarea(Subtarea);

                ListarSubTarea();
                
               
            }
        }

        public void FiltrarSubtarea()
        {
            int idRecibido = Convert.ToInt32(NuevoID.Text);
            Controlador.ControladorSubTarea auxControladorSubTarea = new Controlador.ControladorSubTarea();

            DataTable dt = new DataTable();
            dt = auxControladorSubTarea.FiltrarSubtareaID(idRecibido, Convert.ToInt32(TXTBuscar.Text));
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
                    int idrecibido = Convert.ToInt32(NuevoID.Text);
                    int idbuscado = Convert.ToInt32(TXTBuscar.Text);

                    if (AuxControladorSubTarea.VerificarSubTareaAdministrador2(idrecibido, idbuscado))
                    {
                        TXTBuscar.BorderColor = System.Drawing.Color.Green;
                        AlertaID.Visible = false;
                        AlertaIDNoExiste.Visible = false;

                        FiltrarSubtarea();

                    }
                    else
                    {
                        AlertaIDNoExiste.Visible = true;
                        AlertaID.Visible = false;
                        TXTBuscar.BorderColor = System.Drawing.Color.Red;
                        ListarSubTarea();
                    }

                }
                catch (Exception)
                {

                    AlertaID.Visible = true;
                    AlertaIDNoExiste.Visible = false;
                    ListarSubTarea();

                    TXTBuscar.BorderColor = System.Drawing.Color.Red;
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
            Response.Redirect("FormularioAgregarTarea.aspx?parametro=" + IDTRANSFERIDO.Text + "&parametro2=" + EmailTransferido.Text + "&parametro3="+ NuevoID.Text);
        }

        protected void BtnCerrarSesion_Click(object sender, EventArgs e)
        {
            Controlador.Inseguridad.Variable = "";

            Response.Redirect("Login.aspx");
        }
    }
}