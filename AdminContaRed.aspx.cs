using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class AdminContaRed : System.Web.UI.Page
{
    TblActContaRed Actualizar = new TblActContaRed();

    string usu, usu_cods, pag_ubi, pag_fac, pag_twi, pag_pin, pag_you;
    int usu_cod; 
    Decimal pag_tel;

    protected void Page_Load(object sender, EventArgs e)
    {
        usu = (string)Session["usu_ns"];/*------capturar variable de seccion------*/
        Session["Transparencia"] = "0";
        if (usu == null)
        {
            Response.Redirect("loginUsu.aspx");
        }
        else
        {
            if ((string)Session["ad_co"] == null)
            {
                Response.Write("<script>alert('solo se puede acceder al menu administrador a travez de una cuenta administrador')</script>");
                Response.Redirect("IniUsu.aspx");
            }
            usu_cod = (int)Session["usu_c"];
            usu_cods = (string)Session["usu_cs"];


            //===============se hace la consulta de los datos de contacto==============
            var Sqlconn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion_sin_clave"].ConnectionString);
            var consulta = "select * from tbl_contacto_redes ";
            var cmd = new SqlCommand(consulta, Sqlconn);
            Sqlconn.Open();
            SqlDataReader leerbd = cmd.ExecuteReader();
            if (leerbd.Read() == true)
            {
                //===============se traen los datos de la consulta alas variables==============
                pag_tel = Convert.ToDecimal(leerbd.GetValue(0));
                pag_ubi = Convert.ToString(leerbd.GetValue(1));
                pag_fac = Convert.ToString(leerbd.GetValue(2));
                pag_twi = Convert.ToString(leerbd.GetValue(3));
                pag_pin = Convert.ToString(leerbd.GetValue(4));
                pag_you = Convert.ToString(leerbd.GetValue(5));


            }
            Sqlconn.Close();

        }
        //============enviar datos a los textbox==============
        Label21.Text = Convert.ToString(pag_tel);
        Label22.Text = pag_ubi;
        Label23.Text = pag_fac;
        Label24.Text = pag_twi;
        Label25.Text = pag_pin;
        Label26.Text = pag_you;
    }

    protected void Button10_Click(object sender, EventArgs e)
    {
        if (Telefono.Text != "")
        {
            pag_tel = Convert.ToDecimal(Telefono.Text);
        }

        if (Ubicacion.Text != "")
        {
            pag_ubi = Ubicacion.Text;
        }

        if (Facebook.Text != "")
        {
            pag_fac = Facebook.Text;
        }

        if (Twiter.Text != "")
        {
            pag_twi = Twiter.Text;
        }

        if (Pinterest.Text != "")
        {
            pag_pin = Pinterest.Text;
        }

        if (Youtube.Text != "")
        {
            pag_you = Youtube.Text;
        }

        //============se envian los datos ala clase================
        int resul = Actualizar.Actualizar_TblActContaRed(pag_tel, pag_ubi, pag_fac, pag_twi, pag_pin, pag_you);


        if (resul == 1)
        {
            Response.Write("<script>alert('los datos se han cambiado Correctamente')</script>");
            Response.Redirect("AdminContaRed.aspx");
        }
        else
        if (resul == 2)
        {
            //Response.Write("<script>alert('Error al actualizar la contraseña es incorrecta')</script>");
            return;

        }
        else
        {
            Response.Write("<script>alert('Error al actualizar Datos')</script>");
            return;
        }
    }


    protected void Button11_Click(object sender, EventArgs e)
    {
        Response.Redirect("IniUsu.aspx");
    }
}