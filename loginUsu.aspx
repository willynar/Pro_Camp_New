<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="loginUsu.aspx.cs" Inherits="loginUsu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="FormLog FleJus">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Celular"></asp:Label>
            <br />
            <asp:TextBox ID="Celular" runat="server" CssClass="cajTxt" onpaste="return false" oncut="return false" oncopy="return false" MaxLength="10"></asp:TextBox>
            <br />
            <asp:Label ID="Label13" runat="server" ForeColor="Red"></asp:Label>
            <br />
            <asp:HyperLink ID="HyperLink1" runat="server" ForeColor="#000066" NavigateUrl="~/Registro.aspx">Crear Cuenta</asp:HyperLink>
        </div>
    </div>
    <div class="FormLogBut FleJus">
        <div>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Siguiente" BorderStyle="None" CssClass="ButPag" />
        </div>
    </div>
    <div class="contImglog">
        <asp:Image ID="Image1" runat="server" ImageUrl="~/img/Group 7.png" CssClass="imgReg" />
    </div>
</asp:Content>

