using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Descripción breve de GuarProd
/// </summary>
public class TblGuarProd
{
    public TblGuarProd()
    {
        
    }
    public int Guardar_tblPro(string pro_nom, int pro_cant, double pro_vlr,string usuario)
    {
        int rEsul = 1;

        try
            
        {
            var conex = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion_sin_clave"].ConnectionString);
            var insertar = "insert into tbl_producto values('" + pro_nom + "'," + pro_cant + "," + pro_vlr + ",'" + usuario + "')";
           var comando = new SqlCommand(insertar, conex);
           conex.Open();
           int resul = comando.ExecuteNonQuery();
           if (rEsul == 0)
           {
              rEsul = 0;
              conex.Close();
           }
        }
        catch (Exception e)
        {
        }
        return rEsul;       

    }
}