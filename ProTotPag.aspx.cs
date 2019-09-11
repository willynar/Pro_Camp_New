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

public partial class ProTotPag : System.Web.UI.Page
{
    TblDetVenta actualizar = new TblDetVenta();
    int val_cod,usu_cod;
    string val_tot,usu_cuenta,est_cuenta,usu_est, usu_tel, usu_cel;

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
        //Session["ven_c"] = 14;
        val_cod = (int)Session["ven_c"];
        ListarRegistro();


    }
    //==============================codigos imagen=================

    private Boolean ValidarExtension(string sExtension)        //=====
    {                                                          //=====
        Boolean verif = false;                                 //=====
        switch (sExtension)
        {                                                      //=====
            case ".jpg":                                       //=====
            case ".jpeg":
            case ".png":                                        //=====tengo dudas de como se usa este bloque
            case ".gif":                                        //=====
            case ".bmp":
                verif = true;
                break;                                          //=====
            default:                                            //=====
                verif = false;                                  //=====
                break;
        }                                                       //=====
        return verif;                                           //=====
    }

    //===================================================================

    protected void Button10_Click(object sender, EventArgs e)
    {
       

        usu_cod = Convert.ToInt32(DropDownList1.SelectedValue);

        try
        {

        //===============se hace la consulta valor total compra==============
        var Sqlconn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion_sin_clave"].ConnectionString);
        var consulta = "SELECT SUM  (tbl_producto.pro_vlr_venta) FROM tbl_producto INNER JOIN tbl_det_venta ON tbl_producto.pro_cod = tbl_det_venta.pro_cod WHERE (tbl_det_venta.ven_cod = " + val_cod + ") AND (tbl_producto.usu_cod = " + usu_cod + ")";
        var cmd = new SqlCommand(consulta, Sqlconn);
        Sqlconn.Open();
        SqlDataReader leerbd = cmd.ExecuteReader();
        if (leerbd.Read() == true)
        {
            //===============se traen los datos de la consulta alas variables==============
            val_tot = Convert.ToString(leerbd.GetValue(0));
        }
        else
        {
            val_tot = "0";
        }
        Sqlconn.Close();

    
        //============enviar datos a los label==============
        Label16.Text = val_tot;
        


        //==================================================se hace la consulta numero de cuenta y estado del compra===========================================
            var Sqlconn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion_sin_clave"].ConnectionString);
            var consulta1 = "SELECT DISTINCT  tbl_usuario.usu_cel,tbl_usuario.usu_tel,tbl_usuario.usu_ban,tbl_usuario.usu_cue, tbl_det_venta.det_ven_est from tbl_usuario inner join tbl_producto on tbl_usuario.usu_cod = tbl_producto.usu_cod inner join tbl_det_venta on tbl_det_venta.pro_cod = tbl_producto.pro_cod inner join tbl_venta on tbl_venta.ven_cod = tbl_det_venta.ven_cod WHERE(tbl_det_venta.ven_cod = " + val_cod + ") AND(tbl_producto.usu_cod = " + usu_cod + ")";
            //var consulta1 = "SELECT DISTINCT  tbl_usuario.usu_cel,tbl_usuario.usu_tel,tbl_usuario.usu_ban,tbl_usuario.usu_cue, tbl_det_venta.det_ven_est FROM tbl_det_venta INNER JOIN tbl_venta ON tbl_det_venta.ven_cod = tbl_venta.ven_cod INNER JOIN tbl_usuario ON tbl_venta.usu_cod = tbl_usuario.usu_cod INNER JOIN tbl_producto ON tbl_usuario.usu_cod = tbl_producto.usu_cod WHERE(tbl_det_venta.ven_cod = " + val_cod + ") AND(tbl_producto.usu_cod =" + usu_cod + ")";
            var cmd1 = new SqlCommand(consulta1, Sqlconn1);
            Sqlconn1.Open();
            SqlDataReader leerbd1 = cmd1.ExecuteReader();
            if (leerbd1.Read() == true)
            {
                //===============se traen los datos de la consulta alas variables==============
                usu_cel = Convert.ToString(leerbd1.GetValue(0));
                usu_tel = Convert.ToString(leerbd1.GetValue(1));
                usu_est = Convert.ToString(leerbd1.GetValue(2));
                usu_cuenta = Convert.ToString(leerbd1.GetValue(3));
                est_cuenta = Convert.ToString(leerbd1.GetValue(4));
            }
            else
            {
                val_tot = "0";
            }
            Sqlconn.Close();


            //============enviar datos a los label==============
            Label26.Text = usu_cel;
            Label27.Text = usu_tel;
            Label23.Text = usu_est;
            Label19.Text = usu_cuenta;
            Label21.Text = est_cuenta;

        }
        catch
        {

        }

    }

    protected void Button11_Click(object sender, EventArgs e)
    {
        Byte[] pro_img;
        pro_img = FileUpload1.FileBytes;

        usu_cod = Convert.ToInt32(DropDownList1.SelectedValue);
        try
        {
            string Extension = string.Empty;
            string Nombre = string.Empty;

            if (FileUpload1.HasFile)
            {
                Nombre = FileUpload1.FileName;
                Extension = Path.GetExtension(Nombre);

                if (ValidarExtension(Extension))
                {
                    int intDocFileLength = FileUpload1.PostedFile.ContentLength;
                    if (intDocFileLength > 4096000)
                    {
                        Response.Write("<script>alert('verifica, la imagen excede los 4MB')</script>");
                    }
                    else
                    {
                        int resul = actualizar.actualizar_TblDetVenta(usu_cod,pro_img, val_cod);
                    }
                }
            }
        }
        catch
        {

        }
    }
}