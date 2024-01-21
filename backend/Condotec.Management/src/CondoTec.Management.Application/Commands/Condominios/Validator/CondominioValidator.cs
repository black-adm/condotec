using CondoTec.Management.Application.Commands.Condominios.UseCases.AddCondominio;
using CondoTec.Management.Application.Constants;
using FluentValidation;

namespace CondoTec.Management.Application.Commands.Condominios.Validator
{
    public class CondominioValidator : AbstractValidator<AddCondominioCommand>
    {
        public CondominioValidator()
        {
            RuleFor(x => x.Nome)
                .Must(nome => !string.IsNullOrEmpty(nome))
                .WithMessage(ValidationErrorsConstants.UF);

            RuleFor(x => x)
            .Must(ValidateCnpj)
            .WithMessage(ValidationErrorsConstants.CnpjInvalido);

            RuleFor(x => x.Endereco!.EnderecoCompleto)
                .Must(enderecoCompleto => !string.IsNullOrEmpty(enderecoCompleto))
                .WithMessage(ValidationErrorsConstants.EnderecoError);
            
            RuleFor(x => x.Endereco!.Complemento)
                .Must(complemento => !string.IsNullOrEmpty(complemento))
                .WithMessage(ValidationErrorsConstants.ComplementoError);

            RuleFor(x => x.Endereco!.Cidade)
                .Must(cidade => !string.IsNullOrEmpty(cidade))
                .WithMessage(ValidationErrorsConstants.Cidade);

            RuleFor(x => x.Endereco!.UF)
                .Must(uf => !string.IsNullOrEmpty(uf))
                .WithMessage(ValidationErrorsConstants.UF);

            RuleFor(x => x.Endereco!.Cep)
                .Must(uf => !string.IsNullOrEmpty(uf))
                .WithMessage(ValidationErrorsConstants.UF);
        }

        public static bool ValidateCnpj(AddCondominioCommand addCondominioCommand)
        {
            int[] multiplicador1 = [5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2];
            int[] multiplicador2 = [6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2];
            int soma;
            int resto;
            string digito;
            string tempCnpj;
            var Cnpj = addCondominioCommand.CNPJ?.Documento?.Trim();
            Cnpj = Cnpj?.Replace(".", "").Replace("-", "").Replace("/", "");
            if (Cnpj?.Length != 14)
            {
                return false;
            }

            tempCnpj = Cnpj[..12];
            soma = 0;
            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCnpj += digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito += resto.ToString();
            if (Cnpj.EndsWith(digito) == false)
            {
                return false;
            }

            return true;
        }
    }
}
