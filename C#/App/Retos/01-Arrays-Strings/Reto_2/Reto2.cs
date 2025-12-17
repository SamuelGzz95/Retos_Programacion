using System.Text.RegularExpressions;

namespace ConsoleApp
{
    internal static class Reto2
    {
        public static bool IsPalindrome(string s)
        {
            string filterS = s.ToLower().Trim().Normalize(System.Text.NormalizationForm.FormD);
            string filterT = Regex.Replace(filterS, "[^a-zA-Z0-9_.]+", "", RegexOptions.Compiled);
            int n = filterT.Length % 2 == 0 ? filterT.Length / 2 : (filterT.Length - 1) / 2;
            char[] c = filterT.ToCharArray();
            for (int i = 0; i < n; i++)
            {
                if (c[i] != c[filterT.Length - 1 - i])
                    return false;
            }
            return true;
        }


        public static bool IsPalindrome_IA(string s)
        {
            if (string.IsNullOrEmpty(s))
                return true; // String vacía es considerada palíndromo

            int left = 0;
            int right = s.Length - 1;

            while (left < right)
            {
                // Saltar caracteres no alfanuméricos desde la izquierda
                while (left < right && !IsAlphanumeric(s[left]))
                {
                    left++;
                }

                // Saltar caracteres no alfanuméricos desde la derecha
                while (left < right && !IsAlphanumeric(s[right]))
                {
                    right--;
                }

                // Comparar caracteres (ignorando mayúsculas/minúsculas)
                if (char.ToLower(s[left]) != char.ToLower(s[right]))
                {
                    return false;
                }

                left++;
                right--;
            }

            return true;
        }

        /// <summary>
        /// Verifica si un carácter es alfanumérico (letra o dígito)
        /// </summary>
        private static bool IsAlphanumeric(char c)
        {
            return char.IsLetterOrDigit(c);
        }
    }
}
