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
            string jsonString = File.ReadAllText(path);
            List<Book>? books = JsonConvert.DeserializeObject<List<Book>>(jsonString);
            if (books == null) { return new List<Book>(); }
            return books;
        }
        public static void saveBooks(List<Book> books)
        {
            string savejson = JsonConvert.SerializeObject(books);
            File.WriteAllText(path, savejson);
        }
        public static Book getRefreshedBook(Book book)
        {
            List<Book> books = getBooks();
            foreach (Book item in books)
            {
                if (item.ID == book.ID)
                {
                    return item;
                }
            }
            return new Book();
        }
        public static void add(Book book)
        {
            List<Book> books = getBooks();
            if (books.Count > 0)
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
        public static void AddBookMark(Book book, BookMark bookMark)
        {
            List<Book> books = getBooks();
            foreach (Book item in books)
            {
                if (book.ID == item.ID)
                {
                    if(item.BookMarks == null) { item.BookMarks = new List<BookMark>(); }
                    if (item.BookMarks.Count > 0)
                    {
                        bookMark.ID = item.BookMarks.Last().ID + 1;
                    }
                    else if (item.BookMarks == null)
                    {
                        
                        bookMark.ID = 0;
                    }
                    item.BookMarks.Add(bookMark);
                    saveBooks(books);
                    break;
                }
            }
        }
        public static void RemoveBookMark(Book book, BookMark bookMark)
        {
            List<Book> books = getBooks();
            foreach (Book item in books)
            {
                if (book.ID == item.ID)
                {
                    foreach (BookMark mark in item.BookMarks)
                    {
                        if (mark.ID == bookMark.ID)
                        {
                            item.BookMarks.Remove(mark);
                            saveBooks(books);
                            break;
                        }

                    }

                }
            }
        }
    }
}
