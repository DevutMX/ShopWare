<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Backend.Master" CodeBehind="Ventas.aspx.cs" Inherits="WebShop.Ventas" %>

<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <table style="width:100%;">
            <tr>
                <th><div align="center"><img style="float: left;" src="Images/sistema/Ticket.png" alt="Ventas" /><h1>Listado de ventas registradas</h1></div>
                </th>
            </tr>
            <tr>
                <td>
                    <dx:ASPxGridView Width="100%" ID="ASPxGridView1" runat="server">
                        <SettingsPager Visible="False">
                        </SettingsPager>
                        <SettingsDataSecurity AllowDelete="False" AllowEdit="False" AllowInsert="False" />
                    </dx:ASPxGridView>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>