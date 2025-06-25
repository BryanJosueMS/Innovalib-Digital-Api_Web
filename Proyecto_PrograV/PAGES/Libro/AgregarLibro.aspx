<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarLibro.aspx.cs" Inherits="Proyecto_PrograV.PAGES.Libro.AgregarLibro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Agregar Libro</h2>

    <div class="row">
        <!-- Columna izquierda -->
        <div class="col-md-6">
            <!-- Título -->
            <div class="mb-3">
                <asp:Label ID="lblTitulo" runat="server" Text="Título:"></asp:Label>
                <asp:TextBox ID="txtTitulo" runat="server" CssClass="form-control" placeholder="Ingrese el título del libro"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvTitulo" runat="server" ControlToValidate="txtTitulo" 
                    ErrorMessage="El título es requerido." ForeColor="red" />
            </div>

            <!-- Fecha de Publicación -->
            <div class="mb-3">
                <asp:Label ID="lblFechaPublicacion" runat="server" Text="Fecha de Publicación:"></asp:Label>
                <asp:TextBox ID="txtFechaPublicacion" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvFechaPublicacion" runat="server" ControlToValidate="txtFechaPublicacion" 
                    ErrorMessage="La fecha de publicación es requerida." ForeColor="red" />
            </div>

            <!-- Categoría -->
            <div class="mb-3">
                <asp:Label ID="lblCategoria" runat="server" Text="Categoría:"></asp:Label>
                <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="form-select">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvCategoria" runat="server" ControlToValidate="ddlCategoria" InitialValue=""
                    ErrorMessage="Debe seleccionar una categoría." ForeColor="red" />
            </div>
        </div>

        <!-- Columna derecha -->
        <div class="col-md-6">
            <!-- Autor -->
            <div class="mb-3">
                <asp:Label ID="lblAutor" runat="server" Text="Autor:"></asp:Label>
                <asp:DropDownList ID="ddlAutor" runat="server" CssClass="form-select">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvAutor" runat="server" ControlToValidate="ddlAutor" InitialValue=""
                    ErrorMessage="Debe seleccionar un autor." ForeColor="red" />
            </div>

            <!-- Unidades Disponibles -->
            <div class="mb-3">
                <asp:Label ID="lblUnidadesDisponibles" runat="server" Text="Unidades Disponibles:"></asp:Label>
                <asp:TextBox ID="txtUnidadesDisponibles" runat="server" CssClass="form-control" TextMode="Number" min="1" value="1"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvUnidadesDisponibles" runat="server" ControlToValidate="txtUnidadesDisponibles" 
                    ErrorMessage="Las unidades disponibles son requeridas." ForeColor="red" />
                <asp:RangeValidator ID="rvUnidadesDisponibles" runat="server" ControlToValidate="txtUnidadesDisponibles"
                    Type="Integer" MinimumValue="1" MaximumValue="1000" ErrorMessage="Debe ser un número entre 1 y 1000." ForeColor="red" />
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
        </div>
    </div>

    <!-- Descripción (fila completa) -->
    <div class="row">
        <div class="col-md-12">
            <div class="mb-3">
                <asp:Label ID="lblDescripcion" runat="server" Text="Descripción:"></asp:Label>
                <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="4" 
                    placeholder="Ingrese una descripción del libro"></asp:TextBox>
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