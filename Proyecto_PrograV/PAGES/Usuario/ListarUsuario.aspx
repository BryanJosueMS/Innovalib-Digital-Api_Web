<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListarAutor.aspx.cs" Inherits="Proyecto_PrograV.PAGES.Autor.ListarAutor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="display: flex; justify-content: space-between; align-items: center; padding: 20px;">
        <h2 style="margin: 0;">Lista de Usuarios</h2>
        <asp:Button ID="btnNuevoUsuario" runat="server" Text="Nuevo Usuario" OnClick="btnNuevoUsuario_Click" CssClass="btn-style" />
    </div>

    <div style="display: flex; justify-content: center;">
        <asp:GridView ID="gvUsuarios" runat="server" AutoGenerateColumns="false" CssClass="gridview-style" Height="385px" Width="1265px">
            <Columns>
                <asp:BoundField DataField="usuario_id" HeaderText="ID Usuario" />
                <asp:BoundField DataField="identificacion" HeaderText="Identificación" />
                <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="apellido1" HeaderText="Primer Apellido" />
                <asp:BoundField DataField="apellido2" HeaderText="Segundo Apellido" />
                <asp:BoundField DataField="fecha_nacimiento" HeaderText="Fecha de Nacimiento" DataFormatString="{0:dd/MM/yyyy}" />
                <asp:BoundField DataField="rol_nombre" HeaderText="Rol" />
                <asp:BoundField DataField="documento_nombre" HeaderText="Tipo Documento" />
                <asp:BoundField DataField="email" HeaderText="Email" />
                <asp:TemplateField HeaderText="Estado de Cuenta">
                    <ItemTemplate>
                        <%# Eval("estado").ToString() == "1" ? "Activo" : "Inactivo" %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Acciones">
                <ItemTemplate>
                    <a title="Editar Usuario" class="btn btn-sm btn-outline-secondary" href='<%# "ModificarUsuario.aspx?id=" + Eval("usuario_id") %>'>
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

