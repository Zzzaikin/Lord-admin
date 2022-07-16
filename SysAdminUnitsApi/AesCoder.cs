using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SysAdminUnitsApi
{
    /// <summary>
    /// Отвечает за шифрование и дешифрование.
    /// </summary>
    public class AesCoder
    {
        /// <summary>
        /// Шифрует пароль.
        /// </summary>
        /// <param name="userPassword">Исходный пароль</param>
        /// <returns>Зашифрованный пароль.</returns>
        public static async Task<string> EncryptPasswordAsync(string userPassword)
        {
            byte[] encryptedPassword;
            using (var aes = Aes.Create())
            {
                encryptedPassword = await EncryptStringToBytes(userPassword, aes.Key, aes.IV);
            }

            return Convert.ToBase64String(encryptedPassword, Base64FormattingOptions.None);
        }

        /// <summary>
        /// Зашифровывает строку.
        /// </summary>
        /// <param name="plainText">Текст.</param>
        /// <param name="key">Ключ шифрования.</param>
        /// <param name="initializationVector">Вектор инициализации.</param>
        /// <returns>Массив зашифрованных байтов.</returns>
        /// <exception cref="ArgumentNullException">Генерируется при нарушении валидации параметров.
        /// Валидные парамметры: 
        /// plainText - строка не null и не пустая;
        /// key - массив не null и не пустой;
        /// initializationVector - массив не null и не пустой.</exception>
        private static async Task<byte[]> EncryptStringToBytes(string plainText, byte[] key, byte[] initializationVector)
        {
            if (string.IsNullOrEmpty(plainText))
            {
                throw new ArgumentNullException($"{nameof(plainText)} не может быть пустой или null.");
            }

            if ((key == null) || (key.Length <= 0))
            {
                throw new ArgumentNullException($"{nameof(key)} не может быть null или пустым.");
            }

            if ((initializationVector == null) || (initializationVector.Length <= 0))
            {
                throw new ArgumentNullException($"{nameof(initializationVector)} не может быть null или пустым.");
            }

            byte[] encrypted;

            using (var aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.IV = initializationVector;

                var encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (var msEncrypt = new MemoryStream())
                {
                    using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (var swEncrypt = new StreamWriter(csEncrypt, Encoding.Unicode))
                        {
                            await swEncrypt.WriteAsync(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }

            return encrypted;
        }
    }
}
