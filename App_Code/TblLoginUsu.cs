using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;


/// <summary>
/// Descripción breve de usu
/// </summary>
public class TblLoginUsu
{
    //AQUI VA EL CODIGO PARA INSERTAR EL REGSITRO EN LA BD
    //este metodo se usa para insertar registros de equipos en la BD
    public string validar_acceso_usu_inyeccion_sp(Decimal usuario)
    {
        string mensaje;
        string usu_est = "activo";

        var conex = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion_sin_clave"].ConnectionString);
        SqlCommand leeSP = new SqlCommand("validar_acceso_usu", conex);
        leeSP.CommandType = CommandType.StoredProcedure;

        SqlParameter parametro1 = leeSP.Parameters.Add("@usuario", SqlDbType.Decimal,10);
        parametro1.Direction = ParameterDirection.Input;
        parametro1.Value = usuario;

        SqlParameter parametro2 = leeSP.Parameters.Add("@estado", SqlDbType.VarChar, 20);
        parametro2.Direction = ParameterDirection.Input;
        parametro2.Value = usu_est;

        conex.Open();
        SqlDataReader myReader = leeSP.ExecuteReader();
        if (myReader.Read() == true)
        {
            
            mensaje = "Éxito";
           
        }
        else
        {
            mensaje = "Error";
        }
        conex.Close();
        return mensaje;
    }
}