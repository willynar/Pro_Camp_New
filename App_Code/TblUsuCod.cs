using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Descripción breve de TblUsuCod
/// </summary>
public class TblUsuCod
{
    string mensajeCod;

    public string TblUsuCodConsultar_Codigo_Usuario(Decimal usuarioCod)
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
        /*=====================sacar el cod de usuario===============================*/
        var Sqlconn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion_sin_clave"].ConnectionString);
        var consulta = "select usu_cod from tbl_usuario where usu_cel = '" + usuarioCod + "'";
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