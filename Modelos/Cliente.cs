using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ProyectoDiseñoSoft.Modelos
{
    public class Cliente : IObserver<String>
    {
        [BsonId]
        [BsonElement("_id")]
        public string? _id { get; set; }

        [BsonElement("nombre")]
        public string Nombre { get; set; } = null!;

        [BsonElement("cedula")]
        public int Cedula { get; set; }

       
        [BsonElement("telefono")]
        public int Telefono { get; set; }

        [BsonElement("direccion")]
        public string Direccion { get; set; } = null!;

        [BsonElement("email")]
        public string Email { get; set; }


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
