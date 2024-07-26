<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="FormularioArticulo.aspx.cs" Inherits="comercio_web.FormularioArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .form-header {
            margin: 20px 5px 30px;
            width: 100%;
        }

            .form-header h2 {
                color: #FF3131;
                font-weight: bold;
                text-align: left;
            }

            .form-header p {
                font-size: 22px;
                color: #444;
                text-align: left;
            }

        .textbox-size {
            resize: vertical;
            max-height: 150px;
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="form-header">
        <h2>Formulario de Artículos</h2>
        <p>Completa los datos para crear o modificar el artículo</p>
    </div>
    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <label for="txtId" class="form-label">ID</label>
                <asp:TextBox runat="server" ID="txtId" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtCodigo" class="form-label">Código</label>
                <asp:TextBox runat="server" ID="txtCodigo" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtNombre" class="form-label">Nombre</label>
                <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="ddlMarca" class="form-label">Marca</label>
                <asp:DropDownList runat="server" ID="ddlMarca" CssClass="form-select"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <label for="ddlCategoria" class="form-label">Categoría</label>
                <asp:DropDownList runat="server" ID="ddlCategoria" CssClass="form-select"></asp:DropDownList>
            </div>
            <div>
                <label for="txtPrecio" class="form-label">Precio</label>
                <asp:TextBox runat="server" id="txtPrecio" CssClass="form-control"/>
            </div>
        </div>
        <div class="col-6">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="mb-3">
                        <label for="txtDescripcion" class="form-label">Descripción</label>
                        <asp:TextBox runat="server" ID="txtDescripcion" CssClass="form-control textbox-size"
                            TextMode="MultiLine" />
                    </div>
                    <div class="mb-3">
                        <label for="txtImagenUrl" class="form-label">URL Imagen</label>
                        <asp:TextBox runat="server" ID="txtImagenUrl" CssClass="form-control"
                            AutoPostBack="true" OnTextChanged="txtImagenUrl_TextChanged" />
                    </div>
                    <asp:Image ImageUrl="https://www.svgrepo.com/show/508699/landscape-placeholder.svg"
                        runat="server" ID="imgArticulo" Width="60%" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <div class="row">
        <div class="col-6">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="mb-3">
                        <asp:Button Text="Aceptar" runat="server" ID="btnAceptar"
                            CssClass=" btn btn-danger me-2" OnClick="btnAceptar_Click" />
                        <asp:Button Text="Cancelar" runat="server" ID="btnCancelar"
                            CssClass="btn btn-danger me-2" OnClick="btnCancelar_Click" />
                        <asp:Button Text="Eliminar" runat="server" ID="btnEliminar"
                            CssClass="btn btn-outline-danger" OnClick="btnEliminar_Click" />
                        <%if (ConfirmaEliminacion)
                            { %>
                        <div class="mb-3">
                            <asp:CheckBox Text="Confirmar Eliminación" runat="server"
                                id="chkConfirmaEliminacion" />
                            <asp:Button Text="Eliminar" runat="server"
                                id="btnConfirmaEliminar" OnClick="btnConfirmaEliminar_Click" 
                                CssClass="btn btn-danger" />
                        </div>
                        <%} %>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
