<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VistaGestionTareasAdministrador.aspx.cs" Inherits="ProcessSA.Vista.VistaGestionTareasAdministrador" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    
     <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <link rel="stylesheet" href="../bootstrap-4.5.3-dist/css/bootstrap.min.css">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css">

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
        <asp:LinkButton ID="BtnHome" runat="server"  class="nav-link" OnClick="BtnHome_Click">Home Administrador</asp:LinkButton>
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
          <asp:LinkButton ID="BtnDepartamento" class="nav-link" runat="server" OnClick="BtnDepartamento_Click">Departamentos</asp:LinkButton>
      </li>

        <li>
            <a href="Home.aspx"  class="nav-link" >Cerrar Sesion</a>
        </li>

    </ul>

  </div>

</nav>
          
          </header>                            
            <div class="row">
                               
                <div class="container">
                                    
                    <div class="col-xs-12">
                                        
                        <div class="ContenidoAgregar">
                                               
                            <div class="form-row">
                                                    
                                <div class="col">
                                                      
                                        <h1>Crear Flujo De Tarea</h1>
                                        <!--BOTON CREAR TAREA, DONDE LUEGO SE MOSTRARA LA PANTALLA CON LOS DATOS PARA LLENAR EL FORMULARIO DE LA TAREA-->
                                        <asp:Label ID="IDPiola" runat="server" Text="Label"></asp:Label>
                                        <asp:Label ID="EmailTransferido" runat="server" Text="Label"></asp:Label>
                                        <asp:TextBox ID="TXTNombreFlujo" runat="server" class="form-control" placeholder="Ingrese El Nombre Del Flujo De Tarea"></asp:TextBox>
                                    </div>
                                                    
                                    <div class="col">
                                        <br />
                                        <br />
                                        <asp:Button ID="Button1" runat="server" Text=" + Crear Nuevo Flujo De Tareas" class="btn btn-primary btn-lg" OnClick="Button1_Click"/> 
                                        <asp:Label ID="Alerta" runat="server" Text="Debe Ingresar Un Nombre Valido"></asp:Label>
                                        <asp:Label ID="AlertaExito" runat="server" Text="Flujo Creado Exitosamente "></asp:Label>
                                                        
                                    </div>
                                </div>
                            </div>
                        </div>              
                    </div>
                </div>

 <!--Barra de busqueda--> 
                        <div class="row">
                                <div class="container">
                                    <div class="col-xs-12">
                                        <div class="ContenidoAgregar">
                                                <div class="form-row">
                                                    <div class="col">
                                                        <br />
                                                        <br />
                                                        <asp:TextBox ID="TXTBuscar" runat="server" class="form-control" placeholder="Buscar..."></asp:TextBox>
                                                        <asp:Label ID="lblError" runat="server" Text="El ID Ingresado No Existe "></asp:Label>
                                                        <asp:Label ID="lblExito" runat="server" Text="El Id ingresado Fue Eliminado Exitosamente"></asp:Label>
                                                        <asp:Label ID="lblvacio" runat="server" Text="Debe Ingresar Un ID"></asp:Label>
                                                    </div>
                                                    
                                                    <div class="col">
                                                        <br />
                                                        <br />
                                                                <!--BOTON Buscar-->
                                                        <asp:Button ID="BtnBuscar" runat="server" Text="Buscar" class="btn btn-primary btn-lg" OnClick="BtnBuscar_Click"/> &nbsp &nbsp &nbsp
                                                                <!--BOTON Agregar-->
                                                        <!--<asp:Button ID="BtnAgregar" runat="server" Text="Agregar Tarea" class="btn btn-success" OnClick="BtnAgregar_Click" />&nbsp &nbsp &nbsp -->
                                                        <asp:Button ID="BtnAgregarTarea" class="btn btn-success btn-lg" runat="server" Text="Agregar Tarea" OnClick="BtnAgregarTarea_Click" />&nbsp &nbsp &nbsp
                                                                <!--BOTON ELIMINAR-->
                                                        <asp:Button ID="BtnEliminar" runat="server" Text="Eliminar Tarea"  class="btn btn-danger btn-lg" OnClick="BtnEliminar_Click"/>
                                                    </div>
                                                </div>
                                        </div>
                                    </div>
                                 
                                </div>

                            </div>
 <!--tabla-->                       
                        <div class="row">
                            <div class="container contenidoTabla">
                                <div class="col-xs-12">
                                    <div class="contenidoTabla">
                                    <br />
                                    <br />
                                    <div class="table-responsive">

                                        <asp:GridView ID="GridFlujoTarea" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridFlujoTarea_SelectedIndexChanged" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                                            <Columns  >
                                                <asp:BoundField DataField="ID_Flujo_Tarea" HeaderText="ID Flujo" ItemStyle-Height="50" ItemStyle-Width="125" >
                                                    <ItemStyle Height="50px" Width="125px"></ItemStyle>
                                                    </asp:BoundField> 
                                                <asp:BoundField DataField="Nombre_Flujo_Tarea" HeaderText="Nombre Flujo Tarea" ItemStyle-Height="50" ItemStyle-Width="200">
                                                    <ItemStyle Height="50px" Width="200px" />
                                                </asp:BoundField> 
                                                 <asp:BoundField DataField="Porcentaje_Flujo" HeaderText="Porcentaje Realizado" ItemStyle-Height="50" ItemStyle-Width="200">
                                                    <ItemStyle Height="50px" Width="200px" />
                                                </asp:BoundField> 
                                                </Columns>        
                                            <FooterStyle BackColor="White" ForeColor="#000066" />
                                            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                            <RowStyle ForeColor="#000066" />
                                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                            <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                            <SortedDescendingHeaderStyle BackColor="#00547E" />
                                        </asp:GridView>
                                       
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
