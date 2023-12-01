using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ProyectoDiseñoSoft.Modelos
{
    public class Empleados
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? _id { get; set; }

        [BsonElement("nombre")]
        public string nombre { get; set; }
        [BsonElement("puesto")]
        public string puesto { get; set; }
        [BsonElement("telefono")]
        public string telefono { get; set; }
        [BsonElement("email")]
        public string email { get; set; }
    }
}
