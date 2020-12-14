using Antlr.Runtime;
using Microsoft.Ajax.Utilities;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime;
using System.Net.Mail;
using System.Net;

namespace ProcessSA.Vista
{
    public partial class FormularioAgregarTareaAdministrador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarDropDownTipoTarea();
                //    LlenarDropDownEstado();
                LlenarDropDownResponsable();
                LlenarDropDownDepartamento();
                GenerarID();
                limpiar();

                if (Request.Params["parametro"] != null && Controlador.Inseguridad.Variable.Length > 0)
                {
                    IDTransferido.Text = Request.Params["parametro"];
                    IDTransferido.Visible = false;

                    if (Request.Params["parametro2"] != null && Controlador.Inseguridad.Variable.Length > 0)
                    {
                        EmailTransferido.Text = Request.Params["parametro2"];
                        EmailTransferido.Visible = false;
                    }
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }



                ListarTarea();
                Alerta.Visible = false;
                AlertaExito.Visible = false;
                Alerta2.Visible = false;
                AlertaSemaforo.Visible = false;
                AlertaIDNOExistente.Visible = false;
                aLERTANombreNoExistente.Visible = false;
                AlertaActualizacion.Visible = false;
                AlertaEstado.Visible = false;
                FechaActuaizada.Visible = false;

