using System.Security.Cryptography;
using System.Collections.Generic;
using System.Text;
using System;
namespace motdepasse
{
public static class DataProtectionExtensions
    {
         public static string Protect(
             this string clearText,
             string optionalEntropy = null,
             DataProtectionScope scope = DataProtectionScope.CurrentUser)
         {
             if (clearText == null)
                 throw new ArgumentNullException("clearText");
             byte[] clearBytes = Encoding.UTF8.GetBytes(clearText);
             byte[] entropyBytes = string.IsNullOrEmpty(optionalEntropy)
                 ? null
                 : Encoding.UTF8.GetBytes(optionalEntropy);
             byte[] encryptedBytes = ProtectedData.Protect(clearBytes, entropyBytes, scope);
             return Convert.ToBase64String(encryptedBytes);
         }
          
         public static string Unprotect(
             this string encryptedText,
             string optionalEntropy = null,
             DataProtectionScope scope = DataProtectionScope.CurrentUser)
         {
             if (encryptedText == null)
                 throw new ArgumentNullException("encryptedText");
             byte[] encryptedBytes = Convert.FromBase64String(encryptedText);
             byte[] entropyBytes = string.IsNullOrEmpty(optionalEntropy)
                 ? null
                 : Encoding.UTF8.GetBytes(optionalEntropy);
             byte[] clearBytes = ProtectedData.Unprotect(encryptedBytes, entropyBytes, scope);
             return Encoding.UTF8.GetString(clearBytes);
         }
    
static void Main(string[] args)
        {
        
            string motcrypte= Protect("Thomas");
            Console.WriteLine("Thomas donne {0}",motcrypte);
            string motcrypte2= Protect("thomas");
            Console.WriteLine("thomas donne {0}",motcrypte2);
        
           
            string motdecrypte=Unprotect(motcrypte);
            Console.WriteLine("le mot decrypté donne : {0}",motdecrypte);
        
            Console.ReadLine();
        }
    }    
}

