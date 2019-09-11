<%@ WebHandler Language="C#" Class="manejadorImg" %>

using System;
using System.Web;
using System.Data;

public class manejadorImg : IHttpHandler,System.Web.SessionState.IRequiresSessionState {

    public void ProcessRequest (HttpContext context) {
        if (context.Session["Registro"] != null)
        {
            DataTable tbRegistro = (DataTable)context.Session["Registro"];
            DataRow drRegistro = tbRegistro.Select(string.Format("pro_cod={0}", context.Request.QueryString["pro_cod"]))[0];
            byte[] pro_img = (byte[])drRegistro["pro_img"];
            context.Response.ContentType = "image/jpg";
            context.Response.ContentType = "image/jpeg";
            context.Response.ContentType = "image/png";
            context.Response.ContentType = "image/gif";
            context.Response.ContentType = "image/bmp";
            context.Response.OutputStream.Write(pro_img, 0, pro_img.Length);
        }
    }

    public bool IsReusable {
        get {
            return false;
        }
    }
    //Eval("pro_cod", "manejadorImg.ashx?pro_cod={0}")
}