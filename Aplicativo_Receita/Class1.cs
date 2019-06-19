    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace Aplicativo_Receita
    {
        public class Class1
        {
            public static void Main()
            {

                while (true)
                {
                int operador = 1;
                    Console.WriteLine("Informe o que deseja fazer\nf1-Cadastrar CNPJ\nf2-Buscar um CNPJ\nf3-Deletar um CNPJ");
                   string op = Console.ReadLine();
                    operador = Convert.ToInt32(op);
                    if (operador == 1)
                    {
                        string cnpj;
                        Console.Clear();
                        Console.WriteLine("Informe o CNPJ(Apenas numeros)");
                        cnpj = Console.ReadLine();
                        Console.Clear();
                        bool ver = valida.verifica(cnpj);
                        if(ver == true)
                        PegaInfo.Run(cnpj).Wait();
                        else
                        {
                        Console.WriteLine("Cnpj invalido");
                        }
                    }
                    else if(operador == 2)
                    {
                        Console.Clear();
                        Console.WriteLine("Informe o nome ou o cnpj(XX.XXX.XXX/XXXX-XX) que deseja procurar");
                        string cnpj = Console.ReadLine();
                        Console.Clear();
                        bool ver = valida.verifica(cnpj);
                        if (ver == true)
                            Procura.procurar(cnpj) ;
                        else
                        {
                            Console.WriteLine("Cnpj invalido");
                        }
                    }
                    else if(operador == 3)
                    {
                    Console.Clear();
                    Console.WriteLine("Informe o cnpj(XX.XXX.XXX/XXXX-XX) que deseja deletar");
                    string cnpj = Console.ReadLine();
                    Console.Clear();
                    bool ver = valida.verifica(cnpj);
                    if (ver == true)
                        Deleta.deletar(cnpj);
                    else
                    {
                        Console.WriteLine("Cnpj invalido");
                    }


                }

                    Console.Read();
                    Console.Clear();
                }

            }
        }
    }

