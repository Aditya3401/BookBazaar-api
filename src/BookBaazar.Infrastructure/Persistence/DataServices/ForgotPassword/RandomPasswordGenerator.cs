using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BookBaazar.Infrastructure.Persistence.DataServices.ForgotPassword
{
    public class RandomPasswordGenerator
    {
        private const string Characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()";

        public static string GeneratePassword(int length)
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                var buffer = new byte[length];
                rng.GetBytes(buffer);

                var password = new char[length];
                for (var i = 0; i < length; i++)
                {
                    password[i] = Characters[buffer[i] % Characters.Length];
                }

                return new string(password);
            }
        }
    }
}
