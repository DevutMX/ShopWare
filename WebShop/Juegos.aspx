﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.master" CodeBehind="Juegos.aspx.cs" Inherits="WebShop.Juegos" %>

<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <table style="width:100%;">
            <tr>
                <th style="width: 18%;"></th>
                <th style="width: 70%">Descripción</th>
                <th style="width: 12%">Precio</th>
            </tr>
            <tr>
                <td><img src="Images/Juegos/Doom.jpg" align="center" width="250" height="180" alt="Doom" /></td>
                <td><p align="justify">DOOM, desarrollado por id Software, estudio pionero en el género de los shooters en primera persona y creador de las partidas multijugador en formato Deathmatch, regresa una vez más como un moderno shooter repleto de diversión y desafíos. Despiadados demonios, armas de destrucción inimaginables y un movimiento ágil y fluido constituyen la base de un intenso combate en primera persona, tanto si estás cargándote a las hordas demoníacas del infierno en la campaña para un jugador como si compites contra amigos en los diversos modos multijugador. Amplía tu experiencia de juego con DOOM SnapMap, el editor de juego que permite crear, jugar y compartir contenidos con el resto del mundo.</p></td>
                <td><p align="center">$ 699.00 MXN</p></td>
            </tr>
            <tr>
                <td><p align="center"><b>DOOM</b></p></td>
                <td><b>Tags:</b>   FPS, Shooter, Demonios</td>
                <td><div align="center"><dx:ASPxButton ID="btnDoom" runat="server" Text="Comprar" BackColor="#009900" ForeColor="White" OnClick="btnDoom_Click"></dx:ASPxButton></div></td>
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td></td>
            </tr>
            <!-- Siguiente producto -->
            <tr>
                <th style="width: 18%;"></th>
                <th style="width: 70%">Descripción</th>
                <th style="width: 12%">Precio</th>
            </tr>
            <tr>
                <td><img src="Images/Juegos/Battlefront2.jpg" align="center" width="250" height="180" alt="Star wars" /></td>
                <td><p align="justify">La beta multijugador de Star Wars  Battlefront II ya ha terminado. Los jugadores han luchado en distintos escenarios de Asalto galáctico, se han enfrentado a oleadas de enemigos controlados por la IA en Arcade, se han unido a escuadrones de amigos en Asalto de cazas estelares y han subido al máximo sus habilidades de soldado en las misiones de Ataque ocho contra ocho.</p></td>
                <td><p align="center">$ 1,399.00 MXN</p></td>
            </tr>
            <tr>
                <td><p align="center"><b>Star Wars Battlefront II</b></p></td>
                <td><b>Tags:</b>   Ciencia Ficción, Espacio, Batallas</td>
                <td><div align="center"><dx:ASPxButton ID="btnStarWars" runat="server" Text="Comprar" BackColor="#009900" ForeColor="White" OnClick="btnStarWars_Click"></dx:ASPxButton></div></td>
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td></td>
            </tr>
            <!-- Siguiente producto -->
            <tr>
                <th style="width: 18%;"></th>
                <th style="width: 70%">Descripción</th>
                <th style="width: 12%">Precio</th>
            </tr>
            <tr>
                <td><img src="Images/Juegos/Battlefield1.jpg" align="center" width="250" height="180" alt="Battlefield 1" /></td>
                <td><p align="justify">Únete a la comunidad de Battlefield y descubre la guerra total. Descubre las historias no contadas de la Primera Guerra Mundial con la intensidad incomparable que incluye el Premium Pass y la experiencia siempre en aumento de Battlefield.

Battlefield 1 Revolution te permite participar en la Gran Guerra a través de enormes batallas multijugador por equipos. Con roles de combate únicos por tierra, mar y aire, ninguna batalla es igual. O descubre un mundo en guerra a través de la campaña para un solo jugador con las Historias de guerra.</p></td>
                <td><p align="center">$ 800.00 MXN</p></td>
            </tr>
            <tr>
                <td><p align="center"><b>Battlefield 1</b></p></td>
                <td><b>Tags:</b>   WWII, Shooter, Historico</td>
                <td><div align="center"><dx:ASPxButton ID="btnBattlefield" runat="server" Text="Comprar" BackColor="#009900" ForeColor="White" OnClick="btnBattlefield_Click"></dx:ASPxButton></div></td>
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td></td>
            </tr>
            <!-- Siguiente producto -->
            <tr>
                <th style="width: 18%;"></th>
                <th style="width: 70%">Descripción</th>
                <th style="width: 12%">Precio</th>
            </tr>
            <tr>
                <td><img src="Images/Juegos/YookaLaylee.jpg" align="center" width="250" height="180" alt="Yooka & Laylee" /></td>
                <td><p align="justify">¡Yooka-Laylee es un nuevo juego de plataformas de mundo abierto de los veteranos del género Playtonic!

Explora mundos vastos y preciosos, conoce (y vence) a un reparto inolvidable de personajes y acumula un montón de brillantes coleccionables mientras la pareja de Yooka (el verde) y Laylee (la murciélago ocurrente de nariz grande) se embarcan en una aventura épica para acabar con el malvado empresario Capital B y su retorcidos planes para absorber todos los libros del mundo... ¡Y convertirlos en beneficio puro!</p></td>
                <td><p align="center">$ 459.00 MXN</p></td>
            </tr>
            <tr>
                <td><p align="center"><b>Yooka & Laylee</b></p></td>
                <td><b>Tags:</b>   Plataformas, Cartoon, Aventura</td>
                <td><div align="center"><dx:ASPxButton ID="btnYooka" runat="server" Text="Comprar" BackColor="#009900" ForeColor="White" OnClick="btnYooka_Click"></dx:ASPxButton></div></td>
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td></td>
            </tr>
            <!-- Siguiente producto -->
            <tr>
                <th style="width: 18%;"></th>
                <th style="width: 70%">Descripción</th>
                <th style="width: 12%">Precio</th>
            </tr>
            <tr>
                <td><img src="Images/Juegos/Wolfenstein.jpg" align="center" width="250" height="180" alt="Wolfenstein" /></td>
                <td><p align="justify">Wolfenstein® II, una emocionante aventura hecha realidad gracias al motor id Tech® 6, líder en el sector, enviará a los jugadores a unos Estados Unidos que se encuentran bajo el control nazi, en una misión para reclutar a los líderes más audaces de la resistencia que queden con vida. Combate a los nazis en lugares emblemáticos tales como la pequeña ciudad de Roswell, Nuevo México, las inundadas calles de Nueva Orleans y un Manhattan posnuclear. Equípate con un arsenal de armas brutales y desata nuevas habilidades para abrirte paso a través de legiones de avanzados soldados, cíborgs y über-soldados en este shooter en primera persona definitivo.</p></td>
                <td><p align="center">$ 1,099.00 MXN</p></td>
            </tr>
            <tr>
                <td><p align="center"><b>Wolfenstein II The new colossus</b></p></td>
                <td><b>Tags:</b>   Shooter, FPS, WWII</td>
                <td><div align="center"><dx:ASPxButton ID="btnWolfenstein" runat="server" Text="Comprar" BackColor="#009900" ForeColor="White" OnClick="btnWolfenstein_Click"></dx:ASPxButton></div></td>
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td></td>
            </tr>
        </table>
    </div>
</asp:Content>
