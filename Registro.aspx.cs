using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Security.Cryptography;
using System.IO;
using System.Text;

public partial class Registro : System.Web.UI.Page
{
    TblUsu GuarUsu = new TblUsu();
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["Transparencia"] = "1";
        Session["ocu_men_cont"] = "2";
        Nombre.Attributes["onkeypress"] = " return blocknum(event);";
        Apellidos.Attributes["onkeypress"] = " return blocknum(event);";
        Cedula.Attributes["onkeypress"] = " return blocklet(event);";
        Celular.Attributes["onkeypress"] = " return blocklet(event);";

        
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string usu_nom, usu_ape, usu_email, usu_cla, usu_Cocla, usu_dir;
        Decimal usu_cel, usu_ced;

        usu_nom = Nombre.Text;
        usu_ape = Apellidos.Text;
        usu_email = Correo.Text;
        usu_cla = Contrasena.Text;
        usu_Cocla = Confirmar.Text;
        if (Cedula.Text == "")
        {
            usu_ced = 0;

        }
        else
        {
            usu_ced = Convert.ToDecimal(Cedula.Text);
        }

        usu_dir = Direccion.Text;

        if (Celular.Text == "")
        {
            usu_cel = 0;

        }
        else
        {
            usu_cel = Convert.ToDecimal(Celular.Text);
        }


        ////se valina los campos
        if (usu_nom == "")
        {
            Label13.Text = "Ingrese nombre";
            return;
        }
        else
        if (usu_ape == "")
        {
            Label13.Text = "";
            Label14.Text = "Ingrese apellidos";
            return;
        }
        else
        if (usu_email == "")
        {
            //Response.Write("<script>alert('Ingrese correo')</script>");
            Label14.Text = "";
            Label15.Text = "Ingrese correo";
            return;
        }                  
        else
            if (usu_ced == 0)
        {
            Label15.Text = "";
            Label17.Text = "Ingrese cedula";
            return;
        }
        else
            if (usu_dir == "")
        {
            Label17.Text = "";
            Label18.Text = "Ingrese direccion";
            return;
        }
        else
        if (usu_cel == 0)
        {
             Label18.Text = "";
            Label19.Text = "Ingrese celular";
            return;
        }
        else
           if (Celular.Text.Length < 10)
        {
            Label18.Text = "";
            Label19.Text = "minimo de caracateres es 10";
            return;
        }
        else
        if (usu_cla == "")
        {
            Label19.Text = "";
            Label16.Text = "Ingrese contraseña";
            return;
        }
        else
            if (Contrasena.Text.Length <= 8)
        {
            Label19.Text = "";
            Label16.Text = "minimo de caracateres es 8";
            return;
        }
        else
        if (usu_Cocla == "")
        {
            Label19.Text = "";
            Label9.Text = "Confirme la contraseña";
            return;
        }

        else
            if (Confirmar.Text.Length < 8)
        {
            Label9.Text = "minimo de caracateres es 8";
            return;
        }
        else /*se confirma que las contraseñas coincidan*/
            if (usu_Cocla != usu_cla)
        {
            Label16.Text = "Las contraseñas deben coincidir";
            Label9.Text = "Las contraseñas deben coincidir";
            return;
        }else
        {
            //============se envian los datos ala clase================
            int resul = GuarUsu.Guardar_TblUsu(usu_nom, usu_ape, usu_email, usu_cla, usu_ced, usu_dir, usu_cel);

            if (resul == 1)
            {
                Response.Write("<script>alert('el usuario registrado correctamente')</script>");
                Nombre.Text = "";
                Apellidos.Text = "";
                Correo.Text = "";
                Contrasena.Text = "";
                Confirmar.Text = "";
                Cedula.Text = "";
                Direccion.Text = "";
                Celular.Text = "";
                Label9.Text = "";
                Response.Redirect("loginUsu.aspx");
            }
            else
            if (resul == 2)
            {
                Response.Write("<script>alert('Error al registrar el usuario el celular ya existe')</script>");
                return;

            }
            else
            {
                Response.Write("<script>alert('Error al registrar el usuario')</script>");
                return;
            }
        }


    }

   
}

   