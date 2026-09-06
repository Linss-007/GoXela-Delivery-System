using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Script_Principal
{
    public enum EstadoIncidencia
    {
        Abierta,
        Resuelta
    }
    internal class Incidencia
    {
        private string codigo;
        private TipoIncidencia tipo;
        private string descripcion;
        private DateTime fecha;
        private EstadoIncidencia estado;
        private string accionTomada;

        public Incidencia(string codigoIng, TipoIncidencia tipoIng, string descripcionIng, string accionTomadaIng)
        {
            Codigo = codigoIng;
            Tipo = tipoIng;
            Descripcion = descripcionIng;
            Fecha = DateTime.Now;
            Estado = EstadoIncidencia.Abierta;
            AccionTomada = accionTomadaIng;
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
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Error: Código de incidencia inválido.");
                    Console.ResetColor();
                    Console.ReadLine();
                    Console.WriteLine();
                }
            }
        }
        public TipoIncidencia Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }
        public string Descripcion
        {
            get { return descripcion; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    descripcion = value;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Error: La descripción no puede estar vacía.");
                    Console.ResetColor();
                    Console.ReadLine();
                    Console.WriteLine();
                }
            }
        }
        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }
        public EstadoIncidencia Estado
        {
            get { return estado; }
            set { estado = value; }
        }
        public string AccionTomada
        {
            get { return accionTomada; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    accionTomada = value;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Error: La acción tomada no puede estar vacía.");
                    Console.ResetColor();
                    Console.ReadLine();
                    Console.WriteLine();
                }
            }
        }
        public void Resolver()
        {
            Estado = EstadoIncidencia.Resuelta;
        }
        public void MostrarInformacion()
        {
            Console.WriteLine("+===========================================+");
            Console.WriteLine($"| Código: {Codigo}");
            Console.WriteLine($"| Tipo: {Tipo}");
            Console.WriteLine($"| Descripción: {Descripcion}");
            Console.WriteLine($"| Fecha: {Fecha}");
            Console.WriteLine($"| Estado: {Estado}");
            Console.WriteLine($"| Acción tomada: {AccionTomada}");
            Console.WriteLine("+===========================================+");
        }
    }
}