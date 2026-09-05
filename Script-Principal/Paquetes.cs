using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Script_Principal
{
    abstract class Paquetes
    {
        private string codigo;
        private string descripcion;
        private double pesoPaquete;
        private double valorDeclarado;
        private string direccionOrigen;
        private string direccionDestino;
        private EstadoPaquete estado;
        public Paquetes(string codigoIng, string descripIng, string direcOrigenIng, string direcDestinoIng)
        {
            Codigo = codigoIng;
            Descripcion = descripIng;
            DireccionOrigen = direcOrigenIng;
            DireccionDestino = direcDestinoIng;
        }
        public EstadoPaquete Estado
        {
            get { return estado; }
            set { estado = value; }
        }
        public string DireccionDestino
        {
            get { return direccionDestino; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value) && value.Length >= 15 && value.Length <= 50)
                {
                    direccionDestino = value;
                }
                else if (string.IsNullOrWhiteSpace(value))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: La dirección de destino no puede ir vacío.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: Dirección de destino inválida.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }
        public string DireccionOrigen
        {
            get { return direccionOrigen; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value) && value.Length >= 15 && value.Length <= 50)
                {
                    direccionOrigen = value;
                }
                else if (string.IsNullOrWhiteSpace(value))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: La dirección de origen no puede ir vacía.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: La dirección de origen inválida.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }
        public double ValorDeclarado
        {
            get { return valorDeclarado; }
            set
            {
                if (value > 0)
                {
                    valorDeclarado = value;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: El valor esta fuera de rango.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }
        public double PesoPaquete
        {
            get { return pesoPaquete; }
            set
            {
                if (value > 0)
                {
                    pesoPaquete = value;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: El peso esta fuera de rango.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }
        public string Descripcion
        {
            get { return descripcion; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    descripcion = value;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: La descripción no puede estar vacía.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
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
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: Código inválido.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }

        public abstract double CalcularTarifa(double distancia);
        public virtual void MostrarInformacion()
        {
            Console.WriteLine($"| Código: {Codigo}.");
            Console.WriteLine($"| Descripción: {Descripcion}.");
            Console.WriteLine($"| Peso del paquete: {PesoPaquete} kg.");
            Console.WriteLine($"| Valor declarado: {ValorDeclarado}.");
            Console.WriteLine($"| Dirección de Origen: {DireccionOrigen}.");
            Console.WriteLine($"| Dirección de Destino: {DireccionDestino}.");
            Console.WriteLine($"| Estado: {Estado}.");
        }
    }
}