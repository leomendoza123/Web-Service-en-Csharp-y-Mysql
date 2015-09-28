using System;
using System.Collections.Generic;
using System.Web;
using MySql.Data.MySqlClient;
using System.Collections;

namespace Reque_2._0
{
    public class Datos
    {
        static string conString = "Server=localhost;Database=reque;Uid=root;";
        static MySqlConnection conn = new MySqlConnection(conString);
        public static List<Evento> GetEventos()
        {
            List<Evento> eventos = new List<Evento>();
            
            MySqlCommand command = conn.CreateCommand();
            command.CommandText = "SELECT   `id`,  `name`,  `start`,  `end`,  `category`FROM  `eventos`; ";

            try
            {
                MySqlDataReader reader = null;
                conn.Open();
                reader = command.ExecuteReader();
                
                while (reader.Read())
                {
                    Evento Evento = new Evento(
                        Convert.ToInt32(reader["id"]),
                        reader["name"].ToString(),
                        Convert.ToDateTime(reader["start"]),
                        Convert.ToDateTime(reader["end"]),
                        reader["category"].ToString());

                    eventos.Add(Evento);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            conn.Close();
            return (eventos);

        }
                


    }
}