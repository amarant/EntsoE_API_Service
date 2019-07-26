using EntsoE_BusinessLogic.Loaders;
using System;
using System.Threading.Tasks;

namespace EntsoE_API_Service
{
    class Program
    {
        static async Task Main(string[] args)
        {
            ILoader genForecast = new ForecastGenerationLoader(5, 900000);
            Console.ReadLine();
        }

    }
}
