using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;


namespace Reque_2._0
{
    /// <summary>
    /// Descripción breve de WebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]

    public class WebService : System.Web.Services.WebService
    {

      
        [WebMethod]
        public string  getShows()
        {
            return JsonConvert.SerializeObject(Datos.GetShows(), Formatting.Indented);
     

        }
        [WebMethod]
        public string getRestaurantes()
        {
            return JsonConvert.SerializeObject(Datos.GetRestaurantes(), Formatting.Indented);
        }

        [WebMethod]
        public string GetAtracciones()
        {
            return JsonConvert.SerializeObject(Datos.GetAtracciones(), Formatting.Indented);
        }

        [WebMethod]
        public string GetTiendas()
        {
            return JsonConvert.SerializeObject(Datos.GetTiendas(), Formatting.Indented);
        }



    }
}
