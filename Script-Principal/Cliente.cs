using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Script_Principal
{
    internal class Cliente : Usuario
    {
        private string correo;
        private string direccion;
        private int cantSolicitudes;
        public Cliente(string codigoIng, string nombreIng, string numeroIng, string correoIng, string dirrecionIng, int cantSoliIng) : base(codigoIng, nombreIng, numeroIng)
        {
            Correo = correoIng;
            Direccion = dirrecionIng;
            CantSolicitudes += cantSoliIng;
        }
        public int CantSolicitudes
        {
            get { return cantSolicitudes; }
            set
            {
                if (cantSolicitudes > 0)
                {
                    cantSolicitudes += value;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: La cantidad de solicitudes no puede ser menor a cero.");
                    Console.ResetColor();
                }
            }
        }
        public string Direccion
        {
            get { return direccion; }
            set
            {
                if (value.Length <= 50)
                {
                    direccion = value;
                }
                else if (string.IsNullOrWhiteSpace(value))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: La dirección no puede estar vacia, intente de nuevo.");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: La dirección excede el largo dispoible, intente de nuevo.");
                    Console.ResetColor();
                }
            }
        }
        public string Correo
        {
            get { return correo; }
            set
            {
                if (value.Length <= 30 && value.Contains('@'))
                {
                    correo = value;
                }
                else if (string.IsNullOrWhiteSpace(value))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: El correo no pude estar vacio, intente de nuevo.");
                    Console.ResetColor();

                }
                else if (!value.Contains('@'))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: El correo no tiene @, intente de nuevo.");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: El correo excede el largo disponible, intente de nuevo");
                    Console.ResetColor();
                }
            }
        }
        public override void ConsultarInfo()
        {
            base.ConsultarInfo();
            Console.WriteLine("| Correo: " + correo);
            Console.WriteLine("| Dirección: " + direccion);
            Console.WriteLine("| Cantidad de solicitudes realizadas: " + cantSolicitudes);
        }
        public override void Actualizar(int opcion)
        {
            base.Actualizar(opcion);
            switch(opcion)
            {
                case 3:
                    Console.WriteLine("Ingrese el nuevo correo: ");
                    string nuevoCorreo = Console.ReadLine();
                    if (nuevoCorreo.Length <= 30 && nuevoCorreo.Contains('@'))
                    {
                        correo = nuevoCorreo;
                    }
                    else if (string.IsNullOrWhiteSpace(nuevoCorreo))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Error: El correo no pude estar vacio, intente de nuevo.");
                        Console.ResetColor();

                    }
                    else if (!nuevoCorreo.Contains('@'))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Error: El correo no tiene @, intente de nuevo.");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Error: El correo excede el largo disponible, intente de nuevo");
                        Console.ResetColor();
                    }
                    break;
                case 4:
                    Console.WriteLine("Ingrese la dirección actualizada: ");
                    string nuevaDireccion = Console.ReadLine();
                    if (nuevaDireccion.Length <= 50)
                    {
                        direccion = nuevaDireccion;
                    }
                    else if (string.IsNullOrWhiteSpace(nuevaDireccion))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Error: La dirección no puede estar vacia, intente de nuevo.");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Error: La dirección excede el largo dispoible, intente de nuevo.");
                        Console.ResetColor();
                    }
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: La opción ingresada no existe, intente de nuevo");
                    Console.ResetColor();
                    break;
            }
        }
    }
}
