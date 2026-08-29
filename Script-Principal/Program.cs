using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Script_Principal
{
    internal class Program
    {
        static void Menu()
        {
            Console.WriteLine("========================================");
            Console.WriteLine("=======Bienvenido GoXela Delivery=======");
            Console.WriteLine("========================================\n");
            Console.WriteLine("1. Gestión de clientes");
            Console.WriteLine("2. Gestión de repartidores");
            Console.WriteLine("3. Gestión de vehículos");
            Console.WriteLine("4. Gestión de paquetes");
            Console.WriteLine("5. Gestión de entregas");
            Console.WriteLine("6. Gestión de incidencias");
            Console.WriteLine("7. Reportes");
            Console.WriteLine("8. Salir");
            Console.WriteLine("Ingrese el indice de la acción que desea realizar");
        }
        static void Main(string[] args)
        {
            int opcion;
            do
            {
                Console.Clear();
                Menu();
            MalOpcion:
                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.WriteLine("La opción ingresada no existe, intente de nuevo");
                    goto MalOpcion;
                }

                switch(opcion)
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 6:
                        break;
                    case 7:
                        break;
                    case 8:
                        Console.WriteLine("Gracias por usar nuestro programa, vuelta pronto");
                        break;
                    default:
                        Console.WriteLine("La opción elegida no existe, intente de nuevo");
                        break;
                }
            } while (opcion != 8);
            

        }
    }
}
