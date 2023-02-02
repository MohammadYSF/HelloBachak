using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Configuration;

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
    public static bool IsEmailValid(string email)
    {
        var validEmailRegex = new Regex("^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$");
        return validEmailRegex.IsMatch(email);
    }
    public static bool IsPhoneNumberValid(string phoneNumber)
    {
        var validPhoneNumberRegex = new Regex("[0][9][0-9][0-9]{8,8}");
        return validPhoneNumberRegex.IsMatch(phoneNumber) && phoneNumber.Length == 11;
        //like 09924300159 (must start with zero)
    }
    public static bool IsPasswordValid(string password)
    {

        var validPasswordRegex = new Regex("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$");
        return validPasswordRegex.IsMatch(password) && password.Length <= 100;
        //password conditions : 
        //at least 8 character
        //at least 1 upper
        // at least 1 lower
        // at least 1 special
        //at least 1 digit
        // in the database  , the max size of password is 100 . so we add the condition : 
        // password.lenght <= 100
    }
    public static bool IsUsernameValid(string username)
    {
        var validUsernameRegex = new Regex("^[A-Za-z][A-Za-z0-9]*$");
        return validUsernameRegex.IsMatch(username) && username.Length > 3 && username.Length <= 50;
    }
    public static void SendEmail(IConfiguration config,string destEmailAddress, string message)
    {
        var host = config["Smtp:Host"];
        int port = int.Parse(config["Smtp:Port"]);

        var sourceEmailAddress = config["Smtp:Username"];
        var sourceEmailPassword = config["Smtp:Password"];
        var stmpClient = new SmtpClient(host:host , port:port);
        stmpClient.EnableSsl = true;
        stmpClient.Credentials = new NetworkCredential(sourceEmailAddress,sourceEmailPassword);
        var mailMessage = new MailMessage{
            From =new MailAddress(sourceEmailAddress),
            Subject= "Hello Bachak activation code",
            Body = message,
            IsBodyHtml = true
        };
        mailMessage.To.Add(destEmailAddress);
        stmpClient.Send(mailMessage);
    }
}