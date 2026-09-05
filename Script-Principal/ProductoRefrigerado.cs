using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Script_Principal
{
    internal class ProductoRefrigerado : Paquetes
    {
        private double temperaturaRequerida;
        public double TemperaturaRequerida
        {
            get { return temperaturaRequerida; }
            set {
                if (value >= -10 && value <= 10)
                {
                    temperaturaRequerida = value;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: La temperatura requerida está fuera de rango.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }
        public ProductoRefrigerado(string codigoIng, string descripIng, string direcOrigenIng, string direcDestinoIng)
            : base(codigoIng, descripIng, pesoIng, valorIng, direcOrigenIng, direcDestinoIng)
        {

        }
        public override double CalcularTarifa(double distancia)
        {
            double tarifaBase = ValorDeclarado + (distancia * 10) + (PesoPaquete * 15);
            double recargo = tarifaBase * 0.30;
            return tarifaBase + recargo;
        }
        public override void MostrarInformacion()
        {
            Console.WriteLine("+==============+ Paquete Refrigerado +==============+");
            base.MostrarInformacion();
            Console.WriteLine($"| Temperatura requerida: {TemperaturaRequerida}°C.");
            Console.WriteLine("+===================================================+");
        }
    }
}