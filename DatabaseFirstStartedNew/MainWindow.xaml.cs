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
            //using (var db = new LibraryContext())
            //{
            //    var Tables = db.Model.GetEntityTypes().Select(entityType => entityType.GetTableName()).ToList();
            //    Tables.ForEach(s => ComboClass.Items.Add(s));
            //}


        }
        //private void ComboClass_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    ComboColumns.Items.Clear();

        //    if (ComboClass.SelectedItem is string selectedTable)
        //    {
        //        using (var db = new LibraryContext())
        //        {
        //            var tables = db.Model.GetEntityTypes().Select(entityType => entityType.GetTableName()).ToList();
        //            var table = tables.FirstOrDefault(t => t == selectedTable);
        //            if (table != null)
        //            {
        //                var columns = db.Model.FindEntityType(table).GetProperties().Select(p => p.Name).ToList();
        //                columns.ForEach(c => ComboColumns.Items.Add(c));
        //            }
        //        }
        //    }
        //}

        //public void PrintLibrary()
        //{
        //    using (var db = new LibraryContext())
        //    {
        //        var Tables = db.Model.GetEntityTypes().Select(entityType => entityType.GetTableName()).ToList();
        //        Tables.ForEach(s => ComboClass.Items.Add(s));
        //    }

        //}


    }
}
