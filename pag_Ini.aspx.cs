using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class pag_Ini : System.Web.UI.Page
{
    string cer_bot;
    protected void Page_Load(object sender, EventArgs e)
    {
        cer_bot = "";
        Session["ocu_ini_ses"] = cer_bot;
    }
}