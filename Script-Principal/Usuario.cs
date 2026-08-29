using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Script_Principal
{
    class Usuario
    {
        private string nombre;
        private string numero;
        private int codigo;
        public Usuario(int codigoIng, string nombreIng, string numeroIng)
        {
            Codigo = codigoIng;
            Nombre = nombreIng;
            Numero = numeroIng;
        }
        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        public string Numero
        {
            get { return numero; }
            set
            {
                if (value.Length <= 8 && int.TryParse(value, out int num) == true)
                {
                    numero = value;
                }
            }
        }

        public string Nombre
        {
            get { return nombre; }
            set
            {
                if (value.Length <= 10)
                {
                    nombre = value;
                }
            }
        }

    }
}
