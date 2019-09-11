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
public class TblEliPro
{
    public TblEliPro()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
    public int Eliminar_TblEliPro(int pro_cod)
    {
        int rEsul = 1;//===========controla la coneccion
        


        try
        {
            using (SqlConnection conexi = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion_sin_clave"].ToString()))
            using (SqlCommand cmd = new SqlCommand("eliminar_producto", conexi))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("pro_cod", pro_cod);
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