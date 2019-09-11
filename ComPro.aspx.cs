using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

using System.IO;

public partial class ComPro : System.Web.UI.Page
{
    string usu;
    private void ListarRegistro()
    {
        try
        {
            using (SqlConnection conexi = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion_sin_clave"].ToString()))
            using (SqlDataAdapter da = new SqlDataAdapter("usp_Listar_producto", conexi))
            {
                DataTable tbRegistro = new DataTable();
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.Fill(tbRegistro);
                Session["Registro"] = tbRegistro;
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["ocu_men_cont"] = "1";
        usu = (string)Session["usu_ns"];
        ListarRegistro();
        Session["Transparencia"] = "0";
    }



    protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (usu == null)
        {
            Response.Write("<script>alert('Para Agregar al carrito debe iniciar Sesion Primero')</script>");
        }
        else if(e.CommandName == "agregar")
        {
                Response.Redirect("ComProDet.aspx?pro_cod=" + e.CommandArgument.ToString());

        }
    }

    protected void ComprarPro_Click(object sender, EventArgs e)
    {
        

       
    }

 
}