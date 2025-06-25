<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BitacoraError.aspx.cs" Inherits="Proyecto_PrograV.PAGES.Administracion.BitacoraError" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div class="container mt-4">
     <div class="card">
         <div class="card-header bg-danger text-white">
             <h5 class="card-title">Bitácora de Errores</h5>
         </div>
         <div class="card-body">

             <!-- GridView para mostrar la bitácora de errores -->
             <div class="mt-4">
                 <asp:GridView ID="gvBitacoraErrores" runat="server" CssClass="table table-bordered table-striped" AutoGenerateColumns="true" EmptyDataText="No hay registros de errores para mostrar.">
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
