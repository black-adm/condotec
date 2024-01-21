using Newtonsoft.Json;

namespace CondoTec.Management.Application.Commands.Condominios.Models
{
    public class Cpf
    {
        public Cpf(string? documento)
        {
            ValidarCPF(CPF);
            Documento = documento;
        }

        public string? CPF { get; set; }

        [JsonIgnore]
        public List<string> Erros { get; set; } = [];
        public string? Documento { get; }

        public void ValidarCPF(string? cpf)
        {
            if (cpf is not null)
            {
                int[] multiplicador1 = [10, 9, 8, 7, 6, 5, 4, 3, 2];
                int[] multiplicador2 = [11, 10, 9, 8, 7, 6, 5, 4, 3, 2];
                string tempCpf;
                string digito;
                int soma;
                int resto;
                cpf = cpf?.Trim();
                cpf = cpf?.Replace(".", "").Replace("-", "");
                if (cpf?.Length != 11)
                {
                    Erros.Add("O CNPJ fornecido é inválido!!!");
                }
                tempCpf = cpf![..9];
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
                if (cpf.EndsWith(digito) == false)
                {
                    Erros.Add("O CNPJ fornecido é inválido!!!");
                }
            }
        }
    }
}
