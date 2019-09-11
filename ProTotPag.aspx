<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ProTotPag.aspx.cs" Inherits="ProTotPag" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="scrollPro scroll fomTotPagDat">
        <asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource1">

            <ItemTemplate>
                Nombre usuario a pagar:
            <asp:Label ID="usu_nomLabel" runat="server" Text='<%# Eval("usu_nom") %>' />
                -- 
            <asp:Label ID="usu_apeLabel" runat="server" Text='<%# Eval("usu_ape") %>' />
                <br />
                Producto:
            <asp:Label ID="pro_nomLabel" runat="server" Text='<%# Eval("pro_nom") %>' />

                <asp:Label ID="ven_codLabel" runat="server" Text='<%# Eval("ven_cod") %>' Visible="False" />

                <asp:Label ID="usu_codLabel" runat="server" Text='<%# Eval("usu_cod") %>' Visible="False" />

                <asp:Label ID="pro_codLabel" runat="server" Text='<%# Eval("pro_cod") %>' Visible="False" />

                <br />
                <asp:Image ID="Image1" runat="server" CssClass="imgPro" ImageUrl='<%# Eval("pro_cod", "manejadorImg.ashx?pro_cod={0}") %>' />

                <br />
            </ItemTemplate>
        </asp:DataList>
    </div>
    <div class="fomTotPag">

        <asp:Label ID="Label24" runat="server" Text="Selecionar usuario a pagar total"></asp:Label>
        <br />

        <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource2" DataTextField="Column1" DataValueField="usu_cod"  CssClass="cajTxtdrop">
        </asp:DropDownList>
        <br />
        <asp:Button ID="Button10" runat="server" Text="Consultar total" CssClass="ButPag ButPagIni" OnClick="Button10_Click" />
        <br />
        <asp:Label ID="Label15" runat="server" Text="Total a pagar : "></asp:Label>
        <asp:Label ID="Label16" runat="server"></asp:Label>
        <asp:Label ID="Label20" runat="server" Text="Estado : "></asp:Label>
        <asp:Label ID="Label21" runat="server"></asp:Label>
        <br />
        <asp:Label ID="Label18" runat="server" Text="Cuenta numero : "></asp:Label>
        <asp:Label ID="Label19" runat="server"></asp:Label>
        <asp:Label ID="Label22" runat="server" Text="Banco : "></asp:Label>
        <asp:Label ID="Label23" runat="server"></asp:Label>
        <br />
        <asp:Label ID="Label25" runat="server" Text="Telefonos : "></asp:Label>
        <asp:Label ID="Label26" runat="server"></asp:Label>
        &nbsp;--
        <asp:Label ID="Label27" runat="server"></asp:Label>
        <br />
        <asp:Label ID="Label17" runat="server" Text="Adjuntar imagen consignacion  paga"></asp:Label>
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <asp:Button ID="Button11" runat="server" CssClass="ButPag ButPagIni" Text="Subir Consignacion" OnClick="Button11_Click" />
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:conexion_sin_clave %>" SelectCommand="SELECT DISTINCT tbl_usuario.usu_nom + '  ' +tbl_usuario.usu_ape, tbl_usuario.usu_cod FROM tbl_usuario INNER JOIN tbl_producto ON tbl_usuario.usu_cod = tbl_producto.usu_cod INNER JOIN tbl_det_venta ON tbl_producto.pro_cod = tbl_det_venta.pro_cod WHERE (tbl_det_venta.ven_cod = @ven_c)">
            <SelectParameters>
                <asp:SessionParameter Name="ven_c" SessionField="ven_c" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:conexion_sin_clave %>" SelectCommand="SELECT tbl_usuario.usu_nom, tbl_usuario.usu_ape, tbl_producto.pro_nom, tbl_det_venta.ven_cod, tbl_usuario.usu_cod, tbl_producto.pro_cod FROM tbl_usuario INNER JOIN tbl_producto ON tbl_usuario.usu_cod = tbl_producto.usu_cod INNER JOIN tbl_det_venta ON tbl_producto.pro_cod = tbl_det_venta.pro_cod WHERE (tbl_det_venta.ven_cod = @ven_c)">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="" Name="ven_c" SessionField="ven_c" />
            </SelectParameters>
        </asp:SqlDataSource>
    </div>
</asp:Content>

