using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Script_Principal
{
    class Motocicleta : Vehículos
    {
        public Motocicleta(string codigoIng, string placaIng, string marcaIng, string modeloIng, double capacidadIng, EstadoVehiculo estadoIng, double costoOpIng)
            : base(codigoIng, placaIng, marcaIng, modeloIng, capacidadIng, estadoIng, costoOpIng)
        {
        }

        public override bool PuedeTransportar(Paquetes paquete)
        {
            return paquete.PesoPaquete <= CapacidadCarga;
        }

        public override double CalcularCostoOperativo()
        {
            return CostoOperativo;
        }

        public override void MostrarInformacion()
        {
            Console.WriteLine("+============+ Motocicleta +============+");
            base.MostrarInformacion();
            Console.WriteLine("+=======================================+");
        }
    }
}