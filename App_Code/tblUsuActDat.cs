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
/// Descripción breve de tblUsuActDat
/// </summary>
public class tblUsuActDat
{
    public tblUsuActDat()
    {
       
    }
    string usu_cla_encriptada;

    //AQUI VA EL CODIGO PARA INSERTAR EL REGSITRO EN LA BD
    //este metodo se usa para insertar registros de equipos en la BD
    public int Actualizar_TblUsu(int usu_cod, string usu_nom, string usu_ape, string usu_email, string usu_cla, Decimal usu_ced, string usu_dir, Decimal usu_tel)
    {


        int rEsul = 1;//===========controla la conexion


        try
        {
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
            //=========== confirmar - clave=============

            var conex = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion_sin_clave"].ConnectionString);
            var consulta = "select usu_cla from tbl_usuario where usu_cla = '" + usu_cla_encriptada + "'and usu_cod = " + usu_cod + "";
            var coman = new SqlCommand(consulta, conex);
            conex.Open();
            SqlDataReader leerbd = coman.ExecuteReader();
            if (leerbd.Read() == false)
            {
                rEsul = 2;
            }
            else {
                //var conex1 = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion_sin_clave"].ConnectionString);
                //var insertar = "UPDATE tbl_usuario SET usu_nom ='" + usu_nom + "', usu_ape ='" + usu_ape + "' , usu_dir ='" + usu_dir + "' , usu_tel =" + usu_tel + " , usu_email ='" + usu_email + "' , usu_ced =" + usu_ced + " where usu_cod = " + usu_cod + "";
                //var comando = new SqlCommand(insertar, conex1);
                //conex1.Open();
                //int resul = comando.ExecuteNonQuery();
                //if (rEsul == 0)
                //{
                //    rEsul = 0;
                //    conex1.Close();
                //}

                //=========== se envian los datos a la bd con el procedimiento almacenado(registrar_usuario) =============
                using (SqlConnection conexi = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion_sin_clave"].ToString()))
                using (SqlCommand cmd = new SqlCommand("actualizar_usuario", conexi))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("usu_nom", usu_nom);
                    cmd.Parameters.AddWithValue("usu_ape", usu_ape);
                    cmd.Parameters.AddWithValue("usu_dir", usu_dir);
                    cmd.Parameters.AddWithValue("usu_tel", usu_tel);
                    cmd.Parameters.AddWithValue("usu_email", usu_email);
                    cmd.Parameters.AddWithValue("usu_ced", usu_ced);
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