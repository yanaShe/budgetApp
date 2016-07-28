using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget1.Models
{
    public class Exapnses
    {
        public string Category { get; set; }
        public string Thing { get; set; }
        public int Price { get; set; }

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

    }
}
