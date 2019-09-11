using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

using System.Net.Mail;
using System.Net;
using System.Text;

public partial class LoginRecPass : System.Web.UI.Page
{
    TblUsuConEma consultar = new TblUsuConEma();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button10_Click(object sender, EventArgs e)
    {
        string email;
       

        if (Correo.Text==""){
            Label14.Text = "Debe ingresar email";
            return;
        }
        else
        {
            email = Correo.Text;
            
            int rEsul=consultar.consultar_TblUsuConEma(email);

            if (rEsul == 1)
            {

                //===========validar correo =================
                //Creamos un nuevo Objeto de mensaje
                System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();

                //Direccion de correo electronico a la que queremos enviar el mensaje
                mmsg.To.Add("proyectoxadsi@gmail.com");

                //Nota: La propiedad To es una colección que permite enviar el mensaje a más de un destinatario

                //Asunto
                mmsg.Subject = "Solicitud cambio de clave";
                mmsg.SubjectEncoding = System.Text.Encoding.UTF8;

                //Direccion de correo electronico que queremos que reciba una copia del mensaje
                /*mmsg.Bcc.Add("procamp@gmail.com");*///Opcional

                //Cuerpo del Mensaje
                mmsg.Body = String.Format("<a href='{0}'>{1}</a>", "http://localhost:53326/(S(bpd1zbhxdc0lzivgqutn0osh))/DatUsuRecPass.aspx", "Click aquí para resetear mi clave");
                //mmsg.Body = "Hola, esto es una Prueba de envio de Mail desde ASP.NET";
                mmsg.BodyEncoding = System.Text.Encoding.UTF8;
                mmsg.IsBodyHtml = true; //Si no queremos que se envíe como HTML se pone en false

                //Correo electronico desde la que enviamos el mensaje
                mmsg.From = new System.Net.Mail.MailAddress("proyectoxadsi@gmail.com");


                /*-------------------------CLIENTE DE CORREO----------------------*/

                //Creamos un objeto de cliente de correo
                System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();

                //Hay que crear las credenciales del correo emisor
                cliente.Credentials = new System.Net.NetworkCredential("proyectoxadsi@gmail.com", "GRUPOSENA");

                //Lo siguiente es obligatorio si enviamos el mensaje desde Gmail
                cliente.Port = 587;
                cliente.EnableSsl = true;


                //cliente.Host = "mail.servidordominio.com"; 
                //Para Gmail es "smtp.gmail.com";
                cliente.Host = "smtp.gmail.com";

                /*-------------------------ENVIO DE CORREO----------------------*/

                try
                {
                    //Enviamos el mensaje      
                    cliente.Send(mmsg);
                    Label14.Text = "Mensaje enviado satisfactoriamente";
                }
                catch (System.Net.Mail.SmtpException ex)
                {
                    //Aquí gestionamos los errores al intentar enviar el correo
                    Label14.Text = "ERROR: " + ex.Message;
                }
            }
            else
            {
                Label14.Text = "!El email no existe¡";
            }
        }
    }
}