using System;
using System.Collections.Generic;
using System.Linq;
using SamuraiApp.Data;
using SamuraiApp.Domain;

namespace SamuraiApp.UI
{
    class Program
    {
        private static SamuraiContext _context = new SamuraiContext();

        private static void Main(string[] args)
        {
            _context.Database.EnsureCreated();
            Console.WriteLine("What's your favorite Samurai?");
            string rickmuraiJack = Console.ReadLine();
            if (InDBContext(rickmuraiJack))
            {
                Console.WriteLine("Oh yeah I know this Samurai: ");
                List<Samurai> result = _context.Samurais
                    .Where(samurai => samurai.Name == rickmuraiJack)
                    .ToList();
                foreach(Samurai elem in result)
                {
                    Console.WriteLine(elem.ToString());
                }
                Console.WriteLine("Is your Samurai one of them?")
            }
            else
            {
                Console.WriteLine("This Samurai wasn't seen bevor would you like to add him to the Database? (Y)es | (N)o");
                var key = Console.ReadKey();
               
            }



           
            Console.Write("Press any key...");
            Console.ReadKey();
        }


        private static Samurai GetSamurai(string name)
        {
            Samurai result = _context.Samurais.Where(samurai => samurai.Name == name).First();
            return result;
        }

        private static bool InDBContext(string name)
        {
            return _context.Samurais.Where(s => s.Name == name) != null;
        }


        //private static void AddSamurai()
        //{
        //    var samurai = new Samurai { Name = "Julie" };
        //    _context.Samurais.Add(samurai);
        //    _context.SaveChanges();
        //}
        //private static void GetSamurais(string text)
        //{
        //    var samurais = _context.Samurais.ToList();
        //    Console.WriteLine($"{text}: Samurai count is {samurais.Count}");
        //    foreach (var samurai in samurais)
        //    {
        //        Console.WriteLine(samurai.Name);
        //    }
        //}
    }
}
