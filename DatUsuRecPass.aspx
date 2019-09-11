<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DatUsuRecPass.aspx.cs" Inherits="DatUsuRecPass" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="FormRecCont">
        <div>
            <asp:Label ID="Label13" runat="server" Text="Celular Actual"></asp:Label>
            <asp:Label ID="Label17" runat="server" ForeColor="#CC0000"></asp:Label>
            <br />
            <asp:TextBox ID="Celular" runat="server" CssClass="cajTxt" MaxLength="10" TextMode="Number"></asp:TextBox>
            <br />
            <asp:Label ID="Label14" runat="server" Text="Correo Actual"></asp:Label>
            <asp:Label ID="Label18" runat="server" ForeColor="#CC0000"></asp:Label>
            <br />
            <asp:TextBox ID="Correo" runat="server" CssClass="cajTxt" TextMode="Email"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label15" runat="server" Text="Nueva Contraseña"></asp:Label>
            <asp:Label ID="Label19" runat="server" ForeColor="#CC0000"></asp:Label>
            <br />
            <asp:TextBox ID="NuevaContraseña" runat="server" CssClass="cajTxt"></asp:TextBox>
            <br />
            <asp:Label ID="Label16" runat="server" Text="Confirmar Contraseña"></asp:Label>
            <asp:Label ID="Label20" runat="server" ForeColor="#CC0000"></asp:Label>
            <br />
            <asp:TextBox ID="Confirmar" runat="server" CssClass="cajTxt"></asp:TextBox>
            <br />
        </div>
    </div>
    <div class="FormRecContBut">
        <div>
            <asp:Button ID="Button10" runat="server" BorderStyle="None" CssClass="ButPag" Text="Cambiar" OnClick="Button10_Click" />
        </div>
    </div>
    <div class="contImglog">
        <asp:Image ID="Image1" runat="server" ImageUrl="~/img/Group 7.png" CssClass="imgReg" />
    </div>
</asp:Content>

