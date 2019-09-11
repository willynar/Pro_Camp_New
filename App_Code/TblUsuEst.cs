using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;


/// <summary>
/// Descripción breve de TblUsuEst
/// </summary>
public class TblUsuEst
{
    public TblUsuEst()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
    public int actualizar_TblUsuEst(int usu_cod,string usu_est)
    {
        int rEsul = 1;//===========controla la coneccion



        try
        {
            using (SqlConnection conexi = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion_sin_clave"].ToString()))
            using (SqlCommand cmd = new SqlCommand("actualizar_estado_usuario", conexi))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("usu_cod", usu_cod);
                cmd.Parameters.AddWithValue("usu_est", usu_est);
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