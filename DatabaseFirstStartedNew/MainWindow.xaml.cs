using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public ObservableCollection<Book> GetBooks { get; } = new();
        public MainWindow()
        {
            InitializeComponent();
            FillTableComboBox();
            DataContext = this;


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
            using (LibraryContext database = new())
            {
                ComboBoxItem? selectedItem = ComboClass.SelectedItem as ComboBoxItem;

                if (selectedItem.Content.ToString() == "Authors")
                {
                    GetBooks.Clear();
                    var author = ComboColumns.SelectedItem as string;
                    if (author != null)
                    {
                        var authorbook = database.Books.Join(
                            database.Authors, c => c.IdAuthor, d => d.Id, (c, d) => new { Book = c, Author = d })
                            .ToList()
                            .Where(y => $"{y.Author.FirstName} {y.Author.LastName}" == author).
                            Select(y => y.Book).ToList();
                        authorbook.ForEach(s => GetBooks.Add(s));
                    }
                }
                else if (selectedItem.Content.ToString() == "Themes")
                {
                    GetBooks.Clear();
                    var Themes = ComboColumns.SelectedItem as string;
                    if (Themes != null)
                    {
                        var Themesbook = database.Books.Join(
                            database.Themes, c => c.IdThemes, d => d.Id, (c, d) => new { Book = c, Themes = d })
                            .ToList()
                            .Where(y => $"{y.Themes.Name}" == Themes).
                            Select(y => y.Book).ToList();
                        Themesbook.ForEach(s => GetBooks.Add(s));
                    }
                }
                else if (selectedItem.Content.ToString() == "Categories")
                {
                    GetBooks.Clear();
                    var Categories = ComboColumns.SelectedItem as string;
                    if (Categories != null)
                    {
                        var Categoriesbook = database.Books.Join(
                            database.Categories, c => c.IdCategory, d => d.Id, (c, d) => new { Book = c, Categories = d })
                            .ToList()
                            .Where(y => $"{y.Categories.Name}" == Categories).
                            Select(y => y.Book).ToList();
                        Categoriesbook.ForEach(s => GetBooks.Add(s));
                    }
                }
            }
        }

    }
}