                EliminarAlerta.Visible = false;
                ActualizarPorcentajeFlujo();


            }
        }

        public void ActualizarPorcentajeFlujo()
        {
            Controlador.ControladorFuncionario AuxControladorFuncionario = new Controlador.ControladorFuncionario();

            int idrecibido = Convert.ToInt32(IDTransferido.Text);

            AuxControladorFuncionario.ActualizarPorcentajeFlujoTarea(idrecibido);

        }
        public void limpiar()
        {
            TXTNombreTarea.Text = string.Empty;
            TXTDescTarea.Text = string.Empty;
            DropTipoTarea.SelectedIndex = 0;
            DropResponsable.SelectedIndex = 0;
            //  DropEstado.SelectedIndex = 0;
            DropDepartamento.SelectedIndex = 0;
            TXTFechaInicio.Text = string.Empty;
            TXTFechaTermino.Text = string.Empty;
        }

        public void LlenarDropDownTipoTarea()
        {
            DropTipoTarea.DataSource = consultar("SELECT * FROM TIPO_TAREA");
            DropTipoTarea.DataTextField = "NOMBRE_TIPO_TAREA";
            DropTipoTarea.DataValueField = "ID_TIPO_TAREA";
            DropTipoTarea.DataBind();
            DropTipoTarea.Items.Insert(0, new ListItem("[Seleccionar]", "[0]"));

        }
        /*
        public void LlenarDropDownEstado()
        {
            DropEstado.DataSource = consultar("SELECT * FROM ESTADO_TAREA");
            DropEstado.DataTextField = "ESTADO";
            DropEstado.DataValueField = "ID_ESTADO";
            DropEstado.DataBind();
            DropEstado.Items.Insert(0, new ListItem("[Seleccionar]", "[0]"));
        }
        */

        public void LlenarDropDownResponsable()
        {
            DropResponsable.DataSource = consultar("SELECT* FROM USUARIO WHERE ID_ROL = 2");
            DropResponsable.DataTextField = "NOMBRE_USUARIO";
            DropResponsable.DataValueField = "RUN";
            DropResponsable.DataBind();
            DropResponsable.Items.Insert(0, new ListItem("[Selecionar]", "[0]"));
        }

        public void LlenarDropDownDepartamento()
        {
            DropDepartamento.DataSource = consultar("SELECT * FROM DEPARTAMENTO");
            DropDepartamento.DataTextField = "NOMBRE_DEPARTAMENTO";
            DropDepartamento.DataValueField = "ID_DEPARTAMENTO";
            DropDepartamento.DataBind();
            DropDepartamento.Items.Insert(0, new ListItem("[Seleccionar]", "[0]"));
        }

        public void ListarTarea()
        {

            int idrecibida = Convert.ToInt32(IDTransferido.Text);
            Controlador.ControladorTareas AuxControladorTarea = new Controlador.ControladorTareas();

            DataTable dt = new DataTable();
            dt = AuxControladorTarea.ListarTarea(idrecibida);

            GridTarea.DataSource = dt;
            GridTarea.DataBind();

        }

        public DataSet consultar(string consultaSQL)
        {
            Controlador.Conexion conexion = new Controlador.Conexion();
            OracleConnection conn = new OracleConnection();
            conn = conexion.getConn();

            conn.Open();

            OracleCommand comando = new OracleCommand(consultaSQL, conn);
            OracleDataAdapter da = new OracleDataAdapter(comando);
            DataSet ds = new DataSet();
            da.Fill(ds);

            conn.Clone();

            return ds;

        }

        private void GenerarID()
        {
            Controlador.Conexion conexion = new Controlador.Conexion();
            OracleConnection conn = new OracleConnection();
            conn = conexion.getConn();

            conn.Open();

            OracleCommand comando = new OracleCommand("SELECT COUNT(ID_TAREA) FROM TAREA", conn);


            int i = Convert.ToInt32(comando.ExecuteScalar());
            conn.Close();
            i++;

            TXTIDTarea.Text = i.ToString();

        }

        private Boolean validarCampos()
        {
            Boolean validado = false, VID, VNombre, VDescripcion, VTipoTarea, VResponsable, VEstado, VFechaInicio, VFechaTermino;

            if (TXTIDTarea.Text.Trim() == string.Empty)
            {
                TXTIDTarea.BorderColor = System.Drawing.Color.Red;
                VID = false;

            }
            else
            {
                TXTIDTarea.BorderColor = System.Drawing.Color.Green;
                VID = true;
            }
            if (TXTNombreTarea.Text.Trim() == string.Empty)
            {
                TXTNombreTarea.BorderColor = System.Drawing.Color.Red;
                VNombre = false;
            }
            else
            {
                TXTNombreTarea.BorderColor = System.Drawing.Color.Green;
                VNombre = true;
            }
            if (TXTDescTarea.Text.Trim() == string.Empty)
            {
                TXTDescTarea.BorderColor = System.Drawing.Color.Red;
                VDescripcion = false;
            }
            else
            {
                TXTDescTarea.BorderColor = System.Drawing.Color.Green;
                VDescripcion = true;
            }
            if (DropTipoTarea.SelectedIndex > 0)
            {
                DropTipoTarea.BorderColor = System.Drawing.Color.Green;
                VTipoTarea = false;
            }
            else
            {
                DropTipoTarea.BorderColor = System.Drawing.Color.Red;
                VTipoTarea = true;

            }
            if (DropResponsable.SelectedIndex > 0)
            {
                DropResponsable.BorderColor = System.Drawing.Color.Green;
                VResponsable = true;
            }
            else
            {
                DropResponsable.BorderColor = System.Drawing.Color.Red;
                VResponsable = false;
            }
            /*
            if (DropEstado.SelectedIndex > 0)
            {
                DropEstado.BorderColor = System.Drawing.Color.Green;
                VEstado =  true;
            }
            else
            {
                DropEstado.BorderColor = System.Drawing.Color.Red;
                VEstado = false;
                
            }
            */
            if (TXTFechaInicio.Text.Trim() == string.Empty)
            {
                TXTFechaInicio.BorderColor = System.Drawing.Color.Red;
                VFechaInicio = false;

            }
            else
            {
                TXTFechaInicio.BorderColor = System.Drawing.Color.Green;
                VFechaInicio = true;
            }
            if (TXTFechaTermino.Text.Trim() == string.Empty)
            {
                TXTFechaTermino.BorderColor = System.Drawing.Color.Red;
                VFechaTermino = false;
            }
            else
            {
                TXTFechaTermino.BorderColor = System.Drawing.Color.Green;
                VFechaTermino = true;
                validado = true;

            }

            return validado;

        }



        protected void BtnAgregarTarea_Click(object sender, EventArgs e)
        {
            Controlador.ControladorTareas AuxControlarTarea = new Controlador.ControladorTareas();
            Modelo.Tarea AuxTarea = new Modelo.Tarea();
            Modelo.Plazos plazo = new Modelo.Plazos();
            Modelo.Detalle_Tarea AuxDetalleTarea = new Modelo.Detalle_Tarea();
            /*
            Labeltipotarea.Text = DropTipoTarea.SelectedValue.ToString();
            labelresponsable.Text = DropResponsable.SelectedValue.ToString();
            labelestado.Text = DropEstado.SelectedIndex.ToString();
            labeldepartamento.Text = DropDepartamento.SelectedValue.ToString();
            */

            if (validarCampos())
            {
                DateTime fechat = DateTime.Parse(TXTFechaTermino.Text);
                DateTime fechai = DateTime.Parse(TXTFechaInicio.Text);

                var timeSpan = fechat - fechai;

                double dias = timeSpan.TotalDays;

                if (dias <= 0)
                {

                    AuxTarea.ID_Estado1 = 3;
                }
                else if (dias >= 7)
                {
                    AuxTarea.ID_Estado1 = 1;
                }
                else if (dias <= 6 || dias >= 1)
                {
                    AuxTarea.ID_Estado1 = 2;
                }






                // Llenar modelo Tarea
                AuxTarea.ID_Tarea1 = Convert.ToInt32(TXTIDTarea.Text);
                AuxTarea.Nombre_Tarea1 = TXTNombreTarea.Text;
                AuxTarea.Desc_Tarea1 = TXTDescTarea.Text;
                //  AuxTarea.ID_Estado1 = Convert.ToInt32(DropEstado.SelectedValue.ToString());
                AuxTarea.ID_Tipo_Tarea1 = Convert.ToInt32(DropTipoTarea.SelectedValue.ToString());
                AuxTarea.ID_Departamento1 = Convert.ToInt32(DropDepartamento.SelectedValue.ToString());

                //  Insertar en la tabla tarea
                AuxControlarTarea.AgregarTarea(AuxTarea);

                //Llenar modelo plazo
                plazo.ID_Plazo1 = Convert.ToInt32(TXTIDTarea.Text);
                plazo.Fecha_Inicio1 = Convert.ToDateTime(TXTFechaInicio.Text);
                plazo.Fecha_Termino1 = Convert.ToDateTime(TXTFechaTermino.Text);
                plazo.ID_TAREA1 = Convert.ToInt32(TXTIDTarea.Text);


                // Insertar en la tabla plazo

                AuxControlarTarea.AgregarPlazos(plazo);

                // Llenar modelo detalle_tarea
                AuxDetalleTarea.ID_Flujo_Tarea1 = Convert.ToInt32(IDTransferido.Text);
                AuxDetalleTarea.ID_Tarea1 = Convert.ToInt32(TXTIDTarea.Text);
                AuxDetalleTarea.Run1 = DropResponsable.SelectedValue.ToString();


                // insertar en la tabla Detalle_Tarea

                AuxControlarTarea.AgregarDetalleTarea(AuxDetalleTarea);


                AlertaExito.Visible = true;
                Alerta.Visible = false;
                FechaActuaizada.Visible = false;
                GenerarID();
                limpiar();
                ListarTarea();
                ActualizarPorcentajeFlujo();

            }
            else
            {
                Alerta.Visible = true;
                AlertaExito.Visible = false;
                FechaActuaizada.Visible = false;

            }

        }

        protected void GridTarea_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox6_TextChanged(object sender, EventArgs e)
        {
            Response.Redirect("FormularioSubTarea.aspx");
        }

        protected void BtnAgregarSubTarea_Click(object sender, EventArgs e)
        {
            Controlador.ControladorTareas auxControladorTarea = new Controlador.ControladorTareas();
            if (TXTBuscar.Text.Trim() == string.Empty)
            {
                TXTBuscar.BorderColor = System.Drawing.Color.Red;
                Alerta2.Visible = true;
                AlertaIDNOExistente.Visible = false;
                FechaActuaizada.Visible = false;


            }
            else
            {

                if (auxControladorTarea.verificarTarea(Convert.ToInt32(TXTBuscar.Text)))
                {
                    AlertaIDNOExistente.Visible = false;
                    Alerta2.Visible = false;
                    FechaActuaizada.Visible = false;
                    Response.Redirect("FormularioSubTarea.aspx?parametro=" + IDTransferido.Text + "&parametro2=" + EmailTransferido.Text + "&parametro3=" + TXTBuscar.Text);
                }
                else
                {
                    Alerta2.Visible = false;
                    AlertaIDNOExistente.Visible = true;
                    FechaActuaizada.Visible = false;
                }
            }

        }

        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            Controlador.ControladorTareas auxControladorTarea = new Controlador.ControladorTareas();

            if (TXTBuscar.Text.Trim() == string.Empty)
            {

                TXTBuscar.BorderColor = System.Drawing.Color.Red;

                ListarTarea();

                Alerta.Visible = false;
                AlertaExito.Visible = false;
                Alerta2.Visible = false;
                AlertaSemaforo.Visible = false;
                AlertaIDNOExistente.Visible = false;
                aLERTANombreNoExistente.Visible = false;
                AlertaActualizacion.Visible = false;
                AlertaEstado.Visible = false;
                FechaActuaizada.Visible = false;
                EliminarAlerta.Visible = false;
            }
            else
            {
                if (auxControladorTarea.verificarTareaNombre(TXTBuscar.Text))
                {
                    Alerta.Visible = false;
                    AlertaExito.Visible = false;
                    Alerta2.Visible = false;
                    AlertaSemaforo.Visible = false;
                    AlertaIDNOExistente.Visible = false;
                    aLERTANombreNoExistente.Visible = false;
                    AlertaActualizacion.Visible = false;
                    AlertaEstado.Visible = false;
                    EliminarAlerta.Visible = false;
                    FechaActuaizada.Visible = false;

                    TXTBuscar.BorderColor = System.Drawing.Color.Green;
                    DataTable dt = new DataTable();
                    dt = auxControladorTarea.BuscarTarea(Convert.ToInt32(IDTransferido.Text), TXTBuscar.Text);
                    GridTarea.DataSource = dt;
                    GridTarea.DataBind();
                }
                else
                {

                    Alerta.Visible = false;
                    AlertaExito.Visible = false;
                    Alerta2.Visible = false;
                    AlertaSemaforo.Visible = false;
                    AlertaIDNOExistente.Visible = false;
                    aLERTANombreNoExistente.Visible = true;
                    AlertaActualizacion.Visible = false;
                    AlertaEstado.Visible = false;
                    FechaActuaizada.Visible = false;
                    EliminarAlerta.Visible = false;

                    TXTBuscar.BorderColor = System.Drawing.Color.Red;
                }
            }
        }

        protected void BtnBuscarID_Click(object sender, EventArgs e)
        {
            Controlador.ControladorTareas auxControladorTarea = new Controlador.ControladorTareas();
            if (TXTBuscar.Text.Trim() == string.Empty)
            {
                TXTBuscar.BorderColor = System.Drawing.Color.Red;
                Alerta2.Visible = true;
                FechaActuaizada.Visible = false;
                AlertaEstado.Visible = false;
                EliminarAlerta.Visible = false;
                ListarTarea();
            }
            else
            {
                try
                {
                    if (auxControladorTarea.verificarTarea(Convert.ToInt32(TXTBuscar.Text)))
                    {

                        TXTBuscar.BorderColor = System.Drawing.Color.Green;
                        AlertaIDNOExistente.Visible = false;
                        DataTable dt = new DataTable();
                        dt = auxControladorTarea.BuscarTareaID(Convert.ToInt32(IDTransferido.Text), Convert.ToInt32(TXTBuscar.Text));
                        GridTarea.DataSource = dt;
                        GridTarea.DataBind();
                        Alerta2.Visible = false;
                        AlertaEstado.Visible = false;
                        AlertaActualizacion.Visible = false;
                        aLERTANombreNoExistente.Visible = false;
                        AlertaExito.Visible = false;
                        FechaActuaizada.Visible = false;
                        EliminarAlerta.Visible = false;

                    }
                    else
                    {
                        TXTBuscar.BorderColor = System.Drawing.Color.Red;
                        AlertaIDNOExistente.Visible = true;
                        AlertaEstado.Visible = false;
                        FechaActuaizada.Visible = false;
                        AlertaActualizacion.Visible = false;
                        aLERTANombreNoExistente.Visible = false;
                        AlertaExito.Visible = false;
                        EliminarAlerta.Visible = false;
                    }

                }
                catch (Exception)
                {
                    Alerta.Visible = false;
                    AlertaExito.Visible = false;
                    Alerta2.Visible = true;
                    AlertaSemaforo.Visible = false;
                    AlertaIDNOExistente.Visible = false;
                    aLERTANombreNoExistente.Visible = false;
                    AlertaActualizacion.Visible = false;
                    AlertaEstado.Visible = false;
                    FechaActuaizada.Visible = false;
                    EliminarAlerta.Visible = false;
                    TXTBuscar.BorderColor = System.Drawing.Color.Red;

                }

            }
        }


        protected void BtnActualizarTarea_Click(object sender, EventArgs e)
        {
            Controlador.ControladorTareas AuxControladorTarea = new Controlador.ControladorTareas();


            if (validarCampos())
            {
                int idrecibido = Convert.ToInt32(TXTBuscar.Text);
                string nombre = TXTNombreTarea.Text;
                string descripcon = TXTDescTarea.Text;
                int idtipo = Convert.ToInt32(DropTipoTarea.SelectedValue.ToString());
                int iddepartamento = Convert.ToInt32(DropDepartamento.SelectedValue.ToString()); ;

                string run = DropResponsable.SelectedValue.ToString();

                AuxControladorTarea.ActualizarTarea(idrecibido, nombre, descripcon, idtipo, iddepartamento);



                AuxControladorTarea.ActualizarResponsable(idrecibido, run);

                AlertaActualizacion.Visible = true;
                Alerta.Visible = false;
                AlertaEstado.Visible = false;
                FechaActuaizada.Visible = false;
                aLERTANombreNoExistente.Visible = false;
                AlertaExito.Visible = false;
                EliminarAlerta.Visible = false;
                GenerarID();
                limpiar();
                ListarTarea();

            }
            else
            {
                AlertaActualizacion.Visible = false;
                Alerta.Visible = true;
                AlertaEstado.Visible = false;
                FechaActuaizada.Visible = false;
                aLERTANombreNoExistente.Visible = false;
                AlertaExito.Visible = false;
                EliminarAlerta.Visible = false;

            }


        }

        // Boton Eliminar Tarea
        protected void BtnReportarProblema_Click(object sender, EventArgs e)
        {
            Controlador.ControladorTareas auxControladorTarea = new Controlador.ControladorTareas();
            if (TXTBuscar.Text.Trim() == string.Empty)
            {
                TXTBuscar.BorderColor = System.Drawing.Color.Red;
                Alerta2.Visible = true;
                AlertaEstado.Visible = false;
                FechaActuaizada.Visible = false;
                AlertaActualizacion.Visible = false;
                aLERTANombreNoExistente.Visible = false;
                AlertaExito.Visible = false;
                EliminarAlerta.Visible = false;
                ListarTarea();
            }
            else
            {

                try
                {
                    if (auxControladorTarea.verificarTarea(Convert.ToInt32(TXTBuscar.Text)))
                    {

                        TXTBuscar.BorderColor = System.Drawing.Color.Green;
                        AlertaIDNOExistente.Visible = false;
                        Alerta2.Visible = false;
                        AlertaEstado.Visible = false;
                        FechaActuaizada.Visible = false;
                        AlertaActualizacion.Visible = false;
                        aLERTANombreNoExistente.Visible = false;
                        AlertaExito.Visible = false;

                        EliminarAlerta.Visible = true;

                        auxControladorTarea.EliminarTarea(Convert.ToInt32(TXTBuscar.Text));

                        ListarTarea();
                        limpiar();
                        ActualizarPorcentajeFlujo();
                    }
                    else
                    {
                        TXTBuscar.BorderColor = System.Drawing.Color.Red;
                        AlertaIDNOExistente.Visible = true;
                        AlertaEstado.Visible = false;
                        FechaActuaizada.Visible = false;

                        AlertaActualizacion.Visible = false;
                        aLERTANombreNoExistente.Visible = false;
                        AlertaExito.Visible = false;

                        EliminarAlerta.Visible = false;
                    }

                }
                catch (Exception)
                {

                    Alerta.Visible = false;
                    AlertaExito.Visible = false;
                    Alerta2.Visible = true;
                    AlertaSemaforo.Visible = false;
                    AlertaIDNOExistente.Visible = false;
                    aLERTANombreNoExistente.Visible = false;
                    AlertaActualizacion.Visible = false;
                    AlertaEstado.Visible = false;
                    FechaActuaizada.Visible = false;
                    EliminarAlerta.Visible = false;
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

        protected void BtnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("VistaGestionTareasAdministrador.aspx?parametro=" + EmailTransferido.Text);
        }

        protected void BtnCerrarSesion_Click(object sender, EventArgs e)
        {
            Controlador.Inseguridad.Variable = "";

            Response.Redirect("Login.aspx");
        }

        protected void BtnActualizarFechas_Click(object sender, EventArgs e)
        {
            Controlador.ControladorTareas AuxControladorTarea = new Controlador.ControladorTareas();



            if (TXTBuscar.Text.Trim() == string.Empty)
            {
                TXTBuscar.BorderColor = System.Drawing.Color.Red;
                Alerta2.Visible = true;
                AlertaEstado.Visible = false;
                FechaActuaizada.Visible = false;
                AlertaActualizacion.Visible = false;
                aLERTANombreNoExistente.Visible = false;
                AlertaExito.Visible = false;
                EliminarAlerta.Visible = false;

                ListarTarea();
            }
            else
            {
                if (validarCampos())
                {
                    try
                    {
                        if (AuxControladorTarea.verificarTarea(Convert.ToInt32(TXTBuscar.Text)))
                        {
                            TXTBuscar.BorderColor = System.Drawing.Color.Green;

                            AlertaIDNOExistente.Visible = false;
                            Alerta2.Visible = false;
                            FechaActuaizada.Visible = false;
                            AlertaActualizacion.Visible = false;
                            aLERTANombreNoExistente.Visible = false;
                            AlertaExito.Visible = false;
                            EliminarAlerta.Visible = false;

                            DateTime fechat = Convert.ToDateTime(TXTFechaTermino.Text);
                            DateTime fechahoy = DateTime.Today;
                            /*
                                                DateTime fechat = DateTime.Parse(TXTFechaTermino.Text);
                                                DateTime fechai = DateTime.Parse(TXTFechaInicio.Text);
                            */
                            var DiasTotales = fechat - fechahoy;


                            double dias = DiasTotales.TotalDays;


                            if (dias <= 0)
                            {
                                int idestado = 3;
                                DateTime fechaInicio2 = DateTime.Today;
                                DateTime FechaTermino2 = Convert.ToDateTime(TXTFechaTermino.Text);

                                int idtarea = Convert.ToInt32(TXTBuscar.Text);

                                AuxControladorTarea.ActualizarFechas(idtarea, idestado, fechaInicio2, FechaTermino2);

                                AlertaEstado.Visible = true;
                                FechaActuaizada.Visible = false;

                                ListarTarea();

                                Controlador.ControladorUsuario AuxUsuario = new Controlador.ControladorUsuario();

                                if (!AuxUsuario.ValidarEmail(EmailTransferido.Text))
                                {
                                    Alerta.Visible = false;

                                }
                                else
                                {
                                    Alerta.Visible = false;

                                    AlertaExito.Visible = false;


                                    Modelo.Usuarios usuario = new Modelo.Usuarios();

                                    usuario = AuxUsuario.getUsuario(EmailTransferido.Text);
                                    CorreoTareaAtrasada(EmailTransferido.Text);



                                }

                            }
                            else if (dias >= 7)
                            {
                                int idestado = 1;

                                DateTime fechaInicio2 = DateTime.Today;
                                DateTime FechaTermino2 = Convert.ToDateTime(TXTFechaTermino.Text);

                                int idtarea = Convert.ToInt32(TXTBuscar.Text);

                                AuxControladorTarea.ActualizarFechas(idtarea, idestado, fechaInicio2, FechaTermino2);
                                AlertaEstado.Visible = false;
                                FechaActuaizada.Visible = true;

                                ListarTarea();

                            }
                            else if (dias <= 6 || dias >= 1)
                            {
                                int idestado = 2;

                                DateTime fechaInicio2 = DateTime.Today;
                                DateTime FechaTermino2 = Convert.ToDateTime(TXTFechaTermino.Text);

                                int idtarea = Convert.ToInt32(TXTBuscar.Text);

                                AuxControladorTarea.ActualizarFechas(idtarea, idestado, fechaInicio2, FechaTermino2);
                                AlertaEstado.Visible = false;
                                FechaActuaizada.Visible = true;

                                ListarTarea();

                            }
                        }
                        else
                        {
                            AlertaActualizacion.Visible = false;
                            Alerta.Visible = false;
                            AlertaEstado.Visible = false;
                            FechaActuaizada.Visible = false;

                            AlertaActualizacion.Visible = false;
                            aLERTANombreNoExistente.Visible = false;
                            AlertaExito.Visible = false;

                            EliminarAlerta.Visible = false;
                            AlertaIDNOExistente.Visible = true;
                            Alerta2.Visible = false;
                        }
                    }
                    catch (Exception)
                    {

                        AlertaActualizacion.Visible = false;
                        Alerta.Visible = false;
                        AlertaEstado.Visible = false;
                        FechaActuaizada.Visible = false;

                        AlertaActualizacion.Visible = false;
                        aLERTANombreNoExistente.Visible = false;
                        AlertaExito.Visible = false;

                        EliminarAlerta.Visible = false;
                        AlertaIDNOExistente.Visible = false;
                        Alerta2.Visible = true;
                    }



                }
                else
                {
                    AlertaActualizacion.Visible = false;
                    Alerta.Visible = false;
                    AlertaEstado.Visible = false;
                    FechaActuaizada.Visible = false;

                    AlertaActualizacion.Visible = false;
                    aLERTANombreNoExistente.Visible = false;
                    AlertaExito.Visible = false;

                    EliminarAlerta.Visible = false;

                    AlertaIDNOExistente.Visible = true;
                    Alerta2.Visible = false;
                }

            }
        }

        private void CorreoTareaAtrasada(string email)
        {
            string body = "<body>" + "<h1> Notificacion De Tarea Atrasada</h1>" +
                 "<p>Se a verificado que tiene una tarea con el estado Atrasado, porfavor Ingrese al portal para ingresar el motivo del retraso, Si necesitas contactarte con nosotros puedes hacerlo a través del siguiente email: empresa.process.sa@gmail.com</p>" +
                 "<p>Saludos cordiales </p>" +
                 "<p>Atte. Process S.A</p></body>";

            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress("empresa.process.sa@gmail.com", "Process S.A");
                mail.To.Add(email);
                mail.Subject = "Notificacion De Tarea Atrasada";
                mail.Body = body;
                mail.IsBodyHtml = true;

                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential("empresa.process.sa@gmail.com", "process123");
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
            }
        }

        protected void BtnPasarDatos_Click(object sender, EventArgs e)
        {
            Controlador.ControladorTareas AuxControladorTarea = new Controlador.ControladorTareas();

            if (TXTBuscar.Text.Trim() == string.Empty)
            {
                TXTBuscar.BorderColor = System.Drawing.Color.Red;
                Alerta2.Visible = true;
                AlertaEstado.Visible = false;
                FechaActuaizada.Visible = false;
                AlertaActualizacion.Visible = false;
                aLERTANombreNoExistente.Visible = false;
                AlertaExito.Visible = false;

                EliminarAlerta.Visible = false;
                ListarTarea();
            }
            else
            {
                try
                {
                    if (AuxControladorTarea.verificarTarea(Convert.ToInt32(TXTBuscar.Text)))
                    {
                        Controlador.ControladorUsuario AuxControladorUsuario = new Controlador.ControladorUsuario();

                        Modelo.Usuarios Usuario = new Modelo.Usuarios();
                        Modelo.Tarea tarea = new Modelo.Tarea();
                        Modelo.Plazos plazo = new Modelo.Plazos();

                        TXTBuscar.BorderColor = System.Drawing.Color.Green;

                        AlertaIDNOExistente.Visible = false;
                        Alerta2.Visible = false;
                        AlertaEstado.Visible = false;
                        FechaActuaizada.Visible = false;
                        AlertaActualizacion.Visible = false;
                        aLERTANombreNoExistente.Visible = false;
                        AlertaExito.Visible = false;
                        EliminarAlerta.Visible = false;

                        int idrecibida = Convert.ToInt32(IDTransferido.Text);
                        int idbuscado = Convert.ToInt32(TXTBuscar.Text);

                        Usuario = AuxControladorUsuario.GetRun(idrecibida, idbuscado);
                        tarea = AuxControladorTarea.GetTarea(idrecibida, idbuscado);
                        plazo = AuxControladorTarea.GetPlazo(idrecibida, idbuscado);

                        DateTime fechai = Convert.ToDateTime(plazo.Fecha_Inicio1);
                        DateTime fechat = Convert.ToDateTime(plazo.Fecha_Termino1);


                        TXTNombreTarea.Text = tarea.Nombre_Tarea1;
                        TXTDescTarea.Text = tarea.Desc_Tarea1;
                        DropTipoTarea.SelectedValue = Convert.ToString(tarea.ID_Tipo_Tarea1);
                        DropResponsable.SelectedValue = Usuario.Run1;
                        DropDepartamento.SelectedValue = Convert.ToString(tarea.ID_Departamento1);
                        TXTFechaInicio.Text = fechai.ToString("yyyy-MM-dd");
                        TXTFechaTermino.Text = fechat.ToString("yyyy-MM-dd");

                    }

                }
                catch (Exception)
                {

                    Alerta.Visible = false;
                    AlertaExito.Visible = false;
                    Alerta2.Visible = true;
                    AlertaSemaforo.Visible = false;
                    AlertaIDNOExistente.Visible = false;
                    aLERTANombreNoExistente.Visible = false;
                    AlertaActualizacion.Visible = false;
                    AlertaEstado.Visible = false;
                    FechaActuaizada.Visible = false;
                    EliminarAlerta.Visible = false;
                    TXTBuscar.BorderColor = System.Drawing.Color.Red;
                }

            }
        }
    }
}