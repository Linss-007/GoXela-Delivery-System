using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Script_Principal
{
    class Bicicleta : Vehículos
    {
        private double capacidadLimite;
        public Bicicleta(string codigoIng, string placaIng, string marcaIng, string modeloIng, double capacidadIng, EstadoVehiculo estadoIng, double costoOpIng, double capacidadLimiteIng)
            : base(codigoIng, placaIng, marcaIng, modeloIng, capacidadIng, estadoIng, costoOpIng)
        {
            CapacidadLimite = capacidadLimiteIng;
        }
        public double CapacidadLimite
        {
            get { return capacidadLimite; }
            set
            {
                if (value > 0)
                {
                    capacidadLimite = value;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: Capacidad límite fuera de rango.");
                }
            }
        }
        public override bool PuedeTransportar(Paquetes paquete)
        {
            return paquete.PesoPaquete <= CapacidadCarga && paquete.PesoPaquete <= CapacidadLimite;
        }
        public override double CalcularCostoOperativo()
        {
            return CostoOperativo * 0.2;
        }

        public override void MostrarInformacion()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("+==============+ Bicicleta +==============+");
            base.MostrarInformacion();
            Console.WriteLine($"Capacidad límite propia: {CapacidadLimite} kg");
            Console.WriteLine("+=========================================+");
        }
    }
}