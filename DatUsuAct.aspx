<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DatUsuAct.aspx.cs" Inherits="DatUsuAct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="js/validaciones.js"> </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="FormActUsu FleJus">
        <div>
            <asp:Label ID="Label19" runat="server" Text="Nombre"> </asp:Label>
            <asp:Label ID="LabelNom" runat="server"></asp:Label>
            <br />
            <asp:TextBox ID="Nombre" runat="server" CssClass="cajTxt"></asp:TextBox>
            <br />
            <asp:Label ID="Label20" runat="server" Text="Apellidos"> </asp:Label>
            <asp:Label ID="LabelApe" runat="server"></asp:Label>
            <br />
            <asp:TextBox ID="Apellidos" runat="server" CssClass="cajTxt"></asp:TextBox>
            <br />
            <asp:Label ID="Label21" runat="server" Text="Telefono"> </asp:Label>
            <asp:Label ID="LabelTel" runat="server"></asp:Label>
            <br />
            <asp:TextBox ID="Telefono" runat="server" CssClass="cajTxt" TextMode="Number"></asp:TextBox>
            <br />
            <asp:Label ID="Label23" runat="server" Text="Correo"></asp:Label>
            <asp:Label ID="LabelMai" runat="server"></asp:Label>
            <br />
            <asp:TextBox ID="Correo" runat="server" CssClass="cajTxt" TextMode="Email"></asp:TextBox>
            <br />
            <asp:Label ID="Label24" runat="server" Text="Cedula"> </asp:Label>
            <asp:Label ID="LabelCed" runat="server"></asp:Label>
            <br />
            <asp:TextBox ID="Cedula" runat="server" CssClass="cajTxt" TextMode="Number"></asp:TextBox>
            <br />
            <asp:Label ID="Label25" runat="server" Text="Direccion"> </asp:Label>
            <asp:Label ID="LabelDir" runat="server"></asp:Label>
            <br />
            <asp:TextBox ID="Direccion" runat="server" CssClass="cajTxt"></asp:TextBox>
            <br />
            <asp:Label ID="Label37" runat="server" ForeColor="#CC0000"></asp:Label>
            <br />
            <asp:Label ID="Label27" runat="server" Text="Ingresar Contraseña actual"> </asp:Label>
            <br />
            <asp:TextBox ID="Contrasena" runat="server" CssClass="cajTxt" TextMode="Password"></asp:TextBox>
            <br />
            <asp:Label ID="Label29" runat="server" Text="Confirmar Contraseña"> </asp:Label>
            <asp:Label ID="Label38" runat="server" ForeColor="#CC0000"></asp:Label>
            <br />
            <asp:TextBox ID="Confirmar" runat="server" CssClass="cajTxt" TextMode="Password"></asp:TextBox>
            <br />
        </div>
    </div>
    <div class="FormActUsuBut FleJus">
        <div>
            <asp:Button ID="Button10" runat="server" OnClick="Button10_Click" Text="Actualizar Datos" BorderStyle="None" CssClass="ButPag ButPagIni" />
        </div>
    </div>
    <div class="contImglog">
        <asp:Image ID="Image1" runat="server" ImageUrl="~/img/Group 7.png" CssClass="imgReg" />
    </div>

</asp:Content>

