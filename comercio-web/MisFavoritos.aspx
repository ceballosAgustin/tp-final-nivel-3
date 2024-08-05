<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="MisFavoritos.aspx.cs" Inherits="comercio_web.MisFavoritos" %>

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

        .favs-header {
            margin: 20px 5px 30px;
            width: 100%;
        }

            .favs-header h2 {
                color: #ff3131;
                font-weight: bold;
                text-align: left;
            }

            .favs-header p {
                font-size: 22px;
                color: #444;
                text-align: left;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="favs-header">
        <h2>Artículos Favoritos</h2>
        <p>Aquí podrás encontrar los artículos que elegiste como favoritos. También puedes eliminarlos de esta sección</p>
    </div>
    <div class="container mt-4">
        <div class="row row-cols-1 row-cols-md-3 g-4">
            <asp:Repeater runat="server" ID="repRepetidor">
                <ItemTemplate>
                    <div class="col">
                        <div class="card">
                            <img src="<%#Eval("ImagenUrl") %>" class="card-img-top"
                                onerror="this.src='https://www.svgrepo.com/show/508699/landscape-placeholder.svg'" alt="..." />
                            <div class="card-body">
                                <h5 class="card-title"><%#Eval("Nombre") %></h5>
                                <p class="card-text"><%#Eval("Precio") %></p>
                                <asp:Button Text="Eliminar de Favoritos" ID="btnEliminar" runat="server" CssClass="btn btn-danger"
                                    CommandArgument='<%#Eval("Id") %>' CommandName="ArticuloId" OnClick="btnEliminar_Click" />
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
