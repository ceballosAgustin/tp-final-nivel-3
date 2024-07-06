<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="comercio_web.Registro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .container {
            width: 100%;
        }

        .registro-container {
            margin: 20px auto;
            width: 40%;
            background: #fff;
            padding: 60px 50px;
            border-radius: 5px;
        }

        .registro-header h2 {
            font-size: 28px;
            color: #FF3131;
            font-weight: bold;
            text-align: left;
        }

        .registro-header p {
            font-size: 14px;
            color: #777;
            text-align: left;
        }

        .form-label {
            margin-bottom: 10px;
        }

        .form-control {
            margin-bottom: 20px;
        }

        .btn-registro {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="registro-container">
            <div class="mb-4 registro-header">
                <h2>Registro</h2>
                <p>Registrate para aprovechar ya mismo todos los productos que HADESTOCK tiene para ti</p>
            </div>
            <div class="mb-3">
                <label class="form-label">Nombres</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtNombre" placeholder="José" required />
            </div>
            <div class="mb-3">
                <label class="form-label">Apellidos</label>
                <asp:TextBox type="" runat="server" CssClass="form-control" ID="txtApellido" placeholder="Gómez" required />
            </div>
            <div class="mb-3">
                <label class="form-label">E-mail</label>
                <asp:TextBox runat="server" type="email" CssClass="form-control" ID="txtEmail" placeholder="jgomez@gmail.com" required />
            </div>
            <div class="mb-3">
                <label class="form-label">Contraseña</label>
                <asp:TextBox runat="server" type="password" CssClass="form-control" ID="txtPassword" placeholder="••••••••••" required />
            </div>
            <p>¿Ya tienes una cuenta? <a href="Default.aspx">Iniciar Sesión</a></p>
            <asp:Button type="submit" CssClass="btn btn-danger btn-registro" Text="Regístrarme" ID="btnRegistro" OnClick="btnRegistro_Click" runat="server" />
        </div>
    </div>
</asp:Content>
