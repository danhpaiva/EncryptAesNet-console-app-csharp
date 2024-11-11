using System.Security.Cryptography;
using static System.Console;

namespace EncryptAesApp.Action;

public class EncryptData
{
    public static void EncryptAesManaged(string raw)
    {
        try
        { 
            using (AesManaged aes = new AesManaged())
            { 
                byte[] encrypted = Encrypt(raw, aes.Key, aes.IV);   
                WriteLine($"\nEncrypted Data: {System.Text.Encoding.UTF8.GetString(encrypted)}");   
                string decrypted = Decrypt(encrypted, aes.Key, aes.IV);   
                WriteLine($"\nDecrypted Data: {decrypted}");
            }
        }
        catch (Exception exp)
        {
            WriteLine("Houve um erro: " + exp.Message);
        }
        WriteLine("\nAção executada com sucesso!");
    }
    static byte[] Encrypt(string plainText, byte[] Key, byte[] IV)
    {
        byte[] encrypted;
        using (AesManaged aes = new AesManaged())
        {  
            ICryptoTransform encryptor = aes.CreateEncryptor(Key, IV); 
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                {  
                    using (StreamWriter sw = new StreamWriter(cs))
                        sw.Write(plainText);
                    encrypted = ms.ToArray();
                }
            }
        }  
        return encrypted;
    }
    static string Decrypt(byte[] cipherText, byte[] Key, byte[] IV)
    {
        string plaintext = null;
        using (AesManaged aes = new AesManaged())
        {
            ICryptoTransform decryptor = aes.CreateDecryptor(Key, IV);  
            using (MemoryStream ms = new MemoryStream(cipherText))
            {  
                using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                { 
                    using (StreamReader reader = new StreamReader(cs))
                        plaintext = reader.ReadToEnd();
                }
            }
        }
        return plaintext;
    }
}
