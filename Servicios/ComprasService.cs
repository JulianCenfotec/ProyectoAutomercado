using ProyectoDiseñoSoft.Modelos;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ProyectoDiseñoSoft.Servicios
{
    public class ComprasService  
    {
        private readonly IMongoCollection<Compras> _ComprasCollection;

        public ComprasService()
        {
            var settings = DatabaseSettings.Instance;

            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _ComprasCollection = database.GetCollection<Compras>("Compras");
        }

        public async Task<List<Compras>> GetAsync() =>
            await _ComprasCollection.Find(_ => true).ToListAsync();

        public async Task<Compras?> GetAsync(string id) =>
            await _ComprasCollection.Find(x => x._id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Compras newCompra) =>
            await _ComprasCollection.InsertOneAsync(newCompra);

        public async Task UpdateAsync(string id, Compras updatedCompra) =>
            await _ComprasCollection.ReplaceOneAsync(x => x._id == id, updatedCompra);

        public async Task RemoveAsync(string id) =>
            await _ComprasCollection.DeleteOneAsync(x => x._id == id);
    }
}
