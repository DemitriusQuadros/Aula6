using System;
using Aula6.Pedidos;

namespace Aula6.NotaFiscais
{
    public class NotaFiscal
    {
        public Pedido Pedido { get; private set; }
        public double ValorTotal { get; private set; }
        public bool EstaFechada { get; private set; }

        public NotaFiscal(Pedido pedido)
        {
            Pedido = pedido;
            ValorTotal = 0;
            EstaFechada = false;
        }

        public void FecharNotaFiscal()
        {
            foreach (var item in Pedido.Items)
            {
                ValorTotal += item.Preco;
            }

            ValorTotal += Pedido.TaxaServico;
            EstaFechada = true;
            Console.WriteLine("Nota fiscal fechada com sucesso");
        }

        public void Imprimir()
        {
            Console.WriteLine($@"
            ------------- Nota fiscal ---------
            Nome do Cliente : { Pedido.Nome }
            Taxa de Servico: { Pedido.TaxaServico }
            Valor Total: { ValorTotal }
            ------------------------------------");
            Console.WriteLine(@"
            | Items do seu Pedido |
            ");
            foreach(var item in Pedido.Items)
            {
                Console.WriteLine($@"
                Item do pedido: { item.GetType().ToString() }
                Preço do item: { item.Preco }
                Data Validade: { item.DataValidade }
                ");
            }

            Console.WriteLine($@"
            -----------------------------------------
            Nota Fiscal Fechada em: { DateTime.Now }
            -----------------------------------------
            ");
        }

      
    }
}
