using System;
using System.Text;

namespace core.helper
{
    public class RandomUtil
    {
        #region varaibles

        private const string LOWER_CASE = "abcdefghijklmnopqursuvwxyz";
        private const string UPPER_CAES = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string NUMBERS = "123456789";
        private const string SPECIALS = @"!@£$%^&*()#€";

        #endregion

        #region métodos

        /// <summary>
        /// Get random string of 11 characters.
        /// </summary>
        /// <returns>Random string.</returns>
        public static string GetRandomString()
        {
            const string src = "abcdefghijklmnopqrstuvwxyz0123456789";
            int length = 16;
            var sb = new StringBuilder();
            Random RNG = new Random();
            for (var i = 0; i < length; i++)
            {
                var c = src[RNG.Next(0, src.Length)];
                sb.Append(c);
            }

            return sb.ToString();
        }

        /// <summary>
        /// Generar cadena aleatoria para usarse como contraseña
        /// </summary>
        /// <param name="useLowercase">Usar minúsculas</param>
        /// <param name="useUppercase">Usar mayúsculas</param>
        /// <param name="useNumbers">Usar números</param>
        /// <param name="useSpecial">Usar caracteres especiales</param>
        /// <param name="passwordSize">Longitud de la contraseña</param>
        /// <returns></returns>
        public static string GeneratePassword(bool useLowercase, bool useUppercase, bool useNumbers, bool useSpecial, int passwordSize)
        {
            char[] _password = new char[passwordSize];
            string _charSet = ""; // Initialise to blank
            var _random = new Random();
            int _counter;

            // Build up the character set to choose from
            if (useLowercase) _charSet += LOWER_CASE;

            if (useUppercase) _charSet += UPPER_CAES;

            if (useNumbers) _charSet += NUMBERS;

            if (useSpecial) _charSet += SPECIALS;

            for (_counter = 0; _counter < passwordSize; _counter++)
            {
                _password[_counter] = _charSet[_random.Next(_charSet.Length - 1)];
            }

            return String.Join(null, _password);
        }

        /// <summary>
        /// Generar GUID para usar como token
        /// </summary>
        /// <returns>Cadena generada</returns>
        public static string GenerateToken()
        {
            var guid = Guid.NewGuid();
            return guid.ToString();
        }

        #endregion

    }

}