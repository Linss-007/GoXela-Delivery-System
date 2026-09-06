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
        static List<Usuario> Usuarios = new List<Usuario>();
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
        static void GestionRepartidores()
        {
            int opcion;
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("+===============================================+");
                Console.WriteLine("|            Gestión de Repartidores           |");
                Console.WriteLine("+===============================================+\n");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("+===============================================+");
                Console.WriteLine("| [1] Registrar repartidor.                    |");
                Console.WriteLine("| [2] Mostrar información de repartidores.     |");
                Console.WriteLine("| [3] Actualizar información de un repartidor. |");
                Console.WriteLine("| [4] Volver al menú principal.                |");
                Console.WriteLine("+===============================================+\n");
                Console.Write("Por favor ingrese una opción: ");
                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: La opción ingresada no es un numero.");
                    Console.ResetColor();
                    Console.Write("Presione una tecla para continuar.");
                    Console.ReadKey();
                    continue;
                }
                switch (opcion)
                {
                    case 1:
                        RegistrarRepartidor();
                        break;
                    case 2:
                        int cont = 1;
                        if (Usuarios.OfType<Repartidor>().Count() == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Error: No existen repartidores guardados");
                            Console.ResetColor();
                        }
                        else
                        {
                            foreach (Repartidor repartidor in Usuarios.OfType<Repartidor>())
                            {
                                Console.WriteLine($"Repartidor {cont}");
                                Console.WriteLine("+===========================================+");
                                repartidor.ConsultarInfo();
                                Console.WriteLine("+===========================================+");
                                cont++;
                            }
                        }
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Presione cualquier tecla para continuar.");
                        Console.ReadKey();
                        break;
                    case 3:
                        bool repartidorEncontrado = false;
                        int posRepartidor = 0;
                        if (Usuarios.OfType<Repartidor>().Count() == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Error: No existen repartidores guardados");
                            Console.ResetColor();
                            Console.WriteLine("Presione una tecla para continuar.");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("Ingrese el código del repartidor a actualizar la información");
                            string codigoActu = Console.ReadLine();
                            foreach (Repartidor repartidor in Usuarios.OfType<Repartidor>())
                            {
                                if (repartidor.Codigo == codigoActu)
                                {
                                    repartidorEncontrado = true;
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("Repartidor encontrado");
                                    Console.ResetColor();
                                    posRepartidor = Usuarios.IndexOf(repartidor);
                                    break;
                                }
                            }
                            if (repartidorEncontrado == false)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Error: El repartidor no existe.");
                                Console.ResetColor();
                                Console.WriteLine("Presione una tecla para continuar.");
                                Console.ReadKey();
                            }
                            else
                            {
                                do
                                {
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.WriteLine("+================================================+");
                                    Console.WriteLine("|              Actualizar Repartidor            |");
                                    Console.WriteLine("+================================================+\n");
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("+================================================+");
                                    Console.WriteLine("| [1] Actualizar nombre.                        |");
                                    Console.WriteLine("| [2] Actualizar número.                        |");
                                    Console.WriteLine("| [3] Actualizar tipo de licencia.              |");
                                    Console.WriteLine("| [4] Actualizar número de licencia.            |");
                                    Console.WriteLine("| [5] Actualizar estado de disponibilidad.      |");
                                    Console.WriteLine("| [6] No actualizar nada.                       |");
                                    Console.WriteLine("+================================================+");
                                    Console.WriteLine("Por favor ingrese una opción.");
                                    if (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 1 || opcion > 6)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Error: La opción ingresada no es válida.");
                                        Console.ResetColor();
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.WriteLine("Presione una tecla para continuar.");
                                        Console.ReadKey();
                                        continue;
                                    }
                                    Usuarios[posRepartidor].Actualizar(opcion);
                                } while (opcion != 6);
                            }
                        }
                        break;
                    case 4:
                        break;
                }
            } while (opcion != 4);
        }
        static void RegistrarRepartidor()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("+===========================================+");
            Console.WriteLine("|            Registrar Repartidor           |");
            Console.WriteLine("+===========================================+\n");
            Console.ResetColor();
            Console.WriteLine();
        MalCodigo:
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Ingrese el código del repartidor: ");
            string codigoIng = Console.ReadLine();
            Console.WriteLine();
            if (string.IsNullOrWhiteSpace(codigoIng))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Error: El código no puede ir vacío.");
                Console.ReadKey();
                Console.WriteLine();
                Console.ResetColor();
                goto MalCodigo;
            }
            else if (codigoIng.Length > 10)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Error: Código inválido.");
                Console.ResetColor();
                Console.ReadKey();
                Console.WriteLine();
                goto MalCodigo;
            }
            else if (Usuarios.OfType<Repartidor>().Any(r => r.Codigo == codigoIng))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Error: El código ingresado ya existe.");
                Console.ReadKey();
                Console.WriteLine();
                Console.ResetColor();
                goto MalCodigo;
            }
        MalNombre:
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Ingrese el nombre del repartidor: ");
            string nombreIng = Console.ReadLine();
            Console.WriteLine();
            if (string.IsNullOrWhiteSpace(nombreIng))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Error: El nombre no puede ir vacío.");
                Console.ResetColor();
                Console.ReadKey();
                Console.WriteLine();
                goto MalNombre;
            }
            else if (nombreIng.Length > 50)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Error: El nombre esta fuera del rango establecido.");
                Console.ReadKey();
                Console.WriteLine();
                Console.ResetColor();
                goto MalNombre;
            }
        MalNumero:
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Ingrese el numero del repartidor.");
            string numeroIng = Console.ReadLine();
            Console.WriteLine();
            if (string.IsNullOrWhiteSpace(numeroIng))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Error: El número de teléfono no puede estar vácio");
                Console.ResetColor();
                Console.ReadKey();
                Console.WriteLine();
                goto MalNumero;
            }
            else if (numeroIng.Length != 8)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Error: El número de teléfono debe tener 8 dígitos.");
                Console.ResetColor();
                Console.ReadKey();
                Console.WriteLine();
                goto MalNumero;
            }
            else if (!int.TryParse(numeroIng, out int num) == true)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Error: El número de teléfono no debe contener letras");
                Console.ResetColor();
                Console.ReadKey();
                Console.WriteLine();
                goto MalNumero;
            }
        MalTipoLicencia:
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Ingrese el tipo de licencia del repartidor:");
            Console.WriteLine("[1] C   [2] B   [3] A   [4] M");
            string tipoLicenciaStr = Console.ReadLine();
            Console.WriteLine();
            if (!int.TryParse(tipoLicenciaStr, out int tipoLicenciaOpc) || tipoLicenciaOpc < 1 || tipoLicenciaOpc > 4)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Error: La opción ingresada no es válida.");
                Console.ResetColor();
                Console.ReadKey();
                Console.WriteLine();
                goto MalTipoLicencia;
            }
            Tipolicencia tipoLicenciaIng = (Tipolicencia)(tipoLicenciaOpc - 1);
        MalNumLicencia:
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Ingrese el número de licencia del repartidor: ");
            string numLicenciaIng = Console.ReadLine();
            Console.WriteLine();
            if (string.IsNullOrWhiteSpace(numLicenciaIng))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Error: El número de licencia no puede ir vacío.");
                Console.ResetColor();
                Console.ReadKey();
                Console.WriteLine();
                goto MalNumLicencia;
            }
            else if (numLicenciaIng.Length != 13 || !long.TryParse(numLicenciaIng, out long _))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Error: El número de licencia debe tener 13 dígitos numéricos.");
                Console.ResetColor();
                Console.ReadKey();
                Console.WriteLine();
                goto MalNumLicencia;
            }
            else if (Usuarios.OfType<Repartidor>().Any(r => r.NumLicencia == numLicenciaIng))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: El número de licencia ingresado ya existe.");
                Console.ResetColor();
                goto MalNumLicencia;
            }
            Repartidor repartidor = new Repartidor(codigoIng, nombreIng, numeroIng, tipoLicenciaIng, numLicenciaIng, EstadoRepartidor.Disponible);
            Usuarios.Add(repartidor);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Repartidor creado exitosamente.");
            Console.ResetColor();
            Console.WriteLine();
            Console.Write("Presione cualquier tecla para continuar");
            Console.ReadKey();
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
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("+===========================================+");
                Console.WriteLine("| [1] Registrar cliente.                    |");
                Console.WriteLine("| [2] Mostrar información de clientes.      |");
                Console.WriteLine("| [3] Actualizar información de un cliente. |");
                Console.WriteLine("| [4] Volver al menú principal.             |");
                Console.WriteLine("+===========================================+\n");
                Console.Write("Por favor ingrese una opción: ");
                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: La opción ingresada no es un numero.");
                    Console.ResetColor();
                    Console.WriteLine("Presione una tecla para continuar.");
                    Console.ReadKey();
                    continue;
                }
                switch (opcion)
                {
                    case 1:
                        RegistrarCliente();
                        break;
                    case 2:
                        int cont = 1;
                        if (Usuarios.OfType<Cliente>().Count() == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Error: No existen clientes guardados");
                            Console.ResetColor();
                        }
                        else
                        {
                            foreach (Cliente cliente in Usuarios)
                            {
                                Console.WriteLine($"Cliente {cont}");
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
                            Console.WriteLine("Presione una tecla para continuar.");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("Ingrese el código del cliente a actualizar la información");
                            string codigoActu = Console.ReadLine();
                            foreach (Cliente cliente in Usuarios)
                            {
                                if (cliente.Codigo == codigoActu)
                                {
                                    clienteEncontrado = true;
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("Cliente encontrado");
                                    Console.ResetColor();
                                    posCliente = Usuarios.IndexOf(cliente);
                                    break;
                                }
                            }
                            if (clienteEncontrado == false)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Error: El cliente no existe.");
                                Console.ResetColor();
                                Console.WriteLine("Presione una tecla para continuar.");
                                Console.ReadKey();
                            }
                            else
                            {
                                do
                                {
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.WriteLine("+===========================================+");
                                    Console.WriteLine("|            Actualizar Cliente             |");
                                    Console.WriteLine("+===========================================+\n");
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("+===========================================+");
                                    Console.WriteLine("| [1] Actualizar nombre.                    |");
                                    Console.WriteLine("| [2] Actualizar número.                    |");
                                    Console.WriteLine("| [3] Actualizar córreo.                    |");
                                    Console.WriteLine("| [4] Actualizar Dirección.                 |");
                                    Console.WriteLine("| [5] No actualizar nada.                   |");
                                    Console.WriteLine("+===========================================+");
                                    Console.WriteLine("Por favor ingrese una opción.");
                                    if (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 1 || opcion > 5)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Error: La opción ingresada no es válida.");
                                        Console.ResetColor();
                                        Console.ForegroundColor = ConsoleColor.Yellow;
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
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("+===========================================+");
            Console.WriteLine("|             Registrar Cliente             |");
            Console.WriteLine("+===========================================+\n");
            Console.ResetColor();
        MalCodigo:
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Ingrese el código del cliente: ");
            string codigoIng = Console.ReadLine();
            Console.WriteLine();
            if (string.IsNullOrWhiteSpace(codigoIng))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Error: El código no puede ir vacío.");
                Console.ReadLine();
                Console.WriteLine();
                Console.ResetColor();
                goto MalCodigo;
            }
            else if(codigoIng.Length > 10)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Error: Código inválido.");
                Console.ReadLine();
                Console.WriteLine();
                Console.ResetColor();
                goto MalCodigo;
            }
        MalNombre:
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Ingrese el nombre del cliente: ");
            string nombreIng = Console.ReadLine();
            Console.WriteLine();
            if (string.IsNullOrWhiteSpace(nombreIng))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Error: El nombre no puede ir vacío.");
                Console.ReadLine();
                Console.WriteLine();
                Console.ResetColor();
                goto MalNombre;
            }
            else if(nombreIng.Length > 50)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Error: El nombre esta fuera del rango establecido.");
                Console.ReadLine();
                Console.WriteLine();
                Console.ResetColor();
                goto MalNombre;
            }
        MalNumero:
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Ingrese el numero del cliente: ");
            string numeroIng = Console.ReadLine();
            Console.WriteLine();
            if (string.IsNullOrWhiteSpace(numeroIng))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Error: El número de teléfono no puede estar vácio");
                Console.ReadLine();
                Console.WriteLine();
                Console.ResetColor();
                goto MalNumero;
            }
            else if(numeroIng.Length != 8)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Error: El número de teléfono debe tener 8 dígitos.");
                Console.ReadLine();
                Console.WriteLine();
                Console.ResetColor();
                goto MalNumero;
            }
            else if(!int.TryParse(numeroIng, out int num) == true)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Error: El número de teléfono no debe contener letras");
                Console.ReadLine();
                Console.WriteLine();
                Console.ResetColor();
                goto MalNumero;
            }
        MalCorreo:
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Ingrese el correo electronico del cliente: ");
            string correoIng = Console.ReadLine();
            Console.WriteLine();
            if (string.IsNullOrWhiteSpace(correoIng))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Error: El correo no pude estar vacio, intente de nuevo.");
                Console.ReadLine();
                Console.WriteLine();
                Console.ResetColor();
                goto MalCorreo;
            }
            else if (!correoIng.Contains('@'))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Error: El correo no tiene @, intente de nuevo.");
                Console.ReadLine();
                Console.WriteLine();
                Console.ResetColor();
                goto MalCorreo;
            }
            else if (correoIng.Length > 30)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Error: El correo excede el largo disponible, intente de nuevo");
                Console.ReadLine();
                Console.WriteLine();
                Console.ResetColor();
                goto MalCorreo;
            }
        MalDireccion:
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Ingrese la dirección del cliente: ");
            string direccionIng = Console.ReadLine();
            Console.WriteLine();
            if (string.IsNullOrWhiteSpace(direccionIng))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Error: La dirección no puede estar vacia, intente de nuevo.");
                Console.ReadLine();
                Console.WriteLine();
                Console.ResetColor();
                goto MalDireccion;
            }
            else if (direccionIng.Length > 50)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Error: La dirección excede el largo dispoible, intente de nuevo.");
                Console.ReadLine();
                Console.WriteLine();
                Console.ResetColor();
                goto MalDireccion;
            }
            Cliente cliente = new Cliente(codigoIng, nombreIng, numeroIng, correoIng, direccionIng);
            Usuarios.Add(new Cliente(codigoIng, nombreIng, numeroIng, correoIng, direccionIng));
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Cliente creado exitosamente.");
            Console.ResetColor();
            Console.WriteLine();
            Console.Write("Presione cualquier tecla para continuar");
            Console.ReadKey();
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
                        RegistrarVehiculo("Automovil");
                        break;
                    case 2:
                        RegistrarVehiculo("Motocicleta");
                        break;
                    case 3:
                        RegistrarVehiculo("Bicicleta");
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
            if (tipo == "Automovil" || tipo == "Bicicleta")
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
            if (tipo == "Automovil")
            {
                nuevoVehiculo = new Automovil(codigoIng, placa, marca, modelo, EstadoVehiculo.Disponible);
            }
            else if (tipo == "Motocicleta")
            {
                nuevoVehiculo = new Motocicleta(codigoIng, placa, marca, modelo, EstadoVehiculo.Disponible);
            }
            else if (tipo == "Bicicleta")
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
            Console.WriteLine();
            Console.Write("Presione cualquier tecla para continuar");
            Console.ReadKey();
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
                        RegistrarPaquete("Documento");
                        break;
                    case 2:
                        RegistrarPaquete("Estandar");
                        break;
                    case 3:
                        RegistrarPaquete("Fragil");
                        break;
                    case 4:
                        RegistrarPaquete("Refrigerado");
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
            if (tipo == "Documento")
            {
                Console.WriteLine("+==================================+");
                Console.WriteLine($"|      Registro de {tipo}       |");
                Console.WriteLine("+==================================+");
                Console.ResetColor();
                Console.WriteLine();
            }
            else if (tipo == "Estandar")
            {
                Console.WriteLine("+==================================+");
                Console.WriteLine($"|      Registro de {tipo}        |");
                Console.WriteLine("+==================================+");
                Console.ResetColor();
                Console.WriteLine();
            }
            else if (tipo == "Fragil")
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
            if (tipo == "Documento")
            {
                nuevoPaquete = new Documento(codigoIng, descripcion, direccionOrigen, direccionDestino);
            }
            else if (tipo == "Estandar")
            {
                nuevoPaquete = new PaqueteEstandar(codigoIng, descripcion, direccionOrigen, direccionDestino);
            }
            else if (tipo == "Fragil")
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
            else if (tipo == "Refrigerado")
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
            Console.WriteLine();
            Console.Write("Presione cualquier tecla para continuar");
            Console.ReadKey();
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
                        GestionClientes();
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case 2:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        GestionRepartidores();
                        Console.ForegroundColor = ConsoleColor.White;
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