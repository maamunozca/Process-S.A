<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormularioAgregarTarea.aspx.cs" Inherits="ProcessSA.Vista.FormularioAgregarTarea" %>

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

    
    <style type="text/css">
        .col-md-offset- {
            margin-bottom: 0px;
        }
    </style>

    
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
                 
             
<!--Contenido del lado derecho de la pantalla-->
                <!--Formulario para agregar la tarea-->

                <div id="content">
                   
                    <section>
                           
                        <div class="row">
                                
                            <div class="container">
                                  
                                <div class="col-xs-12">
                                       
                                    <div class="ContenidoAgregar">
                                            
                                        <br />
                                            <!--txt para ID de la tarea-->
                                           
                                        <div class="form-group">
                                                
                                            <h2>Agregar Tarea</h2>
                                            <asp:Label ID="IDTransferido" runat="server" Text="Label"></asp:Label>
                                            <asp:Label ID="EmailTransferido" runat="server" Text="Label"></asp:Label>
                                            
                                                                                   
                                        <br />
                                                                                       
                                           
                                      
                                           
                                        
                                            
                                        <asp:Button ID="BtnAgregarSubTarea" Class="btn btn-primary btn-lg" runat="server" Text="+ Agregar SubTarea" OnClick="BtnAgregarSubTarea_Click" />
                                        &nbsp &nbsp &nbsp
                                        &nbsp &nbsp &nbsp
                                        <br />
                                        <br />
                                        <asp:Label ID="Label3" runat="server" Text="Buscar :"></asp:Label>
                                        <br />
                                        <asp:TextBox ID="TXTBuscar" runat="server" Class="form-control col-lg-6" placeholder="Ingrese El Nombre De La Tarea O El ID ..."></asp:TextBox>
                                        <br />
                                        <asp:Label ID="Alerta2" runat="server" Text="Debe Ingresar un ID Valido"></asp:Label>
                                        <asp:Label ID="AlertaSemaforo" runat="server" Text="Aun Tiene Un Plazo Vigente"></asp:Label>
                                        <asp:Label ID="AlertaIDNOExistente" runat="server" Text="El ID Ingresado No Existe"></asp:Label>
                                        <asp:Label ID="aLERTANombreNoExistente" runat="server" Text="El Nombre De La Tarea Ingresada No Existe"></asp:Label>
                                        <asp:Label ID="AlertaActualizacion" runat="server" Text="Tarea Actualizada Exitosamente "></asp:Label>
                                        <asp:Label ID="AlertaEstado" runat="server" Text="Fechas Actualizadas , Se a enviado un correo al responsable por tarea Atrasada"></asp:Label>
                                            <asp:Label ID="FechaActuaizada" runat="server" Text="Fechas Actualizadas Exitosamente"></asp:Label>
                                        <br />
                                        <br />
                                        <asp:Button ID="BtnBuscar" Class="btn btn-primary btn-lg" runat="server" Text="Buscar Por Nombre" OnClick="BtnBuscar_Click" />&nbsp 
                                        <asp:Button ID="BtnBuscarID" CssClass="btn btn-primary btn-lg" runat="server" Text="Buscar Por ID" OnClick="BtnBuscarID_Click" />&nbsp 
                                        <asp:Button ID="BtnActualizarTarea" CssClass="btn btn-info btn-lg" runat="server" Text="Actualizar Tarea" OnClick="BtnActualizarTarea_Click" />&nbsp 
                                        <asp:Button ID="BtnActualizarFechas"  CssClass="btn btn-info btn-lg" runat="server" Text="Actualizar Fechas" OnClick="BtnActualizarFechas_Click" />&nbsp
                                        <asp:Button ID="BtnEliminarTarea" CssClass="btn btn-danger btn-lg" runat="server" Text="Eliminar Tarea " OnClick="BtnReportarProblema_Click" />&nbsp 
                                        <asp:Button ID="BtnPasarDatos" CssClass="btn btn-primary btn-lg" runat="server" Text="Cargar Datos" OnClick="BtnPasarDatos_Click" />
                                        <br />
                                        <br />

                                                                                                                        <!--GridView--> 
                                        <div class="row">
                                            <div class="container contenidoTabla">
                                                <div class="col-xs-12">
                                                    <div class="contenidoTabla">
                                                        <div class="table-responsive">                                        
                                                            <asp:GridView ID="GridTarea" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Width="100%">
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
                                                                    <asp:BoundField ItemStyle-Width="7%" HeaderText="ID TAREA" DataField="ID TAREA"/>
                                                                    <asp:BoundField ItemStyle-Width="12%" HeaderText="NOMBRE TAREA" DataField="NOMBRE TAREA"/>
                                                                    <asp:BoundField ItemStyle-Width="15%" HeaderText="DESCRIPCION TAREA" DataField="DESCRIPCION TAREA"/>
                                                                    <asp:BoundField ItemStyle-Width="10%" HeaderText="TIPO TAREA" DataField="TIPO TAREA"/>
                                                                    <asp:BoundField ItemStyle-Width="12%" HeaderText="RESPONSABLE" DataField="RESPONSABLE"/>
                                                                    <asp:BoundField ItemStyle-Width="8%" HeaderText="SEMAFORO" DataField="SEMAFORO"/>
                                                                    <asp:BoundField ItemStyle-Width="8%" HeaderText="DEPARTAMENTO" DataField="DEPARTAMENTO"/>
                                                                    <asp:BoundField ItemStyle-Width="10%" HeaderText="FECHA INICIO" DataField="FECHA INICIO"/>
                                                                    <asp:BoundField ItemStyle-Width="15%" HeaderText="FECHA TERMINO" DataField="FECHA TERMINO"/>
                                                                    <asp:BoundField ItemStyle-Width="6%" HeaderText="ESTADO" DataField="ESTADO TAREA"/>
                                                                    <asp:BoundField ItemStyle-Width="6%" HeaderText="PORCENTAJE" DataField="PORCENTAJE"/>

                                                                </Columns>

                                                            </asp:GridView>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                              
                                            <br />
                                               
                                            <label for="exampleInputEmail1">ID Tarea</label>
                                              
                                            <br />
                                               
                                            <asp:TextBox ID="TXTIDTarea" class="form-control" runat="server" Enabled="False"></asp:TextBox>
                                               
                                            <br />
                                            
                                        </div>
                                            <!--txt para "Nombre" de la tarea-->

                                            
                                        <div class="form-group">
                                              
                                            <label for="exampleInputEmail1">Nombre Tarea</label>
                                              
                                            <asp:TextBox ID="TXTNombreTarea" class="form-control col-lg-6" runat="server"></asp:TextBox>

                                               
                                            <br />
                                           
                                            </div>
                                           
                                        <!--txt para la "Descripcion" de la tarea-->

                                            
                                        <div class="form-group">
                                              
                                            <label for="exampleInputEmail1">Descripcion</label>
                                              
                                            <asp:TextBox ID="TXTDescTarea" class="form-control col-lg-6" runat="server"></asp:TextBox>
                                             
                                            
                                            <br />

                                           
                                            </div>
                                           
                                        <!--Tipo tarea-->
                                           
                                        <label for="exampleInputEmail1">Tipo Tarea</label>
                                           
                                        <div>
                                              
                                            <asp:DropDownList ID="DropTipoTarea" class="btn btn-info dropdown-toggle btn-lg" runat="server" AutoPostBack="false" BackColor="#3366FF" ForeColor="White">
                                                
                                                </asp:DropDownList>
    
                                            <br />
                                           
                                            </div>

                                           
                                        <!--Asignar un responsable a la tarea-->
                                          
                                        <div class="form-group">
                                           
                                            <label for="exampleInputEmail1">Responsable</label>
                                               
                                            
                                            <div>   
                                                 
                                                <asp:DropDownList ID="DropResponsable" class="btn btn-info dropdown-toggle btn-lg" runat="server" AutoPostBack="false" BackColor="#3366FF" ForeColor="White"></asp:DropDownList>

                                                </div>
                                            
                                        </div>


                                            
                                        <!--Departamento de la tarea--> 

                                         
                                        <div>   
                                                
                                            <label for="exampleInputEmail1">Departamento Responsable </label>  
                                                
                                            <div>   
                                                  
                                                <asp:DropDownList ID="DropDepartamento" class="btn btn-info dropdown-toggle btn-lg"  runat="server" AutoPostBack="false" BackColor="#3366FF" ForeColor="White"></asp:DropDownList>
                                                   

                                               
                                                </div>
                                           
                                            </div>
                                                                                       
                                            
                                            
                                        <!--Fecha de inicio de la tarea-->
                                           
                                        <div class="row">
                                                       
                                            <div class="col-xs-12 col-md-6">
                                                           
                                                <asp:Label ID="Label1" runat="server" Text="Fecha Inicio"></asp:Label>
                                           
                                                           
                                                <asp:TextBox ID="TXTFechaInicio" runat="server" class="form-control" textmode="Date"></asp:TextBox>
                                                        
                                                           
                                                        
                                            </div>
                                           
                                                
                                            <!--Fecha de termino tarea-->
                                                       
                                            <div class="col-xs-12 col-md-6">
                                                           
                                                <asp:Label ID="Label2" runat="server" Text="Fecha Termino"></asp:Label>
                                           
                                                            
                                                <asp:TextBox ID="TXTFechaTermino" runat="server" class="form-control" textmode="Date"></asp:TextBox>
                                                           
                                                       
                                                </div>
                                            
                                            <br />
                                             <!--Alerta En Caso de que los campos No Esten Llenos-->      
                                       
                                             <asp:Label ID="Alerta" runat="server" Text="Debe Llenar Los Campos Faltantes "></asp:Label>                
                                             <!--Alerta En Caso De Que los Campos Si Esten Llenados-->   
                                              <asp:Label ID="AlertaExito" runat="server" Text="Tarea Agregada Exitosamente"></asp:Label>  
                                            <br />
                                            <br />
                                              <!--btn para guardar la tarea-->   
                                            <asp:Button ID="BtnAgregarTarea" class="btn btn-primary btn-lg" runat="server" Text="Agregar Tarea " OnClick="BtnAgregarTarea_Click" />
                                             

                                            <div class="col-md-offset-11">
                                                <br />
                                                <asp:Button ID="BtnVolver"  Class="btn btn-info btn-lg" runat="server" Text="Volver" OnClick="BtnVolver_Click" />
                                            </div>
                                        </div>
  

                                    </div>
                                 
                                </div>

                            </div>
                           
                </section>

                        </div>
                </div>
           </div>
    </form>
    
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js" integrity="sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNIpG9mGCD8wGNIcPD7Txa" crossorigin="anonymous"></script>
    <script src="../js/script.js"></script>
</body>
</html>
