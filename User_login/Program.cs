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
            string username,passwd;
            int opcio =0;

            while (opcio<3)
            {
                Console.WriteLine();
                Console.WriteLine("Kérem adja meg a bejelentkezési adatait.");
                Console.Write("Felhasználónév: \n>");
                username = Console.ReadLine();
                Console.Write("Jelszó: \n>");
                passwd = Console.ReadLine();
                Console.WriteLine();

                if (UsernameCheck(username)==true)
                {
                    if (PasswordCheck(passwd)==true)
                    {
                        Console.WriteLine("Sikeres bejelentkezés!");
                        opcio = 3;
                        valasszMenubol();
                    }
                    else
                    {
                        Console.WriteLine("Hibás jelszó!");
                        opcio = 2;
                    }
                }
                else 
                {
                    Console.WriteLine("Hibás felhasználónév!");
                    opcio = 1;
                }
            }

            Console.ReadLine();
        }

        private static void valasszMenubol()
        {
            string valasz;
            bool kilep = false;
            List<string> lista = new List<string>(); 
            while (!kilep)
            {
                Console.Write("Válassz a menüből: lista | kilépés \n>");
                valasz = Console.ReadLine();
                if (valasz == "lista")
                {
                    for (int i = 0; i < userek.Count; i++)
                    {
                        lista.Add(userek[i].Username);
                    }
                    lista.Sort();
                    foreach (var item in lista)
                    {
                        Console.WriteLine($" - {item}");
                    }
                    lista.Clear();
                    Console.WriteLine();
                }
                else if (valasz == "kilépés")
                {
                    kilep = true;
                    System.Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Érvénytelen parancs!");
                }
            }
        }

        private static bool PasswordCheck(string passwd)
        {
            bool ertek = false;
            for (int i = 0; i < userek.Count; i++)
            {
                if (passwd == userek[i].Password)
                {
                    ertek = true;
                }
            }
            return ertek;
        }

        private static bool UsernameCheck(string username)
        {
            bool ertek = false;
            for (int i = 0; i < userek.Count; i++)
            {
                if (username==userek[i].Username)
                {
                    ertek = true;
                    break;
                }
            }
            return ertek;
        }
    }
}
