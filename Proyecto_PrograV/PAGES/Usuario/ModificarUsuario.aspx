<%@ Page Title="Actualizar Usuario" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ActualizarUsuario.aspx.cs" Inherits="Proyecto_PrograV.PAGES.Usuario.ActualizarUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Actualizar Usuario</h2>

    <div class="row">
        <!-- Columna izquierda (5 campos) -->
        <div class="col-md-6">
            <!-- Nombre -->
            <div class="mb-3">
                <asp:Label ID="lblNombre" runat="server" Text="Nombre:"></asp:Label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" placeholder="Ingrese el nombre"></asp:TextBox>
            </div>

            <!-- Primer Apellido -->
            <div class="mb-3">
                <asp:Label ID="lblApellido1" runat="server" Text="Primer Apellido:"></asp:Label>
                <asp:TextBox ID="txtApellido1" runat="server" CssClass="form-control" placeholder="Ingrese el primer apellido"></asp:TextBox>
            </div>

            <!-- Segundo Apellido -->
            <div class="mb-3">
                <asp:Label ID="lblApellido2" runat="server" Text="Segundo Apellido:"></asp:Label>
                <asp:TextBox ID="txtApellido2" runat="server" CssClass="form-control" placeholder="Ingrese el segundo apellido"></asp:TextBox>
            </div>

            <!-- Identificación -->
            <div class="mb-3">
                <asp:Label ID="lblIdentificacion" runat="server" Text="Identificación:"></asp:Label>
                <asp:TextBox ID="txtIdentificacion" runat="server" CssClass="form-control" placeholder="Ingrese la identificación"></asp:TextBox>
            </div>

            <!-- Fecha de Nacimiento -->
            <div class="mb-3">
                <asp:Label ID="lblFechaNacimiento" runat="server" Text="Fecha de Nacimiento:"></asp:Label>
                <asp:TextBox ID="txtFechaNacimiento" runat="server" CssClass="form-control" TextMode="Date" />
            </div>
        </div>

        <!-- Columna derecha (5 campos) -->
        <div class="col-md-6">
            <!-- Tipo de Documento de Identidad -->
            <div class="mb-3">
                <asp:Label ID="lblDocumentoIdentidad" runat="server" Text="Tipo de Documento de Identidad:"></asp:Label>
                <asp:DropDownList ID="ddlDocumentoIdentidad" runat="server" CssClass="form-select">
                </asp:DropDownList>
            </div>

            <!-- Correo Electrónico -->
            <div class="mb-3">
                <asp:Label ID="lblEmail" runat="server" Text="Correo Electrónico:"></asp:Label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Ingrese el correo electrónico"></asp:TextBox>
            </div>

            <!-- Contraseña -->
            <div class="mb-3">
                <asp:Label ID="lblContrasena" runat="server" Text="Contraseña:"></asp:Label>
                <asp:TextBox ID="txtContrasena" runat="server" CssClass="form-control" TextMode="Password" placeholder="Ingrese la contraseña"></asp:TextBox>
            </div>


            <!-- Estado -->
            <div class="mb-3">
                <asp:Label ID="lblEstado" runat="server" Text="Estado:"></asp:Label>
                <asp:DropDownList ID="ddlEstado" runat="server" CssClass="form-select">
                    <asp:ListItem Text="Seleccione el estado" Value="" />
                    <asp:ListItem Text="Activo" Value="A" />
                    <asp:ListItem Text="Inactivo" Value="I" />
                </asp:DropDownList>
            </div>

            <!-- Rol -->
            <div class="mb-3">
                <asp:Label ID="lblRol" runat="server" Text="Rol:"></asp:Label>
                <asp:DropDownList ID="ddlRol" runat="server" CssClass="form-select">
                </asp:DropDownList>
            </div>
        </div>
    </div>

    <!-- Botón Actualizar -->
    <div class="d-grid gap-2 d-md-flex justify-content-md-end">
        <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" CssClass="btn btn-primary" OnClick="btnActualizar_Click" />
    </div>

    <!-- Mensajes de Resultado -->
    <div class="mt-3">
        <asp:Label ID="lblResultado" runat="server" ForeColor="Green"></asp:Label>
    </div>
</asp:Content>
