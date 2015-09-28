using System;
using System.Collections.Generic;
using System.Web;

namespace Reque_2._0
{
    [Newtonsoft.Json.JsonObject(Title = "Evento")]
    public class Evento
    {
        public int id { get; set; }
        public String name { get; set; }
        public DateTime end { get; set; }
        public DateTime start { get; set; }
        public string category { get; set; }

        public Evento (int id, string name,  DateTime start, DateTime end, string category)
        {
            this.name = name;
            this.id = id;
            this.end = end;
            this.category = category; 

        }


    }
}