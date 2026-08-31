using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Script_Principal
{
    abstract class Vehículos
    {
        private string codigo;
        private string placa;
        private string marca;
        private string modelo;
        private double capacidadCarga;
        private EstadoVehiculo estado;
        private double costoOperativo;
        public Vehículos(string codigoIng, string placaIng, string marcaIng, string modeloIng, double capacidadIng, EstadoVehiculo estadoIng, double CostoOpIng)
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
                    Console.WriteLine("Error: Costo operativo fuera de rango.");
                }
            }
        }
        public EstadoVehiculo Estado
        {
            get { return estado; }
            set { estado = value; }
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
                    Console.WriteLine("Error: Capacidad de carga fuera de rango.");
                }
            }
        }
        public string Modelo
        {
            get { return modelo; }
            set {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    modelo = value;
                }
                else
                {
                    Console.WriteLine("Error: Por favor, ingrese un modelo correcto.");
                }
            }
        }
        public string Marca
        {
            get { return marca; }
            set {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    marca = value;
                }
                else
                {
                    Console.WriteLine("Error: Por favor, ingrese una marcar correcta.");
                }
            }
        }
        public string Placa
        {
            get { return placa; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value) && value.Length == 7)
                {
                    placa = value;
                }
                else
                {
                    Console.WriteLine("Error: La placa ingresada no es válida.");
                }
            }
        }
        public string Codigo
        {
            get { return codigo; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value) && value.Length <= 10)
                {
                    codigo = value;
                }
                else
                {
                    Console.WriteLine("Error: Codigo inválido.");
                }
            }
        }
        public abstract bool PuedeTransportar(Paquetes paquete);
        public abstract double CalcularCostoOperativo();
        public virtual void MostrarInformacion()
        {
            Console.WriteLine($"| Código: {Codigo}");
            Console.WriteLine($"| Placa: {Placa}");
            Console.WriteLine($"| Marca: {Marca}");
            Console.WriteLine($"| Modelo: {Modelo}");
            Console.WriteLine($"| Capacidad: {CapacidadCarga} kg");
            Console.WriteLine($"| Estado: {Estado}");
        }
    }
}