using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Zakladki.Class;

namespace Zakladki.Windows
{
    /// <summary>
    /// Logika interakcji dla klasy AddBookMarks.xaml
    /// </summary>
    public partial class AddBookMarks : Window
    {
        Tables.Book book;
        public AddBookMarks(Tables.Book book)
        {
            InitializeComponent();
            this.book = book;
            Refresh();
        }
        public async void Refresh()
        {
            // PLIK //
            //LV_BookMarks.ItemsSource = FileFunctions.getRefreshedBook(book).BookMarks;

            // JSON //
            //LV_BookMarks.ItemsSource = JsonFunctions.getRefreshedBook(book).BookMarks;

            // BAZA //
            LV_BookMarks.ItemsSource = await App.DataAccess.getBookMark(book);
        }
        private void Btn_DeleteBookMark_Click(object sender, RoutedEventArgs e)
        {
            Button? button = (Button)sender;
            if (button == null) return;
            Tables.BookMark bookMark = (Tables.BookMark)button.CommandParameter;
            if (bookMark == null) return;

            // PLIK //
            //FileFunctions.RemoveBookMark(book, bookMark);

            // JSON //
            //JsonFunctions.RemoveBookMark(book, bookMark);

            // BAZA //
            App.DataAccess.removeBookMark(bookMark);
            Refresh();
        }
        private void Btn_AddBookMark_Click(object sender, RoutedEventArgs e)
        {
            
            Tables.BookMark bookMark = new Tables.BookMark();
            bookMark.Page = int.Parse(TB_Page.Text);
            bookMark.Description = TB_Description.Text;
            // PLIK //
            //FileFunctions.AddBookMark(book, bookMark);

            // JSON //
            //JsonFunctions.AddBookMark(book, bookMark);

            // BAZA //
            if (App.Database == null) return;
            App.Database.addBookMark(book, bookMark);
            Refresh();
        }
    }
}
