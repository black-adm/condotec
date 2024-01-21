using Condotec.Management.Domain.Interfaces;
using CondoTec.Management.Application.Commands.Condominios.Mapper;
using CondoTec.Management.Application.Commands.Condominios.OutputModels;
using CondoTec.Management.Application.Responses;
using MediatR;

namespace CondoTec.Management.Application.Commands.Condominios.UseCases.AddCondominio
{
    public class AddCondominioCommandHandler(ICondominioRepository condominioRepository) : IRequestHandler<AddCondominioCommand, ApiResponse<CondominioOutputModel>>
    {
        private readonly ICondominioRepository _repository = condominioRepository;

        public async Task<ApiResponse<CondominioOutputModel>> Handle(AddCondominioCommand request, CancellationToken cancellationToken)
        {
            var condominioDomain = request.ToDomain();

            await _repository.AddOneAsync(condominioDomain);

            var apiResponse = new ApiResponse<CondominioOutputModel>
            {
                Data = condominioDomain.ToOutputModel()
            };

            return apiResponse;
        }
    }
}
