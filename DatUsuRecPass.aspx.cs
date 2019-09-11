using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class DatUsuRecPass : System.Web.UI.Page
{
    TblUsuRecPass Recuperar = new TblUsuRecPass();

    protected void Page_Load(object sender, EventArgs e)
    {
        Session["Transparencia"] = "1";
    }

    protected void Button10_Click(object sender, EventArgs e)
    {
        string usu_email,usu_pass,usu_con;
        Decimal usu_cel;
                
        if (Celular.Text == "")
        {
            Label17.Text = "Debe ingresar celular";
            return;
        }
        else
        {
            Label17.Text = "";
            usu_cel = Convert.ToDecimal(Celular.Text);

        }
        if (Correo.Text == "")
        {
            Label18.Text = "Debe ingresar correo";
            return;
        }
        else
        {
            Label18.Text = "";
            usu_email = Correo.Text;

        }
        if (NuevaContraseña.Text == "")
        {
            Label19.Text = "Debe ingresar contraseña";
            return;
        }
        else
        if (NuevaContraseña.Text.Length < 8)
        {
            
            Label19.Text = "minimo de caracateres es 8";
            return;
        }
        else
        if (Confirmar.Text == "")
        {
            Label19.Text = "Debe  confirmar contraseña";
            Label20.Text = "Debe  confirmar contraseña";
            return;

        }
        else
        if (Confirmar.Text.Length < 8)
        {
            Label20.Text = "minimo de caracateres es 8";
            return;
        }
        else /*se confirma que las contraseñas coincidan*/
        if (NuevaContraseña.Text != Confirmar.Text)
        {
            Label19.Text = "Las contraseñas deben coincidir";
            Label20.Text = "Las contraseñas deben coincidir";
            return;
        }
        else
        {
            Label19.Text = "";
            usu_pass = NuevaContraseña.Text;
            Label20.Text = "";
            usu_con = Confirmar.Text;
        }
            int resul = Recuperar.Recu_TblUsuRecPass(usu_cel, usu_email, usu_pass);
        if (resul == 1)
        {
            Response.Write("<script>alert('la clave a sido cambiada correctamente')</script>");
            Response.Redirect("loginUsu.aspx");
        }
        else
        {
            Response.Write("<script>alert('Error al cambiar clave el usuario')</script>");
            return;
        }



    }
}