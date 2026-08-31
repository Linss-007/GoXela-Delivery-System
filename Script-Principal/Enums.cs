using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Script_Principal
{
    public enum EstadoRepartidor
    {
        Disponible,
        Asignado,
        FueraDeServicio
    }
    public enum EstadoVehiculo
    {
        Disponible,
        Asignado,
        EnMantenimiento
    }

    public enum EstadoPaquete
    {
        Registrado,
        Asignado,
        EnTransito,
        Entregado
    }
    public enum EstadoEntrega
    {
        Solicitada,
        Asignada,
        Recogida,
        EnRuta,
        Entregada,
        Cancelada,
        Reprogramada,
        Incidencia
    }
    public enum TipoServicio
    {
        Normal,
        Prioritario,
        Urgente
    }
    public enum TipoIncidencia
    {
        ClienteAusente,
        DireccionIncorrecta,
        PaqueteDañado,
        VehiculoAveriado,
        Retraso,
        ProblemasClimaticos,
        RechazoRecepcion
    }
}