using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class loginPass : System.Web.UI.Page
{
    TblLoginPass Usu = new TblLoginPass();
    TblUsuCod UsuCod = new TblUsuCod();
    TblLogCodAd consultar = new TblLogCodAd();

    Decimal usuario;
    string usu;
    string cer_bot ;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        usu = (string)Session["usu_ns"];/*------capturar variable de seccion------*/

        if (usu == null) {
            Response.Redirect("loginUsu.aspx");
        }
        else
        {
            usuario = (Decimal)Session["usu_n"];


        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string contraseña, mensajeclave,clasenueva,codigoad;
        contraseña = Contraseña.Text;

        if (contraseña == "")
        {
            Label13.Text = "Ingrese contraseña";
            return;
        }
        else {
            mensajeclave = Usu.validar_acceso_inyeccion_clave_sp(usuario, contraseña);
                /*==================================si la contraseña es incorrecta==================================*/
            if (mensajeclave != "Éxito")
            {
                Label13.Text = "La Contraseña es incorrecta";
            }
                /*==================================si la contraseña es correcta==================================*/
            else
            {

                codigoad = consultar.Consultar_TblLogCodAd(usuario);
                if (Convert.ToInt32(codigoad) == 1)
                {
                    Session["ad_co"] = Convert.ToString(codigoad);
                }
                clasenueva = UsuCod.TblUsuCodConsultar_Codigo_Usuario(usuario);
                Session["usu_cs"] = Convert.ToString(clasenueva);
                Session["usu_c"] = Convert.ToInt32(clasenueva);
                Response.Write("<script>alert('acceso validado')</script>");
                cer_bot = "1";
                Session["ocu_ini_ses"] = cer_bot;
                Response.Redirect("IniUsu.aspx");





            }
        }
    }


    protected void Button6_Click(object sender, EventArgs e)
    {
            Response.Redirect("loginUsu.aspx");
    }
    
}