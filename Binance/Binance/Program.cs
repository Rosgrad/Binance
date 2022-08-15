using Binance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
      
        static async Task Main(string[] args)
        {
            Info info = new Info();
            await info.ProcessRepositories();
         
        }


    }
}
