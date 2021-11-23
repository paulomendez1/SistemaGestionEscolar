using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Common
{
    public class CommonValidations
    {
        public static bool ValidateEmail(string Email)
        {
            Regex rg = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            return rg.IsMatch(Email);
        }

        public static bool ValidatePW(string Password)
        {
            Regex letras = new Regex(@"[a-zA-z]");
            Regex numeros = new Regex(@"[0-9]");
            if (!letras.IsMatch(Password))
            {
                return false;
            }
            if (!numeros.IsMatch(Password))
            {
                return false;
            }

            if (Password.Length < 8)
            {
                return false;
            }

            return true;
        }

        public static bool ValidateNumber(string numero)
        {
            Regex regex = new Regex(@"^[-+]?[0-9]*\.?[0-9]+$");
            return regex.IsMatch(numero);
        }
    }
}

