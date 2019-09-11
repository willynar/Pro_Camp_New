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

public partial class DatUsuAct : System.Web.UI.Page
{
    tblUsuActDat objeto = new tblUsuActDat();
    //DataSet dataset = new DataSet();

    //=============conectar la tabla===========0
    tblUsuActDat ActualizarDat = new tblUsuActDat();
    //tblUsuConActDat Consultar = new tblUsuConActDat();

    //==============inicializar variables del page load==============
    int usu_cod;
    string usu,usu_cods;
    string usu_nom, usu_ape, usu_email, usu_dir;
    Decimal usu_ced, usu_tel;
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["Transparencia"] = "0";
        usu = (string)Session["usu_ns"];/*------capturar variable de seccion------*/

        if (usu == null)
        {
            Response.Redirect("loginUsu.aspx");
        }
        else
        {
            usu_cod = (int)Session["usu_c"];
            usu_cods = (string)Session["usu_cs"];

            //===========librerias de validaciones=============
            Nombre.Attributes["onkeypress"] = " return blocknum(event);";
            Apellidos.Attributes["onkeypress"] = " return blocknum(event);";
            Cedula.Attributes["onkeypress"] = " return blocklet(event);";

            //===============se hace la consulta de los datos de usuario==============
            var Sqlconn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion_sin_clave"].ConnectionString);
            var consulta = "select * from tbl_usuario where usu_cod = '" + usu_cod + "'";
            var cmd = new SqlCommand(consulta, Sqlconn);
            Sqlconn.Open();
            SqlDataReader leerbd = cmd.ExecuteReader();
            if (leerbd.Read() == true)
            {
                //===============se traen los datos de la consulta alas variables==============
                usu_nom = Convert.ToString(leerbd.GetValue(2));
                usu_ape = Convert.ToString(leerbd.GetValue(3));
                usu_email = Convert.ToString(leerbd.GetValue(7));
                usu_dir = Convert.ToString(leerbd.GetValue(4));
                usu_ced = Convert.ToDecimal(leerbd.GetValue(8));
                usu_tel = Convert.ToDecimal(leerbd.GetValue(5));


            }
            Sqlconn.Close();

        }
        //============enviar datos a los label==============
        LabelNom.Text = usu_nom;
        LabelApe.Text = usu_ape;
        LabelMai.Text = usu_email;
        LabelDir.Text = usu_dir;
        LabelCed.Text = Convert.ToString(usu_ced);
        LabelTel.Text = Convert.ToString(usu_tel);
    }

    protected void Button10_Click(object sender, EventArgs e)
    {
        string usu_cla, usu_Cocla;

       

        //==========================
        usu_cla = Contrasena.Text;
        usu_Cocla = Confirmar.Text;

        //==========si la caja de texto tiene datos los envia de nuevo a la bd===========
        if ( Nombre.Text != "")
        {
            usu_nom = Nombre.Text;
        }
                   
        if (Apellidos.Text != "")
        {
            usu_ape = Apellidos.Text;
        }
        
        if (Correo.Text != "")
        {
            usu_email = Correo.Text;
        }
       
        if (Direccion.Text != "")
        {
            usu_dir = Direccion.Text;
        }
       
        if (Telefono.Text != "")
        {
            usu_tel = Convert.ToDecimal(Telefono.Text);
        }
       
        if (Cedula.Text != "")
        {            
            usu_ced = Convert.ToDecimal(Cedula.Text);
        }
             
                     
        ////========================== se valina los campos ==========================
        if (usu_cla == "")
        {
            Label37.Text = "Debe ingresar contraseña";
            return;
        }
        else
        if (Contrasena.Text.Length < 8)
        {
           Label37.Text = "minimo de caracateres es 8";
            return;
        }
        else
        if (usu_Cocla == "")
        {
           Label37.Text = "";
           Label38.Text = "Confirme la contraseña";
            return;
        }

        else
        if (Confirmar.Text.Length < 8)
        {
            Label38.Text = "minimo de caracateres es 8";
            return;
        }
        else /*se confirma que las contraseñas coincidan*/
        if (usu_Cocla != usu_cla)
        {
            Label37.Text = "Las contraseñas deben coincidir";
            Label38.Text = "Las contraseñas deben coincidir";
            return;
        }
        else
        {
            //============se envian los datos ala clase================
            int resul = ActualizarDat.Actualizar_TblUsu(usu_cod, usu_nom, usu_ape, usu_email, usu_cla, usu_ced, usu_dir, usu_tel);

            if (resul == 1)
            {
                Response.Write("<script>alert('los datos se han cambiado Correctamente')</script>");
                Nombre.Text = "";
                Apellidos.Text = "";
                Correo.Text = "";
                Contrasena.Text = "";
                Confirmar.Text = "";
                Cedula.Text = "";
                Direccion.Text = "";
                Telefono.Text = "";

                //============enviar datos a los label==============
                LabelNom.Text = usu_nom;
                LabelApe.Text = usu_ape;
                LabelMai.Text = usu_email;
                LabelDir.Text = usu_dir;
                LabelCed.Text = Convert.ToString(usu_ced);
                LabelTel.Text = Convert.ToString(usu_tel);
                //Response.Redirect("DatUsuAct.aspx");
            }
            else
            if (resul == 2)
            {
                Response.Write("<script>alert('Error al actualizar la contraseña es incorrecta')</script>");
                return;

            }
            else
            {
                Response.Write("<script>alert('Error al actualizar Datos')</script>");
                return;
            }
        }
    }
}