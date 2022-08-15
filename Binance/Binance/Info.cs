using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binance
{
    public class Info
    {
        public  readonly HttpClient client = new HttpClient();
      
        public  async Task ProcessRepositories()
        {
            string result;
            Console.WriteLine("Выберите возможный вариант: a:,b:,c");
            result = Console.ReadLine();
            client.DefaultRequestHeaders.Accept.Clear();

            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

            var Noparameter = client.GetStringAsync("https://api.github.com/orgs/dotnet/repos");

            var symbol = client.GetStringAsync("https://api.binance.com/api/v3/exchangeInfo?symbol=BNBBTC");
            var symbols = client.GetStringAsync("https://api.binance.com/api/v3/exchangeInfo?symbols=%5B%22BNBBTC%22,%22BTCUSDT%22%5D" );
           
           
            var msg1 = await symbol;
            var msg2 = await symbols;


            if (result == "a")
            {
                var msg = await Noparameter;
                Console.Write(msg);
            }
            else if (result == "b")
            {
                Console.Write(msg1);
            }
            else if (result == "c")
            {
                Console.Write(msg2);
            }



        }
    }
}
