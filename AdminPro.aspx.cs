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


public partial class AdminPro : System.Web.UI.Page
{
    TblEliPro Eliminar_Pro = new TblEliPro();

    string usu;

    private void ListarRegistro()
    {
        usu = (string)Session["usu_ns"];/*------capturar variable de seccion------*/

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
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        ListarRegistro();
        Session["Transparencia"] = "0";
    }

    protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "Eliminar")
        {
            int pro_coi = Convert.ToInt32(e.CommandArgument.ToString());
            //int codigo = Convert.ToInt32(pro_coi);
            int resul = Eliminar_Pro.Eliminar_TblEliPro(pro_coi);
            if (resul == 1)
            {
                Response.Write("<script>alert('El producto a sido eliminado correctamente')</script>");
                Response.Redirect("AdminPro.aspx");
            }
            else
            {
                Response.Write("<script>alert('Error al eliminar el producto')</script>");
                return;
            }

        }
    }

    protected void Button11_Click(object sender, EventArgs e)
    {
        Response.Redirect("IniUsu.aspx");
    }
}