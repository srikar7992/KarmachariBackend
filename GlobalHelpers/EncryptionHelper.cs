using LoggerImplementation;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GlobalHelpers;

public class EncryptionHelper
{
    private protected readonly byte[] privateKey;
    private protected readonly byte[] publicKey;
    private protected readonly byte[] secondarySalt;
    private protected readonly LoggerImplementation.ILogger logger;
    /// <summary>
    /// Initializes a new instance of the EncryptionHelper class.
    /// </summary>
    /// <param name="configuration">The IConfiguration object to retrieve the keys from appsettings.json.</param>
    public EncryptionHelper(IConfiguration configuration, ILogger _logger)
    {
        this.logger = _logger;
        privateKey = Encoding.UTF8.GetBytes(configuration.GetSection("Encryption:PrivateKey").Value ?? "1da2eb0a-8c9f-4b8a-a294-84fdde9e5d71");
        publicKey = Encoding.UTF8.GetBytes(configuration.GetSection("Encryption:PublicKey").Value ?? "f8b2b619-8198-4187-92b9-8a3a2d0f6e11");
        secondarySalt = GenerateRandomSalt();
    }

    /// <summary>
    /// Encrypts the specified plain text using the private key and a randomly generated secondary salt.
    /// </summary>
    /// <param name="plainText">The plain text to encrypt.</param>
    /// <returns>The encrypted cipher text.</returns>
    public string Encrypt(string plainText, bool usePrivateKey = true)
    {
        return EncryptText(plainText, usePrivateKey);
    }


    /// <summary>
    /// Decrypts the specified cipher text using the private key or the public key.
    /// </summary>
    /// <param name="cipherText">The cipher text to decrypt.</param>
    /// <param name="usePrivateKey">A boolean indicating whether to use the private key or the public key.</param>
    /// <returns>The decrypted plain text.</returns>
    public string Decrypt(string cipherText, bool usePrivateKey = true)
    {
        return DecryptText(cipherText, usePrivateKey);
    }

    private protected static byte[] GenerateRandomSalt()
    {
        byte[] salt = new byte[32];
        using (var rng = new RNGCryptoServiceProvider())
        {
            rng.GetBytes(salt);
        }
        return salt;
    }

    private protected string EncryptText(string plainText, bool usePrivateKey = true)
    {
        try
        {
            byte[] key = usePrivateKey ? privateKey : publicKey;
            byte[] encryptedBytes;

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.GenerateIV();

                byte[] iv = aesAlg.IV;
                byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

                using (ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, iv))
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    msEncrypt.Write(iv, 0, iv.Length);
                    msEncrypt.Write(secondarySalt, 0, secondarySalt.Length);

                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        csEncrypt.Write(plainTextBytes, 0, plainTextBytes.Length);
                        csEncrypt.FlushFinalBlock();
                    }

                    encryptedBytes = msEncrypt.ToArray();
                }
            }

            return Convert.ToBase64String(encryptedBytes);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, ex.Message);
            return string.Empty;
        }
    }

    private protected string DecryptText(string cipherText, bool usePrivateKey = true)
    {
        try
        {
            byte[] key = usePrivateKey ? privateKey : publicKey;
            byte[] cipherTextBytes = Convert.FromBase64String(cipherText);
            byte[] iv = new byte[16];
            byte[] encryptedBytes = new byte[cipherTextBytes.Length - 16 - secondarySalt.Length];

            Buffer.BlockCopy(cipherTextBytes, 0, iv, 0, iv.Length);
            Buffer.BlockCopy(cipherTextBytes, iv.Length, secondarySalt, 0, secondarySalt.Length);
            Buffer.BlockCopy(cipherTextBytes, iv.Length + secondarySalt.Length, encryptedBytes, 0, encryptedBytes.Length);

            using Aes aesAlg = Aes.Create();
            aesAlg.Key = key;
            aesAlg.IV = iv;

            using ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
            using MemoryStream msDecrypt = new(encryptedBytes);
            using CryptoStream csDecrypt = new(msDecrypt, decryptor, CryptoStreamMode.Read);
            using StreamReader srDecrypt = new(csDecrypt);
            return srDecrypt.ReadToEnd();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, ex.Message);
            return string.Empty;
        }
    }
}
