using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace User_login
{
    internal class Adatbazis
    {
        public List<User> Userlista()
        {
            List<User> llista = new List<User>();

            MySqlConnection connection;
            MySqlCommand command;

            connection = new MySqlConnection("server=localhost;userid=userloginclient;password=almaeper;database=userloginapp");
            connection.Open();

            command = new MySqlCommand("SELECT * FROM `userdata`;", connection);

            using (MySqlDataReader dr = command.ExecuteReader())
            {
                while (dr.Read())
                {
                    User a = new User
                    {
                        User_id = dr.GetInt32(0),
                        Username = dr.GetString(1),
                        Email = dr.GetString(2),
                        Password = dr.GetString(3)
                    };
                    llista.Add(a);
                }
            }
            connection.Close();
            return llista;


        }

    }
}
