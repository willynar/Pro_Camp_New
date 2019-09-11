using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//procamp
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Descripción breve de TblDetVenta
/// </summary>
public class TblDetVenta
{
    public TblDetVenta()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
    public int actualizar_TblDetVenta(int usu_cod, Byte[] cons_img,int ven_cod)
    {
        int rEsul = 1;//===========controla la conexion
        string estado = "revisar";
        try
        {


            using (SqlConnection conexi = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion_sin_clave"].ToString()))
            using (SqlCommand cmd = new SqlCommand("actualizar_detalle_venta_comp", conexi))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("usu_cod", usu_cod);
                cmd.Parameters.AddWithValue("ven_cod", ven_cod);
                cmd.Parameters.AddWithValue("cons_img", cons_img);
                cmd.Parameters.AddWithValue("estado", estado);

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