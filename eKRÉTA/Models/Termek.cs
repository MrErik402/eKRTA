using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKRÉTA.Models
{
    class Termek
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string TeremNev { get; set; }

        public Termek()
        {
        }

        public Termek(string teremNev)
        {
            TeremNev = teremNev;
        }
    }
}
