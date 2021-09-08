using System;

namespace Aplicativo_Receita
{
    public class ConsoleMain
    {
        const int
            Register = 1,
            Search = 2,
            Delete = 3;

        public static void Main()
        {

            while (true)
            {
                Console.WriteLine("Informe o que deseja fazer\n1-Cadastrar CNPJ\n2-Buscar um CNPJ\n3-Deletar um CNPJ");

                string op = Console.ReadLine();

                int.TryParse(op, out int result);

                switch (result)
                {
                    case Register:
                        RegisterCompany();
                        break;

                    case Search:
                        SearchCompany();
                        break;

                    case Delete:
                        DeleteCompany();
                        break;

                    default:
                        Console.WriteLine("Informe uma operação valida.");
                        break;
                }

                Console.Read();
                Console.Clear();
            }
        }

        private static void RegisterCompany()
        {
            Console.Clear();
            Console.WriteLine("Informe o CNPJ(Apenas numeros)");
            string cnpj = Console.ReadLine();
            Console.Clear();

            bool valid = Validate.ValidateCNPJ(cnpj);

            if (valid)
                InfraReceita.Run(cnpj).Wait();

            else
                Console.WriteLine("Cnpj invalido");
        }

        private static void SearchCompany()
        {
            Console.Clear();
            Console.WriteLine("Informe o nome ou o cnpj(XX.XXX.XXX/XXXX-XX) que deseja procurar");
            string cnpj = Console.ReadLine();
            Console.Clear();

            bool valid = Validate.ValidateCNPJ(cnpj);
            if (valid)
                InfraTxt.Search(cnpj);
            else
                Console.WriteLine("Cnpj invalido");
        }

        private static void DeleteCompany()
        {
            Console.Clear();
            Console.WriteLine("Informe o cnpj(XX.XXX.XXX/XXXX-XX) que deseja deletar");
            string cnpj = Console.ReadLine();
            Console.Clear();

            bool valid = Validate.ValidateCNPJ(cnpj);
            if (valid)
                InfraTxt.Delete(cnpj);
            else
                Console.WriteLine("Cnpj invalido");
        }
    }
}

