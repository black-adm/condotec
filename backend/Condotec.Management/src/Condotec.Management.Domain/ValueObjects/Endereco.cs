namespace Condotec.Management.Domain.ValueObjects
{
    public class Endereco(string? cep, string? enderecoCompleto, string? complemento, string? cidade, string? uf)
    {
        public string? Cep { get; set; } = cep;
        public string? EnderecoCompleto { get; set; } = enderecoCompleto;
        public string? Complemento { get; set; } = complemento;
        public string? Cidade { get; set; } = cidade;
        public string? UF { get; set; } = uf;
    }
}
