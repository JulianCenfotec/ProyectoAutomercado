using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ProyectoDiseñoSoft.Modelos
{
    public class Compras : IObserver<String>
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? _id { get; set; }

        [BsonElement("Cliente_id")]
        public string cliente_id { get; set; }

        [BsonElement("Empleado_id")]
        public string empleado_id { get; set; }
        public List<ProductoCantidad> productos { get; set; }
        public int total { get; set; }
        public string fecha { get; set; }

        public void OnCompleted()
        {
            
        }

        public void OnError(Exception error)
        {
            
        }

        public void OnNext(string value)
        {
            
        }
        public class ProductoCantidad
        {
            public string producto_id { get; set; }
            public int cantidad { get; set; }
        }
    }

}
