using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Script_Principal
{
    class Automovil : Vehículos
    {
        public Automovil(string codigoIng, string placaIng, string marcaIng, string modeloIng, EstadoVehiculo estadoIng)
             : base(codigoIng, placaIng, marcaIng, modeloIng, estadoIng)
        {
        }
        public override bool PuedeTransportar(Paquetes paquete)
        {
            return paquete.PesoPaquete <= CapacidadCarga;
        }
        public override double CalcularCostoOperativo()
        {
            return CostoOperativo * 1.5;
        }
        public override void MostrarInformacion()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("+===========+ Automóvil +===========+");
            base.MostrarInformacion();
            Console.WriteLine("+===================================+");
        }
    }
}