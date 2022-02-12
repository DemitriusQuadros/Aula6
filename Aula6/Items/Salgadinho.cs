using System;
namespace Aula6.Items
{
    public class Salgadinho : Item
    {
        public string Tipo { get; private set; }
        public string Recheio { get; private set; }

        public Salgadinho(double preco, DateTime validade) : base(preco, validade)
        {

        }
        public bool AdicionarTipo(string tipo)
        {
            if (tipo != "frito" && tipo != "assado")
            {
                Console.WriteLine("Tipo de salgadinho invalido");
                return false;
            }

            Tipo = tipo;
            return true;
        }

        public bool AdicionarRecheio(string recheio)
        {
            if (recheio != "pizza" && recheio != "carne" && recheio != "frango")
            {
                Console.WriteLine("Tipo de recheio invalido");
                return false;
            }

            Recheio = recheio;
            return true;
        }

        public override bool Validar()
        {
            if (Recheio == "")
            {
                Console.WriteLine("Recheio vazio");
                return false;
            }


            if (Tipo == "")
            {
                Console.WriteLine("Tipo invalido");
                return false;
            }

            return true;
        }
    }
}
