using Microsoft.AspNetCore.Mvc;
using ProyectoDiseñoSoft.Modelos;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProyectoDiseñoSoft.Fabrica;

namespace ProyectoDiseñoSoft.Servicios
{
    public class FacturacionService : IPersonaService<Facturacion>
    {
        private readonly IMongoCollection<Facturacion>_FacturacionCollection;

        public FacturacionService()
        {
            var settings = DatabaseSettings.Instance;

            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
           _FacturacionCollection = database.GetCollection<Facturacion>("Facturacion");
        }

        public async Task<List<Facturacion>> GetAsync() =>
            await _FacturacionCollection.Find(_ => true).ToListAsync();

        public async Task<Facturacion?> GetAsync(string Codigo) =>
            await _FacturacionCollection.Find(x => x._id == Codigo).FirstOrDefaultAsync();
        public async Task CreateAsync(Facturacion newFacturacion)
        {
            await _FacturacionCollection.InsertOneAsync(newFacturacion);
            newFacturacion.NotificarObservadores(newFacturacion.cliente_id);
        }
        public async Task UpdateAsync(string id, Facturacion updatedFacturacion) =>
            await _FacturacionCollection.ReplaceOneAsync(x => x._id == id, updatedFacturacion);

        public async Task RemoveAsync(string id) =>
            await _FacturacionCollection.DeleteOneAsync(x => x._id == id);
    }
    
}