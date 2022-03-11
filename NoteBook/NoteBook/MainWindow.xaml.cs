using Logic;
using Storage;
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

namespace NoteBook
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Logic.NoteBook notebook;
        private IStorage storage;

        public MainWindow()
        {
            InitializeComponent();
            this.storage = new JsonStorage("NotebookFinal.txt");
            notebook = this.storage.Load();
        }

        private void GoEditUnits(object sender, RoutedEventArgs e)
        {
            EditUnitsWindow second = new EditUnitsWindow(notebook, storage);
            second.Show();
        }

        private void GoEditExam(object sender, RoutedEventArgs e)
        {
            EditExamWindow pageEditExam = new EditExamWindow(notebook, storage);
            pageEditExam.Show();
        }

        private void GoShowExam(object sender, RoutedEventArgs e)
        {
            ListExamsWindow pageListExams = new ListExamsWindow(notebook);
            pageListExams.Show();
        }
    }
}
