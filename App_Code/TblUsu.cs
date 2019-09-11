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
/// Descripción breve de TblUsu
/// </summary>
public class TblUsu
{
    string usu_cla_encriptada;
    public TblUsu()
    {
        
        
    }
    
    //AQUI VA EL CODIGO PARA INSERTAR EL REGSITRO EN LA BD
    //este metodo se usa para insertar registros de equipos en la BD
    public int Guardar_TblUsu(string usu_nom, string usu_ape, string usu_email, string usu_cla, Decimal usu_ced, string usu_dir,Decimal usu_cel)
    {
        int usu_cue = 0;
        string  usu_ban= "";
        string usu_est = "activo";
        Decimal usu_tel= 0;
        int rEsul = 1;//===========controla la coneccion
        int rol_id = 2;

        try
            
        {      
            var conex = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion_sin_clave"].ConnectionString);
            var consulta = "select usu_cel from tbl_usuario where usu_cel = '" + usu_cel + "'";
            var coman = new SqlCommand(consulta, conex);
            conex.Open();
            SqlDataReader leerbd = coman.ExecuteReader();
            if (leerbd.Read() == true)
            {
                rEsul = 2;
            }
            else
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
                using (SqlCommand cmd = new SqlCommand("registrar_usuario", conexi))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("usu_cla_encriptada", usu_cla_encriptada);
                    cmd.Parameters.AddWithValue("usu_nom", usu_nom);
                    cmd.Parameters.AddWithValue("usu_ape", usu_ape);
                    cmd.Parameters.AddWithValue("usu_dir", usu_dir);
                    cmd.Parameters.AddWithValue("usu_tel", usu_tel);
                    cmd.Parameters.AddWithValue("usu_cel", usu_cel);
                    cmd.Parameters.AddWithValue("usu_email", usu_email);
                    cmd.Parameters.AddWithValue("usu_ced", usu_ced);
                    cmd.Parameters.AddWithValue("rol_id", rol_id);
                    cmd.Parameters.AddWithValue("usu_est", usu_est);
                    cmd.Parameters.AddWithValue("usu_cue", usu_cue);
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
        }
        catch (Exception e)
        {
            string mensaje = e.Message;
        }
        return rEsul;       

    }
}   