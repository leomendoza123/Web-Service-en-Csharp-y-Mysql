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
        public string  Eventos()
        {
            List<Evento> eventos = Datos.GetEventos();
          //  return eventos.ToString();
            return JsonConvert.SerializeObject(eventos, Formatting.Indented);
     

        }

    }
}
