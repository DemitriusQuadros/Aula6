using System;
using System.Collections.Generic;
using Aula6.Items;

namespace Aula6.Pedidos
{
    public class Pedido
    {
        public string Nome { get; private set; }
        public double TaxaServico { get; private set; }
        public List<Item> Items { get; private set; }

        public Pedido(string nome)
        {
            Items = new List<Item>();
            Nome = nome;
            TaxaServico = 5;
        }

        public void AdicionarItem(Item item)
        {
            if (item.Validar())
                Items.Add(item);
        }
     }
}
