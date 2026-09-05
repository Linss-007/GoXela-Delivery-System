using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Script_Principal
{
    internal class Documento : Paquetes
    {
        public Documento(string codigoIng, string descripIng, string direcOrigenIng, string direcDestinoIng)
            : base(codigoIng, descripIng, direcOrigenIng, direcDestinoIng)
        {
        }
        public override double CalcularTarifa(double distancia)
        {
            return ValorDeclarado + (distancia * 10) + (PesoPaquete * 15);
        }
        public override void MostrarInformacion()
        {
            Console.WriteLine("+==============+ Documento +==============+");
            base.MostrarInformacion();
            Console.WriteLine("+========================================+");
        }
    }
}