using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http; 
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHttpClient
{
    /// <summary>
    ///  Programa para teste de execução simples de resquest usando HttpClient
    ///  Pacotes usados:
    ///     -> Newtownsoft.Json
    ///     -> Microsoft.Net.Http
    /// </summary>
    /// 
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Teste");

            //Função pra chamar método asincrono 
            esseEhMain().Wait();
        }

        /// <summary>
        /// Método asinctrono do tipo task que executa chamada com o http client
        /// </summary>
        /// <returns></returns>
        public static async Task esseEhMain()
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("token", "");

            var x = new {
                data = "kakas",
                teste = "ikajsudh"
            };

            StringContent httpContent = new StringContent(JsonConvert.SerializeObject(x));

            // POST
            var y = await client.PostAsync("", httpContent);

            var result = JsonConvert.DeserializeObject(await y.Content.ReadAsStringAsync());

            Console.WriteLine(result);
        }

        

    }
}
