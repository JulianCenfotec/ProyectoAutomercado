using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ProyectoDiseñoSoft.Modelos
{
    public class Producto : IObserver<String>
    {
        [BsonId]
        [BsonElement("_id")]
        public string _id { get; set; }
        [BsonElement("nombre")]
        public string nombre { get; set; }
        [BsonElement("descripcion")]
        public string descripcion { get; set; }
        [BsonElement("precio")]
        public int precio { get; set; }
        [BsonElement("cantidad")]
        public int cantidad { get; set; }

        public void OnCompleted()
        {
            
        }

        public void OnError(Exception error)
        {
            
        }

        public void OnNext(string value)
        {
           
          
        }
    }

}
