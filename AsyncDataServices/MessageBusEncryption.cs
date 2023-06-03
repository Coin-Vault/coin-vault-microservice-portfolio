using System.Security.Cryptography;
using System.Text;

namespace PortfolioService.AsyncDataServices
{
    public class MessageBusEncryption : IMessageBusEncryption
    {
        public string DecryptString(string key, string message)
        {
            byte[] iv = new byte[16];
            byte[] buffer = Convert.FromBase64String(message);

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader(cryptoStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
}
