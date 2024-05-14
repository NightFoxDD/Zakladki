using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zakladki.Class
{
    static class FileFunctions
    {
        static string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "databasetxt.txt");
        public static void createPath()
        {
            if (!File.Exists(path))
            {
                File.Create(path);
            }
        }
        public static List<Book> getBooks()
        {
            List<Book> books = new List<Book>();
            string[] readText = File.ReadAllLines(path);
            foreach (string line in readText)
            {
                List<BookMark> bookMarks = new List<BookMark>();
                
                if (line.Split(';')[5].Length>0)
                {
                    foreach (var item in line.Split(';')[5].Split('/'))
                    {
                        bookMarks.Add(new BookMark(int.Parse(item.Split(',')[0]), int.Parse(item.Split(',')[1]), item.Split(',')[2]));
                    }
                }
                
                Book readedBook = new Book(int.Parse(line.Split(';')[0]), line.Split(';')[1], line.Split(';')[2], line.Split(';')[3], Convert.ToDateTime(line.Split(';')[4]), bookMarks );
                books.Add(readedBook);
            }
            return books;
        }
        public static void saveBooks(List<Book> books)
        {
            List<string> booksString = new List<string>();

            foreach (var book in books)
            {
                string bookmarks = "";
                if (book.BookMarks != null)
                {
                    foreach (BookMark bookMark in book.BookMarks)
                    {
                        bookmarks += bookMark.ID + "," + bookMark.Page + "," + bookMark.Description + '/';
                    }
                }

                booksString.Add(book.ID + ";" + book.Name + ";" + book.Description + ";" + book.Author + ";" + book.PublicatedTime.ToString() + ";" + bookmarks);
            }
            File.WriteAllLines(path, booksString);
        }
        public static void add(Book book)
        {
            List<Book> books = getBooks();
            if(books.Count > 0)
            {
                book.ID = books.Last().ID + 1;
            }
            else
            {
                book.ID = 0;
            }
            books.Add(book);
            saveBooks(books);
        }
        public static void deleteBook(Book book)
        {
            List<Book> books = getBooks();
            foreach (Book item in books)
            {
                if (book.ID == item.ID)
                {
                    books.Remove(item);
                    break;
                }
            }
            saveBooks(books);
        }
    }
}
