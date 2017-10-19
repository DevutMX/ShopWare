<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.master" CodeBehind="Contacto.aspx.cs" Inherits="WebShop.Contacto" %>

<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d1893.2661650584591!2d-99.53442545962612!3d18.368608196782795!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x85cc381ad0af88e3%3A0xefdd470609165b17!2sOrqu%C3%ADdeas+14%2C+PPG%2C+40025+Iguala+de+la+Independencia%2C+Gro.!5e0!3m2!1ses-419!2smx!4v1508391155691" height="450" frameborder="0" style="border-style: none; border-color: inherit; border-width: 0; float:left; width: 100%;" allowfullscreen></iframe>
        <table style="width:100%;">
            <tr>
                <th style="width: 50%;">Datos de contacto</th>
                <th style="width: 17%;"></th>
                <th style="width: 33%"></th>
            </tr>
            <tr>
                <td><img src="Images/sistema/phone.png" width="20" height="20" alt="Telefono" />    (733) 104 7641</td>
                <td rowspan="3" style="align-content:center;"><div align="center"><img src="Images/sistema/WinStore.png" width="100" height="100" alt="WebShop"/></div></td>
                <td rowspan="3"><p align="center" style="font-size: large;"><strong>WebShop</strong><br /><span>Tú mejor opción en software</span></p></td>
            </tr>
            <tr>
                <td><img src="Images/sistema/address.png" width="20" height="20" alt="Direccion" />    Orquideas #14, Col. PPG. Iguala de la Independencia, Gro. México</td>
            </tr>
            <tr>
                <td><img src="Images/sistema/email.png" width="20" height="20" alt="Email" /> <a target="_blank" href="mailto:support@devutmx.com">support@devutmx.com</a></td>
            </tr>
            <tr>
                <td colspan="3"><p align="center">Empresa socialmente responsable.</p></td>
            </tr>
        </table>
    </div>
</asp:Content>