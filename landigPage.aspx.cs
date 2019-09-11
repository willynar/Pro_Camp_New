using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class landigPage : System.Web.UI.Page
{
    TblGuarConta GuarConta = new TblGuarConta();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string conta_nom, conta_email, conta_mens;
        

        conta_nom = Nombre.Text;
        conta_email = Correo.Text;
        conta_mens = Mensaje.Text;

        if (conta_nom == "")
        {
            Label13.Text = "Ingrese nombre";
            return;
        }
        else
        if (conta_email == "")
        {
            Label13.Text = "";
            Label14.Text = "Ingrese Correo";
            return;
        }
        else
        if (conta_mens == "")
        {
            //Response.Write("<script>alert('Ingrese correo')</script>");
            Label14.Text = "";

            Label15.Text = "Ingrese un mensaje";
            return;
        }
        else
        {
            //============se envian los datos ala clase================
            int resul = GuarConta.Guardar_TblGuarConta(conta_nom, conta_email, conta_mens);

            if (resul == 1)
            {
                Response.Write("<script>alert('Su mensaje a sido enviado correctamente')</script>");
                Nombre.Text  = "";
                Correo.Text  = "";
                Mensaje.Text = "";
            }
            else
            {
                Response.Write("<script>alert('Error al enviar su mensaje')</script>");
                return;
            }
        }
    }
}