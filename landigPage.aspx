<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="landigPage.aspx.cs" Inherits="landigPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="landPho">
        <asp:image id="Image1" runat="server" imageurl="~/img/smathPhone.png" cssclass="imgPho" />
    </div>
    <div class="formCont">
        <asp:label id="Label9" runat="server" text="Contactenos"></asp:label>
        <br />
        <asp:label id="Label6" runat="server" text="Tu nombre"></asp:label>
        <br />
        <asp:textbox id="Nombre" runat="server" CssClass="cajTxt"></asp:textbox>
        <asp:label id="Label13" runat="server" forecolor="#CC0000"></asp:label>
        <br />
        <asp:label id="Label7" runat="server" text="Tu correo"></asp:label>
        <br />
        <asp:textbox id="Correo" runat="server" CssClass="cajTxt"></asp:textbox>
        <asp:label id="Label14" runat="server" forecolor="#CC0000"></asp:label>
        <br />
        <asp:label id="Label8" runat="server" text="Tu mensaje"></asp:label>
        <br />
        <asp:textbox id="Mensaje" runat="server" CssClass="cajTxt"></asp:textbox>
        <asp:label id="Label15" runat="server" forecolor="#CC0000"></asp:label>
        <br />
        <br />
        <asp:button id="Button1" runat="server" text="Enviar" onclick="Button1_Click" CssClass="ButPag" />

    </div>
    <div class="comFun">
        <asp:label id="Label1" runat="server" text="Como funciona ProCamp" cssclass="titulo2"></asp:label>
    </div>
    <div class="landDes">
        <div>
            <asp:label id="Label2" runat="server" text="Entra en nuestra Pagina WEB o descarga de la Play Store"></asp:label>
            <asp:image id="Image2" runat="server" imageurl="~/img/log.png" cssclass="iconLand" />
        </div>
        <br />
        <div>
            <asp:label id="Label3" runat="server" text="Haz  click en  Registrate o inicia sesion  para  acceder a nuestro contenido. "></asp:label>
            <asp:image id="Image3" runat="server" imageurl="~/img/log.png" cssclass="iconLand2" />
        </div>
        <br />
        <div>
            <asp:label id="Label4" runat="server" text="Registra tus Productos o  busca los Productos de tu interes"></asp:label>
            <asp:image id="Image4" runat="server" imageurl="~/img/log.png" cssclass="iconLand" />
        </div>
        <br />
        <div>
            <asp:label id="Label5" runat="server" text="Compra productos de la tienda o Aumenta tus ganacias con ProCamp"></asp:label>
            <asp:image id="Image5" runat="server" imageurl="~/img/log.png" cssclass="iconLand2" />
        </div>
    </div>
</asp:Content>

