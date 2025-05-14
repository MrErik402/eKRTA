using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKRÉTA.Models
{
    internal class Student
    {

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string VezNev { get; set; }
        public string UtoNev { get; set; }
        public string SzulDate { get; set; }
        public string AnyjaNeve { get; set; }
        public string Lakcim { get; set; }
    }
}
