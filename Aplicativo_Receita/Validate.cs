﻿namespace Aplicativo_Receita
{
    public class Validate
    {
        //Classe que não será realizada a fatoração.
        public static bool ValidateCNPJ(string cnpj)
        {
            
                int[] mult1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
                int[] mult2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
                int sum;
                int rest;
                string digit;
                string tempCnpj;
                cnpj = cnpj.Trim();
                cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
                if (cnpj.Length != 14)
                    return false;
                tempCnpj = cnpj.Substring(0, 12);
                sum = 0;
                for (int i = 0; i < 12; i++)
                    sum += int.Parse(tempCnpj[i].ToString()) * mult1[i];
                rest = (sum % 11);
                if (rest < 2)
                    rest = 0;
                else
                    rest = 11 - rest;
                digit = rest.ToString();
                tempCnpj = tempCnpj + digit;
                sum = 0;
                for (int i = 0; i < 13; i++)
                    sum += int.Parse(tempCnpj[i].ToString()) * mult2[i];
                rest = (sum % 11);
                if (rest < 2)
                    rest = 0;
                else
                    rest = 11 - rest;
                digit = digit + rest.ToString();
                return cnpj.EndsWith(digit);
            }
        }
    }

