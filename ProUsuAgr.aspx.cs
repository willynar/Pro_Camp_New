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


public partial class ProUsuAgr : System.Web.UI.Page
{
    tblProConCod Consult = new tblProConCod();
    //ListarRegistro listar = new ListarRegistro();
    TblPro GuarPro = new TblPro();
    int usu_cod;
    string usu, usu_codd;
    //===================================================================
    private void ListarRegistro()
    {
        try
        {
            DataTable tbRegistro = new DataTable();

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion_sin_clave"].ToString()))
            {
                SqlCommand cmd = new SqlCommand("usp_Listar_producto_usu", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@usu_code", usu_cod);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.Fill(tbRegistro);
                GridView1.DataSource = tbRegistro;
                GridView1.DataBind();
                Session["Registro"] = tbRegistro;
            }
        }
        catch (Exception e)
        {
            string mensaje = e.Message;
            //throw;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

        usu = (string)Session["usu_cs"];               /*------capturar variable de sesion------*/
        if (usu == null)
    
        {
            Response.Redirect("loginUsu.aspx");
        }
        else
        {
            usu_cod = (int)Session["usu_c"];
            //==============================se consulta si existe la cuenta cancaria =======================================
            var Sqlconn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion_sin_clave"].ConnectionString);
            var consulta = "SELECT usu_ban, usu_cue FROM tbl_usuario where usu_cod = '" + usu_cod + "'";
            var cmd = new SqlCommand(consulta, Sqlconn);
            Sqlconn.Open();
            SqlDataReader leerbd = cmd.ExecuteReader();
            if (leerbd.Read() == true)
            {
                //===============se traen los datos de la consulta alas variables==============
                usu_codd = Convert.ToString(leerbd.GetValue(0));
                if (usu_codd == "0")
                {
                    Response.Redirect("DatUsuActCuen.aspx");
                }
            }
            
            

        }
        NomPro.Attributes["onkeypress"] = " return blocknum(event);";
        Valor.Attributes["onkeypress"] = " return blocklet(event);";
        ListarRegistro();
        //Response.Write("<script>alert('Recuerde para su mayor facilidad de uso a cada producto que ingrese se le sumara el 5% que equivale al iva que la dian en los productos')</script>");

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


    //=================================================================
    protected void Button10_Click(object sender, EventArgs e)
    {


        //==================
        string pro_nom,pro_cant;
        int pro_cat,pro_cod;
        int pro_val;
        Byte[] pro_img;

        pro_nom = NomPro.Text;
        pro_cant = Cantidad.Text;
        pro_cat = Convert.ToInt32(DropDownList.SelectedValue.ToString());
        pro_img = FileUpload1.FileBytes;

        if (Valor.Text == "")
        {
            pro_val = 0;

        }
        else
        {
            pro_val = Convert.ToInt32(Valor.Text);
        }
        //========== se valina los campos =========
        if (pro_nom == "")
        {
            Response.Write("<script>alert('Ingrese un nombre de producto')</script>");
            return;
        }
        else
        if (pro_val == 0)
        {
            Response.Write("<script>alert('Ingrese el valor del producto')</script>");
            return;
        }
        else
        if (pro_cant == "")
        {
            Response.Write("<script>alert('Ingrese la cantidad del producto')</script>");
            return;
        }
        else
        if (pro_cat == 0)
        {
            Response.Write("<script>alert('Ingrese el tipo de producto')</script>");
            return;
        }
        else
        {
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
                            pro_cod = Consult.TblUsuCodConsultar_Codigo_Producto();
                            pro_val = pro_val + pro_val *19/100;


                            int resul = GuarPro.Guardar_TblPro(pro_cod,pro_nom,pro_cant, pro_val, usu_cod, pro_cat,pro_img);

                            if (resul == 1)
                            {
                                
                                Response.Write("<script>alert('el producto a sido registrado correctamente')</script>");
                                NomPro.Text = "";
                                Valor.Text = "";
                                Cantidad.Text = "";
                                ////Mostrar el panel de Registros
                                ListarRegistro();


                            }
                            else if (resul == 2)
                            {
                                Response.Write("<script>alert('el producto ya existe')</script>");
                                return;
                            }else
                            {
                                Response.Write("<script>alert('Error al registrar el producto')</script>");
                                return;
                            }

                        }

                    }
                    else
                    {
                        Response.Write("<script>alert('Por favor verifique la extencion de la imagen')</script>");
                    }
                }

            }
            catch (Exception ex)
            {
                string mesnaje = ex.Message;
            }


        }
        //SEGUNDO:SE ENVIAN LOS DATOS AL MODELO (tbl_rol)
       

    }

    protected void Button11_Click1(object sender, EventArgs e)
    {

    }

 
}