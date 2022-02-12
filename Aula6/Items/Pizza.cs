using System;
using System.Collections.Generic;

namespace Aula6.Items
{
    public class Pizza : Item
    {
        public List<string> Recheios { get; private set; }
        public string Borda { get; private set; }
        public string Molho { get; private set; }

        public Pizza(double preco, DateTime validade) : base (preco, validade)
        {
            Recheios = new List<string>();
        }

        public bool AdicionarBorda(string borda)
        {
            if (borda != "catupiry" && borda != "chedder"
               && borda != "requeijao")
            {
                Console.WriteLine("Borda inválida");
                return false;
            }
            Borda = borda;
            return true;
        }

        public bool AdicionarMolho(string molho)
        {
            if (molho != "tomate" && molho != "branco")
            {
                Console.WriteLine("Molho inválido");
                return false;
            }
            Molho = molho;
            return true;
        }

        public bool AdicionarRecheio(string recheio)
        {
      
            if (Recheios.Count == 4)
            {
                Console.WriteLine("Quantidade de recheios totalmente preenchida");
                return false;
            }

            Recheios.Add(recheio);
            return true;
        }

        public override bool Validar()
        {
            if (Molho == "")
            {
                Console.WriteLine("Pizza deve conter um molho");
                return false;
            }

            if (Recheios.Count == 0)
            {
                Console.WriteLine("Obrigatorio informar um recheio");
                return false;
            }

            return true;

        }
    }
}
