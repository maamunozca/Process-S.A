<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VistaFuncionario.aspx.cs" Inherits="ProcessSA.Vista.VistaFuncionario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title> Vista Funcionario</title>

    <meta charset="utf-8"/>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous"/>
    <link rel="stylesheet" href="../Css/cssAdmin.css" />
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css" />

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
                </div>
           </div>

 <!--Contenido del lado derecho de la pantalla-->
                <div id="content">
                    <section>
                        <div class="container">
                            <div class="col-lg-12">
                                <h1>Bienvenido Funcionario :<asp:Label ID="UsuarioEncontrado" runat="server" Text="Label"></asp:Label></h1>
                                <asp:Label ID="EmailTransferido" runat="server" Text="Label"></asp:Label>
                                
                                    <br />
                            </div>
                            <!--Contenido de todas las tareas asignadas-->
                            <div>
                                
                                <asp:Label ID="Label1" runat="server" Text="Total De Tareas Asignadas :"></asp:Label>
                                <br />
                                <br />
                            </div>
                                                                   
                            <div class="row">
                                <div class="container contenidoTabla">
                                    <div class="col-xs-12">
                                        <div class="contenidoTabla">
                                            <div class="table-responsive">                                        
                                                <asp:GridView ID="GridTotalTareas" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Width="100%">
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
                                                        <asp:BoundField ItemStyle-Width="50%" HeaderText="Responsable" DataField="Responsable"/>
                                                        <asp:BoundField ItemStyle-Width="50%" HeaderText="Total De Tareas Asignadas" DataField="Total Tareas"/>
                                                    </Columns>

                                                </asp:GridView>
                                            </div>
                                        </div>
                                    </div>
                                </div>         
                            </div>
                            <!--Fin de todas las tareas asignadas-->
                                                        
                            <!--Contenido de solo Tareas asignadas-->
                            <div>
                                <asp:Label ID="Label2" runat="server" Text="Tareas Asignadas :"></asp:Label>
                                <br />
                                <br />
                            </div>
                                                                   
                            <div class="row">
                                <div class="container contenidoTabla">
                                    <div class="col-xs-12">
                                        <div class="contenidoTabla">
                                            <div class="table-responsive">                                        
                                                <asp:GridView ID="GridTareaAsignadas" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Width="100%">
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
                                                        <asp:BoundField ItemStyle-Width="33%" HeaderText="Responsable" DataField="Responsable"/>
                                                        <asp:BoundField ItemStyle-Width="33%" HeaderText="Estado Tarea" DataField="Estado"/>
                                                        <asp:BoundField ItemStyle-Width="33%" HeaderText="Total" DataField="Total Tareas"/>
                                                    </Columns>

                                                </asp:GridView>
                                            </div>
                                        </div>
                                    </div>
                                </div>         
                            </div>
                            <!--Fin de solo tareas asignadas-->

                                                        
                            <!--Contenido de solo tareas en desarrollo-->
                            <div>
                                <asp:Label ID="Label3" runat="server" Text="Tareas En Desarrollo :"></asp:Label>
                                <br />
                                <br />
                            </div>
                                                                   
                            <div class="row">
                                <div class="container contenidoTabla">
                                    <div class="col-xs-12">
                                        <div class="contenidoTabla">
                                            <div class="table-responsive">                                        
                                                <asp:GridView ID="GridTareasEnDesarrollo" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Width="100%">
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
                                                        <asp:BoundField ItemStyle-Width="33%" HeaderText="Responsable" DataField="Responsable"/>
                                                        <asp:BoundField ItemStyle-Width="33%" HeaderText="Estado Tarea" DataField="Estado"/>
                                                        <asp:BoundField ItemStyle-Width="33%" HeaderText="Total" DataField="Total Tareas"/>
                                                    </Columns>

                                                </asp:GridView>
                                            </div>
                                        </div>
                                    </div>
                                </div>         
                            </div>
                            <!--Fin de solo tareas en desarrollo-->
                                                       
                            <!--Contenido de solo tareas terminadas-->
                            <div>
                                <asp:Label ID="Label4" runat="server" Text="Tareas Terminadas :"></asp:Label>
                                <br />
                                <br />
                            </div>
                                                                   
                            <div class="row">
                                <div class="container contenidoTabla">
                                    <div class="col-xs-12">
                                        <div class="contenidoTabla">
                                            <div class="table-responsive">                                        
                                                <asp:GridView ID="GridTareasTerminadas" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Width="100%">
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
                                                        <asp:BoundField ItemStyle-Width="33%" HeaderText="Responsable" DataField="Responsable"/>
                                                        <asp:BoundField ItemStyle-Width="33%" HeaderText="Estado Tarea" DataField="Estado"/>
                                                        <asp:BoundField ItemStyle-Width="33%" HeaderText="Total" DataField="Total Tareas"/>
                                                    </Columns>

                                                </asp:GridView>
                                            </div>
                                        </div>
                                    </div>
                                </div>         
                            </div>
                            <!--Fin de solo tareas terminadas-->
                                                       
                            <!--Contenido de todas las tareas Atrasadas-->
                            <div>
                                <asp:Label ID="Label5" runat="server" Text="Tareas Atrasadas :"></asp:Label>
                                <br />
                                <br />
                            </div>
                                                                   
                            <div class="row">
                                <div class="container contenidoTabla">
                                    <div class="col-xs-12">
                                        <div class="contenidoTabla">
                                            <div class="table-responsive">                                        
                                                <asp:GridView ID="GridTareasAtrasadas" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Width="100%">
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
                                                        <asp:BoundField ItemStyle-Width="33%" HeaderText="Responsable" DataField="Responsable"/>
                                                        <asp:BoundField ItemStyle-Width="33%" HeaderText="Estado Tarea" DataField="Estado"/>
                                                        <asp:BoundField ItemStyle-Width="33%" HeaderText="Total" DataField="Total Tareas"/>
                                                    </Columns>

                                                </asp:GridView>
                                            </div>
                                        </div>
                                    </div>
                                </div>         
                            </div>
                            <!--Fin de todas las tareas atrasadas-->
                        </div>
                    </section>
                </div>
      
    </form>
      
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js" integrity="sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNIpG9mGCD8wGNIcPD7Txa" crossorigin="anonymous"></script>
    <script src="../js/script.js"></script>
</body>
</html>
