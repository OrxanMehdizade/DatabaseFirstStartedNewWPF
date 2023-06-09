using Microsoft.EntityFrameworkCore;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DatabaseFirstStartedNew
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary> 
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FillTableComboBox();


        }
        private void FillTableComboBox()
        {
            using (var db = new LibraryContext())
            {
                var tableNames = db.Model.GetEntityTypes()
                    .Select(c => c.GetTableName())
                    .ToList();

                ComboClass.Items.Clear();

                foreach (var tableName in tableNames)
                {
                    ComboClass.Items.Add(new ComboBoxItem { Content = tableName });
                }
            }
        }

        private void ComboClass_SelectionChanged(object sender, RoutedEventArgs e)
        {

            using (var database = new LibraryContext())
            {
                ComboBoxItem? selectedItem = ComboClass.SelectedItem as ComboBoxItem;

                if (selectedItem != null)
                {
                    string selectedTable = selectedItem.Content.ToString()!;

                    ComboColumns.Items.Clear();

                    if (selectedTable == "Authors")
                    {
                        var authors = database.Authors.ToList();
                        authors.ForEach(a => ComboColumns.Items.Add($"{a.FirstName} {a.LastName}"));
                    }
                    else if (selectedTable == "Themes")
                    {
                        var themes = database.Themes.ToList();
                        themes.ForEach(t => ComboColumns.Items.Add($"{t.Name}"));
                    }
                    else if (selectedTable == "Categories")
                    {
                        var categories = database.Categories.ToList();
                        categories.ForEach(c => ComboColumns.Items.Add($"{c.Name}"));
                    }
                }
            }

        }

        private void ComboColumns_SelectionChanged(object sender, RoutedEventArgs e)
        {
            string selectedColumn = ComboColumns.SelectedItem.ToString();
            int bookCount = GetBookCount(selectedColumn);

            ListViewBooksCount.Items.Clear();
            ListViewBooksCount.Items.Add(bookCount);
        }

        private int GetBookCount(string columnName)
        {
            int bookCount = 0;
            using (var dbContext = new LibraryContext())
            {
                if (columnName == "Authors")
                {
                    bookCount = dbContext.Books.Count(b => b.IdAuthor ==4 );
                }
                else if (columnName == "Column2")
                {
                    bookCount = dbContext.Books.Where(b => b.Name == "New").Count();
                }
            }

            return bookCount;
        }




        //void print(List<LibraryContext> tableNames)
        //{
        //    foreach (var tableName in tableNames)
        //    {
        //        ComboColumns.Items.Add(new ComboBoxItem { Content = tableName });
        //    }
        //}

    }
}