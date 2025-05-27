using Microsoft.VisualBasic;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKRÉTA.Models
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string FelhasznaloNev { get; set; }
        public string TeljesNev { get; set; }
        public string Jelszo { get; set; }
        public int UserRole { get; set; }

        //Kiírásra nem kerül, csak így lehet lekérdezni a nevét.

        public string UserRoleName => Enum.GetName(typeof(UserRole), UserRole) ?? "Ismeretlen";

        public User()
        {
        }

        public User(string felhasznaloNev, string teljesNev, int userRole)
        {
            FelhasznaloNev = felhasznaloNev;
            TeljesNev = teljesNev;
            UserRole = userRole;
        }

        public User(string felhasznaloNev, string teljesNev, string jelszo, int userRole)
        {
            FelhasznaloNev = felhasznaloNev;
            TeljesNev = teljesNev;
            Jelszo = jelszo;
            UserRole = userRole;
        }
    }
}
