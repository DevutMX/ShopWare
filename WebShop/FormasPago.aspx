<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Backend.Master" CodeBehind="FormasPago.aspx.cs" Inherits="WebShop.FormasPago" %>

<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <table style="width:100%;">
            <tr>
                <th colspan="2"><div align="center"><h1>Formas de pago</h1></div></th>
            </tr>
            <tr>
                <td>
                    <div align="right"><p>Formas de pago actualmente disponibles:</p>
                    </div>
                </td>
                <td>
                    <dx:ASPxDropDownEdit ID="cbxFormasPago" runat="server" Height="16px" Width="382px">
                    </dx:ASPxDropDownEdit>
                </td>
            </tr>
            <tr>
                <td>
                    <div align="right"><p>Agregar forma de pago: </p>
                    </div>
                </td>
                <td>
                    <div>
                        <dx:ASPxTextBox ID="ASPxTextBox1" runat="server" Width="377px">
                        </dx:ASPxTextBox>
                    </div>
                    <div style="margin-top: 15px;">
                        <dx:ASPxButton ID="ASPxButton1" runat="server" Text="Agregar">
                        </dx:ASPxButton>
                    </div>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>