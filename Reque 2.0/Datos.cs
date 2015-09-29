using System;
using System.Collections.Generic;
using System.Web;
using MySql.Data.MySqlClient;
using System.Collections;

namespace Reque_2._0
{
    public class Datos
    {
        static string conString = "Server=localhost;Database=parque;Uid=root;";
        static MySqlConnection conn = new MySqlConnection(conString);

        public static List<atraccion> GetAtracciones()
        {
            List<atraccion> Atracciones = new List<atraccion>();
            
            MySqlCommand command = conn.CreateCommand();
            command.CommandText = "SELECT   `categoria`,  `nombre`,  `descripcion`,  `horario`,  `estado`,  `id` FROM  `atraccion`; ";

            try
            {
                MySqlDataReader reader = null;
                conn.Open();
                reader = command.ExecuteReader();
                
                while (reader.Read())
                {
                    atraccion Atraccion = new atraccion();
                    Atraccion.categoria = reader["categoria"].ToString();
                    Atraccion.nombre = reader["nombre"].ToString();
                    Atraccion.descripcion = reader["descripcion"].ToString();
                    Atraccion.horario = reader["horario"].ToString();
                    Atraccion.estado = reader["estado"].ToString();
                    Random rnd = new Random();
                    Atraccion.espera = rnd.Next(0, 66);
                    Atracciones.Add(Atraccion);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            conn.Close();
            return (Atracciones);

        }

        public static List<plato> GetPlatos(int id_restaurante)
        {
            MySqlConnection conn2 = new MySqlConnection(conString);


            List<plato> Platos = new List<plato>();

            MySqlCommand command = conn2.CreateCommand();
            command.CommandText = "SELECT    `id_restaurante`,  `nombre`,  `descripcion` FROM  `plato` where id_restaurante = " + id_restaurante + "; "; 
            try
            {
                MySqlDataReader reader = null;
                conn2.Open();
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    plato Plato = new plato();
                    Plato.nombre = (reader["nombre"]).ToString();

                    Plato.descripcion = (reader["descripcion"]).ToString();

                    Platos.Add(Plato);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            conn2.Close();
            return (Platos);
        }

        public static List<restaurante> GetRestaurantes()
        {
            List<restaurante> restaurantes = new List<restaurante>();

            MySqlCommand command = conn.CreateCommand();
            command.CommandText = "SELECT   `id`,  `horario`,  `nombre` FROM  `restaurante`; ";

            try
            {
                MySqlDataReader reader = null;
                conn.Open();
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    restaurante Restaurante = new restaurante();
                    Restaurante.horario = reader["horario"].ToString();
                    Restaurante.nombre = reader["nombre"].ToString();
                    Restaurante.platos = GetPlatos(Convert.ToInt32(reader["id"].ToString())); 
                    restaurantes.Add(Restaurante);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            conn.Close();
            return (restaurantes);

        }

        public static List<show> GetShows()
        {
            List<show> Shows = new List<show>();

            MySqlCommand command = conn.CreateCommand();
            command.CommandText = "SELECT   `id`,  `nombre`,  `lugar`,  `descripcion`,  `horario` FROM  `show`; ";

            try
            {
                MySqlDataReader reader = null;
                conn.Open();
                reader = command.ExecuteReader();
                Random rnd = new Random();
                while (reader.Read())
                {
                    show Show = new show();
                    Show.nombre = reader["nombre"].ToString();
                    Show.lugar = reader["lugar"].ToString();
                    Show.descripcion = reader["descripcion"].ToString();       
                    Show.horario = reader["horario"].ToString();
                    Shows.Add(Show);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            conn.Close();
            return (Shows);

        }

        public static List<articulo> GetArticulos(int id)
        {
            List<articulo> Articulos = new List<articulo>();
            MySqlConnection conn2 = new MySqlConnection(conString);
            MySqlCommand command = conn2.CreateCommand();
            command.CommandText = "SELECT   `id`,  `nombre`,  `precio`,  `cantidad`,  `id_tienda` FROM  `articulo` where id_tienda = " + id + ";  ";

            try
            {
                MySqlDataReader reader = null;
                conn2.Open();
                reader = command.ExecuteReader();
                Random rnd = new Random();
                while (reader.Read())
                {
                    articulo Articulo = new articulo();
                    
                    Articulo.nombre = reader["nombre"].ToString();
                    Articulo.precio = Convert.ToInt32( reader["precio"].ToString());
                    Articulo.cantidad = Convert.ToInt32( reader["cantidad"].ToString());
                    

                    Articulos.Add(Articulo);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            conn2.Close();
            return (Articulos);

        }

        public static List<tienda> GetTiendas()
        {
            List<tienda> Tiendas = new List<tienda>();

            MySqlCommand command = conn.CreateCommand();
            command.CommandText = "SELECT   `nombre`,  `id`,  `horario` FROM  `tienda`; ";

            try
            {
                MySqlDataReader reader = null;
                conn.Open();
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    tienda Tienda = new tienda();
                    Tienda.horario = reader["horario"].ToString();
                    Tienda.nombre = reader["nombre"].ToString();
                    Tienda.articulos = GetArticulos(Convert.ToInt32( reader["id"].ToString())); 
                    Tiendas.Add(Tienda);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            conn.Close();
            return (Tiendas);

        }


    }
}