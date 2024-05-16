using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zakladki.Tables
{
    public class BookMark
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public int BookID { get; set; }
        public int Page { get; set; }
        public string Description { get; set; }
    }
}
