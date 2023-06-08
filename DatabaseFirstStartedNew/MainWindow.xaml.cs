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
            
        }

        private void ComboClass_SelectionChanged(object sender, RoutedEventArgs e)
        {
            using (LibraryContext database = new())
            {
                ComboBoxItem? selectedItem = ComboClass.SelectedItem as ComboBoxItem;



                if (selectedItem!.Content.ToString() == "Authors")
                {
                    ComboColumns.Items.Clear();



                    var authors = database.Authors;

                    authors.ToList().ForEach(a => ComboColumns.Items.Add($"{a.FirstName} {a.LastName}"));
                }
                else if (selectedItem!.Content.ToString() == "Themes")
                {
                    ComboColumns.Items.Clear();

                    var themes = database.Themes;

                    themes.ToList().ForEach(t => ComboColumns.Items.Add($"{t.Name}"));
                }
                else if (selectedItem!.Content.ToString() == "Categories")
                {
                    ComboColumns.Items.Clear();

                    var categories = database.Categories;

                    categories.ToList().ForEach(c => ComboColumns.Items.Add($"{c.Name}"));
                }
            }

        }
    }
}
