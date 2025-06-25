<%@ Page Title="Modificar Autor" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModificarAutor.aspx.cs" Inherits="Proyecto_PrograV.PAGES.Autor.ModificarAutor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Modificar Autor</h2>

    <div class="row">
        <!-- Columna izquierda -->
        <div class="col-md-6">
            <!-- Nombre -->
            <div class="mb-3">
                <asp:Label ID="lblNombre" runat="server" Text="Nombre:"></asp:Label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" placeholder="Ingrese el nombre"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtNombre" 
                    ErrorMessage="El nombre es requerido." ForeColor="red" />
            </div>

            <!-- Primer Apellido -->
            <div class="mb-3">
                <asp:Label ID="lblApellido1" runat="server" Text="Primer Apellido:"></asp:Label>
                <asp:TextBox ID="txtApellido1" runat="server" CssClass="form-control" placeholder="Ingrese el primer apellido"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvApellido1" runat="server" ControlToValidate="txtApellido1" 
                    ErrorMessage="El primer apellido es requerido." ForeColor="red" />
            </div>

            <!-- Segundo Apellido -->
            <div class="mb-3">
                <asp:Label ID="lblApellido2" runat="server" Text="Segundo Apellido:"></asp:Label>
                <asp:TextBox ID="txtApellido2" runat="server" CssClass="form-control" placeholder="Ingrese el segundo apellido"></asp:TextBox>
            </div>
        </div>

        <!-- Columna derecha -->
        <div class="col-md-6">
            <!-- Identificación -->
            <div class="mb-3">
                <asp:Label ID="lblIdentificacion" runat="server" Text="Identificación:"></asp:Label>
                <asp:TextBox ID="txtIdentificacion" runat="server" CssClass="form-control" placeholder="Ingrese la identificación"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvIdentificacion" runat="server" ControlToValidate="txtIdentificacion" 
                    ErrorMessage="La identificación es requerida." ForeColor="red" />
            </div>

            <!-- Fecha de Nacimiento -->
            <div class="mb-3">
                <asp:Label ID="lblFechaNacimiento" runat="server" Text="Fecha de Nacimiento:"></asp:Label>
                <asp:TextBox ID="txtFechaNacimiento" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvFechaNacimiento" runat="server" ControlToValidate="txtFechaNacimiento" 
                    ErrorMessage="La fecha de nacimiento es requerida." ForeColor="red" />
            </div>

            <!-- Fecha de Defunción -->
            <div class="mb-3">
                <asp:Label ID="lblFechaDefuncion" runat="server" Text="Fecha de Defunción (opcional):"></asp:Label>
                <asp:TextBox ID="txtFechaDefuncion" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
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