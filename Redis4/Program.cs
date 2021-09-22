using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redis
{
    class Program
    {
        static void Main(string[] args)
        {

            bool _activo = true;

            while (_activo)
            {
                Console.WriteLine("1 Guardar");
                Console.WriteLine("2 Consultar");
                Console.WriteLine();

                int value = Convert.ToInt32(Console.ReadLine());

                if(value == 1)
                {
                    Guardar();
                }else if( value == 2)
                {
                    Leer();
                }

                Console.WriteLine("¿Quiere continuar?");
                Console.WriteLine("1 = si");
                Console.WriteLine("2 = no");
                Console.WriteLine();

                int option = Convert.ToInt32(Console.ReadLine());

                if (option != 1)
                    _activo = false;
                
            }  
        }

        public static void Guardar()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("¿Cual es la llave?");
            string key = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("¿Cual es el valor?");
            string value = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;

            if(RedisCliDb.SET(key, value))
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Guardado");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Error");
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.WriteLine();
        }

        public static void Leer()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("¿Cual es la llave del valor a consultar?");
            string key = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;

            string data = RedisCliDb.GET(key);

            if(data != null)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("El valor es: ");
                Console.WriteLine(data);
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Error al consultar el valor");                
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.WriteLine();

        }
    }
}
