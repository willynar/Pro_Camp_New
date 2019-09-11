using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class comProPro : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["Transparencia"] = "0";
    }
    
    protected void ComprarPro_Click(object sender, EventArgs e)
    {

    }

    protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "agregar")
        {
            Response.Redirect("ComProDet.aspx?pro_cod=" + e.CommandArgument.ToString());

        }
    }
}