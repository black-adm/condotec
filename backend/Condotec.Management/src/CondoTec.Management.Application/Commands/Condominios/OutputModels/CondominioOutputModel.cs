using CondoTec.Management.Application.Commands.Condominios.Models;

namespace CondoTec.Management.Application.Commands.Condominios.OutputModels
{
    public class CondominioOutputModel(string? nome, Cnpj? cnpj, Endereco? endereco)
    {
        public string? Nome { get; set; } = nome;
        public Cnpj? CNPJ { get; set; } = cnpj;
        public Endereco? Endereco { get; set; } = endereco;
    }
}
