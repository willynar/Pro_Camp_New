using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Fac :  System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["Transparencia"] = "1";
    }

    protected void Button10_Click(object sender, EventArgs e)
    {
        if (Label13.Visible == false)//si el label esta visible
        {
            Label13.Visible = true;  //ojo desocultar label de la respuesta agalo visible
        }
        else
        {
            Label13.Visible = false;  //ojo oultar label de la respuesta agalo invisible
        }
        
    }

    protected void Button11_Click(object sender, EventArgs e)
    {
        if (Label14.Visible == false)//si el label esta visible
        {
            Label14.Visible = true;  //ojo desocultar label de la respuesta agalo visible
        }
        else
        {
            Label14.Visible = false;  //ojo oultar label de la respuesta agalo invisible
        }
    }

    protected void Button12_Click(object sender, EventArgs e)
    {
        if (Label15.Visible == false)//si el label esta visible
        {
            Label15.Visible = true;  //ojo desocultar label de la respuesta agalo visible
        }
        else
        {
            Label15.Visible = false;  //ojo oultar label de la respuesta agalo invisible
        }
    }

    protected void Button13_Click(object sender, EventArgs e)
    {
        if (Label16.Visible == false)//si el label esta visible
        {
            Label16.Visible = true;  //ojo desocultar label de la respuesta agalo visible
        }
        else
        {
            Label16.Visible = false;  //ojo oultar label de la respuesta agalo invisible
        }
    }

    protected void Button14_Click(object sender, EventArgs e)
    {
        if (Label17.Visible == false)//si el label esta visible
        {
            Label17.Visible = true;  //ojo desocultar label de la respuesta agalo visible
        }
        else
        {
            Label17.Visible = false;  //ojo oultar label de la respuesta agalo invisible
        }
    }

    protected void Button15_Click(object sender, EventArgs e)
    {
        if (Label18.Visible == false)//si el label esta visible
        {
            Label18.Visible = true;  //ojo desocultar label de la respuesta agalo visible
        }
        else
        {
            Label18.Visible = false;  //ojo oultar label de la respuesta agalo invisible
        }
    }

    protected void Button16_Click(object sender, EventArgs e)
    {
        if (Label19.Visible == false)//si el label esta visible
        {
            Label19.Visible = true;  //ojo desocultar label de la respuesta agalo visible
        }
        else
        {
            Label19.Visible = false;  //ojo oultar label de la respuesta agalo invisible
        }
    }

    protected void Button17_Click(object sender, EventArgs e)
    {
        if (Label20.Visible == false)//si el label esta visible
        {
            Label20.Visible = true;  //ojo desocultar label de la respuesta agalo visible
            HyperLink1.Visible = true;
        }
        else
        {
            Label20.Visible = false;  //ojo oultar label de la respuesta agalo invisible
            HyperLink1.Visible = false;
        }
    }

    protected void Button18_Click(object sender, EventArgs e)
    {
        if (video.Visible == false)//si el label esta visible
        {
            video.Visible = true;  //ojo desocultar label de la respuesta agalo visible
        }
        else
        {
            video.Visible = false;  //ojo oultar label de la respuesta agalo invisible
        }
    }
}