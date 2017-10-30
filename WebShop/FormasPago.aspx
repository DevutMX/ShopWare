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
                    <dx:ASPxComboBox ID="cbxFormasPago" runat="server" Height="16px" ValueType="System.String" Width="375px">
                    </dx:ASPxComboBox>
                    <dx:ASPxButton ID="btnBorrar" runat="server" Text="Borrar" OnClick="btnBorrar_Click">
                    </dx:ASPxButton>
                </td>
            </tr>
            <tr>
                <td>
                    <div align="right"><p>Agregar forma de pago: </p>
                    </div>
                </td>
                <td>
                    <div>
                        <dx:ASPxTextBox ID="txtFormaPago" runat="server" Width="377px">
                        </dx:ASPxTextBox>
                        <dx:ASPxCheckBox ID="chkRequiereTarjeta" runat="server" Text="Requiere datos bancarios">
                        </dx:ASPxCheckBox>
                    </div>
                    <div style="margin-top: 15px;">
                        <dx:ASPxButton ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click">
                        </dx:ASPxButton>
                    </div>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>