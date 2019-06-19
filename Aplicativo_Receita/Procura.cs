using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Aplicativo_Receita
{
    class Procura
    {
        public static void  procurar(string s)
        {
            
            if (File.Exists("cnpj.txt"))
            {
                int ver = 0;
                string[] lines = File.ReadAllLines("cnpj.txt");
                long tam = File.ReadAllText("cnpj.txt").Length;
                foreach (string line in lines)
                {
                    if(line.Contains(s))
                    { 
                        Console.WriteLine(line);
                        ver = 1;
                    }
                   

                }
                if(ver != 1)
                {
                    Console.WriteLine("Cnpj nao encontrado");
                }
                
            }
            else
            {
                Console.WriteLine("Arquivo não encontrado");
            }
            Console.ReadKey();
        }
    }
}
