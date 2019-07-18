using IncredibleTextAdventure.Injection;
using IncredibleTextAdventure.Service;
using Ninject;

namespace IncredibleTextAdventureConsole
{
    public class Program
    {
        static void Main(string[] args)
        {
            var kernel = new StandardKernel(new NinjectSettings
            {
                AllowNullInjection = true
            }, new ITAInjectionModule());

            var service = kernel.Get<IITAService>();

            service.Play();
        }
    }
}
