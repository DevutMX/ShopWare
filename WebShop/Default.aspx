<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.master" CodeBehind="Default.aspx.cs" Inherits="WebShop._Default" %>

<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">

    <dx:ASPxImageSlider ID="ASPxImageSlider1" runat="server" ImageSourceFolder="~/Images/Juegos" Width="100%">
        <SettingsImageArea EnableLoopNavigation="True" />
        <SettingsAutoGeneratedImages ImageCacheFolder="~/Thumb/" />
    </dx:ASPxImageSlider>

</asp:Content>