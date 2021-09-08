using System;
using System.IO;

namespace Aplicativo_Receita
{
    public class InfraTxt
    {
        public static void Search(string cnpj)
        {

            if (FileExists())
            {
                var found = FindCompany(cnpj);

                if (!found)
                    Console.WriteLine("Cnpj nao encontrado");
            }
            else
                Console.WriteLine("Arquivo não encontrado");

            Console.ReadKey();
        }

        private static bool FindCompany(string cnpj)
        {
            string[] lines = File.ReadAllLines("cnpj.txt");

            foreach (string line in lines)
            {
                if (line.Contains(cnpj))
                {
                    Console.WriteLine(line);
                    return true;
                }
            }

            return false;
        }

        public static void Delete(string cnpj)
        {
            if (FileExists())
            {
                string[] lines = File.ReadAllLines("cnpj.txt");
                File.Delete("cnpj.txt");

                using (StreamWriter streamWriter = new StreamWriter("cnpj.txt"))
                {
                    foreach (string line in lines)
                    {
                        if (!line.Contains(cnpj))
                        {
                            streamWriter.WriteLine();
                        }
                    }
                }

                Console.WriteLine("Cnpj deletado com sucesso");
            }
            else
                Console.WriteLine("Arquivo nao existente");

            Console.Read();
        }

        public static void Save(string cnpj, Company company)
        {
            if (FileExists())
            {
                bool found = FindCompany(cnpj);

                if (found)
                {
                    Console.WriteLine("Cnpj já existente");
                    Console.Read();
                    return;
                }
            }
            else
            {
                string all = company.status + "Empresa: " + company.nome + " Cnpj" + company.cnpj + "Nome fantasia: " + company.fantasia + "Tipo: " + company.tipo + "Natureza juridica: " + company.natureza_juridica + "Data de abertura: " + company.abertura + "Rua: " + company.logradouro + "Numero: " + company.numero + "Complemento: " + company.complemento + "CEP: " + company.cep + "Bairro: " + company.bairro + "Municipio: " + company.municipio + "UF" + company.uf + "Telefone: " + company.telefone;
                File.AppendAllText("cnpj.txt", all);
                Console.WriteLine("Operaçao realizada com sucesso");
            }
        }

        private static bool FileExists()
            => File.Exists("cnpj.txt");
    }
}
