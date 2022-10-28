using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpClient client = new HttpClient();
            Console.WriteLine("Calling Web Api...");
            var response = client.GetAsync("http://localhost:49511/api/Authors");
            response.Wait();
            if (response.IsCompleted)
            {
                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    var apiResult = result.Content.ReadAsStringAsync();
                    apiResult.Wait();
                    var apiRes = apiResult.Result;
                    Console.WriteLine(apiRes);
                    Console.WriteLine("Sıfırıncı Eleman: "+apiRes.Take(1));

                    Console.ReadLine();
                }
            }

        }
    }
}
