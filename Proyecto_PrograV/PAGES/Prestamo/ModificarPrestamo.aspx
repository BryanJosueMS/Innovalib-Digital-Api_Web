<%@ Page Title="Actualizar Préstamo" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModificarPrestamo.aspx.cs" Inherits="Proyecto_PrograV.PAGES.Prestamo.ModificarPrestamo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Actualizar Préstamo</h2>

    <div class="row">
        <!-- Columna izquierda (4 campos) -->
        <div class="col-md-6">
            <!-- Fecha de Préstamo -->
            <div class="mb-3">
                <asp:Label ID="lblFechaPrestamo" runat="server" Text="Fecha de Préstamo:"></asp:Label>
                <asp:TextBox ID="txtFechaPrestamo" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvFechaPrestamo" runat="server" ControlToValidate="txtFechaPrestamo" ErrorMessage="La fecha de préstamo es requerida." ForeColor="red" />
            </div>

            <!-- Fecha de Devolución -->
            <div class="mb-3">
                <asp:Label ID="lblFechaDevolucion" runat="server" Text="Fecha de Devolución:"></asp:Label>
                <asp:TextBox ID="txtFechaDevolucion" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvFechaDevolucion" runat="server" ControlToValidate="txtFechaDevolucion" ErrorMessage="La fecha de devolución es requerida." ForeColor="red" />
            </div>

            <!-- Detalle -->
            <div class="mb-3">
                <asp:Label ID="lblDetalle" runat="server" Text="Detalle:"></asp:Label>
                <asp:TextBox ID="txtDetalle" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3" placeholder="Ingrese el detalle del préstamo"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvDetalle" runat="server" ControlToValidate="txtDetalle" ErrorMessage="El detalle es requerido." ForeColor="red" />
            </div>

            <!-- Estado -->
            <div class="mb-3">
                <asp:Label ID="lblEstado" runat="server" Text="Estado:"></asp:Label>
                <asp:DropDownList ID="ddlEstado" runat="server" CssClass="form-select">
                    <asp:ListItem Text="Seleccione el estado" Value="" />
                    <asp:ListItem Text="Activo" Value="1" />
                    <asp:ListItem Text="Devuelto" Value="0" />
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvEstado" runat="server" ControlToValidate="ddlEstado" InitialValue="" ErrorMessage="El estado es requerido." ForeColor="red" />
            </div>
        </div>

        <!-- Columna derecha (2 campos) -->
        <div class="col-md-6">
            <!-- Usuario -->
            <div class="mb-3">
                <asp:Label ID="lblUsuario" runat="server" Text="Usuario:"></asp:Label>
                <asp:DropDownList ID="ddlUsuario" runat="server" CssClass="form-select">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvUsuario" runat="server" ControlToValidate="ddlUsuario" InitialValue="" ErrorMessage="El usuario es requerido." ForeColor="red" />
            </div>

            <!-- Libros -->
            <div class="mb-3">
                <asp:Label ID="lblLibros" runat="server" Text="Libros:"></asp:Label>
                <div class="libros-container">
                    <asp:Repeater ID="rptLibros" runat="server">
                        <ItemTemplate>
                            <div class="libro-item">
                                <asp:CheckBox ID="chkLibro" runat="server" CssClass="form-check-input" />
                                <asp:Label ID="lblLibroNombre" runat="server" CssClass="form-check-label" Text='<%# Eval("titulo") %>' />
                                <asp:HiddenField ID="hdnLibroId" runat="server" Value='<%# Eval("libro_id") %>' />
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
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