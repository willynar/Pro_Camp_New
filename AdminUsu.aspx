<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AdminUsu.aspx.cs" Inherits="AdminUsu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <asp:Button ID="Button1" runat="server" Text="Volver a menu" BorderStyle="None" CssClass="ButPagIni ButPag" OnClick="Button1_Click" />
    </div>
    <div class="scrollProAdmim scroll">
        <asp:DataList ID="DataList1" runat="server" DataKeyField="usu_cod" DataSourceID="SqlDataSource1" CellPadding="1" CellSpacing="3" RepeatLayout="Flow" HorizontalAlign="Left" OnItemCommand="DataList1_ItemCommand">
            <ItemTemplate>
                --Codigo :  
            <asp:Label ID="usu_codLabel" runat="server" Text='<%# Eval("usu_cod") %>' />

                --Nombre :  
            <asp:Label ID="usu_nomLabel" runat="server" Text='<%# Eval("usu_nom") %>' />

                --Estado :  
            <asp:Label ID="Label1" runat="server" Text='<%# Eval("usu_est") %>' />


                --Rol :  
            <asp:Label ID="Label2" runat="server" Text='<%# Eval("rol_nom") %>' />


                --Direccion :  
            <asp:Label ID="usu_dirLabel" runat="server" Text='<%# Eval("usu_dir") %>' />


                --Apellidos :  
            <asp:Label ID="usu_apeLabel" runat="server" Text='<%# Eval("usu_ape") %>' />


                --Telefono :  
            <asp:Label ID="usu_telLabel" runat="server" Text='<%# Eval("usu_tel") %>' />


                --Celular :  
            <asp:Label ID="usu_celLabel" runat="server" Text='<%# Eval("usu_cel") %>' />


                --Email :  
            <asp:Label ID="usu_emailLabel" runat="server" Text='<%# Eval("usu_email") %>' />


                --Cedula :  
            <asp:Label ID="usu_cedLabel" runat="server" Text='<%# Eval("usu_ced") %>' />

                <br />
                <asp:Label ID="Label15" runat="server" Text="Nuevo estado : "></asp:Label>
                <asp:DropDownList ID="DropDownList1" runat="server">
                    <asp:ListItem Value="activo">activar</asp:ListItem>
                    <asp:ListItem Value="bloqueado">bloquear</asp:ListItem>
                    <asp:ListItem Value="desactivo">desactivar</asp:ListItem>
                </asp:DropDownList>
                <br />
                <br />
                <asp:Button ID="Button10" runat="server" Text="Actualizar" CssClass="ButPagIni ButPag" CommandArgument='<%# Eval("usu_cod") %>' CommandName="Actualizar"/>

                <br />
            </ItemTemplate>
        </asp:DataList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:conexion_sin_clave %>" SelectCommand="SELECT tbl_usuario.usu_cod, tbl_usuario.usu_nom, tbl_usuario.usu_dir, tbl_usuario.usu_ape, tbl_usuario.usu_tel, tbl_usuario.usu_cel, tbl_usuario.usu_email, tbl_usuario.usu_ced, tbl_usuario.usu_est, tbl_rol.rol_nom FROM tbl_usuario INNER JOIN tbl_rol ON tbl_usuario.rol_id = tbl_rol.rol_id"></asp:SqlDataSource>
    </div>
</asp:Content>

