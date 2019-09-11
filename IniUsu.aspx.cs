using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//ProCamp
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Security.Cryptography;
using System.IO;
using System.Text;

public partial class _Default : System.Web.UI.Page
{
    int usu_cod;
    string usu, usu_cods;
    string usu_nom;
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["Transparencia"] = "0";
        //===============ocultar menu administrador ======================
        if ((string)Session["ad_co"] == "1")
        {
            AdmForm.Visible = true;
        }
        else
        {
            AdmForm.Visible = false;
        }

        Session["ocu_men_cont"] = "2";
        usu = (string)Session["usu_ns"];/*------capturar variable de seccion------*/

        if (usu == null)
        {
            Response.Redirect("loginUsu.aspx");
        }

        else
        {
            usu_cod = (int)Session["usu_c"];
            usu_cods = (string)Session["usu_cs"];
        
        //===============se hace la consulta de los datos de usuario==============
        var Sqlconn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion_sin_clave"].ConnectionString);
        var consulta = "select * from tbl_usuario where usu_cod = '" + usu_cod + "'";
        var cmd = new SqlCommand(consulta, Sqlconn);
        Sqlconn.Open();
        SqlDataReader leerbd = cmd.ExecuteReader();
        if (leerbd.Read() == true)
        {
            //===============se traen los datos de la consulta alas variables==============
            usu_nom = Convert.ToString(leerbd.GetValue(2));        
        }
        Sqlconn.Close();
        Label14.Text = usu_nom;

        var Sqlconn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion_sin_clave"].ConnectionString);
        var consulta1 = "select  count(DISTINCT  tbl_venta.ven_cod) from tbl_venta inner join  tbl_det_venta on (tbl_det_venta.ven_cod = tbl_venta.ven_cod) inner join  tbl_producto on (tbl_det_venta.pro_cod = tbl_producto.pro_cod) inner join tbl_usuario on (tbl_producto.usu_cod = tbl_usuario.usu_cod) WHERE(tbl_producto.usu_cod= '" + usu_cod + "') AND (tbl_det_venta.det_ven_est= 'revisar') ";
        var cmd1 = new SqlCommand(consulta1, Sqlconn1);
        Sqlconn1.Open();
        SqlDataReader leerbd1 = cmd1.ExecuteReader();
        if (leerbd1.Read() == true)
        {
            int conCmp = Convert.ToInt32(leerbd1.GetValue(0));
            LabelCont.Text = Convert.ToString(conCmp);
        }
        Sqlconn1.Close();
        }
    }


    protected void Button10_Click(object sender, EventArgs e)
    {
        Response.Redirect("DatUsuAct.aspx");
    }

    protected void Button13_Click(object sender, EventArgs e)
    {
        Response.Redirect("ProUsuAgr.aspx");
    }

    protected void Button11_Click(object sender, EventArgs e)
    {
        Response.Redirect("ProUsuEli.aspx");
        
    }

    protected void Button12_Click(object sender, EventArgs e)
    {
        Response.Redirect("ProMisCom.aspx");
    }
         
    protected void Button1_Click1(object sender, EventArgs e)
    {
        Response.Redirect("AdminPro.aspx");
    }

    protected void Button14_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminContaRed.aspx");
    }

    protected void Button15_Click(object sender, EventArgs e)
    {
        Response.Redirect("DatUsuActCuen.aspx");
    }

    protected void Button16_Click(object sender, EventArgs e)
    {
        Response.Redirect("ComProDet.aspx");
    }

    protected void Button17_Click(object sender, EventArgs e)
    {
        Response.Redirect("ComPro.aspx");
    }

    protected void Button18_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminUsu.aspx");
    }

    protected void Button19_Click(object sender, EventArgs e)
    {
        Response.Redirect("ProUsuVent.aspx");
    }

    protected void Button20_Click(object sender, EventArgs e)
    {
        Response.Redirect("DatUsuCamPass.aspx");
    }
}


