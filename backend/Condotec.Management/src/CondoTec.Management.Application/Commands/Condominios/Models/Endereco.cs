namespace CondoTec.Management.Application.Commands.Condominios.Models
{
    public class Endereco(string? cep, string? enderecoCompleto, string? complemento, string? cidade, string? uF)
    {
        public string? Cep { get; set; } = cep;
        public string? EnderecoCompleto { get; set; } = enderecoCompleto;
        public string? Complemento { get; set; } = complemento;
        public string? Cidade { get; set; } = cidade;
        public string? UF { get; set; } = uF;
    }
}
