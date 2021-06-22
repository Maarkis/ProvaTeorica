using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaTeorica.Validation
{
    public static class ValidateCpf
    {
        public static bool IsCpf(string cpf)
        {
            string cpfTemp;
            string cpfDigito = null;
            string rest;
            int sum;

            cpf = cpf.Replace(".", "").Replace("-", "");            

            if (cpf.Length != 11)
                return false;

            cpfTemp = cpf.Substring(0, 9);

            sum = Calculation(cpfTemp);
            rest = Remainder(sum);

            cpfTemp = cpf.Substring(0, 10);
            cpfDigito = cpfDigito + rest;

            sum = Calculation(cpfTemp);
            rest = Remainder(sum);
            
            cpfDigito = cpfDigito + rest;
            
            return cpf.EndsWith(cpfDigito);
        }

        private static int Calculation(string documento)
        {
            int soma = 0;
            for (int i = 0; i < documento.Length; i++)
                soma += (((documento.Length + 1) - i) * int.Parse(documento[i].ToString()));

            return soma;
        }

        private static string Remainder(int soma)
        {
            int resto = soma % 11;
            if (resto < 2)
                return "0";
            else
                resto = 11 - resto;
            return resto.ToString();            
        }

    }
}
