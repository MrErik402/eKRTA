using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace eKRÉTA
{
    public static class PasswordHelper
    {
        //A jelszó hash-elését végző metódus
        public static string HashPassword(string password)
        {
            using (SHA256 sha = SHA256.Create()) //SHA256 példány létrehozása a hash - eléshez
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password); // A jelszó karakterláncot byte-tömbbé alakítja UTF8 kódolással
                byte[] hashBytes = sha.ComputeHash(bytes); // A jelszó byte-tömbből elkészíti a SHA256 hash-t
                return Convert.ToBase64String(hashBytes); // A hash eredményt Base64 formában adja vissza, szövegként
            }
        }
    }
}
