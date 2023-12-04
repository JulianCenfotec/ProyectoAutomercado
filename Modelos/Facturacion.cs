using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using static ProyectoDiseñoSoft.Modelos.Compras;

namespace ProyectoDiseñoSoft.Modelos
{
    public class Facturacion
    {
        [BsonId] 
        [BsonElement("_id")]
        public string _id { get; set; }

        [BsonElement("cliente_id")]
        public string cliente_id { get; set; }

        [BsonElement("empleado_id")]
        public string empleado_id { get; set; }

        [BsonElement("productos")]
        public List<ProductoCantidad> productos { get; set; }

        [BsonElement("subtotal")]
        public decimal subtotal { get; set; }
        [BsonElement("impuestos")]
        public decimal impuestos { get; set; }
        [BsonElement("total")]
        public decimal total { get; set; }
        [BsonElement("fecha")]
        public string fecha { get; set; }

        public void NotificarObservadores(string cliente_id)
        {
            throw new NotImplementedException();
        }
    }
}
