<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListarAutor.aspx.cs" Inherits="Proyecto_PrograV.PAGES.Autor.ListarAutor1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="display: flex; justify-content: space-between; align-items: center; padding: 20px;">
        <h2 style="margin: 0;">Lista de Autores</h2>
        <asp:Button ID="btnNuevoAutor" runat="server" Text="Nuevo Autor" OnClick="btnNuevoAutor_Click" CssClass="btn-style" />
    </div>

    <div style="display: flex; justify-content: center;">
        <asp:GridView ID="gvAutores" runat="server" AutoGenerateColumns="false" CssClass="gridview-style" Height="385px" Width="1265px">
            <Columns>
                <asp:BoundField DataField="autor_id" HeaderText="ID Autor" />
                <asp:BoundField DataField="identificacion" HeaderText="Identificación" />
                <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="apellido1" HeaderText="Primer Apellido" />
                <asp:BoundField DataField="apellido2" HeaderText="Segundo Apellido" />
                <asp:BoundField DataField="fecha_nacimiento" HeaderText="Fecha de Nacimiento" DataFormatString="{0:dd/MM/yyyy}" />
                <asp:BoundField DataField="fecha_defuncion" HeaderText="Fecha de Defunción" DataFormatString="{0:dd/MM/yyyy}" NullDisplayText="-" />
                <asp:TemplateField HeaderText="Acciones">
                    <ItemTemplate>
                        <a title="Editar Autor" class="btn btn-sm btn-outline-secondary" href='<%# "ModificarAutor.aspx?id=" + Eval("autor_id") %>'>
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
