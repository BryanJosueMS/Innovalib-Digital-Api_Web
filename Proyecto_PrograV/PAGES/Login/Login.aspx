<%@ Page Title="Login" Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Proyecto_PrograV.PAGES.Login.Login" %>

<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Iniciar Sesión - Innovalib Digital</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css">
    <style>
        body {
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
            background-color: #f8f9fa;
        }

        .login-card {
            background: #ffffff;
            padding: 3rem;
            border-radius: 15px;
            box-shadow: 0px 4px 15px rgba(0, 0, 0, 0.2);
            text-align: center;
            width: 450px;
        }

        .login-icon {
            width: 100px;
            margin-bottom: 1rem;
        }

        h2 {
            font-size: 26px;
            color: #333;
        }

        .form-group {
            margin-bottom: 20px;
            text-align: left;
        }

        .form-control {
            width: 100%;
            padding: 12px;
            margin-top: 5px;
            border: 1px solid #ccc;
            border-radius: 5px;
        }

        .btn-login {
            background: #007bff;
            color: white;
            border: none;
            padding: 12px;
            width: 100%;
            border-radius: 5px;
            cursor: pointer;
            font-size: 18px;
            transition: 0.3s;
        }

        .btn-login:hover {
            background: #0056b3;
        }

        .error-message {
            display: block;
            margin-bottom: 15px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-card">
            <asp:Image ID="imgLogo" runat="server" ImageUrl="~/Content/Imagenes/logo.png" CssClass="login-icon" />
            <h2>Iniciar Sesión</h2>

            <!-- Mensaje de error con Bootstrap -->
            <asp:Label ID="lblMessage" runat="server" CssClass="alert alert-danger error-message" Visible="false"></asp:Label>

            <div class="form-group">
                <label for="txtEmail">Correo Electrónico</label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Ingresa tu correo" required></asp:TextBox>
            </div>

            <div class="form-group">
                <label for="txtPassword">Contraseña</label>
                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" placeholder="Ingresa tu contraseña" required></asp:TextBox>
            </div>

            <asp:Button ID="btnLogin" runat="server" CssClass="btn btn-login" Text="Ingresar" OnClick="btnLogin_Click" />
        </div>
    </form>
</body>
</html>
