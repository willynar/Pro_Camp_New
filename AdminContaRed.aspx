<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AdminContaRed.aspx.cs" Inherits="AdminContaRed" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="FormActConaRed FleJus">
        <div>
            <asp:Label ID="Label15" runat="server" Text="Telefono : "></asp:Label>
            <asp:Label ID="Label21" runat="server"></asp:Label>
            <br />
            <asp:TextBox ID="Telefono" runat="server" CssClass="cajTxt"></asp:TextBox>
            <br />
            <asp:Label ID="Label16" runat="server" Text="Ubicacion : "></asp:Label>
            <asp:Label ID="Label22" runat="server"></asp:Label>
            <br />
            <asp:TextBox ID="Ubicacion" runat="server" CssClass="cajTxt"></asp:TextBox>
            <br />
            <asp:Label ID="Label17" runat="server" Text="Link Facebook : "></asp:Label>
            <asp:Label ID="Label23" runat="server"></asp:Label>
            <br />
            <asp:TextBox ID="Facebook" runat="server" CssClass="cajTxt"></asp:TextBox>
            <br />
            <asp:Label ID="Label18" runat="server" Text="Link Twiter : "></asp:Label>
            <asp:Label ID="Label24" runat="server"></asp:Label>
            <br />
            <asp:TextBox ID="Twiter" runat="server" CssClass="cajTxt"></asp:TextBox>
            <br />
            <asp:Label ID="Label19" runat="server" Text="Link Pinterest : "></asp:Label>
            <asp:Label ID="Label25" runat="server"></asp:Label>
            <br />
            <asp:TextBox ID="Pinterest" runat="server" CssClass="cajTxt"></asp:TextBox>
            <br />
            <asp:Label ID="Label20" runat="server" Text="Link Youtube : "></asp:Label>
            <asp:Label ID="Label26" runat="server"></asp:Label>
            <br />
            <asp:TextBox ID="Youtube" runat="server" CssClass="cajTxt"></asp:TextBox>
        <div>
            <br />
            <asp:Button ID="Button10" runat="server" Text="Actualizar" BorderStyle="None" CssClass="ButPagIni ButPag" OnClick="Button10_Click" />
            <asp:Button ID="Button11" runat="server" BorderStyle="None" CssClass="ButPagIni ButPag" OnClick="Button11_Click" Text="Volver al Menu" Visible="False" />

        </div>
            
        </div>
    </div>
    <div class="contImglog">
        <asp:Image ID="Image1" runat="server" ImageUrl="~/img/Group 7.png" CssClass="imgReg" />
    </div>

</asp:Content>

