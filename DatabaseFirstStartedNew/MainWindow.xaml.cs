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
            TablesComboBox();
        }

        private void TablesComboBox()
        {
            using (var db = new LibraryContext())
            {
                var LibraryTables = db.Model.GetEntityTypes()
                    .Select(c => c.GetTableName())
                    .ToList();

                foreach (var item in LibraryTables)
                {
                    ComboClass.Items.Add(item);
                }
            }
        }

        private void ComboClass_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }
    }
}
