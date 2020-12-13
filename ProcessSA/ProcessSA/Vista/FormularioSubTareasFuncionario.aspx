<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormularioSubTareasFuncionario.aspx.cs" Inherits="ProcessSA.Vista.FormularioSubTareasFuncionario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>

    
   
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
                                                            <asp:GridView ID="GridSubtarea" CssClass="table table-bordered table-hover table-responsive" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Width="100%" AllowSorting="True" HorizontalAlign="Center">
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
                    
    </form>

    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="../bootstrap-4.5.3-dist/js/bootstrap.min.js"></script>
    <script src="../js/script.js"></script>

</body>
</html>
