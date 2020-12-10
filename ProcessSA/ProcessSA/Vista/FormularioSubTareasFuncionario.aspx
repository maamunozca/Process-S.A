<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormularioSubTareasFuncionario.aspx.cs" Inherits="ProcessSA.Vista.FormularioSubTareasFuncionario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
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
                        
                        <asp:LinkButton ID="BtnHome" runat="server"  OnClick="BtnHome_Click">Home Funcionario</asp:LinkButton>
                        
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

                 <!-- Boton del nav -->
                  <button type="button" class="btn btn-lg custom-btn" data-toggle="offcanvas">
                    <i class="fa fa-bars"></i>
                </button>

                <div id="content">
                    <section>
                        <div class="row">
                            <div class="container">
                                <div class="col-xs-12">
                                    <div class="ContenidoAgregar">
                                        <br />
                                        <!--txt para Nombre SubTarea-->
                                         <div class="form-group">
                                             <h1>SubTareas Funcionario</h1>
                                           
                                        </div>
                                         <div class="form-group">
                                            <br />
                                            <asp:Label ID="Label1" runat="server" Text="Buscar :"></asp:Label>
                                            <br />
                                            <asp:TextBox ID="TXTBuscar" Class="form-control col-lg-4" placeholder="Ingrese Un ID Valido" runat="server"></asp:TextBox>
                                            <br />
                                             
                                             <asp:Label ID="IDTRANSFERIDO" runat="server" Text="Label"></asp:Label>
                                             <asp:Label ID="EmailTransferido" runat="server" Text="Label"></asp:Label>
                                                                                                                     </asp:Label>
                                            <asp:Label ID="AlertaID" runat="server" Text="Debe Ingresar Un ID Valido"></asp:Label>
                                            <asp:Label ID="AlertaIDNoExiste" runat="server" Text="El ID Ingresado No Existe, Intentelo Nuevamente"></asp:Label>
                                            <br />
                                        <asp:Button ID="BtnBuscar" CssClass="btn btn-info btn-lg" runat="server" Text="Buscar SubTarea" OnClick="BtnBuscar_Click" />&nbsp &nbsp
                                             </div>
                                                                                 
                                        <!--GridView--> 
                                        <div class="row">
                                            <div class="container contenidoTabla">
                                                <div class="col-xs-12">
                                                    <div class="contenidoTabla">
                                                        <br />
                                                        <br />
                                                        <div class="table-responsive">                                        
                                                            <asp:GridView ID="GridSubtarea" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Width="100%">
                                                                <FooterStyle BackColor="White" ForeColor="#000066" />
                                                                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                                                                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                                                <RowStyle ForeColor="#000066" />
                                                                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                                                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                                                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                                                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                                                <SortedDescendingHeaderStyle BackColor="#00547E" />

                                                                <Columns>
                                                                    <asp:BoundField ItemStyle-Width="13%" HeaderText="ID SubTarea" DataField="ID SUBTAREA"/>
                                                                    <asp:BoundField ItemStyle-Width="13%" HeaderText="Nombre SubTarea" DataField="NOMBRE SUBTAREA"/>
                                                                    <asp:BoundField ItemStyle-Width="13%" HeaderText="ID Tarea" DataField="ID TAREA"/>
                                                                    <asp:BoundField ItemStyle-Width="13%" HeaderText="Nombre Tarea" DataField="NOMBRE TAREA"/>
                                                                    <asp:BoundField ItemStyle-Width="13%" HeaderText="Responsable" DataField="RESPONSABLE"/>                                                                
                                                                    <asp:BoundField ItemStyle-Width="15%" HeaderText="Estado Subtarea " DataField="ESTADO SUBTAREA"/>
                                                                    <asp:BoundField ItemStyle-Width="15%" HeaderText="Porcentaje Subtarea " DataField="PORCENTAJE SUBTAREA"/>
                                                                </Columns>

                                                            </asp:GridView>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                       
                                        <div >
                                            <br />  
                                            <asp:Button ID="BtnComenzar" Class="btn btn-info btn-lg" runat="server" Text="Comenzar SubTarea" OnClick="BtnComenzar_Click" />&nbsp &nbsp
                                            <asp:Button ID="BtnTerminar" Class="btn btn-success  btn-lg" runat="server"  Text="Terminar SubTarea" OnClick="BtnTerminar_Click" />&nbsp &nbsp
                                            <asp:Button ID="BtnRechazar" Class="btn btn-danger btn-lg" runat="server" Text="Rechazar SubTarea" OnClick="BtnRechazar_Click" />
                                            
                                            </div>
                                        <br />
                                        <br />
                                        <div>
                                            <asp:Button ID="BtnVolver" runat="server" CssClass="btn btn-info btn-lg" Text="Volver" OnClick="BtnVolver_Click" />
                                        </div>

                                    </div>
                                </div>
                            </div>
                        </div>
                    </section>
                </div>    
            </div>
                <!--Termino Primer Div-->
        </div>
    </form>

    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js" integrity="sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNIpG9mGCD8wGNIcPD7Txa" crossorigin="anonymous"></script>
    <script src="../js/script.js"></script>

</body>
</html>
