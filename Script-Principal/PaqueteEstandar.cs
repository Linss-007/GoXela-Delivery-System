using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Script_Principal
{
    internal class PaqueteEstandar:Paquetes
    {
        public PaqueteEstandar(string codigoIng, string descripIng, string direcOrigenIng, string direcDestinoIng) :base(codigoIng, descripIng,direcOrigenIng, direcDestinoIng)
        {

        }
        public override double CalcularTarifa(double distancia)
        {
            double tarifaBase = ValorDeclarado + (distancia * 10) + (PesoPaquete * 15);
            double recargo = 5;
            return tarifaBase + recargo;
        }
        public override void MostrarInformacion()
        {
            Console.WriteLine("+==============+ Paquete Estandar +==============+");
            base.MostrarInformacion();
            Console.WriteLine("+===================================================+");
        }
    }
}
