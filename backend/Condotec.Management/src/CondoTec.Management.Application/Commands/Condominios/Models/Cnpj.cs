namespace CondoTec.Management.Application.Commands.Condominios.Models
{
    public class Cnpj(string? condominio)
    {
        public string? Documento { get; set; } = condominio;
    }
}
