<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ListaArticulos.aspx.cs" Inherits="comercio_web.ListaArticulos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .lista-header {
            margin: 20px 5px 30px;
            width: 100%;
        }

            .lista-header h2 {
                color: #FF3131;
                font-weight: bold;
                text-align: left;
            }

        .input-group-text {
            display: flex;
            align-items: center;
        }

        .agregar-articulo {
            margin: 20px 5px 30px;
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="lista-header">
        <h2>Lista de Artículos</h2>
    </div>
    <div class="container">
        <div class="col-6">
            <div class="input-group mb-3">
                <asp:Label Text="Filtrar" runat="server" CssClass="form-label me-2"/>
                <asp:TextBox runat="server" ID="txtFiltro" CssClass="form-control" AutoPostBack="true"
                    OnTextChanged="txtFiltro_TextChanged" />
                <div class="input-group-text me-2">
                    <asp:CheckBox Text="Filtro Avanzado" runat="server" ID="chkAvanzado" AutoPostBack="true"
                        OnCheckedChanged="chkAvanzado_CheckedChanged" />
                </div>
            </div>
        </div>

        <%if (chkAvanzado.Checked)
            { %>
        <div class="row">
            <div class="col-3">
                <div class="mb-3">
                    <asp:Label Text="Campo" ID="lblCampo" runat="server" />
                    <asp:DropDownList runat="server" AutoPostBack="true" CssClass="form-control" ID="ddlCampo"
                        OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged">
                        <asp:ListItem Text="Nombre" />
                        <asp:ListItem Text="Marca" />
                        <asp:ListItem Text="Precio" />
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col-3">
                <div class="mb-3">
                    <asp:Label Text="Criterio" runat="server" />
                    <asp:DropDownList runat="server" ID="ddlCriterio" CssClass="form-control">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col-3">
                <div class="mb-3">
                    <asp:Label Text="Filtro" runat="server" />
                    <asp:TextBox runat="server" ID="txtFiltroAvanzado" CssClass="form-control" />
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-3">
                <div class="mb-3">
                    <asp:Button Text="Buscar" runat="server" CssClass="btn btn-primary" ID="btnBuscar"
                        OnClick="btnBuscar_Click" />
                </div>
            </div>
        </div>
        <%  } %>

        <asp:GridView runat="server" ID="dgvArticulos" DataKeyNames="Id"
            CssClass="table" AutoGenerateColumns="false"
            OnSelectedIndexChanged="dgvArticulos_SelectedIndexChanged"
            OnPageIndexChanging="dgvArticulos_PageIndexChanging"
            AllowPaging="true" PageSize="5">
            <Columns>
                <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                <asp:BoundField HeaderText="Marca" DataField="Marca.Descripcion" />
                <asp:BoundField HeaderText="Precio" DataField="Precio" />
                <asp:CommandField HeaderText="Acciones (clickear)" ShowSelectButton="true" SelectText="⚙️" />
            </Columns>
        </asp:GridView>
    </div>
    <div class="agregar-articulo">
        <a href="AgregarArticulo.aspx" class="btn btn-danger">Agregar Artículo</a>
    </div>
</asp:Content>
