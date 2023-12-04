using ProyectoDiseñoSoft.Modelos;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ProyectoDiseñoSoft.Fabrica;

namespace ProyectoDiseñoSoft.Servicios
{
    public class ClienteService : IPersonaService<Cliente>
    {
        private readonly IMongoCollection<Cliente> _ClienteCollection;

        public ClienteService()
        {
            var settings = DatabaseSettings.Instance;

            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _ClienteCollection = database.GetCollection<Cliente>("Cliente");
        }

        public async Task<List<Cliente>> GetAsync() =>
            await _ClienteCollection.Find(_ => true).ToListAsync();

        public async Task<Cliente?> GetAsync(string id) =>
            await _ClienteCollection.Find(x => x._id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Cliente newCliente) =>
            await _ClienteCollection.InsertOneAsync(newCliente);

        public async Task UpdateAsync(string id, Cliente updatedCliente) =>
            await _ClienteCollection.ReplaceOneAsync(x => x._id == id, updatedCliente);

        public async Task RemoveAsync(string id) =>
            await _ClienteCollection.DeleteOneAsync(x => x._id == id);
    }
}
