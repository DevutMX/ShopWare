<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.master" CodeBehind="Registro.aspx.cs" Inherits="WebShop.Registro" %>

<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
    <div align="center">
        <table>
            <tr>
                <td><div align="center"><h1>¡Unete a WebShop ahora!</h1></div></td>
            </tr>
            <tr>
                <td><div align="center"><img src="Images/sistema/WinStore.png" alt="Usuario" width="150" height="150" /></div></td>
            </tr>
            <tr>
                <td>
                    <div align="left">Nombre:
                        <dx:ASPxTextBox ID="txtNombre" runat="server" Width="100%" Font-Size="Medium">
                        </dx:ASPxTextBox>
                        Apellidos:
                        <dx:ASPxTextBox ID="txtApellidos" runat="server" Width="100%" Font-Size="Medium">
                        </dx:ASPxTextBox>
                        Domicilio:
                        <dx:ASPxTextBox ID="txtDomicilio" runat="server" Width="100%" Font-Size="Medium">
                        </dx:ASPxTextBox>
                        Teléfono:
                        <dx:ASPxTextBox ID="txtTelefono" runat="server" Width="100%" Font-Size="Medium">
                        </dx:ASPxTextBox>
                        Correo:
                        <dx:ASPxTextBox ID="txtCorreo" runat="server" Width="100%" Font-Size="Medium">
                        </dx:ASPxTextBox>
                        Usuario:
                        <dx:ASPxTextBox ID="txtUsuario" runat="server" Width="100%" Font-Size="Medium">
                        </dx:ASPxTextBox>
                        Contraseña:
                        <dx:ASPxTextBox ID="txtPassword" runat="server" Width="100%" Font-Size="Medium" Password="True">
                        </dx:ASPxTextBox>
                        Foto:
                        <dx:ASPxUploadControl ID="uploadFoto" runat="server" UploadMode="Auto" Width="100%" UploadStorage="FileSystem">
                            <ValidationSettings  MaxFileSize="4194304" AllowedFileExtensions=".jpg,.jpeg,.gif,.png" />
                            <BrowseButton Text="Buscar...">
                            </BrowseButton>
                        </dx:ASPxUploadControl>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div align="center" width="100%" height="100%">
                        <div style="float: left;">
                            <dx:ASPxButton ID="btnRegistrarte" runat="server" Text="Registrarme" OnClick="btnRegistrarte_Click">
                            </dx:ASPxButton>
                        </div>
                        <div style="float: right;">
                            <dx:ASPxButton ID="btnAcceder" runat="server" Text="¡Ya estoy registrado!" OnClick="btnAcceder_Click">
                            </dx:ASPxButton>
                        </div>
                    </div>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>