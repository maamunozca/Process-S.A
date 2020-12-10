<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormularioDepartamento.aspx.cs" Inherits="ProcessSA.Vista.FormularioDepartamento" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
    <title></title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous">
    <link rel="stylesheet" href="../Css/cssAdmin.css">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css">

</head>
<body>
    <form id="form1" runat="server">
        <div id="wrapper">
            <div class="overlay"></div>
            
            <!-- Sidebar -->
            <nav class="navbar navbar-inverse navbar-fixed-top" id="sidebar-wrapper" role="navigation">
                <ul class="nav sidebar-nav">
                    <li class="sidebar-brand">
                        <a href="#">
                            Process SA
                        </a>
                    </li>

                   <li>
                        <asp:LinkButton ID="BtnHome" runat="server"  OnClick="BtnHome_Click">Home Administrador</asp:LinkButton>
                        </li>
                    <li>
                        
                        <asp:LinkButton ID="BtnFlujo" runat="server"  OnClick="BtnFlujo_Click" >Agregar Flujo De Tarea</asp:LinkButton>
                    </li>

                    <li>
                        
                        <asp:LinkButton ID="BtnTodasLasTareasRechazadas" runat="server" OnClick="BtnTodasLasTareasRechazadas_Click" >Tareas Rechazadas</asp:LinkButton>
                    </li>

                    <li>
                        
                        <asp:LinkButton ID="BtnTareasFuncionario" runat="server" OnClick="BtnTareasFuncionario_Click"  >Tus Tareas Asignadas</asp:LinkButton>
                    </li>

                    <li>
                        <a href="Home.aspx">Cerrar Sesion</a>
                    </li>

                </ul>
            </nav>
            <!-- /#sidebar-wrapper -->
            <!-- Page Content -->
            <div id="page-content-wrapper">
                <!--<button type="button" class="hamburger is-closed" data-toggle="offcanvas">
        <span class="hamb-top"></span>
        <span class="hamb-middle"></span>
        <span class="hamb-bottom"></span>
    </button> -->

                <button type="button" class="btn btn-lg custom-btn" data-toggle="offcanvas">
                    <i class="fa fa-bars"></i>
                </button>


                <div class="container">

                    <h1>Crear Unidades Internas (Departamento)</h1>
                    <div class="form-inline my-2 my-lg-0">
                    <asp:TextBox ID="TxtBuscar" class="form-control mr-sm-2" runat="server"></asp:TextBox>
                    <asp:Button ID="btnBuscar" class="btn btn-outline-success my-2 my-sm-0" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
                    </div>


                    <asp:Label ID="Label1" runat="server" Text="id departamento"></asp:Label>
                    <asp:TextBox ID="TxtId" class="form-control" runat="server"></asp:TextBox>

                    <asp:Label ID="Label2"  runat="server" Text="nombre departamento"></asp:Label>
                    <asp:TextBox ID="TxtNombreDepartamento" class="form-control" runat="server"></asp:TextBox>
                    <br />
                    <br />


                    <asp:GridView ID="gview" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" Width="100%">
                        <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                        <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                        <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                        <RowStyle BackColor="White" ForeColor="#003399" />
                        <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                        <SortedAscendingCellStyle BackColor="#EDF6F6" />
                        <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                        <SortedDescendingCellStyle BackColor="#D6DFDF" />
                        <SortedDescendingHeaderStyle BackColor="#002876" />

                        <Columns>
                            <asp:BoundField HeaderText="Id" DataField="ID_DEPARTAMENTO"/>
                            <asp:BoundField HeaderText="Nombre" DataField="NOMBRE_DEPARTAMENTO"/>
                        </Columns>

                    </asp:GridView>
                    <br />
                    <br />

                    <!--BOTONES-->
                    <asp:Button ID="btnGuardar" runat="server" class="btn btn-primary" Text="Guardar" OnClick="btnGuardar_Click" />


                    <asp:Button ID="btnEliminar" runat="server" class="btn btn-danger" Text="Eliminar" OnClick="btnEliminar_Click" />

                    <asp:Button ID="btnModificar" runat="server" class="btn btn-success" Text="Modificar" OnClick="btnModificar_Click" />



                    <!--Alertas-->
                    <asp:Label ID="lbMensajeError" runat="server"></asp:Label>
                    <asp:Label ID="lbMensajeExito" runat="server"></asp:Label>
                    <asp:Label ID="EmailTransferido" runat="server" Text="Label"></asp:Label>
                </div>




            </div>
            <!-- /#page-content-wrapper -->
        </div>
    </form>


    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js" integrity="sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNIpG9mGCD8wGNIcPD7Txa" crossorigin="anonymous"></script>
    <script src="../js/script.js"></script>

</body>
</html>
