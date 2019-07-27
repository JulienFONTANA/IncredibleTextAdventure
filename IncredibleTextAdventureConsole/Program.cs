using IncredibleTextAdventure.Injection;
using IncredibleTextAdventure.Service;
using Ninject;

namespace IncredibleTextAdventureConsole
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var kernel = new StandardKernel(new NinjectSettings
            {
                AllowNullInjection = true
            }, new ItaInjectionModule());

            var service = kernel.Get<IItaService>();

            service.Play();
        }
    }
}
