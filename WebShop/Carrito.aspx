<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.master" CodeBehind="Carrito.aspx.cs" Inherits="WebShop.Carrito" %>

<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
    <div align="center">
        <img style="float: left;" src="Images/sistema/Carrito.png" alt="Carrito" />
        <h1> Tu Carrito de compras</h1>
        <h4>Aquí podrás ver tu carrito de compra</h4>
    </div>
    <div align="center">
        <p style="float: left;">
            <dx:ASPxLabel ID="lblTicket" runat="server" Text="Ticket" Font-Size="Medium" ForeColor="Red" Visible="False">
            </dx:ASPxLabel>
        </p>
        <p style="float: right;">
            <dx:ASPxLabel ID="lblProductosAgregados" runat="server" Text="Productos" Font-Size="Medium" Visible="False">
            </dx:ASPxLabel>
        </p>
    </div>

    <%--<div align="center">
        <dx:ASPxGridView width="80%" ID="gdvCarrito" runat="server">
            <SettingsPager Visible="False">
            </SettingsPager>
            <SettingsDataSecurity AllowDelete="False" AllowEdit="False" AllowInsert="False" />
        </dx:ASPxGridView>
    </div>--%>

    <div align="center">
        <dx:ASPxGridView width="80%" ID="gdvCarrito" runat="server">
            <SettingsPager Visible="False">
            </SettingsPager>
            <SettingsDataSecurity AllowDelete="False" AllowEdit="False" AllowInsert="False" />
        </dx:ASPxGridView>
    </div>

    <div align="center">
        <table>
            <tr>
                <td>
                    <p style="float:left;">Modificar producto:</p>
                    <div style="float:left;">
                        <dx:ASPxTextBox  ID="ASPxTextBox5" runat="server" Width="50px">
                        </dx:ASPxTextBox>
                    </div>
                    <div  style="float:left;">
                        <dx:ASPxButton Paddings-Padding="4" ID="ASPxButton1" runat="server" Text="-" >
                        </dx:ASPxButton>
                    </div>
                    <div style="float:left;">
                        <dx:ASPxButton Paddings-Padding="4" ID="ASPxButton2" runat="server" Text="+" >
                        </dx:ASPxButton>
                    </div>
                    <div>
                        <dx:ASPxButton Paddings-Padding="4" ID="ASPxButton3" runat="server" Text="X" >
                        </dx:ASPxButton>
                    </div>
                </td>
                <td>

                </td>
            </tr>
        </table>
    </div>

    <asp:Panel ID="pnlTotal" runat="server" Visible="False">
    <div align="center">
        <table>
            <tr>
                <td>Subtotal: </td>
                <td>
                    <dx:ASPxLabel ID="lblSubtotal" runat="server" Text="$ 0.00">
                    </dx:ASPxLabel>
                </td>
                <td>Elija forma de pago:</td>
            </tr>
            <tr>
                <td>I.V.A.: </td>
                <td>
                    <dx:ASPxLabel ID="lblIVA" runat="server" Text="$ 0.00">
                    </dx:ASPxLabel>
                </td>
                <td>
                    <dx:ASPxComboBox AutoPostBack="true" ID="cbxFormasPago" runat="server" Height="16px" ValueType="System.String" Width="375px" OnSelectedIndexChanged="cbxFormasPago_SelectedIndexChanged">
                    </dx:ASPxComboBox>
                </td>
            </tr>
            <tr>
                <td>Monto a pagar: </td>
                <td>
                    <dx:ASPxLabel ID="lblTotal" runat="server" Text="$ 0.00">
                    </dx:ASPxLabel>
                </td>
                <td>
                    <div align="center">
                        <dx:ASPxButton ID="btnPagar" runat="server" Text="Pagar" Visible="False" OnClick="btnPagar_Click">
                        </dx:ASPxButton>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    </asp:Panel>

    <div align="center">
        <asp:Panel ID="pnlDatosBancarios" runat="server" Visible="False">
            <table width="60%">
                <tr>
                    <th colspan="6"><div align="center">Ingrese datos bancarios</div></th>
                </tr>
                <tr>
                    <td>Numero de tarjeta:</td>
                    <td colspan="5">
                        <dx:ASPxTextBox ID="txtTarjeta" runat="server" Width="100%">
                        </dx:ASPxTextBox>
                    </td>
                </tr>
                <tr>
                    <td>Nombre:</td>
                    <td colspan="5">
                        <dx:ASPxTextBox ID="ASPxTextBox1" runat="server" Width="100%">
                        </dx:ASPxTextBox>
                    </td>
                </tr>
                <tr>
                    <td>Mes:</td>
                    <td>
                        <dx:ASPxTextBox ID="ASPxTextBox2" runat="server" Width="100%">
                        </dx:ASPxTextBox>
                    </td>
                    <td>Año:</td>
                    <td>
                        <dx:ASPxTextBox ID="ASPxTextBox3" runat="server" Width="100%">
                        </dx:ASPxTextBox>
                    </td>
                    <td>CVV:</td>
                    <td>
                        <dx:ASPxTextBox ID="ASPxTextBox4" runat="server" Width="100%">
                        </dx:ASPxTextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                        <div align="center">
                            <dx:ASPxButton ID="btnPagarTarjeta" runat="server" Text="Pagar">
                            </dx:ASPxButton>
                        </div>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        
    </div>
</asp:Content>
