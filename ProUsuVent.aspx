<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ProUsuVent.aspx.cs" Inherits="ProUsuVent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="scrollPro scroll fomTotPagDat">
        <asp:DataList ID="DataList1" runat="server" DataKeyField="ven_cod" DataSourceID="SqlDataSource2" OnItemCommand="DataList1_ItemCommand">
            <ItemTemplate>
                Fecha en que se realizo:
            <asp:Label ID="ven_fecLabel" runat="server" Text='<%# Eval("ven_fec") %>' />
                <br />
                Codigo de venta:
            <asp:Label ID="ven_codLabel" runat="server" Text='<%# Eval("ven_cod") %>' />
                <br />
                <asp:Button ID="Button10" runat="server" BorderStyle="None" Text="Detalles" CommandArgument='<%# Eval("ven_cod") %>' CommandName="detalleVenta" CssClass="ButPag ButPagIni" />
                <br />
            </ItemTemplate>
        </asp:DataList>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:conexion_sin_clave %>" SelectCommand="SELECT DISTINCT tbl_venta.ven_fec, tbl_venta.ven_cod FROM tbl_det_venta INNER JOIN tbl_venta ON tbl_det_venta.ven_cod = tbl_venta.ven_cod INNER JOIN tbl_producto ON tbl_det_venta.pro_cod = tbl_producto.pro_cod WHERE (tbl_producto.usu_cod = @usu_c) AND ((tbl_det_venta.det_ven_est = @estado)OR(tbl_det_venta.det_ven_est = @estadoP)OR(tbl_det_venta.det_ven_est = @estadoPe))">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="" Name="usu_c" SessionField="usu_c" />
                <asp:Parameter DefaultValue="revisar" Name="estado" />
                <asp:Parameter DefaultValue="pago" Name="estadoP" />
                <asp:Parameter DefaultValue="pendiente" Name="estadoPe" />
            </SelectParameters>
        </asp:SqlDataSource>
    </div>
        <div class="contImglog">
        <asp:Image ID="Image1" runat="server" ImageUrl="~/img/Group 7.png" CssClass="imgReg" />
    </div>

</asp:Content>

