<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Articulos.aspx.cs" Inherits="comercio_web.Articulos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .container {
            padding-bottom: 20px;
        }

        .card-img-top {
            max-width: 100%;
            max-height: 200px;
            object-fit: contain;
        }

        .articulos-header {
            margin: 20px 5px 30px;
            width: 100%;
        }

            .articulos-header h2 {
                color: #FF3131;
                font-weight: bold;
                text-align: left;
            }

            .articulos-header p {
                font-size: 22px;
                color: #444;
                text-align: left;
            }

        .btn-favorito {
            position: absolute;
            top: 10px;
            right: 10px;
            background: transparent;
            border: none;
            cursor: pointer;
        }

        .toast-success {
            background-color: #FF3131 !important;
        }
    </style>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/toastr.min.css" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/toastr.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="articulos-header">
        <h2>Artículos disponibles</h2>
        <p>Puedes echarle un vistazo a todos nuestros artículos disponibles</p>
    </div>

    <div class="container mt-4">
        <asp:ScriptManager runat="server" />
        <asp:UpdatePanel runat="server">
            <ContentTemplate>

                <div class="row row-cols-1 row-cols-md-3 g-4">
                    <asp:Repeater ID="repRepetidor" runat="server" OnItemDataBound="repRepetidor_ItemDataBound">
                        <ItemTemplate>
                            <div class="col">
                                <div class="card">
                                    <img src="<%#Eval("ImagenUrl") %>" class="card-img-top"
                                        onerror="this.src='https://www.svgrepo.com/show/508699/landscape-placeholder.svg'" alt="..." />
                                    <div class="card-body">
                                        <h5 class="card-title"><%#Eval("Nombre") %></h5>
                                        <p class="card-text"><%#Eval("Descripcion") %></p>
                                        <asp:Button ID="btnDetalle" Text="Ver Detalle" runat="server" CssClass="btn btn-danger btn-detalle"
                                            CommandArgument='<%#Eval("Id") %>' CommandName="ArticuloId" OnClick="btnDetalle_Click" />
                                        <asp:ImageButton ImageUrl="~/Images/favorito.png" ID="btnFavorito" runat="server" CssClass="btn-favorito"
                                            CommandArgument='<%#Eval("Id") %>' OnClick="btnFavorito_Click" />
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

</asp:Content>
