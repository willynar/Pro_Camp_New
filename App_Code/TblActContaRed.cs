using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//procamp
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Descripción breve de TblActContaRed
/// </summary>
public class TblActContaRed
{
    public TblActContaRed()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
    public int Actualizar_TblActContaRed(Decimal pag_tel, string pag_ubi, string pag_fac, string pag_twi, string pag_pin, string pag_you)
    {
        int rEsul = 1;//===========controla la conexion

        try { 


            using (SqlConnection conexi = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion_sin_clave"].ToString()))
            using (SqlCommand cmd = new SqlCommand("actualizar_contactos_pag", conexi))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("pag_tel", pag_tel);
                cmd.Parameters.AddWithValue("pag_ubi", pag_ubi);
                cmd.Parameters.AddWithValue("pag_fac", pag_fac);
                cmd.Parameters.AddWithValue("pag_twi", pag_twi);
                cmd.Parameters.AddWithValue("pag_pin", pag_pin);
                cmd.Parameters.AddWithValue("pag_you", pag_you);
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