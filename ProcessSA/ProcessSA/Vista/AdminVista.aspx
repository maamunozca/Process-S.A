<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminVista.aspx.cs" Inherits="ProcessSA.Vista.AdminVista" %>

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
        <asp:LinkButton ID="BtnHome" class="nav-link" runat="server"  OnClick="BtnHome_Click">Home Administrador</asp:LinkButton>
      </li>

      <li class="nav-item">
        <asp:LinkButton ID="BtnFlujo" class="nav-link" runat="server"  OnClick="BtnFlujo_Click" >Agregar Flujo De Tarea</asp:LinkButton>
      </li>

      <li class="nav-item">
        <asp:LinkButton ID="BtnTodasLasTareasRechazadas" class="nav-link" runat="server" OnClick="BtnTodasLasTareasRechazadas_Click" >Tareas Rechazadas</asp:LinkButton>
      </li>
      <li class="nav-item">
          <asp:LinkButton ID="BtnTareasFuncionario" class="nav-link" runat="server" OnClick="BtnTareasFuncionario_Click"  >Tus Tareas Asignadas</asp:LinkButton>
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
            <div class="row">
                <div class="col-md-12">
                    <div class="ContenidoVistaAdmnin">
                         <div class="col-xs-12">
                             <br />
                                <h1>Usuarios Registrados</h1>
                             <br />
                            </div>
                         <div class="row">
                                <div class="col-md-12" aria-orientation="horizontal">
                                    <div class="table-responsive">
                                    <asp:GridView ID="gvUsuarios" CssClass="table table-bordered table-hover" runat="server" AutoGenerateColumns="false" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" Width="100%" HorizontalAlign="Center">
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
                                <br />
                                <h1>Roles</h1>
                                <br />
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-12">
                                <div class="table-responsive">
                                <asp:GridView ID="gvRoles" CssClass="table table-bordered table-hover" runat="server" AutoGenerateColumns="false" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" Width="100%" HorizontalAlign="Center">
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
                </div>

            </div>
        </div>

             <div>
                <asp:Label ID="EmailTransferido" runat="server" Text="Label"></asp:Label>
            </div>
               
    </form>


    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="../bootstrap-4.5.3-dist/js/bootstrap.min.js"></script>
    <script src="../js/script.js"></script>


</body>
</html>
