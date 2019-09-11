<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ComProFru.aspx.cs" Inherits="ComProFru" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="scrollPro scroll">
        <asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource3" Width="154px" DataKeyField="pro_cod" OnItemCommand="DataList1_ItemCommand">
            <ItemTemplate>
                <div class="divflex">   
                    <div>

                        <asp:Label ID="pro_codLabel" runat="server" Text='<%# Eval("pro_cod") %>' Visible="False" />
                        Producto:
                
                            <asp:Label ID="pro_nomLabel" runat="server" Text='<%# Eval("pro_nom") %>' />
                        <br />
                        Cantidad:
                
                            <asp:Label ID="pro_canLabel" runat="server" Text='<%# Eval("pro_can") %>' />
                        <br />
                        Valor:
                                   
                            <asp:Label ID="pro_vlr_ventaLabel" runat="server" Text='<%# Eval("pro_vlr_venta") %>' />
                        <asp:Image ID="Image3" runat="server" CssClass="imgPro" ImageUrl='<%# Eval("pro_cod", "manejadorImg.ashx?pro_cod={0}") %>' />
                    </div>
                    <asp:Button ID="ComprarPro" runat="server" BorderStyle="None" CssClass="ButPag ButPagIni" Text="Agregar a la Canasta" CommandArgument='<%# Eval("pro_cod") %>' CommandName="agregar" />

                </div>
            </ItemTemplate>
        </asp:DataList>
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:conexion_sin_clave %>" SelectCommand="SELECT [pro_nom], [pro_vlr_venta], [pro_can], [pro_cod] FROM [tbl_producto] WHERE ([cod_cat] = @cod_cat) AND ([pro_est] = @pro_est)  AND  (usu_cod != @usu_codc)">
            <SelectParameters>
                <asp:Parameter DefaultValue="2" Name="cod_cat" Type="Int32" />
                <asp:Parameter DefaultValue="activo" Name="pro_est" Type="String" />
                <asp:SessionParameter DefaultValue="0" Name="usu_codc" SessionField="usu_c" />
            </SelectParameters>
        </asp:SqlDataSource>
    </div>
</asp:Content>

