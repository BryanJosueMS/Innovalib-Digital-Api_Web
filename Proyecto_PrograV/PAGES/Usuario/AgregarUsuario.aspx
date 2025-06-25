<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarUsuario.aspx.cs" Inherits="Proyecto_PrograV.PAGES.Usuario.AgregarUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Guardar Usuario</h2>

    <div class="row">
        <!-- Columna izquierda (5 campos) -->
        <div class="col-md-6">
            <!-- Nombre -->
            <div class="mb-3">
                <asp:Label ID="lblNombre" runat="server" Text="Nombre:"></asp:Label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" placeholder="Ingrese el nombre"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtNombre" ErrorMessage="El nombre es requerido." ForeColor="red" />
            </div>

            <!-- Primer Apellido -->
            <div class="mb-3">
                <asp:Label ID="lblApellido1" runat="server" Text="Primer Apellido:"></asp:Label>
                <asp:TextBox ID="txtApellido1" runat="server" CssClass="form-control" placeholder="Ingrese el primer apellido"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvApellido1" runat="server" ControlToValidate="txtApellido1" ErrorMessage="El primer apellido es requerido." ForeColor="red" />
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
                <asp:RequiredFieldValidator ID="rfvIdentificacion" runat="server" ControlToValidate="txtIdentificacion" ErrorMessage="La identificación es requerida." ForeColor="red" />
            </div>

            <!-- Fecha de Nacimiento -->
            <div class="mb-3">
                <asp:Label ID="lblFechaNacimiento" runat="server" Text="Fecha de Nacimiento:"></asp:Label>
                <asp:TextBox ID="txtFechaNacimiento" runat="server" CssClass="form-control" TextMode="Date" />
                <asp:RequiredFieldValidator ID="rfvFechaNacimiento" runat="server" ControlToValidate="txtFechaNacimiento" ErrorMessage="La fecha de nacimiento es requerida." ForeColor="red" />
            </div>
        </div>

        <!-- Columna derecha (5 campos) -->
        <div class="col-md-6">
            <!-- Tipo de Documento de Identidad -->
            <div class="mb-3">
                <asp:Label ID="lblDocumentoIdentidad" runat="server" Text="Tipo de Documento de Identidad:"></asp:Label>
                <asp:DropDownList ID="ddlDocumentoIdentidad" runat="server" CssClass="form-select">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvDocumentoIdentidad" runat="server" ControlToValidate="ddlDocumentoIdentidad" InitialValue="" ErrorMessage="El tipo de documento es requerido." ForeColor="red" />
            </div>

            <!-- Correo Electrónico -->
            <div class="mb-3">
                <asp:Label ID="lblEmail" runat="server" Text="Correo Electrónico:"></asp:Label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Ingrese el correo electrónico"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="El correo electrónico es requerido." ForeColor="red" />
            </div>

            <!-- Contraseña -->
            <div class="mb-3">
                <asp:Label ID="lblContrasena" runat="server" Text="Contraseña:"></asp:Label>
                <asp:TextBox ID="txtContrasena" runat="server" CssClass="form-control" TextMode="Password" placeholder="Ingrese la contraseña"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvContrasena" runat="server" ControlToValidate="txtContrasena" ErrorMessage="La contraseña es requerida." ForeColor="red" />
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

    <!-- Botón Guardar -->
    <div class="d-grid gap-2 d-md-flex justify-content-md-end">
        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
    </div>

    <!-- Mensajes de Resultado -->
    <div class="mt-3">
        <asp:Label ID="lblResultado" runat="server" ForeColor="Green"></asp:Label>
    </div>

</asp:Content>
