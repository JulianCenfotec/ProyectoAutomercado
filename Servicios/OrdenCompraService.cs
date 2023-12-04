using ProyectoDiseñoSoft.Modelos;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ProyectoDiseñoSoft.Fabrica;

namespace ProyectoDiseñoSoft.Servicios
{
    public class OrdenCompraService : IPersonaService<OrdenCompra>
    {
        private readonly IMongoCollection<OrdenCompra> _OrdenCompraCollection;

        public OrdenCompraService()
        {
            var settings = DatabaseSettings.Instance;

            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _OrdenCompraCollection = database.GetCollection<OrdenCompra>("OrdenCompra");
        }

        public async Task<List<OrdenCompra>> GetAsync() =>
            await _OrdenCompraCollection.Find(_ => true).ToListAsync();

        public async Task<OrdenCompra?> GetAsync(string id) =>
            await _OrdenCompraCollection.Find(x => x._id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(OrdenCompra newOrdenCompra) =>
            await _OrdenCompraCollection.InsertOneAsync(newOrdenCompra);

        public async Task UpdateAsync(string id, OrdenCompra updatedOrdenCompra) =>
            await _OrdenCompraCollection.ReplaceOneAsync(x => x._id == id, updatedOrdenCompra);

        public async Task RemoveAsync(string id) =>
            await _OrdenCompraCollection.DeleteOneAsync(x => x._id == id);
    }

}