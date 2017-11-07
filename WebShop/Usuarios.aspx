<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Backend.Master" CodeBehind="Usuarios.aspx.cs" Inherits="WebShop.Usuarios" %>

<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <table style="width:100%;">
            <tr>
                <th><div align="center"><img style="float: left;" src="Images/sistema/Usuarios.png" alt="Ventas" /><h1>Usuarios registrados en WebShop</h1></div>
                </th>
            </tr>
            <tr>
                <td>
                    <dx:ASPxGridView Width="100%" ID="gdvUsuarios" runat="server">
                        <SettingsPager Visible="False">
                        </SettingsPager>
                        <SettingsDataSecurity AllowDelete="False" AllowEdit="False" AllowInsert="False" />
                    </dx:ASPxGridView>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>