<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ProUsuAgr.aspx.cs" Inherits="ProUsuAgr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
            <div class="formAgrPro">
                <div>
                    <asp:Label ID="Label13" runat="server" Text="Nombre de Producto"></asp:Label>
                    <br />
                    <asp:TextBox ID="NomPro" runat="server" CssClass="cajTxt" onpaste="return false" oncut="return false" oncopy="return false"></asp:TextBox>
                </div>
                <div>
                    <asp:Label ID="Label14" runat="server" Text="Valor"></asp:Label>
                    <br />
                    <asp:TextBox ID="Valor" runat="server" CssClass="cajTxt" onpaste="return false" oncut="return false" oncopy="return false" MaxLength="8"></asp:TextBox>
                </div>
                <div>
                    <asp:Label ID="Label15" runat="server" Text="Cantidad"></asp:Label>
                    <br />
                    <asp:TextBox ID="Cantidad" runat="server" CssClass="cajTxt" ></asp:TextBox>
                </div>
                <div>
                    <asp:Label ID="Label16" runat="server" Text="tipo de producto"></asp:Label>
                    <br />
                    <asp:DropDownList ID="DropDownList" runat="server" DataSourceID="SqlDataSource2" DataTextField="tipo_catalogo" DataValueField="cod_cat" CssClass="cajTxtdrop"></asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:conexion_sin_clave %>" SelectCommand="SELECT [cod_cat], [tipo_catalogo] FROM [tbl_tipo_producto]"></asp:SqlDataSource>
                </div>
                <div>
                    <asp:Label ID="Label17" runat="server" Text="Ubicacion"></asp:Label>
                    <br />
                    <asp:FileUpload ID="FileUpload1" runat="server" CssClass="cajTxt" />
                </div>
            </div>
            <div class="formAgrProbut">
                <asp:Button ID="Button10" runat="server" Text="Guardar" CssClass="ButPag ButPagIni" OnClick="Button10_Click" />
                <asp:Label ID="Label18" runat="server" Visible="False"></asp:Label>
            </div>            
            <div class="formAgrProCon scroll">

                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="2px" CellPadding="0" DataKeyNames="pro_cod" GridLines="Horizontal" CellSpacing="2" >
                    <Columns>
                        <asp:BoundField DataField="pro_cod" HeaderText="Cod" ReadOnly="True" SortExpression=" pro_cod" Visible="False" />
                        <asp:BoundField DataField="pro_nom" HeaderText="Producto" SortExpression=" pro_nom" />
                        <asp:BoundField DataField="pro_can" HeaderText="Cantidad" SortExpression=" pro_can" />
                        <asp:BoundField DataField="pro_vlr_venta" HeaderText="Valor + iva" SortExpression=" pro_vlr_venta" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Image ID="Image2" runat="server" ImageUrl='<%# Eval("pro_cod", "manejadorImg.ashx?pro_cod={0}") %>' Height="109px" Width="229px" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField></asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="White" ForeColor="#333333" BorderStyle="None" />
                    <HeaderStyle BackColor="#CCCCCC" Font-Bold="True" ForeColor="White" BorderStyle="None" />
                    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="White" ForeColor="#333333" BorderColor="#999999" BorderStyle="Solid" />
                    <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#999999" />
                    <SortedAscendingHeaderStyle BackColor="#487575" />
                    <SortedDescendingCellStyle BackColor="#E5E5E5" />
                    <SortedDescendingHeaderStyle BackColor="#666666" />
                </asp:GridView>

            </div>
</asp:Content>

