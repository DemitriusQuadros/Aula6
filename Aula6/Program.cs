using System;
using System.Collections.Generic;
using Aula6.Items;
using Aula6.NotaFiscais;
using Aula6.Pedidos;

namespace Aula6
{
    class MainClass
    {
        public static void Main(string[] args)
        {

            var pedidos = new List<Pedido>();
            var opcao = "";

            while (opcao != "3")
            {
                Console.Clear();
                Console.WriteLine("Bem vindo ao Sistema da lanchonete Quase 3 Lanches!");
                Console.WriteLine("Selecione a opcao:");
                Console.WriteLine("1 - Criar novo pedido");
                Console.WriteLine("2 - Gerar Nota Fiscal");
                Console.WriteLine("3 - Sair");
                opcao = Console.ReadLine();
                switch (opcao)
                {
                    case "1":
                        pedidos.Add(CriarNovoPedido());
                        break;
                    case "2":
                        GerarNotaFiscal(pedidos);
                        break;
                    case "3":
                        Console.WriteLine("Voce ira sair do sistema");
                        break;
                    default:
                        Console.WriteLine("Opcao invalida");
                        break;
                }
                Console.WriteLine("Enter para continuar");
                Console.ReadKey();
            }
        }

        public  static void GerarNotaFiscal(List<Pedido> pedidos)
        {
            Console.Clear();
            Console.WriteLine("Lista dos pedidos em aberto");
            foreach(var pedido in pedidos)
            {
                Console.WriteLine($"Pedido em aberto para o cliente { pedido.Nome }");
            }

            Console.WriteLine("Informe o nome do cliente que deseja fechar a nota");
            var nome = Console.ReadLine();

            foreach (var pedido in pedidos)
            {
                if (pedido.Nome == nome)
                {
                    var notaFiscal = new NotaFiscal(pedido);
                    notaFiscal.FecharNotaFiscal();
                    notaFiscal.Imprimir();
                    pedidos.Remove(pedido);
                    break;
                }
            }
        }

        public static Pedido CriarNovoPedido()
        {
            Console.Clear();
            Console.WriteLine("Informe o nome do cliente");
            var nome = Console.ReadLine();
            var pedido = new Pedido(nome);
            var opcao = "";

            while (opcao != "4")
            {
                Console.Clear();
                Console.WriteLine("Selecione o item do pedido");
                Console.WriteLine("1 - Pizza");
                Console.WriteLine("2 - Salgadinho");
                Console.WriteLine("3 - Lanche");
                Console.WriteLine("4 - Sair");
                opcao = Console.ReadLine();
                Item item = null;
                switch (opcao)
                {
                    case "1":
                        item = CriarPizza();
                        break;
                    case "2":
                        item = CriarSalgadinho();
                        break;
                    case "3":
                        item = CriarLanche();
                        break;
                    default:
                        break;
                }
                if (item != null)
                    pedido.AdicionarItem(item);
            }
            Console.WriteLine($"Pedido criado para { pedido.Nome }");
            return pedido;
        }

        private static Item CriarLanche()
        {
            Lanche lanche = new Lanche(10, DateTime.Now);

            Console.Clear();
            Console.WriteLine("Informe o tipo do pão frances, australiano, integral");
            var tipo = Console.ReadLine();

            while (!lanche.AdicionarTipoPao(tipo))
            {
                Console.WriteLine("Informe o tipo do pão, frances, australiano, integral");
                tipo = Console.ReadLine();
            }

            Console.WriteLine("Informe o recheio");
            var recheio = Console.ReadLine();
            while (!lanche.AdicionarRecheio(recheio))
            {
                Console.WriteLine("Informe o recheio");
                recheio = Console.ReadLine();
            }

            Console.WriteLine("Informe o molho");
            var molho = Console.ReadLine();
            while (!lanche.AdicionarMolho(molho))
            {
                Console.WriteLine("Informe o molho");
                molho = Console.ReadLine();
            }

            return lanche;
        }

        private static Item CriarSalgadinho()
        {
            Salgadinho salgadinho = new Salgadinho(7, DateTime.Now);
            Console.Clear();
            Console.WriteLine("Informe o tipo do salgadinho");
            var tipo = Console.ReadLine();
            while (!salgadinho.AdicionarTipo(tipo))
            {
                Console.WriteLine("Informe o tipo do salgadinho");
                tipo = Console.ReadLine();
            }

            Console.WriteLine("Informe o recheio do salgadinho");
            var recheio = Console.ReadLine();
            while (!salgadinho.AdicionarRecheio(recheio))
            {
                Console.WriteLine("Informe o recheio do salgadinho");
                recheio = Console.ReadLine();
            }

            return salgadinho;
        }

        private static Item CriarPizza()
        {
            Pizza pizza = new Pizza(25, DateTime.Now);
            Console.Clear();
            Console.WriteLine("Informe o molho da pizza");
            var molho = Console.ReadLine();
            while (!pizza.AdicionarMolho(molho))
            {
                Console.WriteLine("Informe o molho da pizza");
                molho = Console.ReadLine();
            }

            Console.WriteLine("Informe a borda da pizza");
            var borda = Console.ReadLine();
            while (!pizza.AdicionarBorda(borda))
            {
                Console.WriteLine("Informe a borda da pizza");
                borda = Console.ReadLine();
            }

            Console.WriteLine("Informe o recheio da pizza");
            var recheio = Console.ReadLine();
            while (!pizza.AdicionarRecheio(recheio))
            {
                Console.WriteLine("Informe o recheio da pizza");
                recheio = Console.ReadLine();
            }
            Console.WriteLine("Deseja informar mais um recheio? digite sair para sair");
            var opcao = Console.ReadLine();

            while(opcao.ToLower() != "sair")
            {
                Console.WriteLine("Informe o recheio da pizza");
                recheio = Console.ReadLine();
                while (!pizza.AdicionarRecheio(recheio)  && pizza.Recheios.Count < 4)
                {
                    Console.WriteLine("Informe o recheio da pizza");
                    recheio = Console.ReadLine();
                }
                Console.WriteLine("Deseja informar mais um recheio? digite sair para sair");
                opcao = Console.ReadLine();
            }
            return pizza;
        }
    }
}
