using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Papeleria.AccesoDatos.Encriptador
{
    public class EncriptadorAES
    {
        //private static readonly byte[] Clave = Encoding.UTF8.GetBytes("TuClaveSecreta"); // Clave de encriptación (debe tener 16, 24 o 32 bytes)
        //private static readonly byte[] IV = Encoding.UTF8.GetBytes("TuVectorInicial"); // Vector inicial (IV) (debe tener 16 bytes)
        private static readonly byte[] Clave = GenerarClave();
        private static readonly byte[] IV = new byte[16]; // Vector de inicialización de 16 bytes (para AES, siempre es 16 bytes)

        private static byte[] GenerarClave()
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                var clave = new byte[16]; // Clave de 16 bytes para AES-128
                rng.GetBytes(clave);
                return clave;
            }
        }
        public static string Encriptar(string textoPlano)
        {
            using (var aesAlg = Aes.Create())
            {
                aesAlg.Key = Clave;
                aesAlg.IV = IV;

                var encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
                using (var msEncrypt = new MemoryStream())
                {
                    using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (var swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(textoPlano);
                        }
                    }
                    return Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
        }

        public static string Desencriptar(string textoEncriptado)
        {
            using (var aesAlg = Aes.Create())
            {
                aesAlg.Key = Clave;
                aesAlg.IV = IV;

                var decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
                using (var msDecrypt = new MemoryStream(Convert.FromBase64String(textoEncriptado)))
                {
                    using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (var srDecrypt = new StreamReader(csDecrypt))
                        {
                            return srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
}
