using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProcessSA.Vista
{
    public partial class VistaFuncionario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (Request.Params["parametro"] != null)
            {
                EmailTransferido.Text = Request.Params["parametro"];
                EmailTransferido.Visible = false;
            }
            else
            {
                Response.Redirect("Login.aspx");         
            }

            obtenerusuario();

            ListarTareasAsignadas();
            ListarTareasAtrasadas();
            ListarTareasEnDesarrollo();
            ListarTareasTerminadas();
            ListarTareasTotal();

        }

        public void obtenerusuario()
        {
            Controlador.ControladorUsuario auxUsuario = new Controlador.ControladorUsuario();
            Modelo.Usuarios usuario = new Modelo.Usuarios();
            usuario = auxUsuario.getUsuario(EmailTransferido.Text);

            UsuarioEncontrado.Text = usuario.Nombre_Usuario1;
        }

        public void ListarTareasTotal()
        {

            string email = EmailTransferido.Text;
            Controlador.ControladorFuncionario AuxControladorFuncionario = new Controlador.ControladorFuncionario();              

            DataTable dt = new DataTable();
            dt = AuxControladorFuncionario.ListarTotalTareas(email);

            GridTotalTareas.DataSource = dt;
            GridTotalTareas.DataBind();

        }

        public void ListarTareasAsignadas()
        {

            string email = EmailTransferido.Text;
            Controlador.ControladorFuncionario AuxControladorFuncionario = new Controlador.ControladorFuncionario(); 

            DataTable dt = new DataTable();
            dt = AuxControladorFuncionario.ListarTareasAsignadas(email);

            GridTareaAsignadas.DataSource = dt;
            GridTareaAsignadas.DataBind();

        }
        public void ListarTareasEnDesarrollo()
        {

            string email = EmailTransferido.Text;
            Controlador.ControladorFuncionario AuxControladorFuncionario = new Controlador.ControladorFuncionario(); 

            DataTable dt = new DataTable();
            dt = AuxControladorFuncionario.ListarTareasEnDesarrollo(email);

            GridTareasEnDesarrollo.DataSource = dt;
            GridTareasEnDesarrollo.DataBind();

        }
        public void ListarTareasTerminadas()
        {

            string email = EmailTransferido.Text;
            Controlador.ControladorFuncionario AuxControladorFuncionario = new Controlador.ControladorFuncionario(); 

            DataTable dt = new DataTable();
            dt = AuxControladorFuncionario.ListarTareasTerminadas(email);

            GridTareasTerminadas.DataSource = dt;
            GridTareasTerminadas.DataBind();

        }
        public void ListarTareasAtrasadas()
        {

            string email = EmailTransferido.Text;
            Controlador.ControladorFuncionario AuxControladorFuncionario = new Controlador.ControladorFuncionario(); 

            DataTable dt = new DataTable();
            dt = AuxControladorFuncionario.ListarTareasAtrasadas(email);

            GridTareasAtrasadas.DataSource = dt;
            GridTareasAtrasadas.DataBind();

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
    }
}