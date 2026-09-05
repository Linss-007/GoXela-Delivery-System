using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Script_Principal
{
    public struct Direccion
    {
        public string Calle;
        public string Referencia;

        public Direccion(string calle, string referencia)
        {
            Calle = calle;
            Referencia = referencia;
        }
        public override string ToString()
        {
            return $"{Calle} ({Referencia})";
        }
        public int LongitudTotal()
        {
            return (Calle ?? "").Length + (Referencia ?? "").Length;
        }
    }
}