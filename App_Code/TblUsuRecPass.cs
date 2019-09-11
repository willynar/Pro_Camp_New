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
/// Descripción breve de TblUsuRecPass
/// </summary>
public class TblUsuRecPass
{
    public TblUsuRecPass()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
    public int Recu_TblUsuRecPass(decimal usu_cel, string usu_email, string usu_cla)
    {
        string usu_cla_encriptada;
        int rEsul = 1;//===========controla la coneccion


        try

        {
            var conex = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion_sin_clave"].ConnectionString);
            var consulta = "select usu_cel and usu_email from tbl_usuario where usu_cel = '" + usu_cel + "'";
            var coman = new SqlCommand(consulta, conex);
            conex.Open();
            SqlDataReader leerbd = coman.ExecuteReader();
            if (leerbd.Read() == true)
            {
                conex.Close();
                //===========se encripta la clave=============
                SHA512 sha512 = SHA512Managed.Create();
                ASCIIEncoding encoding = new ASCIIEncoding();
                byte[] stream = null;
                StringBuilder sb = new StringBuilder();
                stream = sha512.ComputeHash(encoding.GetBytes(usu_cla));
                for (int i = 0; i < stream.Length; i++)
                {
                    sb.AppendFormat("{0:x2}", stream[i]);
                }
                usu_cla_encriptada = sb.ToString();

                //===========se envian los datos  a la  bd con el procedimiento almacenado (registrar_usuario) =============
                using (SqlConnection conexi = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion_sin_clave"].ToString()))
                using (SqlCommand cmd = new SqlCommand("recuperar_contraseña", conexi))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("usu_cla", usu_cla_encriptada);
                    cmd.Parameters.AddWithValue("usu_cel", usu_cel);
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