using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ProyectoDiseñoSoft.Modelos
{
    public class Producto : IObserver<String>
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public int precio { get; set; }
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
