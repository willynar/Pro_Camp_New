using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//procamp
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


/// <summary>
/// Descripción breve de TblPro
/// </summary>
public class TblPro
{
    public TblPro()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
    //AQUI VA EL CODIGO PARA INSERTAR EL REGSITRO EN LA BD
    //este metodo se usa para insertar registros de equipos en la BD

    public int Guardar_TblPro(int pro_cod,string pro_nom, string pro_cant,  int pro_val, int usu_cod, int pro_cat ,Byte[] pro_img)
    {
        
        int rEsul = 1;
              
        try

        {
            var conex = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion_sin_clave"].ConnectionString);
            var consulta = "select pro_cod from tbl_producto where pro_cod = " + pro_cod + "";
            var coman = new SqlCommand(consulta, conex);
            conex.Open();
            SqlDataReader leerbd = coman.ExecuteReader();
            if (leerbd.Read() == true)
            {
                rEsul = 2;
            }
            else
            {

                using (SqlConnection conexi = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion_sin_clave"].ToString()))
                using (SqlCommand cmd = new SqlCommand("ingresar_producto", conexi))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("pro_cod", pro_cod);
                    cmd.Parameters.AddWithValue("pro_nom", pro_nom);
                    cmd.Parameters.AddWithValue("pro_cant", pro_cant);
                    cmd.Parameters.AddWithValue("pro_val", pro_val);
                    cmd.Parameters.AddWithValue("usu_cod", usu_cod);
                    cmd.Parameters.AddWithValue("pro_cat", pro_cat);
                    cmd.Parameters.AddWithValue("pro_img", pro_img);
                    cmd.Connection.Open();
                    rEsul = cmd.ExecuteNonQuery();
                    cmd.Connection.Close();

                }


                if (rEsul == 0)
                {
                    rEsul = 0;


                }
            }
        }
        catch (Exception e)
        {
            string mensaje = e.Message;
        }
        return rEsul;

    }
}