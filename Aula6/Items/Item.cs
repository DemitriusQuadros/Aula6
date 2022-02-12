using System;

namespace Aula6.Items
{
    public abstract class Item
    {
        public double Preco { get; private set; }
        public DateTime DataValidade { get; private set; }

        public Item(double preco, DateTime validade)
        {
            Preco = preco;
            DataValidade = validade;
        }


        public abstract bool Validar();

    }
}
