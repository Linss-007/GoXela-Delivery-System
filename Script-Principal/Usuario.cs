using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Script_Principal
{
    class Usuario
    {
        private string nombre;
        private string numero;
        private string codigo;
        public Usuario(string codigoIng, string nombreIng, string numeroIng)
        {
            Codigo = codigoIng;
            Nombre = nombreIng;
            Numero = numeroIng;
        }
        public string Codigo
        {
            get { return codigo; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value) && value.Length <= 10)
                {
                    codigo = value;
                }
                else if(string.IsNullOrWhiteSpace(value))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: El código no puede ir vacío.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else 
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: Código inválido.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }
        public string Numero
        {
            get { return numero; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value) && value.Length == 8 && int.TryParse(value, out int num) == true)
                {
                    numero = value;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: El número de teléfono debe tener 8 dígitos.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }
        public string Nombre
        {
            get { return nombre; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value) && value.Length <= 50)
                {
                    nombre = value;
                }
                else if (string.IsNullOrWhiteSpace(value))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: El nombre no puede ir vacío.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: El nombre esta fuera del rango establecido.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }
        public virtual void ConsultarInfo()
        {
            Console.WriteLine("| Código: " + codigo);
            Console.WriteLine("| Nombre: " + nombre);
            Console.WriteLine("| Número de teléfono: " + numero);
        }
        public virtual void Actualizar(int opcion)
        {
            switch(opcion)
            {
                case 1:
                MalNombreNuevo:
                    Console.WriteLine("Ingrese el nombre nuevo: ");
                    string nombreNuevo = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(nombreNuevo) && nombreNuevo.Length <= 50)
                    {
                        nombre = nombreNuevo;
                    }
                    else if (string.IsNullOrWhiteSpace(nombreNuevo))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Error: El nombre no puede ir vacío.");
                        Console.ForegroundColor = ConsoleColor.White;
                        goto MalNombreNuevo;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Error: El nombre esta fuera del rango establecido.");
                        Console.ForegroundColor = ConsoleColor.White;
                        goto MalNombreNuevo;
                    }
                    break;
                case 2:
                MalNumeroNuevo:
                    Console.WriteLine("Ingrese el número nuevo: ");
                    string numeroNuevo = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(numeroNuevo) && numeroNuevo.Length == 8 && int.TryParse(numeroNuevo, out int num) == true)
                    {
                        numero = numeroNuevo;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Error: El número de teléfono debe tener 8 dígitos.");
                        Console.ForegroundColor = ConsoleColor.White;
                        goto MalNumeroNuevo;
                    }
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