<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Fac.aspx.cs" Inherits="Fac" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="FormFac">
        <asp:Button ID="Button18" runat="server" Text="Pruebe nuestro video iteractivo" BackColor="White" BorderColor="White" BorderStyle="None" OnClick="Button18_Click" />
        <br />
            <div runat="server" id="video" Visible="False">
                <iframe width="560" height="315" src="https://www.youtube-nocookie.com/embed/9sPuKk0oLzE" frameborder="0" allow="accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>
            </div>
        <br />
        <asp:Button ID="Button10" runat="server" BackColor="White" BorderColor="White" BorderStyle="None" OnClick="Button10_Click" Text="Como hago para crear mi cuenta" />
        <br />
        <asp:Label ID="Label13" runat="server" Text="Ve al boton registrarme situado en la parte superior de la pagina llena tus datos y dale click en registrar " Visible="False"></asp:Label>
        <br />
        <asp:Button ID="Button11" runat="server" BackColor="White" BorderColor="White" BorderStyle="None" OnClick="Button11_Click" Text="Como vendo mis productos" />
        <br />
        <asp:Label ID="Label14" runat="server" Text="Debes ir al boton registrese luego acceder ala cuenta que creaste ir voy a vender agregar productos recuerda que debes registrar antes tu cuenta bancaria para que asi los usuario que quieran comprar tus productos puedan hacerte la contignacionde de los productos que compres" Visible="False"></asp:Label>
        <br />
        <asp:Button ID="Button12" runat="server" BackColor="White" BorderColor="White" BorderStyle="None" OnClick="Button12_Click" Text="Como cambio mis datos personales" />
        <br />
        <asp:Label ID="Label15" runat="server" Text="Ir al boton login accde a tu cuenta luego ve a mis datos cambiar datos llena los datos que deseas cambiar confirma contraseña y dale click en el boton actualizar" Visible="False"></asp:Label>
        <br />
        <asp:Button ID="Button13" runat="server" BackColor="White" BorderColor="White" BorderStyle="None" OnClick="Button13_Click" Text="Como agrego productos al carrito o canasta " />
        <br />
        <asp:Label ID="Label16" runat="server" Text="Primero accede a tu cuenta  luego as click en tienda escoje tl producto que quieres y dale click en el boton agregar a la canasta " Visible="False"></asp:Label>
        <br />
        <asp:Button ID="Button14" runat="server" BackColor="White" BorderColor="White" BorderStyle="None" Text="Donde veo mis compras realizadas" OnClick="Button14_Click" />
        <br />
        <asp:Label ID="Label17" runat="server" Text="Ve al boton mi cuenta lugo as click en mis compras ayi veras una lista de las compras realizadas por fecha" Visible="False"></asp:Label>
        <br />
        <asp:Button ID="Button15" runat="server" BackColor="White" BorderColor="White" BorderStyle="None" Text="Donde veo que productos e vendido" OnClick="Button15_Click" />
        <br />
        <asp:Label ID="Label18" runat="server" Text="Ve al boton mi cuenta lugo as click en mis ventas ayi veras una lista de las compras realizadas por fecha" Visible="False"></asp:Label>
        <br />
        <asp:Button ID="Button16" runat="server" BackColor="White" BorderColor="White" BorderStyle="None" Text="Porque al ingresar un valor de producto se ahumenta" OnClick="Button16_Click" />
        <br />
        <asp:Label ID="Label19" runat="server" Text="El sistema de ProCamp esta diseñado para facilitarle las cuentas al agricultor de tal forma que cuando ingresa  un precio se le ayuda agregandole un 5% mas de valor al producto para que no tenga perdidas ni problemas con los impuestos que aplica el dian" Visible="False"></asp:Label>
        <br />
        <asp:Button ID="Button17" runat="server" BackColor="White" BorderColor="White" BorderStyle="None" OnClick="Button17_Click" Text="Olvidaste tu contraseña " />
        <br />
        <asp:Label ID="Label20" runat="server" Text="Ve al menu inicio  ingresa tu usuario  dale clic en siguiente y acontinuacion veras en letras azules  un hiperlink que dice recuperar  contraseña  ingresa los datos para recibir  el correo donde podras  cambiar tu contraseña o as click en el siguiente" Visible="False"></asp:Label>
        <asp:HyperLink ID="HyperLink1" runat="server" ForeColor="#000066" NavigateUrl="~/LoginRecPass.aspx" Visible="False">Recuperar contraseña</asp:HyperLink>
        <br />
    </div>
</asp:Content>

