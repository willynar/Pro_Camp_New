using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//procamp
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Descripción breve de venta
/// </summary>
public class venta
{
    int nro;
    string mensaje, pro_can;

    public venta()
    {
        //
        
    }

    public int buscar_consecutivo() //inicio del metodo: buscar_consecutivo
    {
        
        SqlCommand cmd = null;

        try
        {
            var Sqlconn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion_sin_clave"].ConnectionString);
            var consulta = "select count(ven_cod) from tbl_venta";
            cmd = new SqlCommand(consulta, Sqlconn);
            Sqlconn.Open();
            //ExecuteScalar():se usa para consultas con clausulas de agregación(sum, min, max, avg, count)
            nro = Convert.ToInt32(cmd.ExecuteScalar());
            string num = Convert.ToString(nro);
            if (num == null)
            {
                nro = 1; //si es la primera factura de venta
            }
            else
            {
                nro = nro + 1;// si ya existen facturas de venta
            }
            Sqlconn.Close();
        }//fin del try
        catch (Exception e)
        {
            string mensaje = e.Message;
        }

        return nro;

    }//fin del metodo: buscar_consecutivo

    //metodo grabar encabezado

    public string grabar_encabezado_venta(int consecutivo, string fec_actual, int usu_cod, int ven_tot_venta, string estado,string tipo_venta)
    {
        try
        {   //Para conectarse a la BD
            var conex = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion_sin_clave"].ConnectionString);
            //se prepara la sentencia sql para insertar
            var insertar = "insert into tbl_venta values(" + consecutivo + ",'" + fec_actual + "'," + usu_cod + "," + ven_tot_venta + ",'" + estado + "','" + tipo_venta + "')";
            //se empaqueta la sentencia sql y la conexion a la bd
            var comando = new SqlCommand(insertar, conex);
            //abrir la conexion
            conex.Open();
            //se ejecuta la sentencia sql
            int resultado = comando.ExecuteNonQuery();
            if (resultado == 0)
            {
                mensaje = "Error al insertar";
            }
            else
            {
                mensaje = "OK";
            }
            conex.Close();
        }//fin del try    
        catch (Exception e)
        {
            mensaje = e.Message;//presenta el error que genera la bd
        }
        return mensaje;
    }//fin del metodo: grabar_encabezado_venta()

    public string grabar_detalle_venta(int consecutivo, int pro_cod, string pro_can, int iva, int pro_vlr_venta)
    {
        string det_est = "pendiente";
        Byte img = 0;
        try

        {   //Para conectarse a la BD
            var conex = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion_sin_clave"].ConnectionString);
            //se prepara la sentencia sql para insertar
            var insertar = "insert into tbl_det_venta values(" + consecutivo + "," + pro_cod + ",'" + pro_can + "'," + iva + ","+ pro_vlr_venta + ", '"+ det_est + "', " + img + ")";
            //se empaqueta la sentencia sql y la conexion a la bd
            var comando = new SqlCommand(insertar, conex);
            //abrir la conexion
            conex.Open();
            //se ejecuta la sentencia sql
            int resultado = comando.ExecuteNonQuery();
            if (resultado == 0)
            {
                mensaje = "Error al insertar";
            }
            else
            {
                mensaje = "Factura Registrada Correctamente";
            }
            conex.Close();
        }//fin del try    
        catch (Exception e)
        {
            mensaje = e.Message;//presenta el error que genera la bd
        }
        return mensaje;
    }//fin del metodo: grabar_detalle_venta()

    public string consultar_existencias(int pro_cod)
    {
        
        try
        {
            var Sqlconn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion_sin_clave"].ConnectionString);
            var consulta = "select pro_can from tbl_producto where pro_cod = " + pro_cod + "";
            var cmd = new SqlCommand(consulta, Sqlconn);
            Sqlconn.Open();
            SqlDataReader leerbd = cmd.ExecuteReader();
            if (leerbd.Read() == true)
            {
                //mensaje = Convert.ToString(leerbd.GetValue(5));//captura el rol del cliente
                //se puede concatenar mas datos asi:
                //mensaje = leerbd.GetString(5)+"-"+leerbd.GetString(2)
                pro_can = leerbd.GetString(0);//captura la cantidad existente de producto
            }
            else
            {
               pro_can = "";
            }
            Sqlconn.Close();
        }//fin del try
        catch (Exception e)
        {
            string mensaje = e.Message;
        }

        return pro_can;

    }//fin del metodo consultar_existencias

}