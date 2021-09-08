using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.IO;
using System.Net.Http.Headers;

namespace Aplicativo_Receita
{

    public class InfraReceita
    {
        public static async Task Run(string cnpj)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("https://www.receitaws.com.br/");
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await httpClient.GetAsync("v1/cnpj/" + cnpj);
                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Falha ao realizar a busca pelo cnpj: {cnpj}.");
                    return;
                }

                Company company = await response.Content.ReadAsAsync<Company>();

                InfraTxt.Save(cnpj, company);
            }

        }
    }
}