using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Script_Principal
{
    internal class Repartidor : Usuario
    {
        private Tipolicencia tipoLicencia;
        private string numLicencia;
        private EstadoRepartidor estadoDisponibilidad;
        private int cantEntregasRealizadas;
        private double calificacionPromedio;
        public Repartidor(string codigoIng, string nombreIng, string numeroIng, Tipolicencia tipoLicenciaIng, string numLicenciaIng, EstadoRepartidor estadoIng) : base(codigoIng, nombreIng, numeroIng)
        {
            TipoLicencia = tipoLicenciaIng;
            NumLicencia = numLicenciaIng;
            EstadoDisponibilidad = estadoIng;
        }
        public Tipolicencia TipoLicencia
        {
            get { return tipoLicencia; }
            set { tipoLicencia = value; }
        }
        public string NumLicencia
        {
            get { return numLicencia; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: El número de licencia no puede ir vacío.");
                    Console.ResetColor();
                }
                else if (value.Length != 13 || !long.TryParse(value, out long _))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: El número de licencia debe tener 13 dígitos numéricos.");
                    Console.ResetColor();
                }
                else
                {
                    numLicencia = value;
                }
            }
        }
        public EstadoRepartidor EstadoDisponibilidad
        {
            get { return estadoDisponibilidad; }
            set { estadoDisponibilidad = value; }
        }
        public int CantEntregasRealizadas
        {
            get { return cantEntregasRealizadas; }
            set
            {
                if (value >= 0)
                {
                    cantEntregasRealizadas += value;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: La cantidad de entregas no puede ser negativa.");
                    Console.ResetColor();
                }
            }
        }
        public double CalificacionPromedio
        {
            get { return calificacionPromedio; }
            set
            {
                if (value >= 0 && value <= 5)
                {
                    calificacionPromedio = value;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: La calificación promedio debe estar entre 0 y 5.");
                    Console.ResetColor();
                }
            }
        }
        public bool EstaDisponible()
        {
            return EstadoDisponibilidad == EstadoRepartidor.Disponible;
        }
        public override void ConsultarInfo()
        {
            base.ConsultarInfo();
            Console.WriteLine($"| Tipo de licencia: {TipoLicencia}");
            Console.WriteLine($"| Número de licencia: {NumLicencia}");
            Console.WriteLine($"| Estado de disponibilidad: {EstadoDisponibilidad}");
            Console.WriteLine($"| Cantidad de entregas realizadas: {CantEntregasRealizadas}");
            Console.WriteLine($"| Calificación promedio: {CalificacionPromedio}");
        }
        public override void Actualizar(int opcion)
        {
            base.Actualizar(opcion);
            switch (opcion)
            {
                case 3:
                MalTipoLicencia:
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Ingrese el tipo de licencia nuevo: ");
                    Console.WriteLine("[1] C   [2] B   [3] A   [4] M");
                    string tipoLicenciaNuevaStr = Console.ReadLine();
                    if (!int.TryParse(tipoLicenciaNuevaStr, out int tipoLicenciaNueva) || tipoLicenciaNueva < 1 || tipoLicenciaNueva > 4)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Error: La opción ingresada no es válida.");
                        Console.ResetColor();
                        goto MalTipoLicencia;
                    }
                    TipoLicencia = (Tipolicencia)(tipoLicenciaNueva - 1);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Tipo de licencia del repartidor actualizado");
                    Console.ResetColor();
                    Console.WriteLine("Presione cualquier tecla para continuar.");
                    Console.ReadKey();
                    break;
                case 4:
                MalNumLicencia:
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Ingrese el número de licencia nuevo (13 dígitos): ");
                    string nuevoNumLicencia = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(nuevoNumLicencia))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Error: El número de licencia no puede ir vacío.");
                        Console.ResetColor();
                        goto MalNumLicencia;
                    }
                    else if (nuevoNumLicencia.Length != 13 || !long.TryParse(nuevoNumLicencia, out long _))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Error: El número de licencia debe tener 13 dígitos numéricos.");
                        Console.ResetColor();
                        goto MalNumLicencia;
                    }
                    else
                    {
                        NumLicencia = nuevoNumLicencia;
                    }
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Número de licencia del repartidor actualizado");
                    Console.ResetColor();
                    Console.WriteLine("Presione cualquier tecla para continuar.");
                    Console.ReadKey();
                    break;
                case 5:
                MalEstado:
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Ingrese el nuevo estado de disponibilidad: ");
                    Console.WriteLine("[1] Disponible   [2] Asignado   [3] Fuera de servicio");
                    string estadoNuevoStr = Console.ReadLine();
                    if (!int.TryParse(estadoNuevoStr, out int estadoNuevo) || estadoNuevo < 1 || estadoNuevo > 3)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Error: La opción ingresada no es válida.");
                        Console.ResetColor();
                        goto MalEstado;
                    }
                    EstadoDisponibilidad = (EstadoRepartidor)(estadoNuevo - 1);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Estado de disponibilidad del repartidor actualizado");
                    Console.ResetColor();
                    Console.WriteLine("Presione cualquier tecla para continuar.");
                    Console.ReadKey();
                    break;
            }
        }
    }
}
