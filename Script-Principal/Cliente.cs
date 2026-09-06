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
        public Cliente(string codigoIng, string nombreIng, string numeroIng, string correoIng, string dirrecionIng) : base(codigoIng, nombreIng, numeroIng)
        {
            Correo = correoIng;
            Direccion = dirrecionIng;
        }
        public int CantSolicitudes
        {
            get { return cantSolicitudes; }
            set
            {
                if (value >= 0)
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

                if (string.IsNullOrWhiteSpace(value))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: La dirección no puede estar vacia, intente de nuevo.");
                    Console.ResetColor();
                }
                else if (value.Length > 50)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: La dirección excede el largo dispoible, intente de nuevo.");
                    Console.ResetColor();
                }
                else
                {
                    direccion = value;
                }
            }
        }
        public string Correo
        {
            get { return correo; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
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
                else if (value.Length > 30)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: El correo excede el largo disponible, intente de nuevo");
                    Console.ResetColor();
                }
                else
                {
                    correo = value;
                }
            }
        }
        public override void ConsultarInfo()
        {
            base.ConsultarInfo();
            Console.WriteLine($"| Correo: {Correo}");
            Console.WriteLine($"| Dirección: {Direccion}");
            Console.WriteLine($"| Cantidad de solicitudes realizadas: {CantSolicitudes}");
        }
        public override void Actualizar(int opcion)
        {
            base.Actualizar(opcion);
            switch (opcion)
            {
                case 3:
                MalCorreo:
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Ingrese el nuevo correo: ");
                    string nuevoCorreo = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(nuevoCorreo))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Error: El correo no pude estar vacio, intente de nuevo.");
                        Console.ResetColor();
                        goto MalCorreo;

                    }
                    else if (!nuevoCorreo.Contains('@'))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Error: El correo no tiene @, intente de nuevo.");
                        Console.ResetColor();
                        goto MalCorreo;
                    }
                    else if (nuevoCorreo.Length > 30)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Error: El correo excede el largo disponible, intente de nuevo");
                        Console.ResetColor();
                        goto MalCorreo;
                    }
                    else
                    {
                        Correo = nuevoCorreo;
                    }
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Correo del cliente actualizado");
                    Console.ResetColor();
                    Console.WriteLine("Presione cualquier tecla para continuar.");
                    Console.ReadKey();
                    break;
                case 4:
                MalDireccion:
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Ingrese la dirección actualizada: ");
                    string nuevaDireccion = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(nuevaDireccion))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Error: La dirección no puede estar vacia, intente de nuevo.");
                        Console.ResetColor();
                        goto MalDireccion;
                    }
                    else if (nuevaDireccion.Length > 50)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Error: La dirección excede el largo dispoible, intente de nuevo.");
                        Console.ResetColor();
                        goto MalDireccion;
                    }
                    else
                    {
                        Direccion = nuevaDireccion;
                    }
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Dirección del cliente actualizada");
                    Console.ResetColor();
                    Console.WriteLine("Presione cualquier tecla para continuar.");
                    Console.ReadKey();
                    break;
            }
        }
    }
}