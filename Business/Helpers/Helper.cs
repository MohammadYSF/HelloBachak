using System.Security.Cryptography;
using System.Text;

namespace Business.Helpers;
public class Helper
{
    public static string ComputeSHA256Hash(string rawText)
    {
        StringBuilder stringBuilder = new StringBuilder();
        using (SHA256 sha256Hash = SHA256.Create())
        {
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawText));
            foreach (var b in bytes)
            {
                stringBuilder.Append(b.ToString("x2"));
            }
        }
        return stringBuilder.ToString();
    }
}