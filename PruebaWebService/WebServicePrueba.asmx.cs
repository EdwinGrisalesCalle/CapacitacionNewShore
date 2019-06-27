using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace PruebaWebService
{
    /// <summary>
    /// Descripción breve de WebServicePrueba
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServicePrueba : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld(string nombre)
        {
            return "Hola a " + nombre + "!!!";
        }
        [WebMethod]
        public int Sumar(int a, int b)
        {
            return a + b;
        }  
        [WebMethod]
        public float ConvertirMoneda(float moneda)
        {
            return moneda / 3259;
        }
        [WebMethod]
        public DateTime horaMundial()
        {
            return DateTime.UtcNow;
        }
        [WebMethod]
        public int LargoNombre(string nombre)
        {
            return nombre.Length;
        }
        static List<string> nombres = new List<string>();
        [WebMethod]
        public void AñadirNombres(string nombre)
        {
            nombres.Add(nombre);
        }
        [WebMethod]
        public List<string> ListarNombre()
        {
            
            return nombres;
        }
    }
}
