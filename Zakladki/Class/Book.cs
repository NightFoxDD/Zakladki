using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zakladki.Class
{
    public class Book
    {
        public Book(int iD, string name, string description, string author, DateTime publicatedTime, List<BookMark> bookmark)
        {
            ID = iD;
            Name = name;
            Description = description;
            Author = author;
            PublicatedTime = publicatedTime;
            BookMarks = bookmark;
        }
        public Book(string name, string description, string author, DateTime? publicatedTime)
        {
            Name = name;
            Description = description;
            Author = author;
            PublicatedTime = publicatedTime;
        }
        public Book() { }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public List<BookMark> BookMarks { get; set; }
        public DateTime? PublicatedTime { get; set; }
    }
}
