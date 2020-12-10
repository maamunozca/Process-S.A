<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="ProcessSA.Vista.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>

    <title> home </title>
   
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link href="../Css/StyleHome.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" integrity="sha384-JcKb8q3iqJ61gNV9KGb8thSsNjpSL0n8PARn9HuZOnIxN0hoP+VmmDGMN5t9UJ0Z" crossorigin="anonymous">




</head>
    <header>

<!--MENU DE LA PAGINA-->
    <nav class="navbar navbar-expand-lg navbar-light bg-light">

        <nav class="navbar navbar-light bg-light">
            <a class="navbar-brand" href="Home.aspx">
              <img src="../Media/Logotipo.png" width="80" height="40" alt="">
            </a>
        </nav>

        <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNavDropdown" aria-controls="navbarNavDropdown" aria-expanded="false" aria-label="Toggle navigation">
          <span class="navbar-toggler-icon"></span>
        </button>

        <div class="collapse navbar-collapse" id="navbarNavDropdown">
          <ul class="navbar-nav">

            <li class="nav-item active">
              <a class="nav-link" href="Home.aspx"><i class="fas fa-home"></i> Inicio<span class="sr-only"></span></a>
            </li>

            <li class="nav-item dropdown">

                <a class="nav-link dropdown-toggle" href="#" id="navbarDropdown" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                  Caracteristicas
                </a>

                <div class="dropdown-menu" aria-labelledby="navbarDropdown">
                  <a class="dropdown-item" href="#caracteristicasAplicacion">Caracteristicas Basicas</a>
                  <a class="dropdown-item" href="#GestionTareas">Gestion facil de tareas</a>
                </div>
              </li>
        

            <li>
                    
                <asp:HyperLink  class="btn btn-outline-primary" NavigateUrl="~/Vista/Login.aspx" runat="server"><i class="fas fa-sign-in-alt"></i> Iniciar Sesion</asp:HyperLink>  
                
            </li>
          </ul>
        </div>
      </nav>

</header>

<body>
<!--CONTENIDO PRINCIPAL DE LA PAGINA-->
    <div id="fondo">
        <div class="container contenedor1">
            <div class="row">
    
                <div class="col-xs-12 col-md-8">   
                    <div class="columna1">
                        <br>
                        <h1>Aplicacion para organizar tareas</h1>
                        <br>
                        <p>
                            Si está cansado de tomar notas en papel y necesita organizar mejor las actividades diarias de su empresa, 
                            aquí está Bitrix24 – la mejor aplicación para organizar tareas y proyectos. Visualización en Lista, Kanban, 
                            diagrama de Gantt, planificador personal, gestión de tareas desde la aplicación móvil y mucho más. 
                            Es gratuita y está disponible para número ilimitado de usuarios.
                            <br>
                            <br>
                        </p>
                    </div>
                </div>
        
                <div class="col-xs-12 col-md-4">
                    <div class="columna2">
                        <img src="../Media/notafondoverde.png" class="img-fluid" alt="Responsive image">
                    </div>
                </div>
        
            </div>
        </div>
    </div>

    <div id="colorFondo">
        <div class="container contenedor2">
            <div class="row">
                <div class="col-xs-12 col-md-12">
                    <div class="contenido">
                        <br>
                        <h1>Aplicacion para organizar tus tareas</h1>
                        <br>
                        <p>
                            Seguro que usted también ha tenido dificultades a la hora de organizarse y recordar todas las tareas que tiene que hacer al día: hora de reuniones, fechas de entrega o de compra en la oficina, eventos importantes, etc.
                            Por suerte, podrá hacer un seguimiento de todo lo que tiene que hacer cada día desde un aparato que le sonará muy familiar: su smartphone. Sea Android o iOS, podrá descragra la aplicación para ogranizar tareas personales y tareas en equipo.
        
                            Bitrix24 está a su servicio. Una de las mejores aplicaciones para organizar tareas, consta de diferentes visualizaciones: lista, Kanban, diagrama de Gantt y planificador personal. Además en Bitrix24 tedrá claro los plazos de cada tareas, y con los nuevos contadores no se le perderán las tareas que requieren su atención inmediata.
                            La mayoría de las funcionalidades para organizar tareas están dentro de la versión gratuita de Bitrix24 y están disponibles para el uso de número ilimitado de usuarios. Las puede usar tanto en la versión en su navegador, como en la aplicación móvil disponible Android e iOS.
                            El software Bitrix24 se ofrece en 2 versiones:
                            Versión CLOUD: sus datos serán guardados en servidores correspondientes al país dónde está localizado. Los usuarios pueden usar Bitrix24 estén donde estén. Sus datos, información y contraseñas serán protegidas. En caso de una mudanza, también podemos mudarlo de servidor.
                            Versión ON-PREMISE: se instala en su propio servidor. Con Bitrix24 en Premisa obtendrá el código fuente abierto, y podrá integrar Bitrix24 con otros servicios utilizando la documentación de la API, adaptando así, todo según sus necesidades.
                        </p>
                        <br>
                    </div>
                </div>
            </div>
    
            <div class="row">
    
                <div class="col-xs-12 col-md-6">
                    <div id="caracteristicasAplicacion">
                        <h2>Caracteristicas de la aplicacion</h2>
                        <p>
                            <ul>
                                  <li>Gestion de tareas</li>
                                  <li>Tareas importantes</li>
                                  <li>Recordatorios</li>
                                  <li>Configuracion de permisos</li>
                            </ul> 
                        </p>
                        <br>
                    </div>
        
                </div>
        
                <div class="col-xs-12 col-md-6">
                        <div class="img">
                            <img src="../Media/Mockups pantanlla principal.png" class="img-fluid" alt="Responsive image">
                            
                        </div>
                        <br>
                        <br>
                </div>
        
            </div>
    
            <div class="row">
                <div class="col-xs-12 col-md-6">
                    <div class="img">
                        <img src="../Media/Mockups pantanlla principal.png" class="img-fluid" alt="Responsive image">
                    </div>
                </div>
    
                <div class="col-xs-12 col-md-6">
                    <div id="GestionTareas">
                        <h2>Gestion facil de tareas</h2>
                        <p>
                            <ul>
                                <li>Plazos claros de tareas</li>
                                <li>Planificacion personal</li>
                                <li>Seguimiento con fechas de tareas</li>
                                <li>Informes de tareas</li>
                            </ul>
                        </p>
                    </div>
                </div>
            </div>
    
        </div>

    </div>


    
    <!--scripts-->
<script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
<script src="https://cdn.jsdelivr.net/npm/bootstrap@4.5.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-ho+j7jyWK8fNQe+A12Hb8AhRq26LrZ/JpcUGGOn+Y7RsweNrtN/tE3MoK7ZeZDyx" crossorigin="anonymous"></script>
<script src="https://unpkg.com/@popperjs/core@2"></script>
<script src="https://kit.fontawesome.com/4837e56e08.js" crossorigin="anonymous"></script>


</body>

       <footer> 
        
        <div class="container">
            <div class="row">
                <div class="col-xs-12">
                    <div class="contenidoFooter">
                        <h3>@Process S.A 2020</h3>
                    </div>
                </div>
            </div>
        </div>

    </footer>

</html>
