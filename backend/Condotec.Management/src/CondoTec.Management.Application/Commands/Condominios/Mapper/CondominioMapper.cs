using Condotec.Management.Domain.Entities;
using CondoTec.Management.Application.Commands.Condominios.OutputModels;
using CondoTec.Management.Application.Commands.Condominios.UseCases.AddCondominio;
using Domain = Condotec.Management.Domain.Entities;
using ValueObjects = Condotec.Management.Domain.ValueObjects;
namespace CondoTec.Management.Application.Commands.Condominios.Mapper
{
    public static class CondominioMapper
    {
        public static Condominio ToDomain(this AddCondominioCommand condominioCommand)
        {
            var cnpj = new Domain.Cnpj(condominioCommand.CNPJ?.Documento);

            var endereco = new ValueObjects.Endereco(condominioCommand.Endereco?.Cep,
                condominioCommand.Endereco?.EnderecoCompleto, 
                condominioCommand.Endereco?.Complemento, 
                condominioCommand.Endereco?.Cidade,
                condominioCommand.Endereco?.UF);

            return new Condominio(condominioCommand.Nome, cnpj, endereco);
        }

        public static CondominioOutputModel ToOutputModel(this Domain.Condominio condominio)
        {
            var cnpj = new Models.Cnpj(condominio.Cnpj.Documento);

            var endereco = new Models.Endereco(condominio.Endereco?.Cep,
                condominio.Endereco?.EnderecoCompleto,
                condominio.Endereco?.Complemento,
                condominio.Endereco?.Cidade,
                condominio.Endereco?.UF);

            var condominioOutputModel = new OutputModels.CondominioOutputModel(condominio.Nome,cnpj, endereco);

            return condominioOutputModel;
        }
    }
}
