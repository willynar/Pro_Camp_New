using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//procamp
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class ComProDet : System.Web.UI.Page
{
    venta vender = new venta();
    int usu_cod, currentrow;
    string usu,pro_est;
    int rEsul = 1;
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["ocu_men_cont"] = "2";
        Session["Transparencia"] = "0";
        //=================bloquear la funcion atras del navegador===================================

        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetExpires(DateTime.UtcNow.AddYears(-1));

        //==================================restringir accerso sin variable de sesion=========================================

        usu = (string)Session["usu_cs"];               /*------capturar variable de sesion------*/

        if (usu == null)
        {
            Response.Redirect("loginUsu.aspx");
        }
        else
        {
            usu_cod = (int)Session["usu_c"];
        }

        //==============================codigo agregar al grid view======================================
        if (!IsPostBack)
        {
            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add("sno");//variable de contador 
            dt.Columns.Add("pro_cod");
            dt.Columns.Add("pro_nom");
            dt.Columns.Add("pro_can");
            dt.Columns.Add("pro_vlr_venta");
            dt.Columns.Add("pro_img");
            

            if (Request.QueryString["pro_cod"] != null)  //ojo aqui habia un id
            {
                if (Session["Buyitems"] == null)
                {

                    dr = dt.NewRow();
                    //////String mycon = "Data Source=DESKTOP-96HRMA0\\SQLEXPRESS;Initial Catalog=PROCAMP;Integrated Security=True"; // ojo aqui se duplico \ ese back slash
                    //////SqlConnection scon = new SqlConnection(mycon);
                    var scon = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion_sin_clave"].ConnectionString);
                    String myquery = "select * from tbl_producto where pro_cod=" + Request.QueryString["pro_cod"];
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = myquery;
                    cmd.Connection = scon;
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    dr["sno"] = 1;   //variable de contador 
                    dr["pro_cod"] = ds.Tables[0].Rows[0]["pro_cod"].ToString();
                    dr["pro_nom"] = ds.Tables[0].Rows[0]["pro_nom"].ToString();
                    dr["pro_can"] = ds.Tables[0].Rows[0]["pro_can"].ToString();
                    dr["pro_img"] = ds.Tables[0].Rows[0]["pro_img"].ToString();
                    dr["pro_vlr_venta"] = ds.Tables[0].Rows[0]["pro_vlr_venta"].ToString();
                    dt.Rows.Add(dr);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                    Session["buyitems"] = dt;
                }
                else
                {

                    dt = (DataTable)Session["buyitems"];
                    int sr;
                    sr = dt.Rows.Count;

                    dr = dt.NewRow();
                    //////String mycon = "Data Source=DESKTOP-96HRMA0\\SQLEXPRESS;Initial Catalog=PROCAMP;Integrated Security=True";// ojo aqui se duplico \ ese back slash
                    //////SqlConnection scon = new SqlConnection(mycon);
                    var scon = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion_sin_clave"].ConnectionString);
                    String myquery = "select * from tbl_producto where pro_cod=" + Request.QueryString["pro_cod"];
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = myquery;
                    cmd.Connection = scon;
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    DataSet ds = new DataSet();
                    da.Fill(ds);


                    //////prueba para validar que no se graben registros repetidos//// 

                    foreach (DataRow row in dt.Rows)
                    {
                        string pro_cod = row["pro_cod"].ToString();
                        string pro_cod1 = ds.Tables[0].Rows[0]["pro_cod"].ToString();
                        if (pro_cod == pro_cod1)
                        {
                            currentrow = 1;
                            break;
                        }
                        else
                        {
                            currentrow = 0;
                        }                       
                    }
                    if (currentrow == 0)
                    {
                        dr["sno"] = sr + 1;
                        dr["pro_cod"] = ds.Tables[0].Rows[0]["pro_cod"].ToString();
                        dr["pro_nom"] = ds.Tables[0].Rows[0]["pro_nom"].ToString();
                        dr["pro_can"] = ds.Tables[0].Rows[0]["pro_can"].ToString();
                        dr["pro_img"] = ds.Tables[0].Rows[0]["pro_img"].ToString();
                        dr["pro_vlr_venta"] = ds.Tables[0].Rows[0]["pro_vlr_venta"].ToString();
                        dt.Rows.Add(dr);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                        Session["buyitems"] = dt;
                    }
                    else
                    {
                        Response.Write("<script>alert('No se pueden insertar productos repetidos')</script>");
                       // Response.Redirect("ComPro.aspx");
                    }

                }
            }
            else
            {
                dt = (DataTable)Session["buyitems"];
                GridView1.DataSource = dt;
                GridView1.DataBind();

            }

        }
    }
    //================fin pageload===================


    protected void Button1_Click(object sender, EventArgs e)
    {
        //primero grabamos el encabezado

        int consecutivo, usu_cod, ven_tot_venta,pro_cod;
        string fec_actual, estado, tipo_venta,pro_nom, pro_can;
        int pro_vlr_venta;

        //se captura el consecutivo de ventas
        consecutivo = vender.buscar_consecutivo();

        //se captura la fecha del sistema
        fec_actual = DateTime.Now.ToString("yyyy-MM-dd");

        //se captura la variable de sesion del usuario
        usu_cod = (int)Session["usu_c"];

        //se inicializa el total en cero

        ven_tot_venta = 0;

        //se captura el estado
        estado = "Activa";

        //se graba el tipo de venta
        tipo_venta = "Venta";


        //se envian los datos a la tabla venta en la bd
        string rdo = vender.grabar_encabezado_venta(consecutivo, fec_actual,usu_cod, ven_tot_venta, estado,tipo_venta);

        if (rdo == "OK")
        {
            //se graba el detalle que en este caso es la grilla
            //SE RECORREN LAS FILAS DE LA GRILLA
            foreach (GridViewRow GVRow in this.GridView1.Rows)
            {
                pro_cod = Convert.ToInt32(GVRow.Cells[1].Text);

                pro_nom = (GVRow.Cells[2].Text);

                pro_can = (GVRow.Cells[3].Text);


                pro_vlr_venta = Convert.ToInt32(GVRow.Cells[4].Text);

                int vlr_iva = Convert.ToInt32(pro_vlr_venta * 0.19);

                pro_est = "inactivo";

               
                //aqui se debe consultar la cantidad de existencias en el inventario

                string existencias = vender.consultar_existencias(pro_cod);

                if (pro_can != "" && existencias != "")
                {
                    //se van grabando los registros en la tabla: tbl_det_venta
                    Label1.Text = vender.grabar_detalle_venta(consecutivo, pro_cod, pro_can, vlr_iva, pro_vlr_venta);
                   

                    //para actulizar el estado del producto 
                    using (SqlConnection conexi = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion_sin_clave"].ToString()))
                    using (SqlCommand cmd = new SqlCommand("actualizar_estado_producto", conexi))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("pro_cod", pro_cod);
                        cmd.Parameters.AddWithValue("pro_est", pro_est);

                        cmd.Connection.Open();
                        rEsul = cmd.ExecuteNonQuery();

                    }
                    if (rEsul == 0)
                    {
                        Response.Write("<script>alert('No se pudo cambiar el estado del producto')</script>");
                        return;
                    }
                }
                else
                {
                    Label1.Text = "La cantidad del producto " + pro_cod + ", debe ser mayor a Cero y menor a las existencias en la bodega";
                    Label1.Visible = true;
                }

            }
            Label1.Visible = true;
            Session.Remove("buyitems");
            Session["ven_c"] = consecutivo;
            Response.Redirect("ProTotPag.aspx");
        }

        
    }

    protected void Button10_Click(object sender, EventArgs e)
    {
        Response.Redirect("ComPro.aspx");
    }
}