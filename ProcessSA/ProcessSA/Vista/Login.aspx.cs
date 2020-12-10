using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProcessSA.Vista
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Alerta.Visible = false;
            AlertaCorreoContraseña.Visible = false;
        }

        protected void BtnIniciarSesion_Click(object sender, EventArgs e)
        {
            Controlador.ControladorUsuario auxUsuario = new Controlador.ControladorUsuario();

            if (TXTContraseña.Text.Trim() == string.Empty && TXTEmail.Text.Trim() == string.Empty)
            {

                    AlertaCorreoContraseña.Visible = true;
            } 
            else
            {
                // verificar si el usuario existe o no 
                if (auxUsuario.verificarUsuario(TXTEmail.Text, TXTContraseña.Text))
                {

                       
                    Modelo.Usuarios usuario = new Modelo.Usuarios();
                    // se guardan los datos del usuario en la modelo, para compararlos con el rol 
                    usuario = auxUsuario.getUsuario(TXTEmail.Text);
                    AlertaCorreoContraseña.Visible = false;
                    Alerta.Visible = false;

                    // si el rol es 1 es administrador
                    if (usuario.ID_Rol1 == 1)
                    {
                        // esto cambiara cuando se cree la de administrador
                        Response.Redirect("AdminVista.aspx?parametro=" + TXTEmail.Text);
                    }
                    // si el rol es 2 es de funcionario 
                    else if (usuario.ID_Rol1 == 2)
                    {
                        Response.Redirect("VistaFuncionario.aspx?parametro=" + TXTEmail.Text);
                    }
                }
                else
                {
                    Alerta.Visible = true;
                } 

            }
        
        }
                
    }
}