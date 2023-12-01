using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using static ProyectoDiseñoSoft.Modelos.Compras;

namespace ProyectoDiseñoSoft.Modelos
{
    public class OrdenCompra
    {
        public string _id { get; set; }
        public List<ProductoCantidad> productos { get; set; }
        public string fecha { get; set; }
    }

}
