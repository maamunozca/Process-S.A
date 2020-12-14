<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormularioDepartamento.aspx.cs" Inherits="ProcessSA.Vista.FormularioDepartamento" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
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
        <asp:LinkButton ID="BtnHome" runat="server"  class="nav-link" OnClick="BtnHome_Click">Home Administrador</asp:LinkButton>
      </li>

      <li class="nav-item">
        <asp:LinkButton ID="BtnFlujo" runat="server"  class="nav-link" OnClick="BtnFlujo_Click" >Agregar Flujo De Tarea</asp:LinkButton>
      </li>

      <li class="nav-item">
        <asp:LinkButton ID="BtnTodasLasTareasRechazadas" runat="server"  class="nav-link" OnClick="BtnTodasLasTareasRechazadas_Click" >Tareas Rechazadas</asp:LinkButton>
      </li>
      <li class="nav-item">
          <asp:LinkButton ID="BtnTareasFuncionario" runat="server"  class="nav-link" OnClick="BtnTareasFuncionario_Click"  >Tareas Funcionarios</asp:LinkButton>
      </li>

        <li>
          <asp:LinkButton ID="BtnDepartamento" class="nav-link" runat="server" OnClick="BtnDepartamento_Click">Departamentos</asp:LinkButton>
      </li>

        <li>
            <asp:LinkButton ID="BtnCerrarSesion" class="nav-link" runat="server" OnClick="BtnCerrarSesion_Click">Cerrar Sesion</asp:LinkButton>
        </li>

    </ul>

  </div>
</nav>
          </header>


                <div class="container">
                    <br />
                    <h1>Crear Unidades Internas (Departamento)</h1>
                    <br />
                    <br />
                    <div class="form-inline my-2 my-lg-0">
                    <asp:TextBox ID="TxtBuscar" class="form-control mr-sm-2" runat="server"></asp:TextBox>
                    <asp:Button ID="btnBuscar" class="btn btn-outline-success my-2 my-sm-0" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
                    </div>
                    <br />
                    <br />

                    <asp:Label ID="Label1" runat="server" Text="id departamento"></asp:Label>
                    <br />
                    <asp:TextBox ID="TxtId" class="form-control" runat="server"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Label ID="Label2"  runat="server" Text="nombre departamento"></asp:Label>
                    <br />
                    <asp:TextBox ID="TxtNombreDepartamento" class="form-control" runat="server"></asp:TextBox>
                    <br />
                    <br />

                    <div class="table-responsive">
                    <asp:GridView ID="gview" runat="server" CssClass="table table-bordered table-hover" AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" Width="100%">
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
                    </div>

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
    </form>


  <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="../bootstrap-4.5.3-dist/js/bootstrap.min.js"></script>
    <script src="../js/script.js"></script>


</body>
</html>
