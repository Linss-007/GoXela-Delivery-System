using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Script_Principal
{

    internal class Program
    {
        static List<Usuario> Usuarios = new List<Usuario>();
        static void Menu()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("+==================================================+");
            Console.WriteLine("|            Bienvenido GoXela Delivery            |");
            Console.WriteLine("+==================================================+");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("+==================================================+");
            Console.WriteLine("|  [1]  Gestión de clientes                        |");
            Console.WriteLine("|  [2]  Gestión de repartidores                    |");
            Console.WriteLine("|  [3]  Gestión de vehículos                       |");
            Console.WriteLine("|  [4]  Gestión de paquetes                        |");
            Console.WriteLine("|  [5]  Gestión de entregas                        |");
            Console.WriteLine("|  [6]  Gestión de incidencias                     |");
            Console.WriteLine("|  [7]  Reportes                                   |");
            Console.WriteLine("|  [8]  Salir                                      |");
            Console.WriteLine("+==================================================+");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Ingrese el índice de la acción que desea realizar: ");
        }
        static void GestionClientes()
        {
            int opcion;
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("+===========================================+");
                Console.WriteLine("|            Gestión de Clientes            |");
                Console.WriteLine("+===========================================+\n");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("+===========================================+");
                Console.WriteLine("| [1] Registrar cliente.                    |");
                Console.WriteLine("| [2] Mostrar información de clientes.      |");
                Console.WriteLine("| [3] Actualizar información de un cliente. |");
                Console.WriteLine("| [4] Volver al menú principal.             |");
                Console.WriteLine("+===========================================+\n");
                Console.WriteLine("Por favor ingrese una opción.");
                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: La opción ingresada no es un numero.");
                    Console.ResetColor();
                    Console.WriteLine("Presione una tecla para continuar.");
                    Console.ReadKey();
                    continue;
                }
                switch(opcion)
                {
                    case 1:
                        RegistrarCliente();
                        break;
                    case 2:
                        int cont = 1;
                        if(Usuarios.OfType<Cliente>().Count() == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Error: No existen clientes guardados");
                            Console.ResetColor();
                        }
                        else
                        {
                            foreach (Cliente cliente in Usuarios)
                            {
                                Console.WriteLine($"Usuario {cont}");
                                Console.WriteLine("+===========================================+");
                                cliente.ConsultarInfo();
                                Console.WriteLine("+===========================================+");
                                cont++;
                            }
                        }
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Presione cualquier tecla para continuar.");
                        Console.ReadKey();
                        break;
                    case 3:
                        bool clienteEncontrado = false;
                        int posCliente = 0;
                        if (Usuarios.OfType<Cliente>().Count() == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Error: No existen clientes guardados");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.WriteLine("Ingrese el código del clinte a actualizar la información");
                            string codigoActu = Console.ReadLine();
                            foreach (Cliente cliente in Usuarios)
                            {
                                if(cliente.Codigo == codigoActu)
                                {
                                    clienteEncontrado = true;
                                    Console.ForegroundColor= ConsoleColor.Green;
                                    Console.WriteLine("Cliente encontrado");
                                    posCliente = Usuarios.IndexOf(cliente);
                                    break;
                                }
                            }
                            if(clienteEncontrado == false)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Error: El cliente no existe.");
                                Console.ResetColor();
                            }
                            else
                            {
                                do
                                {
                                    Console.WriteLine("+===========================================+");
                                    Console.WriteLine("|            Actualizar Cliente             |");
                                    Console.WriteLine("+===========================================+\n");
                                    Console.WriteLine("+===========================================+");
                                    Console.WriteLine("| [1] Actualizar nombre.                    |");
                                    Console.WriteLine("| [2] Actualizar número.                    |");
                                    Console.WriteLine("| [3] Actualizar córreo.                    |");
                                    Console.WriteLine("| [4] Actualizar Dirección.                 |");
                                    Console.WriteLine("| [5] No actualizar nada.                   |");
                                    Console.WriteLine("+===========================================+");
                                    Console.WriteLine("Por favor ingrese una opción.");
                                    if (!int.TryParse(Console.ReadLine(), out opcion))
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Error: La opción ingresada no es un numero.");
                                        Console.ResetColor();
                                        Console.WriteLine("Presione una tecla para continuar.");
                                        Console.ReadKey();
                                        continue;
                                    }
                                    Usuarios[posCliente].Actualizar(opcion);
                                } while (opcion != 5);
                            }
                        }
                        break;
                    case 4:
                        break;
                }
            } while (opcion != 4);
        }
        static void RegistrarCliente()
        {
            Console.Clear();
            Console.ForegroundColor= ConsoleColor.DarkYellow;
            Console.WriteLine("+===========================================+");
            Console.WriteLine("|             Registrar Cliente             |");
            Console.WriteLine("+===========================================+\n");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Ingrese el código del cliente.");
            string codigoIng = Console.ReadLine();
            Console.WriteLine("Ingrese el nombre del cliente.");
            string nombreIng = Console.ReadLine();
            Console.WriteLine("Ingrese el numero del cliente.");
            string numeroIng = Console.ReadLine();
            Console.WriteLine("Ingrese el correo electronico del cliente.");
            string correoIng = Console.ReadLine();
            Console.WriteLine("Ingrese la dirección del cliente.");
            string direccionIng = Console.ReadLine();
        MalClienteCreado:
            Cliente cliente = new Cliente(codigoIng, nombreIng, numeroIng, correoIng, direccionIng);
            if(cliente.Codigo != codigoIng)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Ingrese el código del cliente.");
                codigoIng = Console.ReadLine();
                goto MalClienteCreado;
            }
            else if(cliente.Nombre != nombreIng)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Ingrese el nombre del cliente.");
                nombreIng = Console.ReadLine();
                goto MalClienteCreado;
            }
            else if(cliente.Numero != numeroIng)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Ingrese el numero del cliente.");
                numeroIng = Console.ReadLine();
                goto MalClienteCreado;
            }
            else if(cliente.Correo != correoIng)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Ingrese el correo electronico del cliente.");
                correoIng = Console.ReadLine();
                goto MalClienteCreado;
            }
            else if (cliente.Direccion != direccionIng)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Ingrese la dirección del cliente.");
                direccionIng = Console.ReadLine();
                goto MalClienteCreado;
            }
            else
            {
                Usuarios.Add(new Cliente(codigoIng, nombreIng, numeroIng, correoIng, direccionIng));
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Cliente creado exitosamente.");
                Console.ResetColor();
                Console.WriteLine("Presione cualquier tecla para continuar");
                Console.ReadKey();
            }
        }
        static void ActualizarCliente()
        {

        }
        static void Main(string[] args)
        {
            int opcion;
            do
            {
                Console.Clear();
                Menu();
                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine();
                    Console.Write("Error: Tipo de dato incorrecto, por favor ingrese un número entero.");
                    Console.ResetColor();
                    Console.ReadKey();
                    continue;
                }

                switch (opcion)
                {
                    case 1:
                        GestionClientes();
                        break;
                    case 2:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("+===============================================+");
                        Console.WriteLine("|            Gestión de Repartidores            |");
                        Console.WriteLine("+===============================================+");
                        Console.ResetColor();

                        break;
                    case 3:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("+===========================================+");
                        Console.WriteLine("|            Gestión de Vehículos           |");
                        Console.WriteLine("+===========================================+");
                        Console.ResetColor();
                        Console.ReadLine();
                        break;
                    case 4:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("+===========================================+");
                        Console.WriteLine("|            Gestión de Paquetes            |");
                        Console.WriteLine("+===========================================+");
                        Console.ResetColor();
                        Console.ReadLine();
                        break;
                    case 5:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("+===========================================+");
                        Console.WriteLine("|            Gestión de Entregas            |");
                        Console.WriteLine("+===========================================+");
                        Console.ResetColor();
                        Console.ReadLine();
                        break;
                    case 6:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("+==============================================+");
                        Console.WriteLine("|            Gestión de Incidencias            |");
                        Console.WriteLine("+==============================================+");
                        Console.ResetColor();
                        Console.ReadLine();
                        break;
                    case 7:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("+================================+");
                        Console.WriteLine("|            Reportes            |");
                        Console.WriteLine("+================================+");
                        Console.ResetColor();
                        Console.ReadLine();
                        break;
                    case 8:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("¡Gracias por usar nuestro programa, vuelta pronto!");
                        Console.ResetColor();
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nError: Opción inválida, intente de nuevo.");
                        Console.Write("Presione ENTER para continuar...");
                        Console.ResetColor();
                        Console.ReadLine();
                        break;
                }
            } while (opcion != 8);
        }
    }
}
