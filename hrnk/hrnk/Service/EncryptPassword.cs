using System;
using System.Text;
using System.Security.Cryptography;
using System.Linq;

public static class EncryptPassword
{
    public static byte[] HashPassword(string password)
    {
        using (SHA256 sha256Hash = SHA256.Create())
        {
            byte[] hash = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
            if (hash.Length < 255)
            {
                byte[] paddedHash = new byte[255];
                Array.Copy(hash, paddedHash, hash.Length);
                return paddedHash;
            }
            else
            {
                return hash;
            }
        }
    }

    public static bool VerifyPassword(string password, byte[] hashedPasswordBytes)
    {
        byte[] passwordHashBytes = HashPassword(password);
        return hashedPasswordBytes.SequenceEqual(passwordHashBytes);
    }
}
