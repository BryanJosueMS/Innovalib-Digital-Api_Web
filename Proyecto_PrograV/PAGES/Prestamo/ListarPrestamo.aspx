<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListarPrestamo.aspx.cs" Inherits="Proyecto_PrograV.PAGES.PrestamoLibro.ListarPrestamoLibro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="display: flex; justify-content: space-between; align-items: center; padding: 20px;">
        <h2 style="margin: 0;">Gestión de Préstamos</h2>
        <asp:Button ID="btnNuevoPrestamoLibro" runat="server" Text="Nuevo Préstamo" OnClick="btnNuevoPrestamoLibro_Click" CssClass="btn-style" />
    </div>

    <div class="tab-container">
        <h3>Préstamos Activos</h3>
        <div style="overflow-x: auto;">
            <asp:GridView ID="gvPrestamosActivos" runat="server" AutoGenerateColumns="false" CssClass="gridview-style" Width="100%" CellPadding="4" GridLines="None" OnRowCommand="gvPrestamos_RowCommand">
                <Columns>
                    <asp:BoundField DataField="prestamo_libro_id" HeaderText="ID Préstamo-Libro" />
                    <asp:BoundField DataField="prestamo_id" HeaderText="ID Préstamo" />
                    <asp:BoundField DataField="fecha_prestamo" HeaderText="Fecha de Préstamo" DataFormatString="{0:dd/MM/yyyy}" />
                    <asp:BoundField DataField="fecha_devolucion" HeaderText="Fecha de Devolución" DataFormatString="{0:dd/MM/yyyy}" />
                    <asp:TemplateField HeaderText="Estado">
                        <ItemTemplate>
                            <span style="color: red; font-weight: bold;">Activo</span>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="libro_id" HeaderText="ID Libro" />
                    <asp:BoundField DataField="titulo_libro" HeaderText="Título del Libro" />
                    <asp:BoundField DataField="usuario_id" HeaderText="ID Usuario" />
                    <asp:BoundField DataField="nombre_usuario" HeaderText="Nombre del Usuario" />
                    <asp:BoundField DataField="apellido1_usuario" HeaderText="Primer Apellido" />
                    <asp:BoundField DataField="apellido2_usuario" HeaderText="Segundo Apellido" />
                    <asp:BoundField DataField="email" HeaderText="Email" />
                    <asp:TemplateField HeaderText="Acciones">
                        <ItemTemplate>
                            <a title="Editar Préstamo" class="btn btn-sm btn-outline-secondary" href='<%# "ModificarPrestamo.aspx?id=" + Eval("prestamo_id") %>'>
                                <i class="bi bi-pencil-square"></i>
                            </a>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>

        <h3 style="margin-top: 30px;">Préstamos Devueltos</h3>
        <div style="overflow-x: auto;">
            <asp:GridView ID="gvPrestamosDevueltos" runat="server" AutoGenerateColumns="false" CssClass="gridview-style" Width="100%" CellPadding="4" GridLines="None" OnRowCommand="gvPrestamos_RowCommand">
                <Columns>
                    <asp:BoundField DataField="prestamo_libro_id" HeaderText="ID Préstamo-Libro" />
                    <asp:BoundField DataField="prestamo_id" HeaderText="ID Préstamo" />
                    <asp:BoundField DataField="fecha_prestamo" HeaderText="Fecha de Préstamo" DataFormatString="{0:dd/MM/yyyy}" />
                    <asp:BoundField DataField="fecha_devolucion" HeaderText="Fecha de Devolución" DataFormatString="{0:dd/MM/yyyy}" />
                    <asp:TemplateField HeaderText="Estado">
                        <ItemTemplate>
                            <span style="color: green; font-weight: bold;">Devuelto</span>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="libro_id" HeaderText="ID Libro" />
                    <asp:BoundField DataField="titulo_libro" HeaderText="Título del Libro" />
                    <asp:BoundField DataField="usuario_id" HeaderText="ID Usuario" />
                    <asp:BoundField DataField="nombre_usuario" HeaderText="Nombre del Usuario" />
                    <asp:BoundField DataField="apellido1_usuario" HeaderText="Primer Apellido" />
                    <asp:BoundField DataField="apellido2_usuario" HeaderText="Segundo Apellido" />
                    <asp:BoundField DataField="email" HeaderText="Email" />
                    <asp:TemplateField HeaderText="Acciones">
                        <ItemTemplate>
                            <a title="Editar Préstamo" class="btn btn-sm btn-outline-secondary" href='<%# "ModificarPrestamo.aspx?id=" + Eval("prestamo_id") %>'>
                                <i class="bi bi-pencil-square"></i>
                            </a>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>

    <style>
        .gridview-style {
            border-collapse: collapse;
            text-align: center;
            width: 100%;
        }

            .gridview-style th, .gridview-style td {
                border: 1px solid #ddd;
                padding: 11px; /* Espaciado reducido */
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

        .btn-outline-secondary {
            background-color: transparent;
            border: 1px solid #6c757d;
            color: #6c757d;
            padding: 5px 10px;
            border-radius: 3px;
            text-decoration: none;
        }

            .btn-outline-secondary:hover {
                background-color: #6c757d;
                color: white;
            }

        .tab-container {
            margin-top: 20px;
        }

        h3 {
            color: #333;
            border-bottom: 2px solid #4CAF50;
            padding-bottom: 5px;
            margin-bottom: 15px;
        }
    </style>
</asp:Content>