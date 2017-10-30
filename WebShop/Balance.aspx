<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Backend.Master" CodeBehind="Balance.aspx.cs" Inherits="WebShop.Balance" %>

<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <table style="width:100%;">
            <tr>
                <th><div align="center"><img style="float: left;" src="Images/sistema/SaldoDisponible.png" alt="Balance" /><h1>Saldo disponible en el banco</h1></div>
                </th>
            </tr>
            <tr>
                <td>
                    <div align="center"><h1>Saldo actual de:</h1><dx:ASPxLabel ID="lblSaldo" runat="server" Font-Size="XX-Large" ForeColor="#009933" Text="$ 0.00 MXN">
                        </dx:ASPxLabel></div>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>