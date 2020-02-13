using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConsumeCoinRest
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<Coin> list = GetCoins().Result;

            foreach (var s in list)
            {
                Console.WriteLine(s);
            }
            // Kalder GetOneCoin med id 1
            Console.WriteLine(GetOneCoin(1).Result);
            Console.ReadLine();

        }

        private static string uri = "https://restcoinservicefilip1.azurewebsites.net/api/coin/";

        public static async Task<IList<Coin>> GetCoins()
        {
            using (HttpClient client = new HttpClient())
            {
                string content = await client.GetStringAsync(uri);
                IList<Coin> resultList = JsonConvert.DeserializeObject<IList<Coin>>(content);
                return resultList;

            }

        }

        public static async Task<Coin> GetOneCoin(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                string content = await client.GetStringAsync(uri + id);
                Coin coin = JsonConvert.DeserializeObject<Coin>(content);
                return coin;
            }
        }

        public static async Task<Coin> PostOneCoin(Coin coin)
        {

        }
    }
}
