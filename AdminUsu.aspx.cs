using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class AdminUsu : System.Web.UI.Page
{
    TblUsuEst actualizar = new TblUsuEst();
    string usu;
    protected void Page_Load(object sender, EventArgs e)
    {
        
        Session["Transparencia"] = "0";
        Session["ocu_men_cont"] = "2";
        usu = (string)Session["usu_ns"];/*------capturar variable de seccion------*/

        if (usu == null)
        {
            Response.Redirect("loginUsu.aspx");
        }
        else
        if ((string)Session["ad_co"] == null)
        {
            Response.Write("<script>alert('solo se puede acceder al menu administrador a travez de una cuenta administrador')</script>");
            Response.Redirect("IniUsu.aspx");
        }
    }


    protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "Actualizar")
        {
            
            int usu_cod = Convert.ToInt32(e.CommandArgument.ToString());
            string usu_est = ((DropDownList)e.Item.FindControl("DropDownList1")).SelectedValue;

            int resul = actualizar.actualizar_TblUsuEst(usu_cod, usu_est);
            if (resul == 1)
            {
                Response.Write("<script>alert('El a sido actualizado correctamente')</script>");
                Response.Redirect("AdminUsu.aspx");
            }
            else
            {
                Response.Write("<script>alert('Error actualizar usuario')</script>");
                return;
            }

        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("IniUsu.aspx");
    }
}