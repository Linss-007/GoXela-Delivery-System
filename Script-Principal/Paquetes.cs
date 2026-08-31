using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Script_Principal
{
    class Paquetes
    {
        private string codigo;
        private string descripcion;
        private double pesoPaquete;
        private double valorDeclarado;
        private string direccionOrigen;
        private string direccionDestino;
        private string estado;
        public Paquetes(string codigoIng, string descripIng, double pesoIng, double valorIng, string direcOrigenIng, string direcDestinoIng, string estadoIng)
        {
            Codigo = codigoIng;
            Descripcion = descripIng;
            PesoPaquete = pesoIng;
            ValorDeclarado = valorIng;
            DireccionOrigen = direcOrigenIng;
            DireccionDestino = direcDestinoIng;
            Estado = estadoIng;
        }
        public string Estado
        {
            get { return estado; }
            set
            {
                if (value == "recibido" || value == "empacado" || value == "enviado" || value == "entregado")
                {
                    estado = value;
                }
                else
                {
                    Console.WriteLine("Error: El estado no existe.");
                }
            }
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
                    Console.WriteLine("Error: La dirección de destino no puede ir vacío.");
                }
                else
                {
                    Console.WriteLine("Error: Dirección de destino inválida.");
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
                    Console.WriteLine("Error: La dirección de origen no puede ir vacía.");
                }
                else
                {
                    Console.WriteLine("Error: La dirección de origen inválida.");
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
                    Console.WriteLine("Error: El valor esta fuera de rango.");
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
                    Console.WriteLine("Error: El peso esta fuera de rango.");
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
                    Console.WriteLine("Error: La descripción no puede estar vacía.");
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
                    Console.WriteLine("Error: Código inválido.");
                }
            }
        }
    }
}