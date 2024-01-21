using CondoTec.Management.Application.Commands.Condominios.Models;
using CondoTec.Management.Application.Commands.Condominios.OutputModels;
using CondoTec.Management.Application.Responses;
using MediatR;

namespace CondoTec.Management.Application.Commands.Condominios.UseCases.AddCondominio
{
    public class AddCondominioCommand : IRequest<ApiResponse<CondominioOutputModel>>
    {
        public string? Nome { get; set; }
        public Cnpj? CNPJ { get; set; }
        public Endereco? Endereco { get; set; }
    }
}
