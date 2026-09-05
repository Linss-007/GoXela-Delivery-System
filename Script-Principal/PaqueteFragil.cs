using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Script_Principal
{
    internal class PaqueteFragil : Paquetes
    {
        private bool requiereManejoEspecial;
        public bool RequiereManejoEspecial
        {
            get { return requiereManejoEspecial; }
            set { requiereManejoEspecial = value; }
        }
        public PaqueteFragil(string codigoIng, string descripIng, string direcOrigenIng, string direcDestinoIng)
            : base(codigoIng, descripIng, direcOrigenIng, direcDestinoIng)
        {

        }
        public override double CalcularTarifa(double distancia)
        {
            double tarifaBase = ValorDeclarado + (distancia * 10) + (PesoPaquete * 15);
            double recargo = RequiereManejoEspecial ? tarifaBase * 0.20 : 0;
            return tarifaBase + recargo;
        }
        public override void MostrarInformacion()
        {
            Console.WriteLine("+==============+ Paquete Frágil +==============+");
            base.MostrarInformacion();
            Console.WriteLine($"| Requiere manejo especial: {RequiereManejoEspecial}.");
            Console.WriteLine("+==============================================+");
        }
    }
}