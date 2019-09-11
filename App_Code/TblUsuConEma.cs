using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//procamp
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
/// <summary>
/// Descripción breve de TblUsuConEma
/// </summary>
public class TblUsuConEma
{
    public TblUsuConEma()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
    public int consultar_TblUsuConEma(string usu_ema)
    {
        int rEsul = 1;//===========controla la coneccion
        try
        {
            var conex = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion_sin_clave"].ConnectionString);
            var consulta = "select usu_email from tbl_usuario where usu_email = '" + usu_ema + "'";
            var coman = new SqlCommand(consulta, conex);
            conex.Open();
            SqlDataReader leerbd = coman.ExecuteReader();
            if (leerbd.Read() == false)
            {
                rEsul = 2;
            }
            
        }
        catch (Exception e)
        {
            string mensaje = e.Message;
        }
        return rEsul;
    }
}