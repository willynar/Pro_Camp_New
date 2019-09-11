<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="loginPass.aspx.cs" Inherits="loginPass" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="FormLog FleJus">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Contraseña"></asp:Label>
            <br />
            <asp:TextBox ID="Contraseña" runat="server" TextMode="Password" CssClass="cajTxt" MaxLength="30"></asp:TextBox>
            <br />
            <asp:Label ID="Label13" runat="server" ForeColor="Red"></asp:Label>
            <br />
            <asp:HyperLink ID="HyperLink1" runat="server" ForeColor="#000066" NavigateUrl="~/LoginRecPass.aspx">Recuperar Contraseña</asp:HyperLink>
        </div>
    </div>
    <div class="FormLogBut FleJus">
        <div>
            <asp:Button ID="Button6" runat="server" Text="Atras" BorderStyle="None" CssClass="ButPag" OnClick="Button6_Click" />
            <asp:Button ID="Button1" runat="server" Text="Ingresar" OnClick="Button1_Click" BorderStyle="None" CssClass="ButPag" />
        </div>
    </div>
    <div class="contImglog">
        <asp:Image ID="Image1" runat="server" ImageUrl="~/img/Group 7.png" CssClass="imgReg" />
    </div>
</asp:Content>

