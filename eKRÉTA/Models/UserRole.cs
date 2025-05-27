using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKRÉTA.Models
{
    public enum UserRole
    {
        Admin, //Adminisztrátor
        Teacher, //Tanár
        Student, //Tanuló
        Parent, //Szülő
        Guest //Vendég

            //Értékhozzárendeléskor úgy kell deklarálni, hogy Admin = 10 például
    }
}
