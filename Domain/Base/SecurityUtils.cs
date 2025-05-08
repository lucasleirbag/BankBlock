using System.Security.Cryptography;
using System.Text;

namespace Domain.Base;
public class SecurityUtils
{
    public static string HashSHA256(string text)
    {
        byte[] byteV = Encoding.UTF8.GetBytes(text);
        byte[] byteH = SHA256.HashData(byteV);

        return Convert.ToBase64String(byteH);
    }
}
