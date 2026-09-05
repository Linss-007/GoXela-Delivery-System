using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Script_Principal
{
    internal class Program
    {
        static List<Vehículos> vehiculos = new List<Vehículos>();
        static List<Paquetes> paquetes = new List<Paquetes>();
        static void Menu()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("+==================================================+");
            Console.WriteLine("|           Bienvenido GoXela Delivery             |");
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
                Console.WriteLine();
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
                        ListarVehiculos();
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
            if (tipo == "automovil" || tipo == "bicicleta")
            {
                Console.WriteLine("+==================================+");
                Console.WriteLine($"|      Registro de {tipo}       |");
                Console.WriteLine("+==================================+");
                Console.ResetColor();
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("+==================================+");
                Console.WriteLine($"|      Registro de {tipo}     |");
                Console.WriteLine("+==================================+");
                Console.ResetColor();
                Console.WriteLine();
            }
            string codigoIng = "";
            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"Por favor, ingrese el código del/de la {tipo}: ");
                codigoIng = Console.ReadLine();
                Console.WriteLine();
                if (vehiculos.Exists(v => v.Codigo == codigoIng))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Error: El código ingresado ya existe.");
                    Console.ResetColor();
                    Console.ReadLine();
                    Console.WriteLine();
                    return;
                }
                else if (string.IsNullOrWhiteSpace(codigoIng) || codigoIng.Length > 10)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Error: Código inválido.");
                    Console.ResetColor();
                    Console.ReadLine();
                    Console.WriteLine();
                    valido = false;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Código ingresado correctamente.");
                    Console.ResetColor();
                    Console.ReadLine();
                    Console.WriteLine();
                    valido = true;
                }
            } while (!valido);
            string placa;
            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"Por favor, ingrese la placa del/de la {tipo}: ");
                placa = Console.ReadLine();
                Console.WriteLine();
                if (vehiculos.Exists(v => v.Placa == placa))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Error: La placa ingresada ya existe.");
                    Console.ResetColor();
                    Console.ReadLine();
                    Console.WriteLine();
                    valido = false;
                }
                else if (string.IsNullOrWhiteSpace(placa) || placa.Length != 7)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Error: La placa ingresada no es válida.");
                    Console.ResetColor();
                    Console.ReadLine();
                    Console.WriteLine();
                    valido = false;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Placa ingresada correctamente.");
                    Console.ResetColor();
                    Console.ReadLine();
                    Console.WriteLine();
                    valido = true;
                }
            } while (!valido);
            string marca;
            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"Por favor, ingrese la marca del/de la {tipo}: ");
                marca = Console.ReadLine();
                Console.WriteLine();
                if (string.IsNullOrWhiteSpace(marca))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Error: La marca no puede estar vacía.");
                    Console.ResetColor();
                    Console.ReadLine();
                    Console.WriteLine();
                    valido = false;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Marca ingresada correctamente.");
                    Console.ResetColor();
                    Console.ReadLine();
                    Console.WriteLine();
                    valido = true;
                }
            } while (!valido);
            string modelo;
            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"Por favor, ingrese el modelo del/de la {tipo}: ");
                modelo = Console.ReadLine();
                Console.WriteLine();
                if (string.IsNullOrWhiteSpace(modelo))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Error: El modelo no puede estar vacío.");
                    Console.ResetColor();
                    Console.ReadLine();
                    Console.WriteLine();
                    valido = false;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Modelo ingresado correctamente.");
                    Console.ResetColor();
                    Console.ReadLine();
                    Console.WriteLine();
                    valido = true;
                }
            } while (!valido);
            double capacidadLimite;
            if (tipo == "automovil")
            {
                nuevoVehiculo = new Automovil(codigoIng, placa, marca, modelo, EstadoVehiculo.Disponible);
            }
            else if (tipo == "motocicleta")
            {
                nuevoVehiculo = new Motocicleta(codigoIng, placa, marca, modelo, EstadoVehiculo.Disponible);
            }
            else if (tipo == "bicicleta")
            {
                do
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($"Por favor, ingrese la capacidad límite propia (kg) de la {tipo}: ");
                    valido = double.TryParse(Console.ReadLine(), out capacidadLimite);
                    Console.WriteLine();
                    if (!valido)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("Error: Tipo de dato incorrecto, por favor ingrese un número válido.");
                        Console.ResetColor();
                        Console.ReadLine();
                        Console.WriteLine();
                    }
                    else
                    {
                        nuevoVehiculo = new Bicicleta(codigoIng, placa, marca, modelo, EstadoVehiculo.Disponible);
                        ((Bicicleta)(nuevoVehiculo)).CapacidadLimite = capacidadLimite;
                        if (((Bicicleta)(nuevoVehiculo)).CapacidadLimite == capacidadLimite)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("Capacidad límite ingresada correctamente.");
                            Console.ReadLine();
                            Console.WriteLine();
                            Console.ResetColor();
                        }
                        else
                        {
                            valido = false;
                        }
                    }
                } while (!valido);
            }
            double capacidad;
            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"Por favor, ingrese la capacidad máxima de carga (kg) del/de la {tipo}: ");
                capacidad = 0;
                valido = double.TryParse(Console.ReadLine(), out capacidad);
                Console.WriteLine();
                if (!valido)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Error: Tipo de dato incorrecto, por favor ingrese un número válido.");
                    Console.ResetColor();
                    Console.ReadLine();
                    Console.WriteLine();
                }
                else
                {
                    nuevoVehiculo.CapacidadCarga = capacidad;
                    if (nuevoVehiculo.CapacidadCarga == capacidad)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("Capacidad ingresada correctamente.");
                        Console.ReadLine();
                        Console.WriteLine();
                        Console.ResetColor();
                        valido = true;
                    }
                    else
                    {
                        valido = false;
                    }
                }
            } while (!valido);
            double costoOperativo;
            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"Por favor, ingrese el costo operativo del/de la {tipo}: ");
                valido = double.TryParse(Console.ReadLine(), out costoOperativo);
                Console.WriteLine();
                if (!valido)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Error: Tipo de dato incorrecto, por favor ingrese un número válido.");
                    Console.ResetColor();
                    Console.ReadLine();
                    Console.WriteLine();
                }
                else
                {
                    nuevoVehiculo.CostoOperativo = costoOperativo;
                    if (nuevoVehiculo.CostoOperativo == costoOperativo)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("Costo operativo ingresado correctamente.");
                        Console.ResetColor();
                        Console.ReadLine();
                        Console.WriteLine();
                        valido = true;
                    }
                    else
                    {
                        valido = false;
                    }
                }
            } while (!valido);
            vehiculos.Add(nuevoVehiculo);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"{tipo} registrado correctamente.");
            Console.ResetColor();
            Console.ReadLine();
        }
        static void ListarVehiculos()
        {
            Console.Clear();
            if (vehiculos.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No hay vehículos registrados.");
                Console.ResetColor();
            }
            else
            {
                foreach (Vehículos v in vehiculos)
                {
                    v.MostrarInformacion();
                    Console.WriteLine();
                }
            }
            Console.WriteLine("Presione ENTER para volver...");
            Console.ReadLine();
        }
        static void GestionarPaquetes()
        {
            int opcion;
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("+===========================================+");
                Console.WriteLine("|            Gestión de Paquetes            |");
                Console.WriteLine("+===========================================+");
                Console.ResetColor();
                Console.WriteLine();
                Console.WriteLine("+==================================================+");
                Console.WriteLine("|  [1]  Registrar Documento                        |");
                Console.WriteLine("|  [2]  Registrar Paquete Estándar                 |");
                Console.WriteLine("|  [3]  Registrar Paquete Frágil                   |");
                Console.WriteLine("|  [4]  Registrar Producto Refrigerado             |");
                Console.WriteLine("|  [5]  Listar paquetes                            |");
                Console.WriteLine("|  [6]  Volver al menú principal                   |");
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
                        RegistrarPaquete("documento");
                        break;
                    case 2:
                        RegistrarPaquete("estandar");
                        break;
                    case 3:
                        RegistrarPaquete("fragil");
                        break;
                    case 4:
                        RegistrarPaquete("refrigerado");
                        break;
                    case 5:
                        ListarPaquetes();
                        break;
                    case 6:
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Error: Opción inválida.");
                        Console.ResetColor();
                        Console.ReadLine();
                        break;
                }
            } while (opcion != 6);
        }
        static void RegistrarPaquete(string tipo)
        {
            Console.Clear();
            Paquetes nuevoPaquete = null;
            bool valido = true;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            if (tipo == "documento")
            {
                Console.WriteLine("+==================================+");
                Console.WriteLine($"|      Registro de {tipo}       |");
                Console.WriteLine("+==================================+");
                Console.ResetColor();
                Console.WriteLine();
            }
            else if (tipo == "estandar")
            {
                Console.WriteLine("+==================================+");
                Console.WriteLine($"|      Registro de {tipo}        |");
                Console.WriteLine("+==================================+");
                Console.ResetColor();
                Console.WriteLine();
            }
            else if (tipo == "fragil")
            {
                Console.WriteLine("+==================================+");
                Console.WriteLine($"|      Registro de {tipo}          |");
                Console.WriteLine("+==================================+");
                Console.ResetColor();
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("+==================================+");
                Console.WriteLine($"|      Registro de {tipo}     |");
                Console.WriteLine("+==================================+");
                Console.ResetColor();
                Console.WriteLine();
            }
            string codigoIng = "";
            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"Por favor, ingrese el código del/de la {tipo}: ");
                codigoIng = Console.ReadLine();
                Console.WriteLine();
                if (paquetes.Exists(p => p.Codigo == codigoIng))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Error: El código ingresado ya existe.");
                    Console.ResetColor();
                    Console.ReadLine();
                    Console.WriteLine();
                    return;
                }
                else if (string.IsNullOrWhiteSpace(codigoIng) || codigoIng.Length > 10)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Error: Código inválido.");
                    Console.ResetColor();
                    Console.ReadLine();
                    Console.WriteLine();
                    valido = false;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Código ingresado correctamente.");
                    Console.ResetColor();
                    Console.ReadLine();
                    Console.WriteLine();
                    valido = true;
                }
            } while (!valido);
            string descripcion;
            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"Por favor, ingrese la descripción del/de la {tipo}: ");
                descripcion = Console.ReadLine();
                Console.WriteLine();
                if (string.IsNullOrWhiteSpace(descripcion))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Error: La descripción no puede estar vacía.");
                    Console.ResetColor();
                    Console.ReadLine();
                    Console.WriteLine();
                    valido = false;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Descripción ingresada correctamente.");
                    Console.ResetColor();
                    Console.ReadLine();
                    Console.WriteLine();
                    valido = true;
                }
            } while (!valido);
            string calleOrigen;
            string referenciaOrigen;
            Direccion direccionOrigen = new Direccion();
            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"Por favor, ingrese la calle de origen del/de la {tipo}: ");
                calleOrigen = Console.ReadLine();
                Console.WriteLine();
                Console.Write($"Por favor, ingrese una referencia de origen del/de la {tipo}: ");
                referenciaOrigen = Console.ReadLine();
                Console.WriteLine();
                Direccion intentoOrigen = new Direccion(calleOrigen, referenciaOrigen);
                if (intentoOrigen.LongitudTotal() < 15 || intentoOrigen.LongitudTotal() > 50)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Error: La dirección de origen inválida.");
                    Console.ResetColor();
                    Console.ReadLine();
                    Console.WriteLine();
                    valido = false;
                }
                else
                {
                    direccionOrigen = intentoOrigen;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Dirección de origen ingresada correctamente.");
                    Console.ResetColor();
                    Console.ReadLine();
                    Console.WriteLine();
                    valido = true;
                }
            } while (!valido);
            string calleDestino;
            string referenciaDestino;
            Direccion direccionDestino = new Direccion();
            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"Por favor, ingrese la calle de destino del/de la {tipo}: ");
                calleDestino = Console.ReadLine();
                Console.WriteLine();
                Console.Write($"Por favor, ingrese una referencia de destino del/de la {tipo}: ");
                referenciaDestino = Console.ReadLine();
                Console.WriteLine();
                Direccion intentoDestino = new Direccion(calleDestino, referenciaDestino);
                if (intentoDestino.LongitudTotal() < 15 || intentoDestino.LongitudTotal() > 50)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Error: La dirección de destino inválida.");
                    Console.ResetColor();
                    Console.ReadLine();
                    Console.WriteLine();
                    valido = false;
                }
                else
                {
                    direccionDestino = intentoDestino;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Dirección de destino ingresada correctamente.");
                    Console.ResetColor();
                    Console.ReadLine();
                    Console.WriteLine();
                    valido = true;
                }
            } while (!valido);
            double temperaturaRequerida;
            if (tipo == "documento")
            {
                nuevoPaquete = new Documento(codigoIng, descripcion, direccionOrigen, direccionDestino);
            }
            else if (tipo == "estandar")
            {
                nuevoPaquete = new PaqueteEstandar(codigoIng, descripcion, direccionOrigen, direccionDestino);
            }
            else if (tipo == "fragil")
            {
                string respuestaManejoEspecial;
                do
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($"¿Requiere manejo especial? (S/N): ");
                    respuestaManejoEspecial = Console.ReadLine().Trim().ToUpper();
                    Console.WriteLine();
                    if (respuestaManejoEspecial != "S" && respuestaManejoEspecial != "N")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("Error: Por favor ingrese S o N.");
                        Console.ResetColor();
                        Console.ReadLine();
                        Console.WriteLine();
                        valido = false;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("Respuesta ingresada correctamente.");
                        Console.ResetColor();
                        Console.ReadLine();
                        Console.WriteLine();
                        valido = true;
                    }
                } while (!valido);
                bool requiereManejoEspecial = respuestaManejoEspecial == "S";
                nuevoPaquete = new PaqueteFragil(codigoIng, descripcion, direccionOrigen, direccionDestino);
                ((PaqueteFragil)(nuevoPaquete)).RequiereManejoEspecial = requiereManejoEspecial;
            }
            else if (tipo == "refrigerado")
            {
                do
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($"Por favor, ingrese la temperatura requerida (°C) de la {tipo}: ");
                    valido = double.TryParse(Console.ReadLine(), out temperaturaRequerida);
                    Console.WriteLine();
                    if (!valido)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("Error: Tipo de dato incorrecto, por favor ingrese un número válido.");
                        Console.ResetColor();
                        Console.ReadLine();
                        Console.WriteLine();
                    }
                    else
                    {
                        nuevoPaquete = new ProductoRefrigerado(codigoIng, descripcion, direccionOrigen, direccionDestino);
                        ((ProductoRefrigerado)(nuevoPaquete)).TemperaturaRequerida = temperaturaRequerida;
                        if (((ProductoRefrigerado)(nuevoPaquete)).TemperaturaRequerida == temperaturaRequerida)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Temperatura requerida ingresada correctamente.");
                            Console.WriteLine();
                            Console.ResetColor();
                        }
                        else
                        {
                            valido = false;
                        }
                    }
                } while (!valido);
            }
            double peso;
            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"Por favor, ingrese el peso (kg) del/de la {tipo}: ");
                peso = 0;
                valido = double.TryParse(Console.ReadLine(), out peso);
                Console.WriteLine();
                if (!valido)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Error: Tipo de dato incorrecto, por favor ingrese un número válido.");
                    Console.ResetColor();
                    Console.ReadLine();
                    Console.WriteLine();
                }
                else
                {
                    nuevoPaquete.PesoPaquete = peso;
                    if (nuevoPaquete.PesoPaquete == peso)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("Peso ingresado correctamente.");
                        Console.ReadLine();
                        Console.WriteLine();
                        Console.ResetColor();
                        valido = true;
                    }
                    else
                    {
                        valido = false;
                    }
                }
            } while (!valido);
            double valorDeclarado;
            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"Por favor, ingrese el valor declarado del/de la {tipo}: ");
                valido = double.TryParse(Console.ReadLine(), out valorDeclarado);
                Console.WriteLine();
                if (!valido)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Error: Tipo de dato incorrecto, por favor ingrese un número válido.");
                    Console.ResetColor();
                    Console.ReadLine();
                    Console.WriteLine();
                }
                else
                {
                    nuevoPaquete.ValorDeclarado = valorDeclarado;
                    if (nuevoPaquete.ValorDeclarado == valorDeclarado)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("Valor declarado ingresado correctamente.");
                        Console.ResetColor();
                        Console.ReadLine();
                        Console.WriteLine();
                        valido = true;
                    }
                    else
                    {
                        valido = false;
                    }
                }
            } while (!valido);
            paquetes.Add(nuevoPaquete);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"{tipo} registrado correctamente.");
            Console.ResetColor();
            Console.ReadLine();
        }
        static void ListarPaquetes()
        {
            Console.Clear();
            if (paquetes.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No hay paquetes registrados.");
                Console.ResetColor();
            }
            else
            {
                foreach (Paquetes p in paquetes)
                {
                    p.MostrarInformacion();
                    Console.WriteLine();
                }
            }
            Console.WriteLine("Presione ENTER para volver...");
            Console.ReadLine();
        }
        static int ContarPaquetesRecursivo(int indice)
        {
            if (indice >= paquetes.Count)
            {
                return 0;
            }
            return 1 + ContarPaquetesRecursivo(indice + 1);
        }
        static unsafe double SumarPesosConPunteros()
        {
            if (paquetes.Count == 0)
            {
                return 0;
            }
            double[] pesos = new double[paquetes.Count];
            for (int i = 0; i < paquetes.Count; i++)
            {
                pesos[i] = paquetes[i].PesoPaquete;
            }
            double suma = 0;
            fixed (double* ptrPesos = pesos)
            {
                double* p = ptrPesos;
                for (int i = 0; i < pesos.Length; i++)
                {
                    suma += *p;
                    p++;
                }
            }
            return suma;
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
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkYellow;

                        Console.ForegroundColor = ConsoleColor.White;
                        Console.ReadLine();
                        break;
                    case 2:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkYellow;

                        Console.ForegroundColor = ConsoleColor.White;
                        Console.ReadLine();
                        break;
                    case 3:
                        Console.Clear();
                        GestionarVehiculos();
                        Console.ReadLine();
                        break;
                    case 4:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        GestionarPaquetes();
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.ReadLine();
                        break;
                    case 5:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkYellow;

                        Console.ForegroundColor = ConsoleColor.White;
                        Console.ReadLine();
                        break;
                    case 6:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkYellow;

                        Console.ForegroundColor = ConsoleColor.White;
                        Console.ReadLine();
                        break;
                    case 7:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("+================================+");
                        Console.WriteLine("|            Reportes            |");
                        Console.WriteLine("+================================+");
                        Console.ResetColor();
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine($"Cantidad de paquetes registrados: {ContarPaquetesRecursivo(0)}");
                        Console.WriteLine($"Suma total de pesos registrados: {SumarPesosConPunteros()} kg");
                        Console.WriteLine();
                        Console.WriteLine("Presione ENTER para volver...");
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