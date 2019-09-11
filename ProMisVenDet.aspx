<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ProMisVenDet.aspx.cs" Inherits="ProMisVenDet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="formAgrProCon scroll">
        <asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource1" OnItemCommand="DataList1_ItemCommand" DataKeyField="ven_cod">
            <ItemTemplate>
                Producto:
           
                <asp:Label ID="pro_nomLabel" runat="server" Text='<%# Eval("pro_nom") %>' />
                <br />
                Estado:
                <asp:Label ID="det_ven_estLabel" runat="server" Text='<%# Eval("det_ven_est") %>' />
                
                <asp:Label ID="ven_codLabel" runat="server" Text='<%# Eval("ven_cod") %>' Visible="False" />
                              
                <asp:Label ID="pro_codLabel" runat="server" Text='<%# Eval("pro_cod") %>' Visible="False" />
                <br />
                <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("pro_cod", "manejadorImgCon.ashx?pro_cod={0}") %>' CssClass="imgVent" />
                <br />
                <asp:DropDownList ID="DropDownList2" runat="server" CssClass="cajTxtdrop">
                    <asp:ListItem>pendiente</asp:ListItem>
                    <asp:ListItem>pago</asp:ListItem>
                </asp:DropDownList>
                <br />
                <asp:Button ID="Button10" runat="server" Text="Actualizar" BorderStyle="None" CssClass="ButPag ButPagIni" CommandName="actualizar" />
                <br />





            </ItemTemplate>
        </asp:DataList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:conexion_sin_clave %>" SelectCommand="SELECT DISTINCT tbl_producto.pro_nom, tbl_det_venta.det_ven_est, tbl_det_venta.ven_cod, tbl_det_venta.pro_cod FROM tbl_det_venta INNER JOIN tbl_producto ON tbl_det_venta.pro_cod = tbl_producto.pro_cod WHERE (tbl_det_venta.ven_cod = @ven_cod) AND (tbl_producto.usu_cod = @usu_cod) 
AND ((tbl_det_venta.det_ven_est = @estado) OR (tbl_det_venta.det_ven_est = @estadoP)OR (tbl_det_venta.det_ven_est = @estadoPe))">
            <SelectParameters>
                <asp:SessionParameter Name="ven_cod" SessionField="ven_cod_ved" />
                <asp:SessionParameter Name="usu_cod" SessionField="usu_c" />
                <asp:Parameter DefaultValue="revisar" Name="estado" />
                <asp:Parameter DefaultValue="pago" Name="estadoP" />
                <asp:Parameter DefaultValue="pendiente" Name="estadoPe" />
            </SelectParameters>
        </asp:SqlDataSource>
    </div>

</asp:Content>

