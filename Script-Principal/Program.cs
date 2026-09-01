using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Script_Principal
{
    internal class Program
    {
        static List<Vehículos> vehiculos=new List<Vehículos>();
        static List<Paquetes> paquetes = new List<Paquetes>();
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
            Console.ForegroundColor= ConsoleColor.White;
            Console.Write("Ingrese el índice de la acción que desea realizar: ");
        }
        static void GestionarVehiculos()
        {
            int opcion;
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("+===========================================+");
                Console.WriteLine("|            Gestión de Vehículos           |");
                Console.WriteLine("+===========================================+");
                Console.ResetColor();
                Console.WriteLine("+==================================================+");
                Console.WriteLine("|  [1]  Registrar Automóvil                        |");
                Console.WriteLine("|  [2]  Registrar Motocicleta                      |");
                Console.WriteLine("|  [3]  Registrar Bicicleta                        |");
                Console.WriteLine("|  [4]  Listar vehículos                           |");
                Console.WriteLine("|  [5]  Volver al menú principal                   |");
                Console.WriteLine("+==================================================+");
                Console.WriteLine();
                Console.Write("Por favor, ingrese una opción: ");
                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: Ingrese un número entero.");
                    Console.ResetColor();
                    Console.ReadLine();
                    continue;
                }
                    switch (opcion)
                    {
                        case 1:
                            RegistrarVehiculo("automovil");
                            break;
                        case 2:
                            RegistrarVehiculo("motocicleta");
                            break;
                        case 3:
                            RegistrarVehiculo("bicicleta");
                            break;
                        case 4:
                           
                            break;
                        case 5:
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Error: Opción inválida.");
                            Console.ResetColor();
                            Console.ReadLine();
                            break;
                    }
            } while (opcion != 5);
        }
        static void RegistrarVehiculo(string tipo)
        {
            Console.Clear();
            Vehículos nuevoVehiculo = null;
            bool valido = true;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("+===========================================+");
            Console.WriteLine($"|      Registro de {tipo}                   |");
            Console.WriteLine("+===========================================+");
            Console.ResetColor();
            do {
                Console.Write($"Por favor, ingrese el código del/de la {tipo}: ");
                string codigo = Console.ReadLine();
                Console.WriteLine();
                if (vehiculos.Exists(v => v.Codigo == codigo))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: El código ingresado ya existe.");
                    Console.ResetColor();
                    Console.ReadLine();
                    return;
                }
                else
                {
                    nuevoVehiculo.Codigo = codigo;
                    if (nuevoVehiculo.Codigo == codigo)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Código ingresado correctamente.");
                        Console.ResetColor();
                    }
                    else
                    {
                        valido= false;
                    }
                }
            } while (!valido);
            Console.WriteLine();
            do {
                Console.Write($"Por favor, ingrese la placa del/de la {tipo}: ");
                string placa = Console.ReadLine();
                Console.WriteLine();
                if (vehiculos.Exists(v => v.Placa == placa))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: La placa ingresada ya existe.");
                    Console.ResetColor();
                    Console.ReadLine();
                    valido = false;
                }
                else
                {
                    nuevoVehiculo.Placa = placa;
                    if(nuevoVehiculo.Placa == placa)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Placa ingresada correctamente.");
                        Console.ResetColor();
                        valido = true;
                    }
                    else
                    {
                        valido = false;
                    }
                }
            } while (!valido);
            Console.WriteLine();
            do {
                Console.Write($"Por favor, ingrese la marca del/de la {tipo}: ");
                string marca = Console.ReadLine();
                Console.WriteLine();
                    nuevoVehiculo.Marca = marca;
                if(nuevoVehiculo.Marca == marca)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Marca ingresada correctamente.");
                    Console.ResetColor();
                    valido = true;
                }
                else
                {
                    valido = false;
                }

            } while (!valido);
            Console.WriteLine();
            do
            {
                Console.Write($"Por favor, ingrese el modelo del/de la {tipo}: ");
                string modelo = Console.ReadLine();
                Console.WriteLine();
                nuevoVehiculo.Modelo = modelo;
                if (nuevoVehiculo.Modelo == modelo)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Modelo ingresado correctamente.");
                    Console.ResetColor();
                    valido = true;
                }
                else
                {
                    valido = false;
                }
            } while (!valido);
            Console.WriteLine();
            do
            {
                Console.Write($"Por favor, ingrese la capacidad máxima de carga (kg) del/de la {tipo}: ");
                double capacidad = 0;
                valido=double.TryParse(Console.ReadLine(), out capacidad);
                Console.WriteLine();
                if (!valido)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: Tipo de dato incorrecto, por favor ingrese un número válido.");
                    Console.ResetColor();
                }
                nuevoVehiculo.CapacidadCarga = capacidad;
                if (nuevoVehiculo.CapacidadCarga == capacidad)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Capacidad ingresada correctamente.");
                    Console.ResetColor();
                    valido = true;
                }
                else
                {
                    valido = false;
                }
            } while (!valido); 
            Console.WriteLine();
            do {
                Console.Write($"Por favor, ingrese el costo operativo del/de la {tipo}: ");
                double costoOperativo = 0;
                valido = double.TryParse(Console.ReadLine(), out costoOperativo);
                Console.WriteLine();
                if (!valido)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: Tipo de dato incorrecto, por favor ingrese un número válido.");
                    Console.ResetColor();
                }
                else
                {
                    nuevoVehiculo.CostoOperativo = costoOperativo;
                    if (nuevoVehiculo.CostoOperativo == costoOperativo)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Costo operativo ingresado correctamente.");
                        Console.ResetColor();
                        valido = true;
                    }
                    else
                    {
                        valido = false;
                    }
                }
            } while (!valido);
            if (tipo == "automovil")
            {
                nuevoVehiculo = new Automovil(codigo, placa, marca, modelo, capacidad, EstadoVehiculo.Disponible, costoOperativo);
            }
            else if (tipo == "motocicleta")
            {
                nuevoVehiculo = new Motocicleta(codigo, placa, marca, modelo, capacidad, EstadoVehiculo.Disponible, costoOperativo);
            }
            else if (tipo == "bicicleta")
            {
                do
                {
                    Console.Write($"Por favor, ingrese la capacidad límite propia (kg) de la {tipo}: ");
                    double capacidadLimite = 0;
                    valido = double.TryParse(Console.ReadLine(), out capacidadLimite);
                    Console.WriteLine();
                    if (!valido)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Error: Tipo de dato incorrecto, por favor ingrese un número válido.");
                        Console.ResetColor();
                    }
                    else
                    {
                        nuevoVehiculo.CapacidadLimite = capacidadLimite;
                        if (nuevoVehiculo.CapacidadLimite == capacidadLimite)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Capacidad límite ingresada correctamente.");
                            Console.ResetColor();

                            nuevoVehiculo = new Bicicleta(codigo, placa, marca, modelo, capacidad, EstadoVehiculo.Disponible, costoOperativo, capacidadLimite);
                        }
                        else
                        {
                            valido = false;
                        }
                    }
                } while (!valido);
            }
            vehiculos.Add(nuevoVehiculo);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{tipo} registrado correctamente.");
            Console.ResetColor();
            Console.ReadLine();
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

                switch(opcion)
                {
                    case 1:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("+===========================================+");
                        Console.WriteLine("|            Gestión de Clientes            |");
                        Console.WriteLine("+===========================================+");
                        Console.ResetColor();
                        Console.ReadLine();
                        break;
                    case 2:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("+===============================================+");
                        Console.WriteLine("|            Gestión de Repartidores            |");
                        Console.WriteLine("+===============================================+");
                        Console.ResetColor();
                        Console.ReadLine();
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
