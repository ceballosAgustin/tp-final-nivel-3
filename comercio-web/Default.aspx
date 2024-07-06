<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="comercio_web.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .container {
            width: 100%;
        }

        .login-container {
            margin: 20px auto;
            width: 40%;
            background: #fff;
            padding: 60px 50px;
            border-radius: 5px;
        }

        .login-header h2 {
            font-size: 28px;
            color: #FF3131;
            font-weight: bold;
            text-align: left;
        }

        .login-header p {
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

        .btn-login {
            width: 100%;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="login-container">
            <div class="mb-4 login-header">
                <h2>Ingreso</h2>
                <p>Para disfrutar de todos los productos que HADESTOCK tiene para ti, debés identificarte</p>
            </div>
            <div class="mb-3">
                <label class="form-label">E-mail</label>
                <asp:TextBox runat="server" type="email" CssClass="form-control" required ID="txtEmail" placeholder="jgomez@gmail.com" />
            </div>
            <div class="mb-3">
                <label class="form-label">Contraseña</label>
                <asp:TextBox runat="server" type="password" CssClass="form-control" required ID="txtPassword" placeholder="••••••••••" />
            </div>
            <p>¿No tienes una cuenta? <a href="Registro.aspx">Regístrate</a></p>
            <asp:Button type="submit" CssClass="btn btn-danger btn-login" Text="Iniciar Sesión" ID="btnLogin" OnClick="btnLogin_Click" runat="server" />
        </div>
    </div>
</asp:Content>
