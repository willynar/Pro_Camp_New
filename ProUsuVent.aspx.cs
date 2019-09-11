using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProUsuVent : System.Web.UI.Page
{
    int usu_cod;
    string usu, usu_cods;
    protected void Page_Load(object sender, EventArgs e)
    {
        usu = (string)Session["usu_ns"];
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

    protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
    {
        int ven_c = Convert.ToInt32(e.CommandArgument.ToString());
        Session["ven_cod_ved"] = Convert.ToInt32(ven_c);
        Response.Redirect("ProMisVenDet.aspx");

    }
}