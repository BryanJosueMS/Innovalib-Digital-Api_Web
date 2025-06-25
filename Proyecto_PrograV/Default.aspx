<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Proyecto_PrograV._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <!-- Imagen del Logo -->
    <div class="text-center my-5">
        <img src="~/Content/Imagenes/logo.png" alt="Innovalib Digital Logo" class="img-fluid rounded shadow-sm" style="max-width: 200px;" runat="server" />
    </div>

    <!-- Hero Section -->
    <section class="hero bg-light text-center py-5">
        <div class="container">
            <h1 class="display-4 fw-bold">Bienvenido a Innovalib Digital</h1>
            <p class="lead text-muted">Explora miles de libros digitales de todos los géneros. ¡Tu próxima lectura te espera!</p>
        </div>
    </section>

    <!-- Beneficios -->
    <section class="benefits py-5">
        <div class="container text-center">
            <h2 class="fw-bold mb-4"><span class="text-primary"> ¿ Por qué elegir Innovalib Digital ?</span></h2>
            <br />
            <div class="row">
                <div class="col-md-4">
                    <h3 class="text-primary fw-semibold">📚 Acceso 24/7</h3>
                    <p class="text-muted">Tu biblioteca digital siempre disponible en cualquier dispositivo y a cualquier hora.</p>
                </div>
                <div class="col-md-4">
                    <h3 class="text-primary fw-semibold">📖 Variedad de Géneros</h3>
                    <p class="text-muted">Desde novelas hasta ensayos, descubre una colección diversa de títulos digitales.</p>
                </div>
                <div class="col-md-4">
                    <h3 class="text-primary fw-semibold">📱 Lectura sin interrupciones</h3>
                    <p class="text-muted">Disfruta de una experiencia fluida en cualquier dispositivo, sin anuncios ni distracciones.</p>
                </div>
            </div>
        </div>
    </section>

    <!-- Catálogo -->
    <section class="catalogue py-5 text-center">
        <div class="container">
            <h2 class="fw-bold mb-3">Explora nuestro Catálogo</h2>
            <p class="lead text-muted">Descubre una gran variedad de libros disponibles para ti.</p>
            <asp:HyperLink runat="server" NavigateUrl="~/PAGES/Libro/ListarLibro" CssClass="btn btn-lg btn-primary mt-3 shadow-sm" Text="Ver Catálogo" />
        </div>
    </section>

</asp:Content>
