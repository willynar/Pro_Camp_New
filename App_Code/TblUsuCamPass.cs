using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//procamp
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
//librerias  encriptar
using System.Security.Cryptography;
using System.IO;
using System.Text;

/// <summary>
/// Descripción breve de TblUsuCamPass
/// </summary>
public class TblUsuCamPass
{
    public TblUsuCamPass()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
    public int Camb_TblUsuCamPass( string usu_pass_act, string usu_pass, int usu_cod)
    {
        string usu_cla_encriptada;
        int rEsul = 1;//===========controla la coneccion


        try
        {
            //===========se encripta la clave=============
            SHA512 sha512 = SHA512Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha512.ComputeHash(encoding.GetBytes(usu_pass));
            for (int i = 0; i < stream.Length; i++)
            {
                sb.AppendFormat("{0:x2}", stream[i]);
            }
            usu_cla_encriptada = sb.ToString();

            var conex = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion_sin_clave"].ConnectionString);
            var consulta = "select usu_cod from tbl_usuario where usu_cod = '" + usu_cod + "'";
            var coman = new SqlCommand(consulta, conex);
            conex.Open();
            SqlDataReader leerbd = coman.ExecuteReader();
            if (leerbd.Read() == true)
            {
                conex.Close();
               

                //===========se envian los datos  a la  bd con el procedimiento almacenado (registrar_usuario) =============
                using (SqlConnection conexi = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion_sin_clave"].ToString()))
                using (SqlCommand cmd = new SqlCommand("cambiar_contrasena", conexi))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("usu_cla", usu_cla_encriptada);
                    cmd.Parameters.AddWithValue("usu_cod", usu_cod);
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
