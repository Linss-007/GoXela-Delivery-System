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
                    Console.WriteLine("Error: El código no puede ir vacío.");
                }
                else {
                    Console.WriteLine("Error: Código inválido.");
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
                    Console.WriteLine("Error: El número de teléfono debe tener 8 dígitos.");
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
                    Console.WriteLine("Error: El nombre no puede ir vacío.");
                }
                else
                {
                    Console.WriteLine("Error: El nombre esta fuera del rango establecido.");
                }
            }
        }
    }
}