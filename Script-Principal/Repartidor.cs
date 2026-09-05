using System;

namespace Script_Principal
{
    internal class Repartidor : Usuario
    {
        private TipoLicencia licencia;
        private string numLicencia;
        private EstadoRepartidor estado;
        private int cantEntregas;
        private double califPromedio;
        private double califViaje;
        public Repartidor(string codigoIng, string nombreIng, string numeroIng, TipoLicencia licenciaIng, string numLicenciaIng, EstadoRepartidor estadoIng, int cantEntregasIng, double califViajeIng) : base(codigoIng, nombreIng, numeroIng)
        {
            Licencia = licenciaIng;
            NumLicencia = numLicenciaIng;
            Estado = estadoIng;
            CantEntregas += cantEntregasIng;
            CalifViaje = califViajeIng;
        }
        public double CalifViaje
        {
            get { return califViaje; }
            set
            {
                if (value < 0 || value > 5)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: La calificación ingresada esta fuera del rango, intente de nuevo");
                    Console.ResetColor();
                }
                else
                {
                    califViaje = value;
                }
            }
        }
        public double CalifPromedio
        {
            get { return califPromedio; }
            set { califPromedio = value; }
        }
        public int CantEntregas
        {
            get { return cantEntregas; }
            set
            {
                if (value < 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: La cantidad de entregas no puede ser negativa");
                    Console.ResetColor();
                }
                else
                {
                    cantEntregas += value;
                }
            }
        }
        public EstadoRepartidor Estado
        {
            get { return estado; }
            set { estado = value; }
        }
        public string NumLicencia
        {
            get { return numLicencia; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: El numero de licencia no puede ser estar vacío, intente de nuevo");

                    Console.ResetColor();
                }
                else if (value.Length != 13)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: El numero de licencia no cumple con el rango, intente de nuevo");
                    Console.ResetColor();
                }
                else if (!int.TryParse(value, out int num))
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: El numero debe contener solo números no letras, intente de nuevo");
                    Console.ResetColor();
                }
                else
                {
                    numLicencia = Convert.ToString(num);
                }
            }
        }
        public TipoLicencia Licencia
        {
            get { return licencia; }
            set { licencia = value; }
        }
        public override void Actualizar(int opcion)
        {
            base.Actualizar(opcion);
            switch (opcion)
            {
                case 3:
                MalTipoLicencia:
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Ingrese el tipo de licencia a actualizar.");
                    Console.WriteLine("1. C");
                    Console.WriteLine("2. B");
                    Console.WriteLine("3. A");
                    Console.WriteLine("4. M");
                    if (!int.TryParse(Console.ReadLine(), out int tipoLicenciaNueva) || tipoLicenciaNueva < 1 || tipoLicenciaNueva > 4)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("El tipo ingresado no es válido, intente de nuevo");
                        Console.ResetColor();
                        goto MalTipoLicencia;
                    }
                    Licencia = (TipoLicencia)tipoLicenciaNueva - 1;
                    Console.WriteLine("Licencia actualizada con éxito");
                    Console.ResetColor();
                    break;
                case 4:
                MalEstado:
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Ingrese el nuevo estado del repartidor");
                    Console.WriteLine("1. Disponible.");
                    Console.WriteLine("2. Asignado.");
                    Console.WriteLine("3. Fuera de Servicio.");
                    if (!int.TryParse(Console.ReadLine(), out int estadoNuevo) || estadoNuevo < 1 || estadoNuevo > 3)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("El estado ingresado no es válido, intente de nuevo");
                        Console.ResetColor();
                        goto MalEstado;
                    }
                    Estado = (EstadoRepartidor)estadoNuevo - 1;
                    Console.WriteLine("Estado actualizado con éxito");
                    Console.ResetColor();
                    break;
                case 5:
                MalNumLicencia:
                    Console.ForegroundColor= ConsoleColor.DarkYellow;
                    Console.WriteLine("Ingrese el nuevo numero de licencia");
                    string nuevoNumLicencia = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(nuevoNumLicencia))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Error: El numero de licencia no puede ser estar vacío, intente de nuevo");
                        Console.ResetColor();
                        goto MalNumLicencia;
                    }
                    else if (nuevoNumLicencia.Length != 13)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Error: El numero de licencia no cumple con el rango, intente de nuevo");
                        Console.ResetColor();
                        goto MalNumLicencia;
                    }
                    else if (!int.TryParse(nuevoNumLicencia, out int num))
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine("Error: El numero debe contener solo números no letras, intente de nuevo");
                        Console.ResetColor();
                        goto MalNumLicencia;
                    }
                    else
                    {
                        numLicencia = Convert.ToString(num);
                        Console.WriteLine("Licencia actualizada con éxito");
                    }
                    Console.ResetColor();
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: La opción ingresada no existe, intente de nuevo");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }
        }
    }
}
