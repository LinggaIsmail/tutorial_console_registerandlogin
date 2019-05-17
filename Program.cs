using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterAndLogin
{
    class Program
    {
        public static List<string> username = new List<string>();
        public static List<string> password = new List<string>();
        public static bool startup = true;
        public static bool logged = false;

        static void Main(string[] args)
        {
            Build();
        }

        public static void Build()
        {
            string choice = string.Empty;
            while (startup == true)
            {
                Console.WriteLine("Welcome...");
                Console.WriteLine("Do you want to login or register?");
                Console.WriteLine("Press 'l' to Login, 'r' to register and 'ctrl + c' to Exit");

                choice = Console.ReadLine();

                switch (choice.ToString().ToLower())
                {
                    case "r":
                        Register();
                        break;
                    case "l":
                        Login(ref logged, out startup);
                        break;
                    default:
                        Console.WriteLine("Error, please repeat.");
                        Console.WriteLine();
                        break;
                }
            }
        }
            
        public static void Register()
        {
            Console.WriteLine("Register");

            Console.WriteLine("enter username:");
            username.Add(Console.ReadLine());
            
            string pass = string.Empty;
            ConsoleKeyInfo key;
            Console.WriteLine("enter password:");
            do
            {
                key = Console.ReadKey(true);

                // Backspace Should Not Work
                if (key.Key != ConsoleKey.Backspace)
                {
                    pass += key.KeyChar;
                    Console.Write("*");
                }
                else
                {
                    Console.Write("\b");
                }
            }            
            while (key.Key != ConsoleKey.Enter);

            Console.WriteLine();
            password.Add(pass);

            Console.WriteLine("Register successful");
            Console.WriteLine();
        }

        public static bool Login(ref bool logged, out bool startup)
        {
            string name = string.Empty;
            string pass = string.Empty;

            Console.WriteLine("Login");
            Console.WriteLine("enter username");
            
            name = Console.ReadLine();

            foreach (string user in username)
            {
                if (user == name)
                {
                    string pwd = string.Empty;
                    ConsoleKeyInfo key;
                    Console.WriteLine("enter password:");
                    do
                    {
                        key = Console.ReadKey(true);

                        if (key.Key != ConsoleKey.Backspace)
                        {
                            pwd += key.KeyChar;
                            Console.Write("*");
                        }
                        else
                        {
                            Console.Write("\b");
                        }
                    }
                    while (key.Key != ConsoleKey.Enter);

                    Console.WriteLine();
                    pass = pwd;
                    
                    foreach (string pword in password)
                    {
                        if (pword == pass)
                        {
                            Console.WriteLine("Login successful");
                            Console.WriteLine("Login as " + name);
                            Console.WriteLine();
                            logged = true;
                            startup = false;
                            Run();
                            return logged;
                        }
                    }
                    var pw =
                        from a in password
                        where a.Equals(pass)
                        select new { Password = (a == null ? "" : a) };
                    var result = password.Where(x => x.Equals(pass)).Select(r => (r == null ? "" : r.ToString()));
                    Console.WriteLine("Login pass " + pw + " | " + result);

                    Console.WriteLine("Incorrect password");
                    Console.WriteLine();
                    startup = true;
                    return logged;
                }
            }

            Console.WriteLine("Incorrect username");
            Console.WriteLine();
            startup = true;
            return logged;
        }

        public static void Run()
        {
            string menus = string.Empty;
            while (logged == true)
            {
                Console.WriteLine("App Menu");
                Console.WriteLine("Choose an menus: Logout, Exit.");
                Console.WriteLine("Press 'q' to Logout and 'x' to Exit");

                menus = Console.ReadLine();

                switch (menus.ToString().ToLower())
                {
                   case "q":
                        logged = false;
                        startup = true;
                        Console.WriteLine();
                        Build();
                        break;
                    case "x":
                        Console.WriteLine("Goodbye...");
                        logged = false;
                        break;
                    default:
                        Console.WriteLine("Incorrect menus");
                        Console.WriteLine();
                        break;
                }
            }
        }
    }
}
