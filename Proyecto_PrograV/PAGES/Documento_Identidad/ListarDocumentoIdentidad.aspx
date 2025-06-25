<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListarDocumentoIdentidad.aspx.cs" Inherits="Proyecto_PrograV.PAGES.Documento_Identidad.ListarDocumentoIdentidad" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="display: flex; justify-content: space-between; align-items: center; padding: 20px;">
        <h2 style="margin: 0;">Lista de Documentos de Identidad</h2>
        <asp:Button ID="btnNuevoDocumento" runat="server" Text="Nuevo Documento" OnClick="btnNuevoDocumento_Click" CssClass="btn-style" />
    </div>

    <div style="display: flex; justify-content: center;">
        <asp:GridView ID="gvDocumentos" runat="server" AutoGenerateColumns="false" CssClass="gridview-style" Height="385px" Width="1265px">
            <Columns>
                <asp:BoundField DataField="documento_identidad_id" HeaderText="ID Documento" />
                <asp:BoundField DataField="nombre" HeaderText="Tipo de Documento" />
                <asp:TemplateField HeaderText="Acciones">
                    <ItemTemplate>
                        <a title="Editar Documento" class="btn btn-sm btn-outline-secondary" href='<%# "ModificarDocumentoIdentidad.aspx?id=" + Eval("documento_identidad_id") %>'>
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