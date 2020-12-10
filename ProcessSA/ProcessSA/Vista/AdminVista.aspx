<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminVista.aspx.cs" Inherits="ProcessSA.Vista.AdminVista" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">

    <title></title>

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
                        
                        <asp:LinkButton ID="BtnDepartamento" runat="server" OnClick="BtnDepartamento_Click">Departamentos</asp:LinkButton>
                    </li>
                    <li>
                        <a href="Home.aspx">Cerrar Sesion</a>
                    </li>



                </ul>
            </nav>

            <!-- /#sidebar-wrapper -->
            <!-- Page Content -->
            <div id="page-content-wrapper">
                  

               
                 <!-- Boton del nav -->
                  <button type="button" class="btn btn-lg custom-btn" data-toggle="offcanvas">
                    <i class="fa fa-bars"></i>
                </button>
                 
                 <div class="container">

                        <div class="row">
                            <div class="col-xs-12">
                                <h1>Usuarios Registrados</h1>
                            </div>
                        </div>

                        <div class="row">
                                <div class="col-md-12" aria-orientation="horizontal">
                                    <div class="table-responsive">
                                    <asp:GridView ID="gvUsuarios" CssClass="table table-bordered table-hover table-responsive" runat="server" AutoGenerateColumns="false" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" Width="100%" HorizontalAlign="Center">
                                       <Columns>
                                            <asp:BoundField HeaderText="Rut" DataField="RUN"/>
                                            <asp:BoundField HeaderText="Nombre Usuario" DataField="NOMBRE_USUARIO"/>
                                            <asp:BoundField HeaderText="Numero" DataField="NUMERO_USUARIO"/>
                                            <asp:BoundField HeaderText="Email" DataField="EMAIL_USUARIO"/>
                                            <asp:BoundField HeaderText="clave" DataField="CLAVE_USUARIO"/>
                                            <asp:BoundField HeaderText="Rol" DataField="ID_ROL"/>
                                        </Columns>
                                        <HeaderStyle HorizontalAlign="Center" CssClass="table table-primary" />
                                    </asp:GridView>
                                    </div>

                                </div>
                         </div>

                        <div class="row">
                            <div class="col-xs-12">
                                <h1>Roles</h1>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-12">
                                <div class="table-responsive">
                                <asp:GridView ID="gvRoles" CssClass="table table-bordered table-hover table-responsive" runat="server" AutoGenerateColumns="false" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" Width="100%" HorizontalAlign="Center">
                                    <Columns>
                                    <asp:BoundField HeaderText="Nombre" DataField="NOMBRE_USUARIO"/>
                                    <asp:BoundField HeaderText="Rol" DataField="NOMBRE_ROL"/>
                                    <asp:BoundField HeaderText="Id rol" DataField="ID_ROL"/>
                                    </Columns>
                                    <HeaderStyle HorizontalAlign="Center" CssClass="table table-primary"/>
                                </asp:GridView>
                                </div>

                            </div>

                        </div>

                        <div class="row">
                            <div class="col-md-12">
                            </div>
                        </div>

                
            </div>

            <div>
                <asp:Label ID="EmailTransferido" runat="server" Text="Label"></asp:Label>
            </div>
            
            <!-- /#page-content-wrapper -->
        </div>
    </form>


    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js" integrity="sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNIpG9mGCD8wGNIcPD7Txa" crossorigin="anonymous"></script>
    <script src="../js/script.js"></script>


</body>
</html>
