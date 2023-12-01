using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using static ProyectoDiseñoSoft.Modelos.Compras;

namespace ProyectoDiseñoSoft.Modelos
{
    public class Facturacion
    {
        public string _id { get; set; }
        public string cliente_id { get; set; }
        public string empleado_id { get; set; }
        public List<ProductoCantidad> productos { get; set; }
        public decimal subtotal { get; set; }
        public decimal impuestos { get; set; }
        public decimal total { get; set; }
        public string fecha { get; set; }

        public void NotificarObservadores(string cliente_id)
        {
            throw new NotImplementedException();
        }
    }
}
