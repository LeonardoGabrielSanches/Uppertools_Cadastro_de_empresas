using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Aplicativo_Receita
{
    class Deleta
    {
        public static void deletar(string s)
        {
            if(File.Exists("cnpj.txt"))
            {
                
                string[] all = File.ReadAllLines("cnpj.txt");
                File.Delete("cnpj.txt");
                using(StreamWriter escreve = new StreamWriter("cnpj.txt"))
                {
                    foreach(string line in all)
                    {
                        if(!line.Contains(s))
                        {
                            escreve.WriteLine();
                        }
                    }
                }


                        

            }
            else
            {
                Console.WriteLine("Arquivo nao existente");
                Console.Read();
                return;
            }
            Console.WriteLine("Cnpj deletado com sucesso");
            Console.Read();
        }
    }
}
