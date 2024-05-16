using SQLite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zakladki.Class
{
    public class DatabaseFunctions
    {
        public readonly SQLiteAsyncConnection _database;
        public DatabaseFunctions(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Tables.Book>().Wait();
            _database.CreateTableAsync<Tables.BookMark>().Wait();
        }
        public Task<List<Tables.Book>> getBooks()
        {
            return _database.Table<Tables.Book>().ToListAsync();
        }
        public Task<List<Tables.BookMark>> getBookMark(Tables.Book book)
        {
            return _database.Table<Tables.BookMark>().Where(item=>item.BookID == book.ID).ToListAsync();
        }
        public Task addBook(Tables.Book book)
        {
            return _database.InsertAsync(book);
        }
        public Task updateBook(Tables.Book book)
        {
            return _database.UpdateAsync(book);
        }
        public Task deleteBook(Tables.Book book)
        {
            return _database.DeleteAsync(book);
        }
        public Tables.Book getBook(int id)
        {
            return _database.Table<Tables.Book>().Where(item => item.ID == id).FirstAsync().Result;
        }
        public Task addBookMark(Tables.Book book, Tables.BookMark bookMark)
        {
            bookMark.BookID = book.ID;
            return _database.InsertAsync(bookMark);
        }
        public Task removeBookMark(Tables.BookMark bookMark)
        {
            return _database.DeleteAsync(bookMark);
        }
    }
}
