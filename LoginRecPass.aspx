<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="LoginRecPass.aspx.cs" Inherits="LoginRecPass" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <asp:Label ID="Label13" runat="server" Text="Correo Actual"></asp:Label>
        <br />
        <asp:TextBox ID="Correo" runat="server" CssClass="cajTxt" TextMode="Email"></asp:TextBox>
        <br />
        <asp:Label ID="Label14" runat="server" ForeColor="#CC0000"></asp:Label>
        <br />
        <asp:Button ID="Button10" runat="server" BorderStyle="None" CssClass="ButPag" OnClick="Button10_Click" Text="Enviar" />

    </div>
</asp:Content>

