using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DatUsuCamPass : System.Web.UI.Page
{
    TblUsuCamPass Cambiar = new TblUsuCamPass();
    int usu_cod;
    string usu, usu_cods;
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["Transparencia"] = "1";
        usu = (string)Session["usu_ns"];/*------capturar variable de seccion------*/
        if (usu == null)
        {
            Response.Redirect("loginUsu.aspx");
        }
        else
        {
            usu_cod = (int)Session["usu_c"];
            usu_cods = (string)Session["usu_cs"];
        }
    }
    protected void Button10_Click(object sender, EventArgs e)
    {
        string usu_pass_act,usu_pass, usu_con;
       
        if (ContraseñaActual.Text == "")
        {
            Label18.Text = "Debe ingresar contraseña actual";
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
            Label18.Text = "";
            usu_pass_act = ContraseñaActual.Text;
            Label19.Text = "";
            usu_pass = NuevaContraseña.Text;
            Label20.Text = "";
            usu_con = Confirmar.Text;
        }
        int resul = Cambiar.Camb_TblUsuCamPass(usu_pass_act,usu_pass,usu_cod);
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