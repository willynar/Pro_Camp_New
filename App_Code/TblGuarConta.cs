using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Descripción breve de TblGuarConta
/// </summary>
public class TblGuarConta
{
    public TblGuarConta()
    {

    }

    public int Guardar_TblGuarConta(string conta_nom, string conta_email ,string conta_mens)
    {
        int rEsul = 1;//===========controla la coneccion
        try
        {
            using (SqlConnection conexi = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion_sin_clave"].ToString()))
            using (SqlCommand cmd = new SqlCommand("ingresar_contactenos", conexi))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("conta_nom", conta_nom);
                cmd.Parameters.AddWithValue("conta_email", conta_email);
                cmd.Parameters.AddWithValue("conta_mens", conta_mens);               
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