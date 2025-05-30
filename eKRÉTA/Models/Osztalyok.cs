﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKRÉTA.Models
{
    class Osztalyok
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string OsztalyNev { get; set; }
        public int TeremID { get; set; }

        public Osztalyok()
        {
        }

        public Osztalyok(string osztalyNev, int teremID)
        {
            OsztalyNev = osztalyNev;
            TeremID = teremID;
        }
    }

}
