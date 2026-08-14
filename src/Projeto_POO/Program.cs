using System.Text;

namespace Projeto_POO
{
    internal class Program
    {
        static LinkedList<Produto> produtos;
        static void Pausa()
        {
            Console.Write("\nTecle Enter para continuar.");
            Console.ReadKey();
        }
        static void Cabecalho()
        {
            Console.Clear();
            Console.WriteLine("Produto - v0.1");
            Console.WriteLine("=====================");
        }
        static int MenuPrincipal()
        {
            int opcao;
            Cabecalho();
            Console.WriteLine("1 - Cadastrar Produto");
            Console.WriteLine("2 - Ver Dados de um Produto");
            Console.WriteLine("3 - Ver todos os Produtos");
            Console.WriteLine("0 - Sair");
            Console.Write("Digite sua opção: ");
            int.TryParse(Console.ReadLine(), out opcao);
            return opcao;
        }

        private static void RelatorioProdutos()
        {
            Cabecalho();
            Console.WriteLine("Produtos Cadastrados: \n");
            int i = 1;
            foreach(Produto produto in produtos){
                Console.WriteLine($"{i} - {produto.NotaDeVenda()}");
                i++;
            }
        }

        private static void DadosProduto()
        {
            Cabecalho();
            Console.Write("Descrição do produto: ");
            string descricao = Console.ReadLine();
            foreach (Produto produto in produtos)
            {
                if (produto.NotaDeVenda().Contains(descricao))
                {
                    Console.WriteLine($"\n{produto.NotaDeVenda()}");
                    return;
                }
            }
        }

        private static void CadastrarProduto()
        {
            Cabecalho();
            string descricao;
            double precoCusto;
            double margemLucro;
            Produto novo;

            Console.WriteLine("Cadastro de produto.");
            Console.Write("Descrição: ");
            descricao = Console.ReadLine();
            Console.Write("Preço de custo (R$): ");
            precoCusto = double.Parse(Console.ReadLine());
            Console.Write("Margem de lucro (10-50%): ");
            margemLucro = double.Parse(Console.ReadLine());
            novo = new Produto(descricao, precoCusto, margemLucro);
            produtos.AddLast(novo);

            Console.WriteLine($"Adicionado:\n{novo.NotaDeVenda()}");

        }

        static void Main(string[] args)
        {
            produtos = new LinkedList<Produto>();
            int opcao;
        

            do
            {
                opcao = MenuPrincipal();
                Action ac =
                    opcao switch
                    {
                        1 => () => CadastrarProduto(),
                        2 => () => DadosProduto(),
                        3 => () => RelatorioProdutos(),
                        0 => () => Console.WriteLine("Encerrando sistema"),
                        _ => () => Console.WriteLine("Opção inválida")
                    };
                ac.Invoke();
                Pausa();
            } while (opcao != 0);
        }

        
    }
}
