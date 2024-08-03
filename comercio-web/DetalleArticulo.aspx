<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="DetalleArticulo.aspx.cs" Inherits="comercio_web.DetalleArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .container {
            width: 100%;
        }

        .detalle-container {
            margin: 20px auto;
            width: 80%;
            background: #fff;
            padding: 60px 50px;
            border-radius: 5px;
        }

        .articulo-header {
            margin: 20px 5px 30px;
            width: 100%;
        }

        .detalle-header h2 {
            color: #FF3131;
            font-weight: bold;
            text-align: left;
        }

        .detalle-header p {
            color: #444;
            font-size: 22px;
            text-align: left;
        }

        .txt-size {
            resize: vertical;
            max-height: 100px;
            width: 100%;
        }

        .img-limited {
            max-width: 100%;
            max-height: 400px;
            object-fit: contain;
            display: block;
            margin: 0 auto;
        }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" />
    <div class="container">
        <div class="detalle-container">
            <div class="detalle-header">
                <h2>Detalle del Artículo</h2>
                <p>Aquí podrás observar el detalle del artículo seleccionado</p>
            </div>
            <div class="row">
                <div class="col-md-6">
                    <div class="mb-3">
                        <label class="form-label">Código</label>
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtCodigo" ReadOnly="true" />
                    </div>
                    <div class="mb-3">
                        <label class="form-label">Nombre</label>
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtNombre" ReadOnly="true" />
                    </div>
                    <div class="mb-3">
                        <label class="form-label">Descripción</label>
                        <asp:TextBox runat="server" CssClass="form-control txt-size" ID="txtDescripcion"
                            TextMode="MultiLine" ReadOnly="true" />
                    </div>
                    <div class="mb-3">
                        <label class="form-label">Marca</label>
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtMarca" ReadOnly="true" />
                    </div>
                    <div class="mb-3">
                        <label class="form-label">Categoria</label>
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtCategoria" ReadOnly="true" />
                    </div>
                    <div class="mb-3">
                        <label class="form-label">Precio</label>
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtPrecio" ReadOnly="true" />
                    </div>
                </div>
                <div class="col-md-6">
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <asp:Image runat="server" onerror="this.src='https://www.svgrepo.com/show/508699/landscape-placeholder.svg'" 
                                ID="imgArticulo" CssClass="img-limited img-fluid" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
            <div class="row mt-3">
                <div class="col-6">
                    <div class="mb-3">
                        <asp:Button Text="Volver" runat="server" ID="btnVolver"
                            CssClass="btn btn-danger me-2"  OnClick="btnVolver_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
