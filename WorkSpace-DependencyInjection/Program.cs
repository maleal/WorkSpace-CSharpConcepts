using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkSpace_DependencyInjection
{
 /* 
 * Reviewing Dependencies Injections:
 *      Ejemplo de Constructor Injection
*/

    /* Ejemplo 01
     * 1ro. Creamos la Interface, que define la accion comun que deberán implementar
            las clases
     * 2do. Creamos las clases especializadas
     * 3ro. El consumidor
     * Nota:Tambien tengo un método (identico a los ejemplos de polimorfismo de C++)
    */

    public interface IArma
    {
        string Disparar();
    }
 
    public class Revolver : IArma
    {
        public string Disparar()
        {
            return "Pum Pum ..";
        }
    }

    public class Rifle : IArma
    {
        public string Disparar()
        {
            return "Pum pum pum pum pum ..";
        }
    }

    public class Escopeta : IArma
    {
        public string Disparar()
        {
            return "pum PUMMM !! ..";
        }
    }
    public class Soldado
    {
        protected IArma _arma;

        public Soldado(IArma arma)
        {
            this._arma = arma;
        }

        public string Disparar()
        {
            return this._arma.Disparar();
        }

        public string Disparar(IArma arma)
        {
            return arma.Disparar();
        }
    }

    /*
     * Este segundo ejemplo, obliga a todos a enviar un mensaje
    */


    public interface INotificar
    {
        string EjecutarNotificar(string msg);
    }

    public class Servidor : INotificar
    {
        public string EjecutarNotificar(string msg)
        {
            string xx = "Servidor Notifica:";
            return string.Concat(xx, msg);
        }
    }

    public class Impresora : INotificar
    {
        public string EjecutarNotificar(string msg)
        {
            string xx = "Impresora Notifica:";
            return string.Concat(xx, msg);
        }
    }

    public class Correo
    {
        protected INotificar _notificar;
        public Correo(INotificar notificar)
        {
            this._notificar = notificar;
        }

        public string Notifica(string msg)
        {
            return _notificar.EjecutarNotificar(msg);
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            var soldado = new Soldado(new Rifle());
            Console.WriteLine ("El Soldado Dispara: {0}", soldado.Disparar());

            var correo01 = new Correo(new Servidor());

            Console.WriteLine("Soy correo01: {0}", correo01.Notifica("Soy el Servidor ... Hay que salir Ya!!!"));
            
            var correo02 = new Correo(new Impresora());
            Console.WriteLine("Soy correo02: {0}", correo02.Notifica("Soy la Impresora ... No hay mas hojas!!!"));

            var esta = Console.ReadKey();

        }
    }
}
