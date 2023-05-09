using Projeto04.Controllers;

namespace Projeto04
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("\nPROJETO PARA CONTROLE DE EMPRESAS E FUNCIONÁRIOS\n");

            Console.WriteLine("(1) CADASTRAR EMPRESAS");
            Console.WriteLine("(2) ATUALIZAR EMPRESAS");
            Console.WriteLine("(3) EXCLUIR EMPRESAS");
            Console.WriteLine("(4) CONSULTAR EMPRESAS");

            Console.Write("\nINFORME A OPÇÃO DESEJADA: ");
            var opcao = int.Parse(Console.ReadLine());

            var empresaController = new EmpresaController();

            switch (opcao)
            {
                case 1: empresaController.CadastrarEmpresa(); break;
                case 2: empresaController.AtualizarEmpresa(); break;
                case 3: empresaController.ExcluirEmpresa(); break;
                case 4: empresaController.ConsultarEmpresas(); break;
                default:
                    Console.WriteLine("\nOPÇÃO INVÁLIDA!");
                    break;
            }

            Console.Write("\nDESEJA CONTINUAR? (S,N): ");
            var continuar = Console.ReadLine();

            if (continuar.Equals("S", StringComparison.OrdinalIgnoreCase))
            {
                Console.Clear();
                Main(args); //recursividade!
            }
            else
            {
                Console.WriteLine("\nFIM DO PROGRAMA!");
            }
        }
    }
}