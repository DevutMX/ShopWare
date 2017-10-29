<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Backend.Master" CodeBehind="Dashboard.aspx.cs" Inherits="WebShop.Dashboard" %>

<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <table width="100%">
            <tr>
                <th colspan="3"><div align="center"><h1>Opciones disponibles</h1></div></th>
            </tr>
            <tr>
                <td width="33%"><div align="center"><img src="Images/sistema/Clientes.png" alt="Clientes"/><dx:ASPxButton ID="btnClientes" runat="server" Text="Clientes"></dx:ASPxButton></div></td>
                <td width="33%"><div align="center"><img src="Images/sistema/Ventas.png" alt="Ventas"/><dx:ASPxButton ID="btnVentas" runat="server" Text="Ventas"></dx:ASPxButton></div></td>
                <td width="33%"><div align="center"><img src="Images/sistema/Usuarios.png" alt="Usuarios"/><dx:ASPxButton ID="btnUsuarios" runat="server" Text="Usuarios"></dx:ASPxButton></div></td>
            </tr>
            <tr>
                <td width="33%"><div align="center"><img src="Images/sistema/Pago.png" alt="Formas de pago"/><dx:ASPxButton ID="btnFormasPago" runat="server" Text="Formas de pago"></dx:ASPxButton></div></td>
                <td width="33%"><div align="center"><img src="Images/sistema/Cerrar.png" alt="Cerrar Sesion"/><dx:ASPxButton ID="btnCerrarSesion" runat="server" Text="Cerrar Sesión" OnClick="btnCerrarSesion_Click"></dx:ASPxButton></div></td>
                <td width="33%"><div align="center"><img src="Images/sistema/SaldoDisponible.png" alt="Balance"/><dx:ASPxButton ID="btnSaldoActual" runat="server" Text="Saldo actual"></dx:ASPxButton></div></td>
            </tr>
        </table>
    </div>
</asp:Content>