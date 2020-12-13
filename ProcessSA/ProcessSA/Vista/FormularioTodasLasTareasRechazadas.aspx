﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormularioTodasLasTareasRechazadas.aspx.cs" Inherits="ProcessSA.Vista.FormularioTodasLasTareasRechazadas" %>

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
                                    <div class="ContenidoRechazo">   
                                        <br />
                                          <!--txt para Filtrar Todos Las Tareas Rechazadas-->
                                         <div class="form-group">
                                             <h1>Todas Las Tareas Rechazadas</h1>
                                             <asp:Label ID="Label2" runat="server" Text="Filtrar Tareas Rechazadas :"></asp:Label>
                                             <asp:Label ID="EmailTransferido" runat="server" Text="Label"></asp:Label>
                                             <br />
                                             <asp:TextBox ID="TXTBuscar"  Class="form-control col-lg-4" placeholder="Debe Ingresar El ID Del Motivo" runat="server"></asp:TextBox>
                                             <br />
                                             <asp:Label ID="AlertaID" runat="server" Text="Debe Ingresar Un ID Valido"></asp:Label>
                                             <asp:Label ID="AlertaIDNoExiste" runat="server" Text="El ID Ingresado No Existe, Intentelo Nuevamente"></asp:Label>
                                             <br />
                                             <asp:Button ID="BtnBuscar" class="btn btn-info btn-lg" runat="server" Text="Buscar" OnClick="BtnBuscar_Click" />

                                        </div>
                                                                                <!--GridView--> 
                                        <div class="row">
                                            <div class="container contenidoTabla">
                                                <div class="col-xs-12">
                                                    <div class="contenidoTabla">
                                                        <div class="table-responsive">                                        
                                                            <asp:GridView ID="GridRechazo" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Width="100%">
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
                                                                    <asp:BoundField ItemStyle-Width="15%" HeaderText="ID Motivo" DataField="ID_MOTIVO"/>
                                                                    <asp:BoundField ItemStyle-Width="15%" HeaderText="ID Tarea" DataField="ID_TAREA"/>
                                                                    <asp:BoundField ItemStyle-Width="15%" HeaderText="Fecha Rechazo" DataField="FECHA RECHAZO"/>
                                                                    <asp:BoundField ItemStyle-Width="55%" HeaderText="Motivo Rechazo" DataField="MOTIVO"/>
                                                                </Columns>

                                                            </asp:GridView>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                         <div class="col-md-offset-11">                                         
                                             <br />                                              
                                             <asp:Button ID="BtnVolver"  Class="btn btn-info btn-lg" runat="server" Text="Volver" OnClick="BtnVolver_Click" />
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
