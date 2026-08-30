using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Script_Principal
{
    class Vehículos
    {
        private string codigo;
        private string placa;
        private string marca;
        private string modelo;
        private double capacidadCarga;
        private string estado;
        private double costoOperativo;
        public Vehículos(string codigoIng, string placaIng, string marcaIng, string modeloIng, double capacidadIng, string estadoIng, double CostoOpIng)
        {
            Codigo = codigoIng;
            Placa = placaIng;
            Marca = marcaIng;
            Modelo = modeloIng;
            CapacidadCarga = capacidadIng;
            Estado = estadoIng;
            CostoOperativo = CostoOpIng;
        }
        public double CostoOperativo
        {
            get { return costoOperativo; }
            set
            {
                if (value > 0)
                {
                    costoOperativo = value;
                }
                else
                {
                    Console.WriteLine("Costo operativo fuera de rango");
                }
            }
        }

        public string Estado
        {
            get { return estado; }
            set
            {
                if (value == "disponible" || value == "asignado" || value == "mantenimiento")
                {
                    estado = value;
                }
                else
                {
                    Console.WriteLine("El estado no existe");
                }
            }
        }

        public double CapacidadCarga
        {
            get { return capacidadCarga; }
            set
            {
                if (value > 0)
                {
                    capacidadCarga = value;
                }
                else
                {
                    Console.WriteLine("Capacidad de carga fuera de rango");
                }
            }
        }

        public string Modelo
        {
            get { return modelo; }
            set { modelo = value; }
        }

        public string Marca
        {
            get { return marca; }
            set { marca = value; }
        }

        public string Placa
        {
            get { return placa; }
            set
            {
                if (value.Length == 7)
                {
                    placa = value;
                }
                else
                {
                    Console.WriteLine("La placa ingresada no es válida");
                }
            }
        }

        public string Codigo
        {
            get { return codigo; }
            set
            {
                if (value.Length <= 10)
                {
                    codigo = value;
                }
            }
        }

    }
}
