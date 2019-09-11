using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//procamp
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class DatUsuActCuen : System.Web.UI.Page
{
    TblUsuActCue actualizar = new TblUsuActCue();

    string usu_ban,usu;
    int usu_cuent,usu_c;
    protected void Page_Load(object sender, EventArgs e)
    {
        usu = (string)Session["usu_ns"];/*------capturar variable de seccion------*/

        if (usu == null)
        {
            Response.Redirect("loginUsu.aspx");
        }

        else
        {
            usu_c = (int)Session["usu_c"];
        }

    }

    protected void Button10_Click(object sender, EventArgs e)
    {

        if (NumeroCuenta.Text =="")
        {
            Label17.Text = "ingresar el numero de cuenta";
            return;
        }
        else {
            usu_cuent = Convert.ToInt32(NumeroCuenta.Text);
        }
        if (NombreBanco.Text=="")
        {
            Label18.Text = "ingresar nombre del Banco";
            return;
        }
        else
        { 
        
            usu_ban = NombreBanco.Text;
        }
        int resul = actualizar.Actualizar_TblUsuActCue(usu_ban, usu_cuent, usu_c);
        if (resul == 1)
        {
            Response.Write("<script>alert('Cuenta bancaria registrada correctamente')</script>");
            
        }
        else
        {
            Response.Write("<script>alert('Error al registrar la Cuenta bancaria')</script>");
            return;
        }
    }
}