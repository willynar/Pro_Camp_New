using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class MasterPage : System.Web.UI.MasterPage
{
    private void CargarNumeroTabla()
    {
        //==================================contador carrito ===================================

        DataTable dt = new DataTable();
        dt = (DataTable)Session["buyitems"];
        if (dt != null)
        {

            LabelCar.Text = dt.Rows.Count.ToString();
        }
        else
        {
            LabelCar.Text = "0";
        }


        //======================================================================


    }

    string bot_cer_sesion, men_cont,pag_ubi, pag_fac, pag_twi, pag_pin, pag_you;
    Decimal pag_tel;
    int conCmp;
    public void Page_Load(object sender, EventArgs e)
    {
        


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
        Label13.Text = Convert.ToString(pag_tel);
        Label14.Text = pag_ubi;    



        if ((string)Session["Transparencia"] == "1")
        {
            Transparencia.Visible = true;
        }
        else
        {
            Transparencia.Visible = false;
        }

        if ((string)Session["ocu_ini_ses"] != "")
        {

            bot_cer_sesion = (string)Session["ocu_ini_ses"];
            if (bot_cer_sesion == "1")
            {
                IniciarSecion.Visible = false;
                Button5.Visible = false;
                Button9.Visible = true;
                Button2.Visible = true;
                LabelCar.Visible = true;
                ImageButton7.Visible = true;
            }
        }
        else
        {
            IniciarSecion.Visible = true;
            Button5.Visible = true;
            Button2.Visible = false;
            Button9.Visible = false;
            LabelCar.Visible = false;
            ImageButton7.Visible = false;
        }
        CargarNumeroTabla();
        if ((string)Session["ocu_men_cont"] != "")
        {
            men_cont = (string)Session["ocu_men_cont"];
            if (men_cont == "1")
            {
                ButtonFru.Visible = true;
                ButtonVer.Visible = true;
                ButtonPro.Visible = true;
            }
            else
            if (men_cont == "2")
            {
                ButtonFru.Visible = false;
                ButtonVer.Visible = false;
                ButtonPro.Visible = false;
            }
            if (men_cont == "3")
            {
                ButtonFru.Visible = false;
                ButtonVer.Visible = false;
                ButtonPro.Visible = false;
            }

        }
        else
        {
            ButtonFru.Visible = false;
            ButtonVer.Visible = false;
            ButtonPro.Visible = false;
        }

    }

    protected void Button5_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(Page, typeof(Page), "ScrollToADiv", "setTimeout(scrollToDiv, 1);", true);
        Response.Redirect("Registro.aspx");
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        
        Response.Redirect("loginUsu.aspx");
    }



    protected void Button4_Click(object sender, EventArgs e)
    {
        
        Response.Redirect("ComPro.aspx");
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        Session["Transparencia"] = "1";
        Session["ocu_men_cont"] = "";
        Response.Redirect("ini.aspx");
    }

    public void Button9_Click(object sender, EventArgs e)
    {
        Session["ocu_men_cont"] = "";
        Response.Redirect("IniUsu.aspx");

    }

    protected void Button8_Click(object sender, EventArgs e)
    {

        Response.Redirect("comProPro.aspx");
    }

    protected void ImageButton7_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("ComProDet.aspx");
    }

    protected void Button1_Click1(object sender, EventArgs e)
    {
        Session["ocu_men_cont"] = "";
        Response.Redirect("Fac.aspx");
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Session.Clear();
        Response.Redirect("loginUsu.aspx");
    }
    protected void ButtonFru_Click(object sender, EventArgs e)
    {
        Response.Redirect("ComProFru.aspx");
    }

    protected void ButtonVer_Click(object sender, EventArgs e)
    {
        Response.Redirect("ComProVer.aspx");
    }

    protected void ButtonPro_Click(object sender, EventArgs e)
    {
        Response.Redirect("ComProPro.aspx");

    }
    
    protected void Transpa(object sender, EventArgs e)
    {
        Session["Transparencia"] = "0";
    }

    protected void CerrarTrans_Click(object sender, EventArgs e)
    {
        Session["Transparencia"] = "0";
        Response.Redirect("ini.aspx");
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect(pag_fac);
    }

    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect(pag_twi);
    }

    protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect(pag_pin);
    }

    protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect(pag_you);
    }
}
    
