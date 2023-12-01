using ProyectoDiseñoSoft.Modelos;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ProyectoDiseñoSoft.Servicios
{
    public class OrdenCompraService
    {
        private readonly IMongoCollection<OrdenCompra> _OrdenCompraCollection;

       /* public UserService(
            IOptions<UniversidadDatabaseSettings> universidadDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                universidadDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                universidadDatabaseSettings.Value.DatabaseName);

            _OrdenCompraCollection = mongoDatabase.GetCollection<User>(
                universidadDatabaseSettings.Value.CollectionName);
        }
       */
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