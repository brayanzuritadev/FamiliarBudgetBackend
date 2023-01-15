using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Services.Utilities
{
    public class Hash
    {
        public string HashPassword(string password)
        {
            var hash = SHA256.Create();

            var passwordBytes = Encoding.Default.GetBytes(password);
            //encryptamos la contraseña
            var hasedPassword = hash.ComputeHash(passwordBytes);

            return Convert.ToHexString(hasedPassword);
        }
    }
}
