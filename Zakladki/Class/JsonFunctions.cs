using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Zakladki.Class
{
    static class JsonFunctions
    {
        static string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "databasejs.json");
        public static void createPath()
        {
            if(!File.Exists(path))
            {
                File.Create(path);
            }
        }
        public static List<Book> getBooks()
        {
            List<Book> books = new List<Book>();
            string[] readjson = File.ReadAllLines(path);
            foreach (string line in readjson)
            {
                Book? readedBook = JsonConvert.DeserializeObject<Book>(line);
                if (readedBook != null)
                    books.Add(readedBook);
            }
            return books;
        }
        public static void saveBooks(List<Book> books)
        {
            string savejson = JsonConvert.SerializeObject(books);
            File.WriteAllText(path, savejson);
        }
        public static void add(Book book)
        {
            List<Book> books = getBooks();
            books.Add(book);
            saveBooks(books);
        }
    }
}
