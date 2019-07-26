using System;

namespace WorkSpace_DependencyInjection
{

    public interface IArma
    {
        string Disparar();
    }

    public class Revolver : IArma
    {
        public string Disparar()
        {
            return "Revolver Pum Pum ..";
        }
    }

    public class Rifle : IArma
    {
        public string Disparar()
        {
            return "Rifle Pum pum pum pum pum ..";
        }
    }

    public class Escopeta : IArma
    {
        public string Disparar()
        {
            return "Escopeta pum PUMMM !! ..";
        }
    }

    public class Soldado
    {
        private
            IArma _arma;
        public Soldado(IArma arma)
        {
            this._arma = arma;
        }

        public string Dispara()
        {
            return this._arma.Disparar();
        }

        public string DisparaArgumento(IArma arma)
        {
            return arma.Disparar();
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Soldado sold = new Soldado(new Rifle());
            Console.WriteLine("Soldado Dispara: {0}", sold.Dispara());

            Console.WriteLine("Soldado Dispara Metodo: {0}", sold.DisparaArgumento(new Escopeta()));
            Console.ReadKey();

        }
    }
}
