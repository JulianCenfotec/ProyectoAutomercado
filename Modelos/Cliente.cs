using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ProyectoDiseñoSoft.Modelos
{
    public class Cliente : IObserver<String>
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? _id { get; set; }

        [BsonElement("Nombre")]
        public string Nombre { get; set; } = null!;

        [BsonElement("Telefono")]
        public int Telefono { get; set; }

        [BsonElement("Direccion")]
        public string Direccion { get; set; } = null!;

        [BsonElement("Email")]
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
