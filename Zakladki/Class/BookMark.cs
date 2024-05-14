using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zakladki.Class
{
    public class BookMark
    {
        public BookMark(int page, string description)
        {
            Page = page;
            Description = description;
        }

        public BookMark(int iD, int page, string description)
        {
            ID = iD;
            Page = page;
            Description = description;
        }

        public int ID { get; set; }
        public int Page { get; set; }
        public string Description { get; set; }

    }
}
