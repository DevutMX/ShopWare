﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.master" CodeBehind="Login.aspx.cs" Inherits="WebShop.Login" %>

<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
    <div align="center">
        <table>
            <tr>
                <td><div align="center"><h1>Inicia sesión para continuar</h1></div></td>
            </tr>
            <tr>
                <td><div align="center"><img src="Images/sistema/Users.png" alt="Usuario" width="150" height="150" /></div></td>
            </tr>
            <tr>
                <td>
                    <div align="left">Usuario:
                        <dx:ASPxTextBox ID="ASPxTextBox1" runat="server" Width="100%" Font-Size="Medium">
                        </dx:ASPxTextBox>
                        Contrase&ntilde;a:
                        <dx:ASPxTextBox ID="ASPxTextBox2" runat="server" Width="100%" Font-Size="Medium" Password="True">
                        </dx:ASPxTextBox>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div align="center" width="100%" height="100%">
                        <div style="float: left;">
                            <dx:ASPxButton ID="ASPxButton1" runat="server" Text="Registrate">
                            </dx:ASPxButton>
                        </div>
                        <div style="float: right;">
                            <dx:ASPxButton ID="ASPxButton2" runat="server" Text="Acceder">
                            </dx:ASPxButton>
                        </div>
                    </div>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>