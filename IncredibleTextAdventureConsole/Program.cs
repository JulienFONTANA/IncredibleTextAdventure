using System;
using IncredibleTextAdventure.Injection;
using IncredibleTextAdventure.Service;
using Ninject;

namespace IncredibleTextAdventureConsole
{
    public class Program
    {
        public static void Main(string[] args)
        {
            char input;

            while (true)
            {
                Console.WriteLine("Do you want to play in English (press e) ?" + Environment.NewLine +
                                  "Ou voulez vous jouer en Français (appuyer sur f) ?");

                input = Console.ReadKey().KeyChar;
                if (input == 'e' || input == 'f')
                {
                    break;
                }
                Console.WriteLine("Please press 'e' or 'f' / Prière d'appuyer sur 'e' ou 'f'");
            }

            var kernel = new StandardKernel(new NinjectSettings
            {
                AllowNullInjection = true
            }, new ItaInjectionModule(input));

            var service = kernel.Get<IItaService>();

            service.Play();
        }
    }
}
