using ProyectoDiseñoSoft.Modelos;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProyectoDiseñoSoft.Fabrica;

namespace ProyectoDiseñoSoft.Servicios
{
    public class EmpleadoService : IPersonaService<Empleados>
    {
        private readonly IMongoCollection<Empleados> _EmpleadoCollection;

        public EmpleadoService()
        {
            var settings = DatabaseSettings.Instance;

            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _EmpleadoCollection = database.GetCollection<Empleados>("Empleados"); ;
        }

        public async Task<List<Empleados>> GetAsync() =>
            await _EmpleadoCollection.Find(_ => true).ToListAsync();

        public async Task<Empleados?> GetAsync(string id) =>
            await _EmpleadoCollection.Find(x => x._id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Empleados newEmpleado) =>
            await _EmpleadoCollection.InsertOneAsync(newEmpleado);

        public async Task UpdateAsync(string id, Empleados updatedEmpleado) =>
            await _EmpleadoCollection.ReplaceOneAsync(x => x._id == id, updatedEmpleado);

        public async Task RemoveAsync(string id) =>
            await _EmpleadoCollection.DeleteOneAsync(x => x._id == id);
    }
}
