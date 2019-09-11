<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DatUsuCamPass.aspx.cs" Inherits="DatUsuCamPass" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="FormActCue FleJus">
        <div>

            <asp:Label ID="Label15" runat="server" Text="Contraseña Actual"></asp:Label>
            <asp:Label ID="Label18" runat="server" ForeColor="#CC0000"></asp:Label>
            <br />
            <asp:TextBox ID="ContraseñaActual" runat="server" CssClass="cajTxt" TextMode="Password"></asp:TextBox>
            <br />
            <asp:Label ID="Label16" runat="server" Text="Nueva Contraseña"></asp:Label>
            <asp:Label ID="Label19" runat="server" ForeColor="#CC0000"></asp:Label>
            <br />
            <asp:TextBox ID="NuevaContraseña" runat="server" CssClass="cajTxt" TextMode="Password"></asp:TextBox>
            <br />
            <asp:Label ID="Label17" runat="server" Text="Confirmar Contraseña"></asp:Label>
            <asp:Label ID="Label20" runat="server" ForeColor="#CC0000"></asp:Label>
            <br />
            <asp:TextBox ID="Confirmar" runat="server" CssClass="cajTxt" TextMode="Password"></asp:TextBox>
            <br />
            <asp:Button ID="Button10" runat="server" BorderStyle="None" CssClass="ButPag ButPagIni" OnClick="Button10_Click" Text="Actualizar" />
        </div>
    </div>
    <div class="contImglog">
        <asp:Image ID="Image1" runat="server" ImageUrl="~/img/Group 7.png" CssClass="imgReg" />
    </div>
</asp:Content>

