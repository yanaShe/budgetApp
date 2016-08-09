using SQLite;
using SQLiteNetExtensions.Attributes;
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

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        [OneToMany]
        public List<Items> Items { get; set; }

    }

    public class Items
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Item { get; set; }
        public int Price { get; set; }

        [ForeignKey(typeof (Exapnses))]
        public int CategoryId { get; set; }
    }
   
}
