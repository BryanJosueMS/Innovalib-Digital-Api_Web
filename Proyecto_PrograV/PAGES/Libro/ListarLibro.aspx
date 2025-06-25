<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListarLibro.aspx.cs" Inherits="Proyecto_PrograV.PAGES.Libro.ListarLibro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="display: flex; justify-content: space-between; align-items: center; padding: 20px;">
        <h2 style="margin: 0;">Lista de Libros</h2>
        <asp:Button ID="btnNuevoLibro" runat="server" Text="Nuevo Libro" OnClick="btnNuevoLibro_Click" CssClass="btn-style" />
    </div>

    <div style="display: flex; justify-content: center;">
        <asp:GridView ID="gvLibros" runat="server" AutoGenerateColumns="false" CssClass="gridview-style" Height="385px" Width="1265px">
            <Columns>
                <asp:BoundField DataField="libro_id" HeaderText="ID Libro" />
                <asp:BoundField DataField="titulo" HeaderText="Título" />
                <asp:BoundField DataField="fecha_publicacion" HeaderText="Fecha Publicación" DataFormatString="{0:dd/MM/yyyy}" />
                <asp:BoundField DataField="unidades_disponibles" HeaderText="Unidades Disponibles" />
                <asp:TemplateField HeaderText="Estado del Libro">
                    <ItemTemplate>
                        <%# Eval("estado").ToString() == "1" ? "Activo" : "Inactivo" %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="categoria_nombre" HeaderText="Categoría" />
                <asp:BoundField DataField="persona_nombre" HeaderText="Nombre Autor" />
                <asp:BoundField DataField="apellido1" HeaderText="Primer Apellido Autor" />
                <asp:BoundField DataField="apellido2" HeaderText="Segundo Apellido Autor" />
                <asp:TemplateField HeaderText="Acciones">
                    <ItemTemplate>
                        <a title="Editar Libro" class="btn btn-sm btn-outline-secondary" href='<%# "ModificarLibro.aspx?id=" + Eval("libro_id") %>'>
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