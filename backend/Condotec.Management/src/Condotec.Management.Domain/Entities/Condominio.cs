using Condotec.Management.Domain.ValueObjects;
using MongoDB.Bson.Serialization.Attributes;

namespace Condotec.Management.Domain.Entities
{
    public class Condominio(string? nome, Cnpj cnpj, Endereco? endereco)
    {
        [BsonId]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Nome { get; set; } = nome;
        public Cnpj Cnpj { get; set; } = cnpj;
        public Endereco? Endereco { get; set; } = endereco;
    }
}
