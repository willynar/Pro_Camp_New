using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//procamp
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


/// <summary>
/// Descripción breve de TblUsuActCue
/// </summary>
public class TblUsuActCue
{
    public TblUsuActCue()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
    public int Actualizar_TblUsuActCue(string usu_ban, int usu_cuent, int usu_c)
    {
        int rEsul = 1;//===========controla la coneccion
        try
        { 
        //===========se envian los datos  a la  bd con el procedimiento almacenado (registrar_usuario) =============
        using (SqlConnection conexi = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion_sin_clave"].ToString()))
        using (SqlCommand cmd = new SqlCommand("actualizar_cuenta_usuario", conexi))
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("usu_c", usu_c);
            cmd.Parameters.AddWithValue("usu_cuent", usu_cuent);
            cmd.Parameters.AddWithValue("usu_ban", usu_ban);

            cmd.Connection.Open();
            rEsul = cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }
        if (rEsul == 0)
        {
            rEsul = 0;
        }
        }
        catch (Exception e)
        {
            string mensaje = e.Message;
        }
        return rEsul;
    }
}