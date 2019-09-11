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

public partial class ProMisVenDet : System.Web.UI.Page
{
    TblDetVentaUsu actualizar = new TblDetVentaUsu();
    int usu_cod, usu_vencod;
    string usu, usu_cods, usu_est;
    private void ListarRegistros()
    {
        try
        {
            using (SqlConnection conexi = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion_sin_clave"].ToString()))
            using (SqlDataAdapter da = new SqlDataAdapter("usp_Listar_consignacion", conexi))
            {
                DataTable tbRegistro = new DataTable();
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.Fill(tbRegistro);
                Session["Registros"] = tbRegistro;
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
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
            ListarRegistros();
        }
    }
    

    protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
    {
        
        usu_vencod = (int)Session["ven_cod_ved"];
        usu_est = ((DropDownList)e.Item.FindControl("DropDownList2")).SelectedValue;

        int resul = actualizar.actualizar_TblDetVentaUsu(usu_cod, usu_est, usu_vencod);
        if (resul == 2)
        {
            Response.Write("<script>alert('el estado de compra asido actualizado correctamente')</script>");
            Response.Redirect("ProMisVenDet.aspx");
        }
        else
        {
            Response.Write("<script>alert('Error actualizar estado')</script>");
            return;
        }
    }
}