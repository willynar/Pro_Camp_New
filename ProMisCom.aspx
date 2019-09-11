<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ProMisCom.aspx.cs" Inherits="ProMisCom" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="scrollPro scroll fomTotPagDat">
        <asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource1" DataKeyField="ven_cod" OnItemCommand="DataList1_ItemCommand" HorizontalAlign="Justify" RepeatColumns="1" CellPadding="5" CellSpacing="5" RepeatDirection="Horizontal">
            <ItemStyle BackColor="White" BorderColor="#666666" BorderStyle="None" BorderWidth="1px" />
            <ItemTemplate>
                Fecha en que se realizo:
            <asp:Label ID="ven_fecLabel" runat="server" Text='<%# Eval("ven_fec") %>' />
                <br />
                codigo de venta:
            <asp:Label ID="ven_codLabel" runat="server" Text='<%# Eval("ven_cod") %>' />
                <br />
                <asp:Button ID="Button10" runat="server" BorderStyle="None" CssClass="ButPag ButPagIni" Text="Ver Detalles" CommandArgument='<%# Eval("ven_cod") %>' CommandName="detalle" />
                <br />
            </ItemTemplate>
        </asp:DataList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:conexion_sin_clave %>" SelectCommand="SELECT DISTINCT tbl_venta.ven_fec, tbl_venta.ven_cod FROM tbl_venta INNER JOIN tbl_det_venta ON tbl_venta.ven_cod = tbl_det_venta.ven_cod INNER JOIN tbl_producto ON tbl_det_venta.pro_cod = tbl_producto.pro_cod WHERE (tbl_venta.usu_cod = @usu_c) AND (tbl_venta.ven_est = @ven_est)">
            <SelectParameters>
                <asp:SessionParameter Name="usu_c" SessionField="usu_c" />
                <asp:Parameter DefaultValue="Activa" Name="ven_est" />
            </SelectParameters>
        </asp:SqlDataSource>
    </div>
    <div class="contImglog">
        <asp:Image ID="Image1" runat="server" ImageUrl="~/img/Group 7.png" CssClass="imgReg" />
    </div>
</asp:Content>

