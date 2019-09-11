using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;
/// <summary>
/// Descripción breve de TblLogCodAd
/// </summary>
public class TblLogCodAd
{
    public TblLogCodAd()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
    string mensajeCod;

    public string Consultar_TblLogCodAd(Decimal usuarioCod)
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
        /*=====================sacar el cod de usuario===============================*/
        var Sqlconn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion_sin_clave"].ConnectionString);
        var consulta = "select rol_id from tbl_usuario where usu_cel = " + usuarioCod + "";
        var cmd = new SqlCommand(consulta, Sqlconn);
        Sqlconn.Open();
        SqlDataReader leerbd = cmd.ExecuteReader();
        if (leerbd.Read() == true)
        {
            //captura un dato tipo int
            mensajeCod = Convert.ToString(leerbd.GetValue(0));


        }
        else
        {
            mensajeCod = "";
        }

        Sqlconn.Close();

        return mensajeCod;

        /*============================fin consulta========================*/
    }
}