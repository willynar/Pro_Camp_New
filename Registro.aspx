<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Registro.aspx.cs" Inherits="Registro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script src="js/validaciones.js"> </script>

    <link href="Css/masterTot.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            border-radius: 10%;
        }
    </style>
</asp:Content>
<%-- ======================contenido pagina=================================--%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="formCent">
        <div class="FleJus">
            <div>


                <asp:Label ID="Label1" runat="server" Text="Nombre"></asp:Label>
                <asp:Label ID="Label13" runat="server" ForeColor="Red"></asp:Label>
                <br />
                <asp:TextBox ID="Nombre" runat="server" MaxLength="20" onpaste="return false" oncut="return false" oncopy="return false" CssClass="cajTxt"></asp:TextBox>
                <br />
                <asp:Label ID="Label2" runat="server" Text="Apellidos"></asp:Label>
                <asp:Label ID="Label14" runat="server" ForeColor="Red"></asp:Label>
                <br />
                <asp:TextBox ID="Apellidos" runat="server" MaxLength="20" onpaste="return false" oncut="return false" oncopy="return false" CssClass="cajTxt"></asp:TextBox>
                <br />
                <asp:Label ID="Label3" runat="server" Text="Correo"></asp:Label>
                <asp:Label ID="Label15" runat="server" ForeColor="Red"></asp:Label>
                <br />
                <asp:TextBox ID="Correo" runat="server" MaxLength="50" TextMode="Email" CssClass="cajTxt"></asp:TextBox>
                <br />
                <asp:Label ID="Label6" runat="server" Text="Cedula"></asp:Label>
                <asp:Label ID="Label17" runat="server" ForeColor="Red"></asp:Label>
                <br />
                <asp:TextBox ID="Cedula" runat="server" MaxLength="10" TextMode="Number" onpaste="return false" oncut="return false" oncopy="return false" CssClass="cajTxt"></asp:TextBox>
                <br />
                <asp:Label ID="Label7" runat="server" Text="Direccion"></asp:Label>
                <asp:Label ID="Label18" runat="server" ForeColor="Red"></asp:Label>
                <br />
                <asp:TextBox ID="Direccion" runat="server" MaxLength="50" onpaste="return false" oncut="return false" oncopy="return false" CssClass="cajTxt"></asp:TextBox>
                <br />
                <asp:Label ID="Label8" runat="server" Text="Celular"></asp:Label>
                <asp:Label ID="Label19" runat="server" ForeColor="Red"></asp:Label>
                <br />
                <asp:TextBox ID="Celular" runat="server"  onpaste="return false" oncut="return false" oncopy="return false" CssClass="cajTxt" MaxLength="10" ></asp:TextBox>
                <br />
                <asp:Label ID="Label4" runat="server" Text="Contraseña"></asp:Label>
                <asp:Label ID="Label16" runat="server" ForeColor="Red"></asp:Label>
                <br />
                <asp:TextBox ID="Contrasena" runat="server" MaxLength="30" TextMode="Password" onpaste="return false" oncut="return false" oncopy="return false" CssClass="cajTxt"></asp:TextBox>
                <br />
                <asp:Label ID="Label5" runat="server" Text="Confirmar Contraseña"></asp:Label>
                <asp:Label ID="Label9" runat="server" ForeColor="Red"></asp:Label>
                <br />
                <asp:TextBox ID="Confirmar" runat="server" MaxLength="30" TextMode="Password" onpaste="return false" oncut="return false" oncopy="return false" CssClass="cajTxt"></asp:TextBox>
                <br />
                <asp:HyperLink ID="HyperLink1" runat="server" ForeColor="#000066" NavigateUrl="~/LoginUsu.aspx">Iniciar Sesion</asp:HyperLink>
                <br />
                <asp:Button ID="Button1" runat="server" Text="Guardar" OnClick="Button1_Click" BorderStyle="None" CssClass="ButPag" />
            </div>
        </div>
    </div>
    <div class="contImgReg">
        <asp:Image ID="Image1" runat="server" ImageUrl="~/img/Group 7.png" CssClass="imgReg" />
    </div>
</asp:Content>

