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
        Book book;
        public AddBookMarks(Book book)
        {
            InitializeComponent();
            this.book = book;
            LV_BookMarks.ItemsSource = FileFunctions.getRefreshedBook(book).BookMarks;
        }
        private void Btn_DeleteBookMark_Click(object sender, RoutedEventArgs e)
        {
            Button? button = (Button)sender;
            if (button == null) return;
            BookMark bookMark = (BookMark)button.CommandParameter;
            if (bookMark == null) return;
            FileFunctions.RemoveBookMark(book, bookMark);
            book = FileFunctions.getRefreshedBook(book);
        }
        private void Btn_AddBookMark_Click(object sender, RoutedEventArgs e)
        {
            BookMark bookMark = new BookMark(int.Parse(TB_Page.Text), TB_Description.Text);
            FileFunctions.AddBookMark(book, bookMark);
            book = FileFunctions.getRefreshedBook(book);
            LV_BookMarks.ItemsSource = FileFunctions.getRefreshedBook(book).BookMarks;


        }
    }
}
