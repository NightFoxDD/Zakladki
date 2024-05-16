﻿using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Zakladki.Class;
using Zakladki.Windows;

namespace Zakladki
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Refresh();
        }
        public async void Refresh()
        {
            //LV_Books.ItemsSource = FileFunctions.getBooks();
            //LV_Books.ItemsSource = JsonFunctions.getBooks();
            LV_Books.ItemsSource = await App.DataAccess.getBooks();
        }
        
        private void Btn_AddBookWindow_Click(object sender, RoutedEventArgs e)
        {
            (new AddBook()).ShowDialog();
            Refresh();
        }

        private void Btn_DeleteBook_Click(object sender, RoutedEventArgs e)
        {
            Button? button = sender as Button;
            if (button == null) return;
            Tables.Book? delBook = (button).CommandParameter as Tables.Book;
            if(delBook == null) return;
            //FileFunctions.deleteBook(delBook);
            //JsonFunctions.deleteBook(delBook);
            App.DataAccess.deleteBook(delBook);
            Refresh();
        }
        private void Btn_AddBookMark_Click(object sender, RoutedEventArgs e)
        {
            Button? button = sender as Button;
            if (button == null) return;
            Tables.Book? book = (button).CommandParameter as Tables.Book;
            if (book == null) return;
            (new AddBookMarks(book)).ShowDialog();
            Refresh();
        }
    }
}