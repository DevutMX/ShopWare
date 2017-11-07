<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.master" CodeBehind="Carrito.aspx.cs" Inherits="WebShop.Carrito" %>

<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
    <div align="center">
        <img style="float: left;" src="Images/sistema/Carrito.png" alt="Carrito" />
        <h1> Tu Carrito de compras</h1>
        <h4>Aquí podrás ver tu carrito de compra</h4>
    </div>
    <div align="center">
        <dx:ASPxGridView Width="100%" ID="gdvCarrito" runat="server">
            <SettingsPager Visible="False">
            </SettingsPager>
            <SettingsDataSecurity AllowDelete="False" AllowEdit="False" AllowInsert="False" />
        </dx:ASPxGridView>
    </div>
    <div align="center">
        <dx:ASPxButton ID="btnPagar" runat="server" Text="Pagar" Visible="False">
        </dx:ASPxButton>
    </div>
</asp:Content>
