using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.DataAccess.Client;
using ProcessSA.Controlador;

namespace ProcessSA.Vista
{
    public partial class AdminVista : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["parametro"] != null && Controlador.Inseguridad.Variable.Length > 0)
            {
                EmailTransferido.Text = Request.Params["parametro"];
                EmailTransferido.Visible = false;
            }
            else
            {
                Response.Redirect("Login.aspx");
            }

            using (OracleConnection conn = new OracleConnection("DATA SOURCE = xe; PASSWORD = 123; USER ID = portafolio"))
            {
                conn.Open();
                OracleDataAdapter adaptador = new OracleDataAdapter("SELECT * FROM usuario", conn);
                DataTable dtbl = new DataTable();
                adaptador.Fill(dtbl);
                gvUsuarios.DataSource = dtbl;
                gvUsuarios.DataBind();

            }

            using (OracleConnection conn = new OracleConnection("DATA SOURCE = xe; PASSWORD = 123; USER ID = portafolio"))
            {
                conn.Open();
                OracleDataAdapter adaptador = new OracleDataAdapter("SELECT usuario.nombre_usuario, rol.nombre_rol, rol.id_rol FROM usuario INNER JOIN rol ON usuario.id_rol=rol.id_rol", conn);
                DataTable dt = new DataTable();
                adaptador.Fill(dt);
                gvRoles.DataSource = dt;
                gvRoles.DataBind();
            }

            Actualizar();

        }

        public void Actualizar()
        {
            OracleConnection conn = new OracleConnection("DATA SOURCE = xe; PASSWORD = 123; USER ID = portafolio");
            conn.Open();
            OracleCommand comando = new OracleCommand("ActualizarRegistroUsuario", conn);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add("RUN", OracleDbType.Int32);
            comando.Parameters.Add("NOMBRE_USUARIO", OracleDbType.Varchar2);
            comando.Parameters.Add("NUMERO_USUARIO", OracleDbType.Int32);
            comando.Parameters.Add("EMAIL_USUARIO", OracleDbType.Varchar2);
            comando.Parameters.Add("CLAVE_USUARIO", OracleDbType.Varchar2);
            comando.Parameters.Add("ID_ROL", OracleDbType.Int32);
            comando.ExecuteNonQuery();
            conn.Close();

        }
        /*
        OracleConnection conn = new OracleConnection("DATA SOURCE = xe; PASSWORD = 123; USER ID = portafolio");
        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            conn.Open();
            OracleCommand comando = new OracleCommand("ActualizarRegistroUsuario", conn);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add("RUN", OracleDbType.Int32);
            comando.Parameters.Add("NOMBRE_USUARIO", OracleDbType.Varchar2);
            comando.Parameters.Add("NUMERO_USUARIO", OracleDbType.Int32);
            comando.Parameters.Add("EMAIL_USUARIO", OracleDbType.Varchar2);
            comando.Parameters.Add("CLAVE_USUARIO", OracleDbType.Varchar2);
            comando.Parameters.Add("ID_ROL", OracleDbType.Int32);
            comando.ExecuteNonQuery();
            conn.Close();

        }
        */

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