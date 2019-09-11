using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//procamp
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
/// <summary>
/// Descripción breve de tblProConCod
/// </summary>
public class tblProConCod
{
    public tblProConCod(){

    }
    int pro_cod, pro_cod1;

    public int TblUsuCodConsultar_Codigo_Producto()
    {
        try
        {

            var Sqlconn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion_sin_clave"].ConnectionString);
            var consulta = "select count(*) from tbl_producto";
            var cmd = new SqlCommand(consulta, Sqlconn);
            Sqlconn.Open();
            pro_cod = Convert.ToInt32(cmd.ExecuteScalar());
        
            Sqlconn.Close();

            if (pro_cod == 0)
            {
                pro_cod = 1;
            }
            else
            {
                
                
                var Sqlconn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion_sin_clave"].ConnectionString);
                var consulta1 = "select pro_cod from tbl_producto where pro_cod = (SELECT MAX(pro_cod)  FROM tbl_producto)";
                var cmd1 = new SqlCommand(consulta1, Sqlconn1);
                Sqlconn1.Open();
                pro_cod1 = Convert.ToInt32(cmd1.ExecuteScalar());
                Sqlconn1.Close();

                if (pro_cod1 != 0)
                {
                    //===============se traen los datos de la consulta alas variables==============
                    
                    pro_cod = pro_cod1 + 1;

                }
            }
        }
        catch(Exception e)
        {
            string mensaje = e.Message;
        }
        return pro_cod;

            /*============================fin consulta========================*/
    }
    
}