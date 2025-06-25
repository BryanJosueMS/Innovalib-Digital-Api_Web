<%@ Page Title="Modificar Rol" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModificarRol.aspx.cs" Inherits="Proyecto_PrograV.PAGES.Rol.ModificarRol" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="display: flex; justify-content: space-between; align-items: center; padding: 20px;">
        <h2 style="margin: 0;">Modificar Rol</h2>
    </div>

    <asp:HiddenField ID="hfRolId" runat="server" />

    <div class="row">
        <div class="col-md-6">
            <!-- Nombre -->
            <div class="mb-3">
                <asp:Label ID="lblNombre" runat="server" Text="Nombre del Rol:"></asp:Label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" placeholder="Ingrese el nombre del rol"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtNombre" 
                    ErrorMessage="El nombre es requerido." ForeColor="red" />
            </div>
        </div>
    </div>

    <!-- Botón Actualizar -->
    <div class="d-grid gap-2 d-md-flex justify-content-md-end">
        <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" CssClass="btn-style" OnClick="btnActualizar_Click" />
    </div>

    <!-- Mensajes de Resultado -->
    <div class="mt-3">
        <asp:Label ID="lblResultado" runat="server" ForeColor="Green"></asp:Label>
    </div>

    <style>
        .form-control {
            width: 100%;
            padding: 8px;
            margin-bottom: 10px;
            border: 1px solid #ddd;
            border-radius: 4px;
        }

        .btn-style {
            padding: 10px 20px;
            background-color: #4CAF50;
            color: white;
            border: none;
            cursor: pointer;
            border-radius: 5px;
        }

            .btn-style:hover {
                background-color: #45a049;
            }
    </style>
</asp:Content>