using System.Text.Json.Serialization;

namespace CondoTec.Management.Application.Commands.Condominios.InputModels
{
    public class Documento
    {
        public Documento(string documento, TipoDocumento tipoDocumento)
        {
            if(tipoDocumento == TipoDocumento.Cnpj)
            {
                ValidarCNPJ(documento);
                Cnpj = documento;
                return;
            }

            ValidarCPF(documento);
            Cnpj = documento;
        }

        [JsonIgnore]
        public TipoDocumento TipoDocumento { get; set; }

        public string? Cpf { get; set; }

        public string? Cnpj { get; set; }

        [JsonIgnore]
        public List<string> Erros { get; set; } = [];

        public void ValidarCNPJ(string cnpj)
        {
            int[] multiplicador1 = [5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2];
            int[] multiplicador2 = [6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2];
            int soma;
            int resto;
            string digito;
            string tempCnpj;
            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
            if (cnpj.Length != 14)
            {
                Erros.Add("O CNPJ fornecido é inválido!!!");
            }

            tempCnpj = cnpj[..12];
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
            if (cnpj.EndsWith(digito) == false)
            {
                Erros.Add("O CNPJ fornecido é inválido!!!");
            }
        }

        public void ValidarCPF(string cpf)
        {
            int[] multiplicador1 = [10, 9, 8, 7, 6, 5, 4, 3, 2];
            int[] multiplicador2 = [11, 10, 9, 8, 7, 6, 5, 4, 3, 2];
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
            {
                Erros.Add("O CNPJ fornecido é inválido!!!");
            }
            tempCpf = cpf[..9];
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf += digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito += resto.ToString();
            if(cpf.EndsWith(digito) == false)
            {
                Erros.Add("O CNPJ fornecido é inválido!!!");
            }
        }
    }
}
