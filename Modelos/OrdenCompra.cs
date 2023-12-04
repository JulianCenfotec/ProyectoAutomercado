using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using static ProyectoDiseñoSoft.Modelos.Compras;

namespace ProyectoDiseñoSoft.Modelos
{
    public class OrdenCompra
    {
        [BsonId]
        [BsonElement("_id")]
        public string _id { get; set; }
        [BsonElement("productos")]
        public List<ProductoCantidad> productos { get; set; }
        [BsonElement("fecha")]
        public string fecha { get; set; }
    }

}
