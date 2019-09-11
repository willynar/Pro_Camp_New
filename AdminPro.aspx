<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AdminPro.aspx.cs" Inherits="AdminPro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="scrollPro scroll">
        <asp:Button ID="Button11" runat="server" BorderStyle="None" CssClass="ButPagIni ButPag" OnClick="Button11_Click" Text="Volver  menu" />
        <asp:DataList ID="DataList1" runat="server" DataKeyField="pro_cod" DataSourceID="SqlDataSource1" RepeatColumns="3" RepeatDirection="Horizontal" OnItemCommand="DataList1_ItemCommand">
            <ItemTemplate>
                Catalogo:
            <asp:Label ID="cod_catLabel" runat="server" Text='<%# Eval("cod_cat") %>' />
                <br />
                Codigo usuario:
            <asp:Label ID="usu_codLabel" runat="server" Text='<%# Eval("usu_cod") %>' />
                <br />
                Valor:
            <asp:Label ID="pro_vlr_ventaLabel" runat="server" Text='<%# Eval("pro_vlr_venta") %>' />
                <br />
                Cantidad:
            <asp:Label ID="pro_canLabel" runat="server" Text='<%# Eval("pro_can") %>' />
                <br />
                Nombre:
            <asp:Label ID="pro_nomLabel" runat="server" Text='<%# Eval("pro_nom") %>' />
                <br />
                Codigo de producto:
            <asp:Label ID="pro_codLabel" runat="server" Text='<%# Eval("pro_cod") %>' />
                <br />
                <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("pro_cod", "manejadorImg.ashx?pro_cod={0}") %>' BorderStyle="None" CssClass="imgPro" />
                <br />
                <asp:Button ID="Button10" runat="server" BorderStyle="None" CssClass="ButPag" Text="Eliminar" CommandArgument='<%# Eval("pro_cod") %>' CommandName="Eliminar"/>
                <br />
            </ItemTemplate>
        </asp:DataList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:conexion_sin_clave %>" SelectCommand="SELECT [cod_cat], [usu_cod], [pro_vlr_venta], [pro_can], [pro_nom], [pro_cod] FROM [tbl_producto]"></asp:SqlDataSource>
    </div>
</asp:Content>

