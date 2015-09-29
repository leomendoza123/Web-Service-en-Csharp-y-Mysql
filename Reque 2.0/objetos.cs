using System;
using System.Collections.Generic;
using System.Web;

namespace Reque_2._0
{

    public class atraccion
    {
        public String categoria { get; set; }
        public String nombre { get; set; }
        public String descripcion { get; set; }
        public String horario { get; set; }
        public String estado { get; set; }
        public int espera { get; set; }



    }

    public class restaurante
    {
        public String nombre { get; set; }
        public String horario { get; set; }
        public List <plato>  platos{ get; set; }

}
    public class plato
    {
        public string restaurante { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }

    }

    public class show
    {
        public String nombre { get; set; }
        public String horario { get; set; }
        public String lugar { get; set; }
        public String descripcion { get; set; }

    }

    public class tienda
    {
        public string nombre { get; set;  }
        public string horario { get; set;  }
        public List<articulo> articulos {get; set;}

    }

    public class articulo
    {
        public string nombre { get; set;  }
        public  int  precio {get; set; }
        public int cantidad { get; set;  }
        
        


    }

}