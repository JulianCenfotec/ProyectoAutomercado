using ProyectoDiseñoSoft.Modelos;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ProyectoDiseñoSoft.Fabrica;

namespace ProyectoDiseñoSoft.Servicios
{
    public class ProductoService : IPersonaService<Producto>
    {
        private readonly IMongoCollection<Producto> _ProductoCollection;

        public ProductoService()
        {
            var settings = DatabaseSettings.Instance;

            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _ProductoCollection = database.GetCollection<Producto>("Producto");
        }

        public async Task<List<Producto>> GetAsync() =>
            await _ProductoCollection.Find(_ => true).ToListAsync();

        public async Task<Producto?> GetAsync(string id) =>
            await _ProductoCollection.Find(x => x._id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Producto newProducto) =>
            await _ProductoCollection.InsertOneAsync(newProducto);

        public async Task UpdateAsync(string id, Producto updatedProducto) =>
            await _ProductoCollection.ReplaceOneAsync(x => x._id == id, updatedProducto);

        public async Task RemoveAsync(string id) =>
            await _ProductoCollection.DeleteOneAsync(x => x._id == id);
    }
}
