using System;
namespace Aula6.Items
{
    public class Lanche : Item
    {
        public string TipoPao { get; private set; }
        public string Recheio { get; private set; }
        public string Molho { get; private set; }


        public Lanche(double preco, DateTime validade) : base(preco, validade)
        {

        }
        public bool MontarLanche(string tipo, string recheio, string molho)
        {
            bool retorno = true;
            retorno = AdicionarRecheio(recheio);
            if (!retorno)
                return false;

            retorno = AdicionarMolho(molho);
            if (!retorno)
                return false;

            retorno = AdicionarTipoPao(tipo);
            if (!retorno)
                return false;

            return true;
        }
        public bool AdicionarRecheio(string recheio)
        {
            if (recheio != "frango" && recheio != "hamburguer")
            {
                Console.WriteLine("Recheio invalido");
                return false;
            }

            Recheio = recheio;
            return true;
        }

        public bool AdicionarMolho(string molho)
        {
            if (molho != "mostarda" && molho != "maionese")
            {
                Console.WriteLine("Molho inválido");
                return false;
            }

            Molho = molho;
            return true;
        }

        public bool AdicionarTipoPao(string tipo)
        {
            if (tipo != "integral" && tipo != "australiano" && tipo != "frances")
            {
                Console.WriteLine("Tipo pão invalido");
                return false;
            }

            TipoPao = tipo;
            return true;
        }

        public override bool Validar()
        {
            if (TipoPao == "")
            {
                Console.WriteLine("Tipo de pão invalido");
                return false;
            }
            if (Molho == "")
            {
                Console.WriteLine("Molho invalido");
                return false;
            }
            if (Recheio == "")
            {
                Console.WriteLine("Recheio invalido");
                return false;
            }

            return true;
        }

    }
}
