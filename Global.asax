<%@ Application Language="C#" %>
<%@ Import Namespace="System.Web.Routing" %>

<script RunAt="server">

    void Application_Start(object sender, EventArgs e)
    {
        
        // Código que se ejecuta al iniciarse la aplicación
        //iniciar void paginas urls amigables
        RegisterRoutes(RouteTable.Routes);
 
    }

    void RegisterRoutes(RouteCollection routes)
    {
        routes.MapPageRoute("", "ProCamp", "~/Registro.aspx");
        routes.MapPageRoute("", "ProCamp", "~/ComPro.aspx");
        routes.MapPageRoute("", "ProCamp", "~/ComProFru.aspx");
        routes.MapPageRoute("", "ProCamp", "~/ComProVer.aspx");
        routes.MapPageRoute("", "ProCamp", "~/comProPro.aspx");
        routes.MapPageRoute("", "ProCamp", "~/loginUsu.aspx");
        routes.MapPageRoute("", "ProCamp", "~/loginPass.aspx");
    }

    void Application_End(object sender, EventArgs e)
    {
        //  Código que se ejecuta al cerrarse la aplicación

    }

    void Application_Error(object sender, EventArgs e)
    {
        // Código que se ejecuta cuando se produce un error sin procesar

    }

    void Session_Start(object sender, EventArgs e)
    {
        // Código que se ejecuta al iniciarse una nueva sesión

    }

    void Session_End(object sender, EventArgs e)
    {
        // Código que se ejecuta cuando finaliza una sesión. 
        // Nota: el evento Session_End se produce solamente con el modo sessionstate
        // se establece como InProc en el archivo Web.config. Si el modo de sesión se establece como StateServer
        // o SQLServer, el evento no se produce.

    }

</script>
