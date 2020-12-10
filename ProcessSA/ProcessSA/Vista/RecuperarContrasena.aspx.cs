using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net;

namespace ProcessSA.Vista
{
    public partial class RecuperarContrasena : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // alerta cuando no se ingresa ningun texto 
            Alerta.Visible = false;
            // alerta cuando el correo ingresado no existe
            AlertaCorreo.Visible = false;
            // alerta cuando el correo ingresado si existe 
            AlertaExito.Visible = false;

           
        }

        protected void BtnRecuperarContraseña_Click(object sender, EventArgs e)
        {
            if (TXTEmail.Text.Trim() == string.Empty)
            {
                TXTEmail.BorderColor = System.Drawing.Color.Red;
                Alerta.Visible = true;

            }
            else
            {
                Controlador.ControladorUsuario AuxUsuario = new Controlador.ControladorUsuario();
                if (!AuxUsuario.ValidarEmail(TXTEmail.Text))
                {
                    Alerta.Visible = false;
                    TXTEmail.BorderColor = System.Drawing.Color.Red;
                    AlertaCorreo.Visible = true;
                }
                else
                {
                    Alerta.Visible = false;
                    AlertaCorreo.Visible = false;
                    AlertaExito.Visible = true;

                    TXTEmail.BorderColor = System.Drawing.Color.Green;
                    Modelo.Usuarios usuario = new Modelo.Usuarios();

                    usuario = AuxUsuario.getUsuario(TXTEmail.Text);
                    correoRecuperarContraseña(TXTEmail.Text, usuario.Clave_Usuario1);

                }
            }
        }

        private void correoRecuperarContraseña(string email, string password)
        {
            string body = "<body>" + "<h1> Solicitud de recuperación de contraseña</h1>" +
                 "<p>La contraseña correspondiente a esta cuenta Process S.A es la siguiente: " + password + " . Si necesitas contactarte con nosotros puedes hacerlo a través del siguiente email: empresa.process.sa@gmail.com</p>" +
                 "<p>Saludos cordiales </p>" +
                 "<p>Atte. Process S.A</p></body>";

            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress("empresa.process.sa@gmail.com", "Process S.A");
                mail.To.Add(email);
                mail.Subject = "Recuperación de contraseña";
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

    }       
}