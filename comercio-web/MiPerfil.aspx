<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="MiPerfil.aspx.cs" Inherits="comercio_web.MiPerfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .perfil-header {
            margin: 20px 5px 30px;
            width: 100%;
        }

            .perfil-header h2 {
                color: #FF3131;
                font-weight: bold;
                text-align: left;
            }

            .perfil-header p {
                font-size: 22px;
                color: #444;
                text-align: left;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="perfil-header">
        <h2>Mi Perfil</h2>
        <p>Puedes actualizar tus datos y tu foto de perfil aquí</p>
    </div>
    <asp:Panel runat="server" ID="pnlMiPerfil" DefaultButton="btnGuardar">
        <div class="row">
            <div class="col-md-4">
                <div class="mb-3">
                    <label class="form-label">E-mail</label>
                    <asp:TextBox runat="server" CssClass="form-control" TextMode="Email"
                        ID="txtEmail" />
                </div>
                <div class="mb-3">
                    <label class="form-label">Nombres</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtNombre" />
                </div>
                <div class="mb-3">
                    <label class="form-label">Apellidos</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtApellido" />
                </div>
            </div>
            <div class="col-md-4">
                <div class="mb-3">
                    <label class="form-label">Foto de Perfil</label>
                    <input type="file" id="txtImagen" runat="server" class="form-control" />
                </div>
                <asp:Image ImageUrl="https://www.svgrepo.com/show/508699/landscape-placeholder.svg"
                    runat="server" ID="imgNuevoPerfil" CssClass="img-fluid mb-3" />
            </div>
        </div>
        <div class="row mt-3">
            <div class="col-md-4">
                <asp:Button Text="Guardar" CssClass="btn btn-danger" ID="btnGuardar"
                    OnClick="btnGuardar_Click" runat="server" />
            </div>
        </div>
    </asp:Panel>
</asp:Content>
