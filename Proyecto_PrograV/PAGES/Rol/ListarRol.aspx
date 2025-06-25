<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListarRol.aspx.cs" Inherits="Proyecto_PrograV.PAGES.Rol.ListarRol" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="display: flex; justify-content: space-between; align-items: center; padding: 20px;">
        <h2 style="margin: 0;">Lista de Roles</h2>
        <asp:Button ID="btnNuevoRol" runat="server" Text="Nuevo Rol" OnClick="btnNuevoRol_Click" CssClass="btn-style" />
    </div>

    <div style="display: flex; justify-content: center;">
        <asp:GridView ID="gvRoles" runat="server" AutoGenerateColumns="false" CssClass="gridview-style" Height="385px" Width="1265px">
            <Columns>
                <asp:BoundField DataField="rol_id" HeaderText="ID Rol" />
                <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                <asp:TemplateField HeaderText="Acciones">
                    <ItemTemplate>
                        <a title="Editar Rol" class="btn btn-sm btn-outline-secondary" href='<%# "ModificarRol.aspx?id=" + Eval("rol_id") %>'>
                            <i class="bi bi-pencil-square"></i>
                        </a>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>

    <div style="text-align: center; margin-top: 20px;">
    </div>

    <style>
        .gridview-style {
            border-collapse: collapse;
            text-align: center;
        }

            .gridview-style th, .gridview-style td {
                border: 1px solid #ddd;
                padding: 8px;
            }

            .gridview-style th {
                background-color: #f2f2f2;
                font-weight: bold;
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