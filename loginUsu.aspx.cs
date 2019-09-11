using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class loginUsu : System.Web.UI.Page
{
    TblLoginUsu usu = new TblLoginUsu();

    protected void Page_Load(object sender, EventArgs e)
    {
        Session["Transparencia"] = "1";
        Session["ocu_men_cont"] = "2";
        Celular.Attributes["onkeypress"] = " return blocklet(event);";
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Session["ocu_men_cont"] = "3";

        Decimal usuario;
        string mensaje;
        
        if (Celular.Text == "")
        {
            usuario = 0;

        }
        else
        {
            usuario = Convert.ToDecimal(Celular.Text);
        }
        if (usuario == 0)
        {
            //Response.Write("<script>alert('Ingrese Usuario')</script>");
            
            Label13.Text = "Ingrese usuario";
            return;
        }
        else 
        if(Celular.Text.Length < 10) {
            Label13.Text = "El minimo de caracateres es 10";
        }
        //SEGUNDO:SE ENVIAN LOS DATOS AL MODELO (login_usu)
        mensaje = usu.validar_acceso_usu_inyeccion_sp(usuario);/*ojo aqui estoy enrredado sale error*/

        if (mensaje != "Éxito")
        {

            Label13.Text = "El Usuario no existe";

        }
        else
        {
            //Convert.ToString(usuario);   tambien puede ser con este
            
            Session["usu_n"] = usuario; /*-----envio usuario a variable session-----*/
            Session["usu_ns"] = Convert.ToString(usuario);
            Response.Redirect("loginPass.aspx");
            Response.Write("<script>alert('Ingrese la contraseña')</script>)");
        }

    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("Registro.aspx");
    }

  
}