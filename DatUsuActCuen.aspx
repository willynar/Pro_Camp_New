<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DatUsuActCuen.aspx.cs" Inherits="DatUsuActCuen" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .auto-style2 {
            margin-bottom: 0;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="FormActCue FleJus">
        <div>
            <asp:Label ID="Label15" runat="server" Text="Numero de cuenta"></asp:Label>
            <asp:Label ID="Label17" runat="server" ForeColor="#CC0000"></asp:Label>
            <br />
            <asp:TextBox ID="NumeroCuenta" runat="server" CssClass="cajTxt"></asp:TextBox>
            <br />
            <asp:Label ID="Label16" runat="server" Text="Banco"></asp:Label>
            <asp:Label ID="Label18" runat="server" ForeColor="#CC0000"></asp:Label>
            <br />
            <asp:TextBox ID="NombreBanco" runat="server" CssClass="cajTxt"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button10" runat="server" CssClass="ButPag ButPagIni" OnClick="Button10_Click" Text="Actualizar" />
            <br />
        </div>
    </div>
    <div class="contImglog">
        <asp:Image ID="Image1" runat="server" ImageUrl="~/img/Group 7.png" CssClass="imgReg" />
    </div>
</asp:Content>

