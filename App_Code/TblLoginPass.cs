using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Security.Cryptography;
using System.IO;
using System.Text;

/// <summary>
/// Descripción breve de loggin
/// </summary>
public class TblLoginPass
{
    string usu_cla_encriptada;
    string mensaje;
    public string validar_acceso_inyeccion_clave_sp(Decimal usuario,string usu_cla)
    {
        SqlConnection conex = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion_sin_clave"].ConnectionString);
        SqlCommand leeSP = new SqlCommand("validar_acceso_cla", conex);
        leeSP.CommandType = CommandType.StoredProcedure;


        SqlParameter parametro1 = leeSP.Parameters.Add("@usuario", SqlDbType.Decimal,10);
        parametro1.Direction = ParameterDirection.Input;
        parametro1.Value = usuario;

        //para encriptar password

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

        SqlParameter parametro2 = leeSP.Parameters.Add("@clave", SqlDbType.VarChar, 600);
        parametro2.Direction = ParameterDirection.Input;
        parametro2.Value = usu_cla_encriptada;

        conex.Open();
        SqlDataReader myReader = leeSP.ExecuteReader();
        if (myReader.Read() == true)
        {
        
            mensaje = "Éxito";            
        }
        else
        {
            mensaje = "Error";
        }
        conex.Close();
        return (mensaje);



    }
}