<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VistaFuncionario.aspx.cs" Inherits="ProcessSA.Vista.VistaFuncionario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title> Vista Funcionario</title>

    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <link rel="stylesheet" href="../bootstrap-4.5.3-dist/css/bootstrap.min.css">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css">
    <link href="../Css/styleDocument.css" rel="stylesheet" />

</head>
<body>

   <form id="form1" runat="server">
        
         <header>
    <!--Nuevo Menu horizontal-->
    <nav class="navbar navbar-expand-lg navbar-light bg-light">

  <a class="navbar-brand" href="#">Process S.A</a>

  <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
    <span class="navbar-toggler-icon"></span>
  </button>

  <div class="collapse navbar-collapse" id="navbarSupportedContent">
    <ul class="navbar-nav mr-auto">

      <li class="nav-item">
        <asp:LinkButton ID="BtnHome" runat="server"  class="nav-link" OnClick="BtnHome_Click">Home Funcionario</asp:LinkButton>
      </li>

      <li class="nav-item">
        <asp:LinkButton ID="BtnFlujo" runat="server"  class="nav-link" OnClick="BtnFlujo_Click" >Agregar Flujo De Tarea</asp:LinkButton>
      </li>

      <li class="nav-item">
        <asp:LinkButton ID="BtnTodasLasTareasRechazadas" runat="server"  class="nav-link" OnClick="BtnTodasLasTareasRechazadas_Click" >Tareas Rechazadas</asp:LinkButton>
      </li>
      <li class="nav-item">
          <asp:LinkButton ID="BtnTareasFuncionario" runat="server"  class="nav-link" OnClick="BtnTareasFuncionario_Click"  >Tus Tareas Asignadas</asp:LinkButton>
      </li>

        <li>
            <asp:LinkButton ID="BtnCerrarSesion" class="nav-link" runat="server" OnClick="BtnCerrarSesion_Click">Cerrar Sesion</asp:LinkButton>
        </li>

    </ul>

  </div>

</nav>
          
          </header>
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
                                                <asp:GridView ID="GridTotalTareas" class="table table-bordered table-hover" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" AllowSorting="True" HorizontalAlign="Justify">
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
                                                                                    
                                                <asp:GridView ID="GridTareaAsignadas" CssClass="table table-bordered table-hover" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Width="100%" AllowSorting="True" HorizontalAlign="Center">
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
                                                <asp:GridView ID="GridTareasEnDesarrollo" CssClass="table table-bordered table-hover" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Width="100%" AllowSorting="True" HorizontalAlign="Center">
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
                                                <asp:GridView ID="GridTareasTerminadas" CssClass="table table-bordered table-hover" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Width="100%" AllowSorting="True" HorizontalAlign="Center">
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
                                                <asp:GridView ID="GridTareasAtrasadas" CssClass="table table-bordered table-hover" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Width="100%" AllowSorting="True" HorizontalAlign="Center">
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
                            <!--Fin de todas las tareas Rechazadas-->

                             <div>
                                <asp:Label ID="Label6" runat="server" Text="Tareas Rechazadas :"></asp:Label>
                                <br />
                                <br />
                            </div>
                                                                   
                            <div class="row">
                                <div class="container contenidoTabla">
                                    <div class="col-xs-12">
                                        <div class="contenidoTabla">
                                            <div class="table-responsive">                                        
                                                <asp:GridView ID="GridTareasRechazadas" CssClass="table table-bordered table-hover" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Width="100%" AllowSorting="True" HorizontalAlign="Center">
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
                            <!--Fin de todas las tareas Rechazadas-->
                        </div>      
    </form>
      
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="../bootstrap-4.5.3-dist/js/bootstrap.min.js"></script>
    <script src="../js/script.js"></script>
</body>
</html>
