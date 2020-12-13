using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.pdf;


namespace ProcessSA.Vista
{
    public partial class FormularioTareaFuncionarioAdministrador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AlertaID.Visible = false;
            AlertaIDNoExiste.Visible = false;
            AlertaSemaforo.Visible = false;

            if (Request.Params["parametro"] != null && Controlador.Inseguridad.Variable.Length > 0)
            {
                EmailTransferido.Text = Request.Params["parametro"];
                EmailTransferido.Visible = false;
            }
            else
            {
                Response.Redirect("Login.aspx");
            }


            ListarTarea();

        }


        public void ListarTarea()
        {


            Controlador.ControladorTareas AuxControladorTarea = new Controlador.ControladorTareas();

            DataTable dt = new DataTable();
            dt = AuxControladorTarea.ListarTareaAdministrador();

            GridTarea.DataSource = dt;
            GridTarea.DataBind();

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

        protected void BtnCerrarSesion_Click(object sender, EventArgs e)
        {
            Controlador.Inseguridad.Variable = "";

            Response.Redirect("Login.aspx");
        }



        protected void BtnSubTarea_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormularioSubTareaFuncionarioAdministrador.aspx?parametro=" + TXTBuscar.Text + "&parametro2=" + EmailTransferido.Text);
        }


        public DataTable dtFuncionario()
        {
            DataTable dt = new DataTable();

            Controlador.Conexion conexion = new Controlador.Conexion();
            OracleConnection conn = new OracleConnection();
            conn = conexion.getConn();

            conn.Open();
            OracleCommand comando = new OracleCommand("ListarTareasAdministrador", conn);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add("ListarTarea", OracleDbType.RefCursor).Direction = System.Data.ParameterDirection.Output;
            OracleDataAdapter adaptador = new OracleDataAdapter(comando);

            adaptador.Fill(dt);
            adaptador.Dispose();

            return dt;

        }


        protected void BtnPDF_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            Document document = new Document();
            PdfWriter writer = PdfWriter.GetInstance(document, HttpContext.Current.Response.OutputStream);
            dt = dtFuncionario();
            if (dt.Rows.Count > 0)
            {
                document.Open();
                Font fontTitle = FontFactory.GetFont(FontFactory.COURIER_BOLD, 25);
                Font font9 = FontFactory.GetFont(FontFactory.TIMES, 9);


                PdfPTable table = new PdfPTable(dt.Columns.Count);
                document.Add(new Paragraph(20, "Reporte de Funcionarios Process S.A 2020", fontTitle));
                document.Add(new Chunk("\n"));

                float[] widths = new float[dt.Columns.Count];
                for (int i = 0; i < dt.Columns.Count; i++)
                    widths[i] = 6f;

                table.SetWidths(widths);
                table.WidthPercentage = 90;

                PdfPCell cell = new PdfPCell(new Phrase("columns"));
                cell.Colspan = dt.Columns.Count;

                foreach (DataColumn c in dt.Columns)
                {
                    table.AddCell(new Phrase(c.ColumnName, font9));
                }

                foreach (DataRow r in dt.Rows)
                {
                    if (dt.Rows.Count > 0)
                    {
                        for (int h = 0; h < dt.Columns.Count; h++)
                        {
                            table.AddCell(new Phrase(r[h].ToString(), font9));
                        }
                    }
                }
                document.Add(table);
            }
            document.Close();

            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=FuncionariosProcess2020" + ".pdf");
            HttpContext.Current.Response.Write(document);
            Response.Flush();
            Response.End();

        }
    }
}