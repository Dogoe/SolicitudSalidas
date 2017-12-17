<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PracticaCapas.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Solicitud de Salida</title>
    <meta name= "viewport" content="width=device-width, user-scalable=no, initial-scale=1.0"/>
    <link rel="stylesheet" href="../CSS/bootstrap.min.css"/>
    <link rel="stylesheet" href="../VistasUsuario/css/estilos.css"/>
</head>
<body>
    <header>
    <div class="text-center">
        <!--Banner de la UABC-->
        <div class="row">
            <div class="hidden-xs hidden-sm col-md-2 col-lg-2">
                <img src="../Imagenes/logouabc.png" height="110"/>
            </div>
            <div class="col-sm-8 col-md-8 col-lg-8">
                <h1 class="uabc">Universidad Autónoma de Baja California</h1>
                <h3 class="facultad">Facultad de Ingeniería, Arquitectura y Diseño</h3>
            </div>
            <div class="hidden-xs hidden-sm col-md-2 col-lg-2">
                <img src="../Imagenes/logofiad.png" height="110" class="logo"/>
            </div>
        </div>				
        <hr />
    </div>
    </header>
    <div class="container">
    
    <h2 class="text-center">Bienvenido al Sistema de Solicitudes de Salida</h2>
    <div>
        <!--Formulario para iniciar sesión-->
        <div class="container">
            <div class="row">
                <div class="col-md-4 col-md-offset-4">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h3 class="panel-title">Iniciar sesi&oacute;n:</h3>
                        </div>
                        <div class="panel-body">
                            
                            <form  id="formLogin" runat="server">
                                <div ></div>
                                <div class="form-group">
                                    <label>Correo:</label>
                                    <asp:TextBox ID= "EmailLogin" runat="server" class="form-control" placeholder="Correo" required="tre"></asp:TextBox>    
                                </div>
                                <div class="form-group">
                                    <label>Contraseña:</label>
                                    <asp:TextBox ID= "PassUser" runat="server" class="form-control" placeholder="Contraseña" type="password" required="true"></asp:TextBox>
                                </div>
                                <asp:Button ID="btnTryLogin" runat="server" class="btn btn-success btn-block" type="submit" text="Ingresar" OnClick="btnTryLogin_click"/>
                                
                                
                                <div id="divMsjErrorLogin" runat="server" class="alert alert-danger text-center form-group" hidden="hidden">
                                    <asp:Label ID="msj" runat="server"></asp:Label>
                                </div>
                                
                               
                            </form>
                        </div>
                    </div>
                </div>
            </div>
          
        </div>
    </div>
    
    
    
 
    </div>
    <script src="../Javascrip/jquery-3.2.1.min.js"></script>    
    <script src="../Javascrip/bootstrap.min.js"></script> 
    <footer>
        <div class="container">
            <div class="row">
                <div class="text-center col-xs-12">
                    <p>Universidad Autónoma de Baja California</p>
                    <p>Diseñado por ©JD.</p>
                </div>
            </div>
        </div>
    </footer>
</body>
</html>
