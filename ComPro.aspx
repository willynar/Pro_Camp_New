<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ComPro.aspx.cs" Inherits="ComPro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="scrollPro scroll">
        <asp:DataList ID="DataList1" runat="server" DataKeyField="pro_cod" DataSourceID="SqlDataSource1" Width="154px" OnItemCommand="DataList1_ItemCommand">
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
                        <br />
                    </div>
                    <asp:Button ID="ComprarPro" runat="server" BorderStyle="None" CssClass="ButPag ButPagIni" Text="Agregar a la Canasta" CommandArgument='<%# Eval("pro_cod") %>' CommandName="agregar" />

                </div>

            </ItemTemplate>
        </asp:DataList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:conexion_sin_clave %>" SelectCommand="SELECT [pro_cod], [pro_nom], [pro_can], [pro_vlr_venta], [usu_cod] FROM [tbl_producto] WHERE ([pro_est] = @pro_est)  AND  (usu_cod != @usu_codc)">
            <%--condicional sera la el where--%>
            <SelectParameters>
                <asp:Parameter DefaultValue="activo" Name="pro_est" Type="String" />
                <asp:SessionParameter DefaultValue="0" Name="usu_codc" SessionField="usu_c" />
            </SelectParameters>
        </asp:SqlDataSource>
    </div>
</asp:Content>

