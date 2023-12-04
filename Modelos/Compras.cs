using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ProyectoDiseñoSoft.Modelos
{
    public class Compras : IObserver<String>
    {
        [BsonId]
        [BsonElement ("_id")]
        public string? _id { get; set; }

        [BsonElement("cliente_id")]
        public string cliente_id { get; set; }

        [BsonElement("empleado_id")]
        public string empleado_id { get; set; }

        
        public List<ProductoCantidad> productos { get; set; }

        [BsonElement("total")]
        public int total { get; set; }

        [BsonElement("fecha")]
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
            [BsonElement("producto_id")]
            public string producto_id { get; set; }

            [BsonElement("cantidad")]
            public int cantidad { get; set; }
        }
    }

}
