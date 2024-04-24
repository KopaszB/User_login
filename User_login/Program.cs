using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User_login
{
    class Program
    {
        static Adatbazis db = new Adatbazis();
        static List<User> userek = db.Userlista();
        static void Main(string[] args)
        {
            Console.WriteLine("***Sziper-szuper bejelentkező program 4000***");
            Console.WriteLine();
            Console.WriteLine("Kérem adja meg a bejelentkezési adatait.");
            
            
            foreach (User item in userek)
            {
                Console.WriteLine(item.Username +"  "+ item.Email +"   "+ item.Password);
            }
            
            

            Console.ReadKey();
        }


    }
}
