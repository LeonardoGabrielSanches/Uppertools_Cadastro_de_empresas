using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.IO;

namespace Aplicativo_Receita
{

    public class PegaInfo
    {

        public static async Task Run(string s)
        {
            using (var empresa = new HttpClient())
            {
                empresa.BaseAddress = new System.Uri("https://www.receitaws.com.br/");
                empresa.DefaultRequestHeaders.Accept.Clear();
                empresa.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage resposta = await empresa.GetAsync("v1/cnpj/" + s);
                if (resposta.IsSuccessStatusCode)
                {
                    Estrutura info = await resposta.Content.ReadAsAsync<Estrutura>();
                    if (File.Exists("cnpj.txt"))
                    {
                        string[] procura = File.ReadAllLines("cnpj.txt");
                        foreach (string line in procura)
                        {
                            if (line.Contains(s))
                            {
                                Console.WriteLine("Cnpj já existente");
                                Console.Read();
                                return;
                            }
                        }
                    }
                    else
                    {
                        string all = info.status + "Empresa: " + info.nome + " Cnpj" + info.cnpj + "Nome fantasia: "+ info.fantasia + "Tipo: " + info.tipo + "Natureza juridica: " + info.natureza_juridica + "Data de abertura: " + info.abertura + "Rua: " + info.logradouro + "Numero: " + info.numero + "Complemento: " + info.complemento + "CEP: " + info.cep + "Bairro: " + info.bairro + "Municipio: " + info.municipio + "UF" + info.uf + "Telefone: " + info.telefone ;
                        File.AppendAllText("cnpj.txt", all);
                        Console.WriteLine("Operaçao realizada com sucesso");
                    }
                }

            }
            
        }
    }
}