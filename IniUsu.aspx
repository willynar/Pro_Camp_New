<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="IniUsu.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="FormIniUsu">
        <asp:Label ID="Label13" runat="server" Text="Bienvenido" CssClass='titulo2'></asp:Label>
        <p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</p>
        <asp:Label ID="Label14" runat="server" CssClass="titulo2"></asp:Label>
    </div>
    <div class="FormIniUsuflex">
        <div class="FormIniUsuBut">
            <div>
                <asp:Label ID="Label4" runat="server" Text="Mis Datos"></asp:Label>
                <br />
                <asp:Button ID="Button10" runat="server" BorderStyle="None" CssClass="ButPag ButPagIni" Text="Cambiar Mis datos" OnClick="Button10_Click" />
                <br />
                <asp:Button ID="Button15" runat="server" BorderStyle="None" CssClass="ButPag ButPagIni" OnClick="Button15_Click" Text="Cuenta  bancaria" />

                <br />
                <asp:Button ID="Button20" runat="server" BorderStyle="None" CssClass="ButPag ButPagIni" OnClick="Button20_Click" Text="Cambiar contraseña" />

            </div>
        </div>
        <div class="FormIniUsuButVen">
            <asp:Label ID="Label1" runat="server" Text="Voy a Vender"></asp:Label>
            <br />
            <div>
                <asp:Button ID="Button13" runat="server" BorderStyle="None" CssClass="ButPag ButPagIni" OnClick="Button13_Click" Text="Agregar Productos" />
                <br />
                <asp:Button ID="Button11" runat="server" BorderStyle="None" CssClass="ButPag ButPagIni" Text="Mis Productos" OnClick="Button11_Click" />
                <br />
                <div>
                    <asp:Label ID="LabelCont" runat="server" ForeColor="#CC0000"></asp:Label>
                    <asp:Button ID="Button19" runat="server" BorderStyle="None" CssClass="ButPag ButPagIni" OnClick="Button19_Click" Text="Mis ventas" />
                </div>
            </div>
        </div>
        <div class="FormIniUsuButComp">
            <asp:Label ID="Label2" runat="server" Text="Voy a Comprar"></asp:Label>
            <br />
            <asp:Button ID="Button17" runat="server" BorderStyle="None" CssClass="ButPag ButPagIni" OnClick="Button17_Click" Text="Tienda" />
            <br />
            <asp:Button ID="Button12" runat="server" BorderStyle="None" CssClass="ButPag ButPagIni" Text="Mis compras" OnClick="Button12_Click" />
            <br />
            <asp:Button ID="Button16" runat="server" BorderStyle="None" CssClass="ButPag ButPagIni" OnClick="Button16_Click" Text="Mi carrito" />
        </div>
        <div class="FormIniAdmMen" runat="server" id="AdmForm">
            <asp:Label ID="Label3" runat="server" Text="Menu Administrador"></asp:Label>
            <br />
            <asp:Button ID="Button1" runat="server" Text="Eliminar Productos" BorderStyle="None" CssClass="ButPag ButPagIni" OnClick="Button1_Click1" />
            <br />
            <asp:Button ID="Button14" runat="server" BorderStyle="None" CssClass="ButPag ButPagIni" OnClick="Button14_Click" Text="Contacto y Redes" />
            <br />
            <asp:Button ID="Button18" runat="server" BorderStyle="None" CssClass="ButPag ButPagIni" OnClick="Button18_Click" Text="Editar usuarios" />
        </div>

    </div>
</asp:Content>
