<%@ Page Title="Bitácora de Transacciones" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Bitacora.aspx.cs" Inherits="Proyecto_PrograV.PAGES.Administracion.Bitacora" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-4">
        <div class="card">
            <!-- Cabecera de la tarjeta con fondo verde -->
            <div class="card-header bg-success text-white">
                <h5 class="card-title">Bitácora de Transacciones</h5>
            </div>
            <div class="card-body">

                <!-- GridView para mostrar la bitácora -->
                <div class="mt-4">
                    <asp:GridView ID="gvBitacora" runat="server" CssClass="table table-bordered table-striped" AutoGenerateColumns="true" EmptyDataText="No hay registros para mostrar.">
                        <HeaderStyle CssClass="thead-dark" />
                        <RowStyle CssClass="table-row" />
                        <AlternatingRowStyle CssClass="table-alt-row" />
                        <PagerStyle CssClass="pagination" />
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>