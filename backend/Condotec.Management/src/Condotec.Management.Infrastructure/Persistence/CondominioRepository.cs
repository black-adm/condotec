using Condotec.Management.Domain.Entities;
using Condotec.Management.Domain.Interfaces;
using MongoDB.Driver;
using Serilog;

namespace Condotec.Management.Infrastructure.Persistence
{
    public class CondominioRepository(IMongoDatabase mongoDb, ILogger _logger) : BaseRepository<Condominio>(mongoDb, "Condominios", _logger), ICondominioRepository
    {

    }
}
