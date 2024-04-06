using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio04
{
    public class Producto
    {
        public int idproducto { get; set; }
        public string nombreProducto { get; set; }
        public string cantidadPorUnidad { get; set; }
        public decimal precioUnidad { get; set; }
        public int unidadesEnExistencia { get; set; }
        public int unidadesEnPedido { get; set; }
        public int nivelNuevoPedido { get; set; }
        public int suspendido { get; set; }
        public string categoriaProducto { get; set; }
    }
}
