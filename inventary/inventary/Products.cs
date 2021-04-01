using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inventary
{
    public class Products
    {      

        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Codigo { get; set; }
        public string Marca { get; set; }
        public string Categoria { get; set; }
        public string Unidades { get; set; }
        public string Stock { get; set; }
        public string Packing { get; set; }
        public string Bodega { get; set; }
        public string id_bodega_product { get; set; }
    }
}
