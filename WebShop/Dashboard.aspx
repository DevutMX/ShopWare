<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Backend.Master" CodeBehind="Dashboard.aspx.cs" Inherits="WebShop.Dashboard" %>

<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <table width="100%">
            <tr>
                <th colspan="3"><div align="center"><h1>Opciones disponibles</h1></div></th>
            </tr>
            <tr>
                <td width="33%"><div align="center"><img src="Images/sistema/Clientes.png" alt="Clientes"/><br /><dx:ASPxButton ID="btnClientes" runat="server" Text="Clientes" OnClick="btnClientes_Click"></dx:ASPxButton></div></td>
                <td width="33%"><div align="center"><img src="Images/sistema/Ventas.png" alt="Ventas"/><br /><dx:ASPxButton ID="btnVentas" runat="server" Text="Ventas" OnClick="btnVentas_Click"></dx:ASPxButton></div></td>
                <td width="33%"><div align="center"><img src="Images/sistema/Usuarios.png" alt="Usuarios"/><br /><dx:ASPxButton ID="btnUsuarios" runat="server" Text="Usuarios" OnClick="btnUsuarios_Click"></dx:ASPxButton></div></td>
            </tr>
            <tr>
                <td width="33%"><div align="center"><img src="Images/sistema/Pago.png" alt="Formas de pago"/><br /><dx:ASPxButton ID="btnFormasPago" runat="server" Text="Formas de pago" OnClick="btnFormasPago_Click"></dx:ASPxButton></div></td>
                <td width="33%"><div align="center"><img src="Images/sistema/Cerrar.png" alt="Cerrar Sesion"/><br /><dx:ASPxButton ID="btnCerrarSesion" runat="server" Text="Cerrar Sesión" OnClick="btnCerrarSesion_Click"></dx:ASPxButton></div></td>
                <td width="33%"><div align="center"><img src="Images/sistema/SaldoDisponible.png" alt="Balance"/><br /><dx:ASPxButton ID="btnSaldoActual" runat="server" Text="Saldo actual" OnClick="btnSaldoActual_Click"></dx:ASPxButton></div></td>
            </tr>
        </table>
    </div>
</asp:Content>