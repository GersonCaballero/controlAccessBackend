using System;
using System.Security.Cryptography;
using System.Text;

namespace MvcCoreUtilidades.Helpers
{
    public class HelperCryptography
    {
        public static string Salt { get; set; }

        public static string GenerateSalt()
        {
            Random random = new Random();
            string salt = "";
            for (int i = 1; i <= 50; i++)
            {
                int aleat = random.Next(0, 255);
                char letra = Convert.ToChar(aleat);
                salt += letra;
            }
            return salt;
        }

        public static string EncriptarContenido(string contenido, bool comparar)
        {
            if (!comparar)
            {
                Salt = GenerateSalt();
            }

            string contenidosalt = contenido + Salt;

            byte[] salida;
            UnicodeEncoding encoding = new UnicodeEncoding();
            salida = encoding.GetBytes(contenidosalt);

            SHA256Managed sHA256 = new SHA256Managed();

            for (int i = 1; i <= 55; i++)
            {
                salida = sHA256.ComputeHash(salida);
            }

            sHA256.Clear();
            StringBuilder resultado = new StringBuilder();
            foreach (byte b in salida)
            {
                resultado.Append(b.ToString("X2"));
            }

            // Truncar la cadena resultante a los primeros 16 caracteres
            return resultado.ToString().Substring(0, 25);
        }

        public static string EncriptarContrasena(string contrasena)
        {
            // Encripta la contraseña utilizando EncriptarContenido
            return EncriptarContenido(contrasena, false);
        }
    }
}
