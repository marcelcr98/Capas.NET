using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Pedido
    {
        public int IdPedido { get; set; }
        public string IdCliente { get; set; }

        public int IdEmpleado { get; set; }

        public DateTime FechaPedido { get; set; }

        public DateTime FechaEntrega { get; set; }

        public DateTime FechaEnvio { get; set; }

        public int FormaEnvio { get; set; }

        public decimal Cargo { get; set; }

        public string Destinario { get; set; }

        public string DireccionDestinario { get; set; }

        public string CiudadDestinario { get; set; }

        public string RegionDestinario { get; set; }

        public string CodPostalDestinario { get; set; }

        public string PaisDestinario { get; set; }

        public List<Pedido> Pedidos { get; set; }

        public DateTime FechaInicio { get; set; }

        public DateTime FechaFin { get; set; }


    }
}