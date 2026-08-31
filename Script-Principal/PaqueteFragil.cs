using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Script_Principal
{
	internal class PaqueteFragil : Paquetes
	{
		private bool RequiereManejoEspecial;

		public bool requiereManejoEspecial
		{
			get { return RequiereManejoEspecial; }
			set { RequiereManejoEspecial = value; }
		}
		public PaqueteFragil(string codigoIng, string descripIng, double pesoIng, double valorIng, string direcOrigenIng, string direcDestinoIng, bool requiereManejoEspecial) : base(codigoIng, descripIng, pesoIng, valorIng, direcOrigenIng, direcDestinoIng)
		{
			RequiereManejoEspecial = requiereManejoEspecial;
		}
	}
}
