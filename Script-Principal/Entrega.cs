using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Script_Principal
{
    internal class Entrega
    {
        private string codigo;
        private DateTime fechaSolicitud;
        private Direccion direccionOrigen;
        private Direccion direccionDestino;
        private double distanciaEstimada;
        private TipoServicio tipoServicio;
        private EstadoEntrega estado;
        private double tarifaBase;
        private double recargos;
        private double descuentos;
        private double total;
        private Cliente cliente;
        private Paquetes paquete;
        private Repartidor repartidor;
        private Vehículos vehiculo;
        private List<Incidencia> incidencias;

        public Entrega(string codigoIng, Cliente clienteIng, Paquetes paqueteIng, Direccion direccionOrigenIng, Direccion direccionDestinoIng, double distanciaEstimadaIng, TipoServicio tipoServicioIng)
        {
            Codigo = codigoIng;
            FechaSolicitud = DateTime.Now;
            Cliente = clienteIng;
            Paquete = paqueteIng;
            DireccionOrigen = direccionOrigenIng;
            DireccionDestino = direccionDestinoIng;
            DistanciaEstimada = distanciaEstimadaIng;
            TipoServicio = tipoServicioIng;
            Estado = EstadoEntrega.Solicitada;
            incidencias = new List<Incidencia>();
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
                    Console.Write("Error: Código de entrega inválido.");
                    Console.ResetColor();
                    Console.ReadKey();
                    Console.WriteLine();
                }
            }
        }
        public DateTime FechaSolicitud
        {
            get { return fechaSolicitud; }
            set { fechaSolicitud = value; }
        }
        public Direccion DireccionOrigen
        {
            get { return direccionOrigen; }
            set
            {
                if (value.LongitudTotal() >= 15 && value.LongitudTotal() <= 50)
                {
                    direccionOrigen = value;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Error: Dirección de origen de la entrega inválida.");
                    Console.ResetColor();
                    Console.ReadKey();
                    Console.WriteLine();
                }
            }
        }
        public Direccion DireccionDestino
        {
            get { return direccionDestino; }
            set
            {
                if (value.LongitudTotal() >= 15 && value.LongitudTotal() <= 50)
                {
                    direccionDestino = value;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Error: Dirección de destino de la entrega inválida.");
                    Console.ResetColor();
                    Console.ReadKey();
                    Console.WriteLine();
                }
            }
        }
        public double DistanciaEstimada
        {
            get { return distanciaEstimada; }
            set
            {
                if (value > 0)
                {
                    distanciaEstimada = value;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Error: La distancia estimada debe ser mayor a cero.");
                    Console.ReadKey();
                    Console.WriteLine();
                    Console.ResetColor();
                }
            }
        }
        public TipoServicio TipoServicio
        {
            get { return tipoServicio; }
            set { tipoServicio = value; }
        }
        public EstadoEntrega Estado
        {
            get { return estado; }
            set { estado = value; }
        }
        public double TarifaBase
        {
            get { return tarifaBase; }
            set { tarifaBase = value; }
        }
        public double Recargos
        {
            get { return recargos; }
            set { recargos = value; }
        }
        public double Descuentos
        {
            get { return descuentos; }
            set { descuentos = value; }
        }
        public double Total
        {
            get { return total; }
            set
            {
                if (value >= 0)
                {
                    total = value;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Error: El total calculado no puede ser negativo, revise los recargos y descuentos aplicados.");
                    Console.ResetColor();
                    Console.ReadKey();
                    Console.WriteLine();
                }
            }
        }
        public Cliente Cliente
        {
            get { return cliente; }
            set
            {
                if (value != null)
                {
                    cliente = value;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Error: No hay cliente asignado a la entrega.");
                    Console.ResetColor();
                    Console.ReadKey();
                    Console.WriteLine();
                }
            }
        }
        public Paquetes Paquete
        {
            get { return paquete; }
            set
            {
                if (value != null)
                {
                    paquete = value;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Error: No hay un paquete asignado a la entrega.");
                    Console.ResetColor();
                    Console.ReadKey();
                    Console.WriteLine();
                }
            }
        }

        public Repartidor Repartidor
        {
            get { return repartidor; }
            set { repartidor = value; }
        }

        public Vehículos Vehiculo
        {
            get { return vehiculo; }
            set { vehiculo = value; }
        }

        public List<Incidencia> Incidencias
        {
            get { return incidencias; }
        }
        public bool AsignarRepartidorVehiculo(Repartidor repartidorIng, Vehículos vehiculoIng)
        {
            return AsignarRepartidorVehiculo(repartidorIng, vehiculoIng, 0);
        }

        public bool AsignarRepartidorVehiculo(Repartidor repartidorIng, Vehículos vehiculoIng, double descuentoIng)
        {
            if (repartidorIng == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Error: Repartidor ingresado no existe en el sistema.");
                Console.ResetColor();
                Console.ReadKey();
                Console.WriteLine();
                return false;
            }
            if (vehiculoIng == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Error: Vehículo ingresado no existe en el sistema.");
                Console.ResetColor();
                Console.ReadKey();
                Console.WriteLine();
                return false;
            }
            if (!repartidorIng.EstaDisponible())
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"Error: El repartidor no se encuentra disponible actualmente (estado actual: {repartidorIng.EstadoDisponibilidad}).");
                Console.ResetColor();
                Console.ReadKey();
                Console.WriteLine();
                return false;
            }
            if (vehiculoIng.Estado != EstadoVehiculo.Disponible)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"Error: El vehículo no se encuentra disponible actualmente (estado actual: {vehiculoIng.Estado}).");
                Console.ResetColor();
                Console.ReadKey();
                Console.WriteLine();
                return false;
            }
            if (!vehiculoIng.PuedeTransportar(Paquete))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Error: La cantidad ingresada excede el peso permitido en el vehículo, o el tipo de paquete no puede enviarse en este tipo de vehículo.");
                Console.ResetColor();
                Console.ReadKey();
                Console.WriteLine();
                return false;
            }
            Repartidor = repartidorIng;
            Vehiculo = vehiculoIng;
            Repartidor.EstadoDisponibilidad = EstadoRepartidor.Asignado;
            Vehiculo.Estado = EstadoVehiculo.Asignado;
            Descuentos = descuentoIng;
            Estado = EstadoEntrega.Asignada;

            CalcularTarifa();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Repartidor y vehículo asignados correctamente.");
            Console.ResetColor();
            return true;
        }
        public double CalcularTarifa()
        {
            if (Vehiculo == null || Paquete == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Error: No se puede calcular la tarifa sin un vehículo y un paquete asignados.");
                Console.ResetColor();
                Console.ReadKey();
                Console.WriteLine();
                return 0;
            }
            double costoBase = Vehiculo.CalcularCostoOperativo() * DistanciaEstimada;
            double tarifaPaquete = Paquete.CalcularTarifa(DistanciaEstimada);
            double recargoServicio;
            switch (TipoServicio)
            {
                case TipoServicio.Prioritario:
                    recargoServicio = costoBase * 0.25;
                    break;
                case TipoServicio.Urgente:
                    recargoServicio = costoBase * 0.50;
                    break;
                default:
                    recargoServicio = 0;
                    break;
            }
            TarifaBase = costoBase;
            Recargos = (tarifaPaquete - Paquete.ValorDeclarado) + recargoServicio;
            Total = TarifaBase + Recargos - Descuentos;
            return Total;
        }
        public bool CambiarEstado(EstadoEntrega nuevoEstado)
        {
            if (Estado == EstadoEntrega.Entregada || Estado == EstadoEntrega.Cancelada)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: Esta entrega ya ha sido entregada o cancelada, no es posible su modificación.");
                Console.ResetColor();
                return false;
            }
            bool ordenValido = (Estado, nuevoEstado) switch
            {
                (EstadoEntrega.Solicitada, EstadoEntrega.Asignada) => true,
                (EstadoEntrega.Asignada, EstadoEntrega.Recogida) => true,
                (EstadoEntrega.Recogida, EstadoEntrega.EnRuta) => true,
                (EstadoEntrega.EnRuta, EstadoEntrega.Entregada) => true,
                (_, EstadoEntrega.Cancelada) => true,
                (_, EstadoEntrega.Reprogramada) => true,
                (_, EstadoEntrega.Incidencia) => true,
                _ => false
            };
            if (!ordenValido)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Error: La entrega no puede ser marcada como entregada antes de enviarla o enviada después de entregarla.");
                Console.ResetColor();
                Console.ReadKey();
                Console.WriteLine();
                return false;
            }
            Estado = nuevoEstado;
            if (nuevoEstado == EstadoEntrega.Entregada)
            {
                if (Repartidor != null)
                {
                    Repartidor.EstadoDisponibilidad = EstadoRepartidor.Disponible;
                    Repartidor.CantEntregasRealizadas = 1;
                }
                if (Vehiculo != null)
                {
                    Vehiculo.Estado = EstadoVehiculo.Disponible;
                }
                if (Paquete != null)
                {
                    Paquete.Estado = EstadoPaquete.Entregado;
                }
                if (Cliente != null)
                {
                    Cliente.CantSolicitudes = 1;
                }
            }

            return true;
        }
        public void RegistrarIncidencia(Incidencia incidenciaIng)
        {
            incidencias.Add(incidenciaIng);
            CambiarEstado(EstadoEntrega.Incidencia);
        }

        public bool Cancelar()
        {
            bool resultado = CambiarEstado(EstadoEntrega.Cancelada);
            if (resultado)
            {
                if (Repartidor != null) Repartidor.EstadoDisponibilidad = EstadoRepartidor.Disponible;
                if (Vehiculo != null) Vehiculo.Estado = EstadoVehiculo.Disponible;
            }
            return resultado;
        }
        public bool Reprogramar(DateTime nuevaFecha)
        {
            if (nuevaFecha < DateTime.Now)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Error: La fecha de reprogramación no puede ser anterior a la fecha actual.");
                Console.ResetColor();
                Console.ReadKey();
                Console.WriteLine();
                return false;
            }
            bool resultado = CambiarEstado(EstadoEntrega.Reprogramada);
            if (resultado)
            {
                FechaSolicitud = nuevaFecha;
            }
            return resultado;
        }

        public void MostrarInformacion()
        {
            Console.WriteLine("+===========================================+");
            Console.WriteLine($"| Código de entrega: {Codigo}");
            Console.WriteLine($"| Fecha de solicitud: {FechaSolicitud}");
            Console.WriteLine($"| Cliente: {(Cliente != null ? Cliente.Nombre : "N/A")}");
            Console.WriteLine($"| Repartidor: {(Repartidor != null ? Repartidor.Nombre : "Sin asignar")}");
            Console.WriteLine($"| Vehículo: {(Vehiculo != null ? Vehiculo.Codigo : "Sin asignar")}");
            Console.WriteLine($"| Dirección de origen: {DireccionOrigen}");
            Console.WriteLine($"| Dirección de destino: {DireccionDestino}");
            Console.WriteLine($"| Distancia estimada: {DistanciaEstimada} km");
            Console.WriteLine($"| Tipo de servicio: {TipoServicio}");
            Console.WriteLine($"| Estado: {Estado}");
            Console.WriteLine($"| Tarifa base: {TarifaBase}");
            Console.WriteLine($"| Recargos: {Recargos}");
            Console.WriteLine($"| Descuentos: {Descuentos}");
            Console.WriteLine($"| Total: {Total}");
            Console.WriteLine($"| Incidencias registradas: {Incidencias.Count}");
            Console.WriteLine("+===========================================+");
        }
    }
}