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
    /// Logika interakcji dla klasy AddBook.xaml
    /// </summary>
    public partial class AddBook : Window
    {
        public AddBook()
        {
            InitializeComponent();
        }

        private void Btn_AddBook_Click(object sender, RoutedEventArgs e)
        {
            FileFunctions.add(new Book(TB_Name.Text,TB_Description.Text,TB_Author.Text, DP_PublicatedTime.SelectedDate));
            this.Close();
        }
    }
}
