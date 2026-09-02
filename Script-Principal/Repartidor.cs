using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Script_Principal
{
    internal class Repartidor : Usuario
    {
        private TipoLicencia licencia;
        private string numLicencia;
        private EstadoRepartidor estado;
        private int cantEntregas;
        private double califPromedio;
        private double califViaje;
        public Repartidor(string codigoIng, string nombreIng, string numeroIng, TipoLicencia licenciaIng, string numLicenciaIng, EstadoRepartidor estadoIng, int cantEntregasIng, double califViajeIng) : base(codigoIng, nombreIng, numeroIng)
        {
            Licencia = licenciaIng;
            NumLicencia = numLicenciaIng;
            Estado = estadoIng;
            CantEntregas += cantEntregasIng;
            CalifViaje = califViajeIng;
        }
        public double CalifViaje
        {
            get { return califViaje; }
            set
            {
                if (value < 0 || value > 5)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: La calificación ingresada esta fuera del rango, intente de nuevo");
                    Console.ResetColor();
                }
                else
                {
                    califViaje = value;
                }
            }
        }
        public double CalifPromedio
        {
            get { return califPromedio; }
            set { califPromedio = value; }
        }
        public int CantEntregas
        {
            get { return cantEntregas; }
            set
            {
                if (value < 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: La cantidad de entregas no puede ser negativa");
                    Console.ResetColor();
                }
                else
                {
                    cantEntregas += value;
                }
            }
        }
        public EstadoRepartidor Estado
        {
            get { return estado; }
            set { estado = value; }
        }
        public string NumLicencia
        {
            get { return numLicencia; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: El numero de licencia no puede ser estar vacio, intente de nuevo");
                    Console.ResetColor();
                }
                else if (value.Length != 13)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: El numero de licencia no cumple con el rango, intente de nuevo");
                    Console.ResetColor();
                }
                else if (!int.TryParse(value, out int num))
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: El numero debe contener unicamente numeros no letras, intente de nuevo");
                    Console.ResetColor();
                }
                else
                {
                    numLicencia = Convert.ToString(num);
                }
            }
        }
        public TipoLicencia Licencia
        {
            get { return licencia; }
            set { licencia = value; }
        }
        public override void Actualizar(int opcion)
        {
            base.Actualizar(opcion);
            switch(opcion)
            {
                case 3:
                    Console.WriteLine();
                    break;
                case 4:
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: La opción ingresada no existe, intente de nuevo");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }
        }
    }
}
