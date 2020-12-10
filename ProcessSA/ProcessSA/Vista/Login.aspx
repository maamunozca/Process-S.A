<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ProcessSA.Vista.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>


    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link href="../Css/StyleLogin_Recuperar.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" integrity="sha384-JcKb8q3iqJ61gNV9KGb8thSsNjpSL0n8PARn9HuZOnIxN0hoP+VmmDGMN5t9UJ0Z" crossorigin="anonymous" />


    <title>Login</title>
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
       
          </ul>

        </div>
      </nav>
    </header>

<body>

   <!--CONTENIDO PRINCIPAL DE LA PAGINA-->

                <form runat="server" id="FormLogin">
                    <div id="fondoLogin">

                    
                    <div class="container">
                        <div class="row">
                            <div class="col-xs-12">

                                <div class="formularioLogin">
                                    <!--Login: email-->
                                    <div class="form-group">                                       
                                        <label for="exampleInputEmail1">Email</label>
                                        <asp:TextBox type="email" class="form-control" ID="TXTEmail" placeholder="Ejemplo@gmail.com" runat="server"></asp:TextBox>
                                    </div>

                                    <!--Login: password-->
                                    <div class="form-group">
                                        <label id="labelContrasena" for="exampleInputPassword1">Contraseña</label>
                                        <asp:TextBox type="password" class="form-control" ID ="TXTContraseña" placeholder="Contraseña" runat="server"></asp:TextBox>
                                    </div>

                                    <!--Login: boton enviar-->
                                    <asp:Label ID="Alerta" runat="server" Text="Email o Contraseña Incorrecta, Intentelo Nuevamente"></asp:Label>
                                    <asp:Label ID="AlertaCorreoContraseña" runat="server" Text="Debe Ingresar un correo o Contraseña Valido Para Poder Ingresar"></asp:Label>
                    
                                        <br />
                                        <br />
                                    <asp:Button type="submit" class="btn btn-primary" ID="BtnIniciarSesion" runat="server" Text="Iniciar Sesion" OnClick="BtnIniciarSesion_Click" />

                                    <br />
                                    <br />

                                    <asp:HyperLink ID="LinkRecuperar" NavigateUrl="~/Vista/RecuperarContrasena.aspx" runat="server"> ¿Olvidaste tu contraseña? </asp:HyperLink>



                                </div>

                            </div>

                        </div>

                    </div>
                </div>
                </form>


    
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.5.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-ho+j7jyWK8fNQe+A12Hb8AhRq26LrZ/JpcUGGOn+Y7RsweNrtN/tE3MoK7ZeZDyx" crossorigin="anonymous"></script>
    <script src="https://unpkg.com/@popperjs/core@2%22%3E</script"></script>
    <script src="https://kit.fontawesome.com/4837e56e08.js" crossorigin="anonymous"></script>



</body>
</html>
