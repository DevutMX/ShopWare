<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Backend.Master" CodeBehind="Dashboard.aspx.cs" Inherits="WebShop.Dashboard" %>

<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <table width="100%">
            <tr>
                <th colspan="3"><div align="center">Opciones disponibles</div></th>
            </tr>
            <tr>
                <td width="33%"><div align="center"><a href="#"><img src="Images/sistema/Clientes.png" alt="Clientes"/><br />Clientes</a></div></td>
                <td width="33%"><div align="center"><a href="#"><img src="Images/sistema/Ventas.png" alt="Ventas"/><br />Ventas</a></div></td>
                <td width="33%"><div align="center"><a href="#"><img src="Images/sistema/Usuarios.png" alt="Usuarios"/><br />Usuarios</a></div></td>
            </tr>
            <tr>
                <td width="33%"><div align="center"><a href="#"><img src="Images/sistema/Pago.png" alt="Formas de pago"/><br />Formas de pago</a></div></td>
                <td width="33%"><div align="center"><a href="#"><img src="Images/sistema/Cerrar.png" alt="Cerrar Sesion"/><br />Cerrar Sesión</a></div></td>
            </tr>
        </table>
    </div>
</asp:Content>