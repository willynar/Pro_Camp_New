<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ComProDet.aspx.cs" Inherits="ComProDet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            margin-right: 0;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
            <div class="scrollPro scroll">
                <asp:Button ID="Button1" runat="server" Text="comprar" OnClick="Button1_Click" BorderStyle="None" CssClass="ButPag ButPagIni" />
                <asp:Button ID="Button10" runat="server" BorderStyle="None" CssClass="ButPag ButPagIni" OnClick="Button10_Click" Text="Volver ala tienda" />
                <asp:Label ID="Label1" runat="server" Text="Label" Visible="False"></asp:Label>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="auto-style1" CellPadding="4" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="sno" HeaderText="Sno" Visible="False" />
                        <asp:BoundField DataField="pro_cod" HeaderText="Codigo" />
                        <asp:BoundField DataField="pro_nom" HeaderText="Nombre de producto" />
                        <asp:BoundField DataField="pro_can" HeaderText="Cantidad" />
                        <asp:BoundField DataField="pro_vlr_venta" HeaderText="Valor" />
                        <asp:TemplateField HeaderText="Imagen">
                            <ItemTemplate>
                                <asp:Image ID="Image2" runat="server" ImageUrl='<%# Eval("pro_cod", "manejadorImg.ashx?pro_cod={0}") %>' CssClass="imgPro" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EditRowStyle BackColor="#7C6F57" />
                    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#E3EAEB" />
                    <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F8FAFA" />
                    <SortedAscendingHeaderStyle BackColor="#246B61" />
                    <SortedDescendingCellStyle BackColor="#D4DFE1" />
                    <SortedDescendingHeaderStyle BackColor="#15524A" />
                </asp:GridView>
            </div>
</asp:Content>

